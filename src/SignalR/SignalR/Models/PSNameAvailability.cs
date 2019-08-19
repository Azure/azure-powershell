using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    class PSNameAvailability
    {
        public PSNameAvailability(NameAvailability nameAvailability)
        {
            NameAvailable = nameAvailability.NameAvailable;
            Reason = nameAvailability.Reason;
            Message = nameAvailability.Message;
        }

        public bool? NameAvailable { get; }

        public string Reason { get; }

        public string Message { get; }
    }
}
