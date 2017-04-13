
namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public enum ReliabilityLevel
    {
        Bronze = 3, // The system services replica set count (3/3) and Seed Nodes = 3
        Silver = 5, // The system services replica set count (3/5) and Seed Nodes = 5
        Gold = 7, // The system services replica set count (5/7) and Seed Nodes = 7
        //Platinum = 9 // The system services replica set count (5/7) and Seed Nodes >= 9
    }
}
