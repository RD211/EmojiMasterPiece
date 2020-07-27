using System;
using System.Collections.Generic;
using System.Text;

namespace GATesting.GA
{
    public interface IGenome
    {
        double? Fitness { get; set; }
        int Length { get; }

    }
}
