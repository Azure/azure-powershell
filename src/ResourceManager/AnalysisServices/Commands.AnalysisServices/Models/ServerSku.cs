using System.Collections.Generic;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices.Models
{
    internal class ServerSku
    {
        internal static IReadOnlyDictionary<string, string> FromResourceSku(ResourceSku resourceSku)
        {
            return new Dictionary<string, string>
            {
                { "Name", resourceSku.Name },
                { "Tier", resourceSku.Tier },
                { "Capacity", resourceSku.Capacity.ToString() }
            };
        }
    }
}
