using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldnetWrapper.Core.Properties;

namespace GoldnetWrapper.Core
{
    internal class RepManager
    {

        public RepData[] GetEnabledReps()
        {
            //Get reps from current app dir
            return new RepData[] { };
        }
        public RepData[] GetDisabledReps()
        { 
            //Get reps from RepBank
            return new RepData[] { };
        }
    
    }
}
