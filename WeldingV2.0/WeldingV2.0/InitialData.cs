using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeldingV2._0.Models;

namespace WeldingV2._0
{
    public class InitialData
    {
        private readonly WeldingContext _context;

        public InitialData(WeldingContext context)
        {
            _context = context;
        }

        public void AddInitialData()
        { 
        }
    }
}
