using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBSAnalytics.Models;
using TBSAnalytics.ViewModels;

namespace TBSAnalytics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly TBSContext _context;

        public CustomerController(TBSContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStatus>>> GetCustomers()
        {
            return await _context.Customers
                                 .Where(c => c.CustStatus == "Active")
                                 .GroupBy(c => new { c.Enrolled, c.CustType })
                                 .Select(x => new UserStatus
                                 { 
                                     CustStatus = x.Key.Enrolled ? "Enrolled" : "Not Enrolled",
                                     CustType = x.Key.CustType.ToString(),
                                     CustStatusCount = x.Count()}).ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

    }
}
