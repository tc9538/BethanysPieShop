using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository :IPieRepository
    {
        private readonly AppDbContext _appDbContext;
        
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(predicate => predicate.PieId == pieId);
        }

        public void SubmitPieFeedback(PieFeedback pieFeedback)
        {
            if(pieFeedback.Feedback != null)
            {
                _appDbContext.PieFeedback.Add(pieFeedback);
                _appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("No entry for pie feed back");
            }

        }


    }
}
