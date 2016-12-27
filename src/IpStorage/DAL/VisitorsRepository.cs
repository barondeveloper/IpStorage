using Microsoft.EntityFrameworkCore;
using IpStorage.Models;
using System.Linq;
using System.Threading.Tasks;

namespace IpStorage.DAL
{

    public class VisitorsRepository : EntityBaseRepository<Visitors> 
    {
        private video_tdsContext _context;
        public VisitorsRepository(video_tdsContext context)
            : base(context)
        {
            _context = context;
        }

        public override Visitors GetSingle (int id)
        {
            return _context.Set<Visitors>().FirstOrDefault(x => x.Id == id);
        }

        public override async Task<Visitors> GetSingleAsync (int id)
        {
            return await _context.Set<Visitors>().FirstOrDefaultAsync(e => e.Id == id);
        }

    }

}
