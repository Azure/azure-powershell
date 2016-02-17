using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.MachineLearning.Contracts
{
    public class Operation
    {
        public string Name;
        public DisplayProperties Display;
        public OriginTypes Origin;
        public OperationProperties Properties;
    }

    public class DisplayProperties
    {
        public string Provider;
        public string Resource;
        public string Operation;
        public string Description;
    }

    public class OperationProperties
    {
        // TODO: Fill it up
    }

    public enum OriginTypes
    {
        User,
        System,
        UserSystem
    }
}
