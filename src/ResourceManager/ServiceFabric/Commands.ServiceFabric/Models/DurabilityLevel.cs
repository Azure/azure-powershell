
namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public enum DurabilityLevel
    {
        Bronze, //No MR  
        Silver, // MR time out is 30 min
        Gold, // The MR time out is 2 hours
    }
}
