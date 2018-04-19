using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Strategies.SignalRRp
{
    static class SignalRStrategy
    {
        public static ResourceStrategy<SignalRResource> Strategy { get; }
            = ResourceStrategy.Create(
                type: new ResourceType("Microsoft.SignalRService", "SignalR"),
                getOperations: (SignalRManagementClient client) => client.Signalr,
                getAsync: (o, p) => o.GetAsync(p.ResourceGroupName, p.Name, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName,
                    p.Name,
                    new SignalRCreateParameters(
                        p.Model.Location,
                        p.Model.Tags,
                        p.Model.Signalrsku,
                        new SignalRCreateOrUpdateProperties(p.Model.HostNamePrefix)),
                    p.CancellationToken),
                getLocation: config => config.Location,
                setLocation: (config, location) => config.Location = location,
                createTime: c => 5,
                compulsoryLocation: true);
    }
}
