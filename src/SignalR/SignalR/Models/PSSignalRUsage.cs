using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    class PSSignalRUsage
    {
        public PSSignalRUsage(SignalRUsage signalrUsage)
        {
            Id = signalrUsage.Id;
            CurrentValue = signalrUsage.CurrentValue;
            Limit = signalrUsage.Limit;
            Name = signalrUsage.Name.Value;
            LocalizedName = signalrUsage.Name.LocalizedValue;
            Unit = signalrUsage.Unit;
        }

        public string Id { get; }

        public long? CurrentValue { get; }

        public long? Limit { get; }

        public string Name { get; }

        public string LocalizedName { get; }

        public string Unit { get; }
    }
}
