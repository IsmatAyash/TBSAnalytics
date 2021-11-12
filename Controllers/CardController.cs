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
    public class CardController : ControllerBase
    {
        private readonly TBSContext _context;

        public CardController(TBSContext context)
        {
            _context = context;
        }

        // GET: api/Card
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardStatView>>> GetCardStats()
        {
            var curm = CurMonth();
            return await _context.CardStats
                                 .Where(c => c.CardYear == DateTime.Now.Year && c.CardMonth == curm)
                                 .GroupBy(g => new { g.CurAbv, g.CardType, g.CustId })
                                 .Select(x => new CardStatView()
                                  {
                                      CardType = x.Key.CardType,
                                      CurAbv = x.Key.CurAbv,
                                      CustId = x.Key.CustId,
                                      CardCount = x.Sum(c => c.NumberOfCards),
                                      LbpBal = x.Sum(c => c.OutstandingBal),
                                      UsdBal = x.Sum(c => c.OutstandingBalUsd)
                                  }).ToListAsync();
        }

        int CurMonth()
        {
            var curm = DateTime.Now.Month;
            var dbm = _context.CardStats.Where(m => m.CardYear == DateTime.Now.Year).Max(m => m.CardMonth);

            if (dbm == curm)
                return curm;

            return curm - 1 == 0 ? 12 : curm - 1;
        }

        [HttpGet("usage")]
        public async Task<ActionResult<IEnumerable<CardUsageView>>> GetCardUsage()
        {
            return await _context.CardUsages
                                 .Where(c => c.CardYear == DateTime.Now.Year)
                                 .GroupBy(g => new { g.CardType, g.TrxType, g.CustId })
                                 .Select(x => new CardUsageView()
                                 {
                                     CardType = x.Key.CardType,
                                     TrxType = x.Key.TrxType,
                                     CustId = x.Key.CustId,
                                     CardCount = x.Sum(c => c.TrxCount),
                                     UsdBal = x.Sum(c => c.TrxAmountUsd)
                                 }).ToListAsync();
        }

        // GET: api/Card/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardStat>> GetCardStat(int id)
        {
            var cardStat = await _context.CardStats.FindAsync(id);

            if (cardStat == null)
            {
                return NotFound();
            }

            return cardStat;
        }
    }
}
