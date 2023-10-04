using MassageStudio.App.Services.Interaces;
using MassageStudio.Data;
using MassageStudio.Areas.Identity.Data;
using MassageStudio.App.Models;
using System.Linq;

namespace MassageStudio.App.Services
{
    public class DbService : IDbService
    {
        private readonly ApplicationDbContext _dbContext;

        public DbService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public int AddFreeTerm(Term term)
        {
            _dbContext.freeTerms.Add(term);
            return _dbContext.SaveChanges();
        }

        public bool ChangeTermStatus(int id)
        {
            var term = _dbContext.freeTerms.Where(x => x.Id == id).SingleOrDefault();
            term.Reserved = !term.Reserved;
            return term.Reserved;
        }

        public IEnumerable<Term> GetAllFreeTerms()
        {
            return _dbContext.freeTerms.Where(x => x.Date > DateTime.Now).OrderBy(x => x.Date);
        }

        public IEnumerable<Term> GetAllTermsOld()
        {
            return _dbContext.freeTerms.Where(x => x.Date < DateTime.Now).OrderByDescending(x => x.Date);
        }


        public IEnumerable<Term> GetAllTerms()
        {
            return _dbContext.freeTerms.Where(x => x.Date > DateTime.Now).OrderBy(x => x.Date);
        }

        public Massage GetReservedById(int id)
        {
            return _dbContext.massages.Where(x => x.Id == id).SingleOrDefault();

        }

        public IEnumerable<Massage> GetReservedByUserId(string id)
        {
            var ms = _dbContext.massages.Where(x => x.UserId == id).OrderBy(x => x.Date).ToList();
            return ms;
        }

        public Term GetTermById(int id)
        {
            var term = _dbContext.freeTerms.Where(x => x.Id == id).SingleOrDefault();
            return term;
        }

        public bool MassageExists(int id)
        {
            var result = _dbContext.massages.SingleOrDefault(x => x.Id == id);
            if(result == null)
            {
                return false;
            }
            return true;
        }

        public void ReserveTerm(Massage massage)
        {
            _dbContext.massages.Add(massage);
            _dbContext.SaveChanges();
        }

        public Massage GetReservedByTermId(int Id)
        {
            return _dbContext.massages.Where(x => x.term.Id == Id).SingleOrDefault();
        }
    }
}
