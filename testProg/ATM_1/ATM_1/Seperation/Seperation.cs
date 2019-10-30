using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_1
{
    public class Seperation : ISeperation
    {
        public ILog _logFile;
        
        public Seperation(ILog logFile)
        {
            _logFile = logFile;
        }

        public void CheckSeperation()
        {
        }

    }
}
