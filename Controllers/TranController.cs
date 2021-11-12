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
    public class TranController : ControllerBase
    {
        private readonly TBSContext _context;

        public TranController(TBSContext context)
        {
            _context = context;
        }

        // GET: api/tran
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StpView>>> GetTrans()
        {
            var stpData = await _context.Transactions
                                 .Include(c => c.Customers)
                                 .Include(t => t.TrxTypes)
                                 .Where(d => d.TrxDate.Year == DateTime.Now.Year)
                                 .Select(x => new
                                 {
                                     x.CustId,
                                     x.Customers.CustName,
                                     x.Customers.CustType,
                                     x.TrxTypes.TrxTypeDesc,
                                     x.TrxChannel,
                                     x.TrxAmountUsd,
                                     TrxMonth = x.TrxDate.Month,
                                 }).ToListAsync();

            return stpData.GroupBy(g => new { g.TrxMonth, g.CustId, g.CustName, g.CustType, g.TrxTypeDesc, g.TrxChannel })
                                  .Select(x => new StpView()
                                  {
                                      StpMonth = x.Key.TrxMonth,
                                      CustId = x.Key.CustId,
                                      CustName = x.Key.CustName,
                                      CustType = x.Key.CustType.ToString(),
                                      StpType = x.Key.TrxTypeDesc,
                                      StpCount = x.Count(),
                                      StpAmount = x.Sum(t => t.TrxAmountUsd),
                                      Channel = x.Key.TrxChannel
                                  }).ToList();
        }

        // GET: api/tran/stpyoy
        [HttpGet("stpyoy")]
        public async Task<ActionResult<IEnumerable<StpView>>> GetTranByYear()
        {
            
            var stpData = await _context.Transactions
                     .Include(c => c.Customers)
                     .Include(t => t.TrxTypes)
                     .Select(x => new
                     {
                         x.Customers.CustType,
                         x.TrxTypes.TrxTypeDesc,
                         x.TrxAmountUsd,
                         TrxYear = x.TrxDate.Year,
                     }).ToListAsync();

            if (stpData == null)
            {
                return NotFound();
            }

            return stpData.GroupBy(g => new { g.TrxYear, g.CustType, g.TrxTypeDesc })
                                  .Select(x => new StpView()
                                  {
                                      StpYear = x.Key.TrxYear,
                                      CustType = x.Key.CustType.ToString(),
                                      StpType = x.Key.TrxTypeDesc,
                                      StpCount = x.Count(),
                                      StpAmount = x.Sum(t => t.TrxAmountUsd),
                                  }).ToList();
        }

        // GET: api/tran/freshfund
        [HttpGet("freshfund")]
        public async Task<ActionResult<IEnumerable<StpView>>> GetFreshFund()
        {

            var stpData = await _context.Transactions
                     .Include(c => c.Customers)
                     .Include(t => t.TrxTypes)
                     .Where(t => (t.AccountNumber.Substring(2,3) == "40Z" || t.AccountNumber.Substring(2, 3) == "43Z" || t.AccountNumber.Substring(2, 3) == "48Z") && t.TrxCurrency != "01" && t.TrxDate.Year == DateTime.Now.Year )
                     .Select(x => new
                     {
                         x.Customers.CustId,
                         x.Customers.CustType,
                         x.TrxTypes.TrxTypeDesc,
                         x.TrxAmountUsd,
                         TrxYear = x.TrxDate.Year,
                     }).ToListAsync();

            if (stpData == null)
            {
                return NotFound();
            }

            return stpData.GroupBy(g => new { g.TrxYear, g.CustId, g.TrxTypeDesc, g.CustType })
                                  .Select(x => new StpView()
                                  {
                                      StpYear = x.Key.TrxYear,
                                      CustId = x.Key.CustId,
                                      StpType = x.Key.TrxTypeDesc,
                                      CustType = x.Key.CustType.ToString(),
                                      StpCount = x.Count(),
                                      StpAmount = x.Sum(t => t.TrxAmountUsd),
                                  }).ToList();
        }

        // GET: api/tran/ffmbals
        [HttpGet("ffmbals")]
        public async Task<ActionResult<IEnumerable<FFMonthlyBalance>>> GetFFMonthlyBals()
        {

            var bals = await _context.FFMonthlyBalances
                                     .Where(m => m.Year == DateTime.Now.Year && m.CustType != "")
                                     .GroupBy(g => new { g.Month, g.CustType})
                                     .Select(x => new
                                     {
                                        x.Key.CustType,
                                        x.Key.Month,
                                        Balance = x.Sum(b => b.BalanceUsd)
                                     }).ToListAsync();

            if (bals == null)
            {
                return NotFound();
            }

            return Ok(bals);
        }

        // GET: api/tran/ffmbals
        [HttpGet("ffbals")]
        public async Task<ActionResult<IEnumerable<FFBalance>>> GetFFBals()
        {
            var bals = await _context.FFBalances
                                .Select(x => new
                                 {
                                     x.CustType,
                                     x.CustId,
                                     Balance = x.BalanceUsd
                                 }).ToListAsync();

            if (bals == null)
            {
                return NotFound();
            }

            return Ok(bals);
        }


        // GET: api/tran/stpyoy
        [HttpGet("stpyoy/{id}")]
        public async Task<ActionResult<IEnumerable<StpView>>> GetTranByYear(string id)
        {
            var stpData = await _context.Transactions
                     .Include(c => c.Customers)
                     .Include(t => t.TrxTypes)
                     .Where(t => t.TrxDate.Day <= DateTime.Today.Day && t.TrxDate.Month <= DateTime.Today.Month && t.CustId == id)
                     .Select(x => new
                     {
                         x.TrxTypes.TrxTypeDesc,
                         x.TrxAmountUsd,
                         TrxYear = x.TrxDate.Year,
                     }).ToListAsync();

            if (stpData == null)
            {
                return NotFound();
            }

            return stpData.GroupBy(g => new { g.TrxYear, g.TrxTypeDesc })
                                  .Select(x => new StpView()
                                  {
                                      StpYear = x.Key.TrxYear,
                                      StpType = x.Key.TrxTypeDesc,
                                      StpCount = x.Count(),
                                      StpAmount = x.Sum(t => t.TrxAmountUsd),
                                  }).ToList();
        }
    }
}
