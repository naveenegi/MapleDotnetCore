using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClassLibraryCore.DataContextLayer.DataContext;
using ClassLibraryCore.DataContextLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;

namespace ApiappNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly EFDataContext _context;
        public ContractController(EFDataContext context)
        {
            _context = context;
        }

        #region Creating a new life insurance contract
        [HttpPost]
        public async Task<ActionResult<Contracts>> PostProducts(Contracts contracts)
        {
            //
          var  oCustomerDoc = new Contracts();
            oCustomerDoc.CustomerName = contracts.CustomerName;
            oCustomerDoc.CustomerAddress = contracts.CustomerAddress;
            oCustomerDoc.CustomerCountry = contracts.CustomerCountry;
            oCustomerDoc.CustomerDOB = contracts.CustomerDOB;
            oCustomerDoc.CustomerGender = contracts.CustomerGender;
            oCustomerDoc.SaleDate= contracts.SaleDate;

            var coverplan = (from cover in _context.CoveragePlans where cover.EligibilityCountry == contracts.CustomerCountry select cover.CoveragePlanName).FirstOrDefault();
            oCustomerDoc.CoveragePlan = coverplan;

            int age = 0;
            DateTime dobcurrent = Convert.ToDateTime(contracts.CustomerDOB);
            age = DateTime.Now.Year - dobcurrent.Year;
            if (DateTime.Now.DayOfYear < dobcurrent.DayOfYear)
                age = age - 1;


            var netprice = (from rate in _context.RateCharts where rate.CoveragePlanName == coverplan && rate.CustomerGender == contracts.CustomerGender && rate.CustomerAge== Convert.ToString(age) select rate.NetPrice).FirstOrDefault();

            oCustomerDoc.NetPrice = netprice;
            _context.Contracts.Add(oCustomerDoc);
            await _context.SaveChangesAsync();
            return oCustomerDoc;

        }
        #endregion
        #region Getting a list of life insurance contracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contracts>>> GetAllContracts()
        {

            return await _context.Contracts.OrderByDescending(x => x.CustomerId).ToListAsync();
        }
        #endregion

        #region Deleting an existing life insurance contract
        [HttpDelete("{CustomerId}")]
        public async Task<ActionResult<Contracts>> DeleteCustomer(string CustomerId)
        {
            var customer = await _context.Contracts.FindAsync(CustomerId);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Contracts.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }
        #endregion
    }
}