using Microsoft.Azure.Management.Reservations.Models;

namespace Microsoft.Azure.Commands.Reservations.Custom
{
    public class PSCalculatePriceResponse
    {
        public CalculatePriceResponseProperties Properties { get; set; }

        public PSCalculatePriceResponse()
        { 
        }

        public PSCalculatePriceResponse(CalculatePriceResponse response)
        {
            Properties = response.Properties;
        }
    }
}
