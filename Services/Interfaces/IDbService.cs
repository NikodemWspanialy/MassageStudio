using MassageStudio.App.Models;

namespace MassageStudio.App.Services.Interaces
{
    public interface IDbService
    {
        int AddFreeTerm(Term term);
        void ReserveTerm(Massage massage);
        IEnumerable<Term> GetAllFreeTerms();
        IEnumerable<Term> GetAllTerms();
        IEnumerable<Term> GetAllTermsOld();
        Massage GetReservedById(int id);
        Term GetTermById(int id);
        IEnumerable<Massage> GetReservedByUserId(string id);
        bool ChangeTermStatus(int id);
        bool MassageExists(int id);
        Massage GetReservedByTermId(int Id);

    }
}
