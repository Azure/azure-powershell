using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.PrivateLinkService.Models
{
    [Rest.Serialization.JsonTransformation]
    public partial class TrackedResource : ProxyResource
    {

        public TrackedResource()
        {
            CustomInit();
        }

        public TrackedResource(string id = default(string), string name = default(string), string type = default(string), IList<PrivateEndpointConnection> privateEndpointConnections = default(IList<PrivateEndpointConnection>))
            : base(id, name, type)
        {
            PrivateEndpointConnections = privateEndpointConnections;
            CustomInit();
        }

        partial void CustomInit();

        [JsonProperty(PropertyName = "properties.privateEndpointConnections")]
        public IList<PrivateEndpointConnection> PrivateEndpointConnections { get; private set; }

    }
}
