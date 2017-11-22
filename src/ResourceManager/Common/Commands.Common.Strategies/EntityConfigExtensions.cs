using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class EntityConfigExtensions
    {
        public static string IdToString(this IEnumerable<string> id)
            => "/" + string.Join("/", id);

        public static string DefaultIdStr(this IEntityConfig config)
            => config.GetId(string.Empty).IdToString();
    }
}
