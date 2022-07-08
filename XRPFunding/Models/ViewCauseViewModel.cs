using XRPFunding.Data;

namespace XRPFunding.Models
{
    public class ViewCauseViewModel
    {
        private ApplicationDbContext db;
        public Cause Cause { get; set; }
        public IEnumerable<Donation> Donations { get; set; }

        public ViewCauseViewModel(ApplicationDbContext db, int id)
        {
            Cause = db.Causes.SingleOrDefault(x => x.Id == id);
            Donations = db.Donations.Where(x => x.CauseId == id).OrderByDescending(x => x.CreatedAt);
        }
    }
}
