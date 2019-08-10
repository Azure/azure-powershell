using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    public interface IResource
    {
        string Location { get; set; }
    }
}
