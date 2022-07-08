using XRPFunding.Data;

namespace XRPFunding.Models
{
    public class ListCausesViewModel
    {
        public IEnumerable<Cause> Causes { get; set; }
        private ApplicationDbContext _db;

        public ListCausesViewModel(ApplicationDbContext db)
        {
            Causes = db.Causes.OrderBy(x => x.Deadline);
            _db = db;
        }

        public string DonationsByCause(int id)
        {
            var donations = _db.Donations.Where(x => x.CauseId == id);
            return donations.Sum(x => x.Amount).ToString("N2");
        }
    }
}
