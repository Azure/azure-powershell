using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public class PSSignalRKeys
    {
        public string Name { get; }

        public string PrimaryKey { get; }

        public string SecondaryKey { get; }

        public PSSignalRKeys(string name, SignalRKeys obj)
        {
            Name = name;
            PrimaryKey = obj.PrimaryKey;
            SecondaryKey = obj.SecondaryKey;
        }
    }
}
