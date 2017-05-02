using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecoBerBP.Models
{
    public class BPContextSeedData
    {
        private BPContext _context;

        public BPContextSeedData(BPContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {

            // Add some data in the database.



            await _context.SaveChangesAsync();
        }

    }
}
