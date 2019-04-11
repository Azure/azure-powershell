using Microsoft.Azure.Management.Blueprint.Models;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSWhoIsBlueprintContract
    {
        public string ObjectId { get; private set; }

        public PSWhoIsBlueprintContract(WhoIsBlueprintContract response)
        {
            ObjectId = response.ObjectId;
        }
    }
}
