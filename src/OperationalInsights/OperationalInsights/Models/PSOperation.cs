using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSOperationsApiVersions
    {
        public const string October2020 = "2020-10-01";
    }

    public class PSOperation
    {
        public string Name { get; set; }
        public string Provider { get; set; }
        public string Resource { get; set; }
        public string Operation { get; set; }
        public string Description { get; set; }


        public PSOperation(Operation op)
        {
            Name = op.Name;
            Provider = op.Display.Provider;
            Resource = op.Display.Resource;
            Operation = op.Display.Operation;
            Description = op.Display.Description;
        }

    }
}
