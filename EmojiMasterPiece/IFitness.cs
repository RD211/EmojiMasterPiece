using GATesting.GA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public interface IFitness
    {
        double Measure();
    }
}
