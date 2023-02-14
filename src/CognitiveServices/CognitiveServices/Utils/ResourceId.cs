using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    public class ResourceId
    {
        public IReadOnlyList<string> Types { get; private set; }

        public IReadOnlyList<string> Names { get; private set; }

        public static bool TryParse(string resourceId, out ResourceId output)
        {
            output = null;

            if (resourceId == null)
            {
                return false;
            }

            var segments = resourceId.Trim('/').SplitRemoveEmpty('/');
            if (segments.Length % 2 == 1)
            {
                return false;
            }

            output = new ResourceId(
                segments.Where((_, i) => i % 2 == 0),
                segments.Where((_, i) => i % 2 == 1));

            return true;
        }

        public ResourceId(IEnumerable<string> types, IEnumerable<string> names)
        {
            if (types == null || names == null || types.Count() != names.Count())
            {
                throw new Exception("Invalid ResourceId segments");
            }

            this.Types = types.ToList();
            this.Names = names.ToList();
        }

        public string SubscriptionId
        {
            get
            {
                if (this.Types.Count <= 0
                    || !"subscriptions".EqualsInsensitively(this.Types[0]))
                {
                    return "";
                }

                return this.Names[0];
            }
        }

        public string ResourceGroupName
        {
            get
            {
                if (this.Types.Count <= 1
                    || !"resourceGroups".EqualsInsensitively(this.Types[1]))
                {
                    return "";
                }

                return this.Names[1];
            }
        }

        public string ProvidersName
        {
            get
            {
                if (this.Types.Count <= 2
                    || !"providers".EqualsInsensitively(this.Types[2]))
                {
                    return "";
                }

                return this.Names[2];
            }
        }
    }

    public static class CognitiveServicesResourceIdExtension
    {
        public static string GetAccountName(this ResourceId resourceId)
        {
            if (resourceId.Types.Count <= 3
                || !"accounts".EqualsInsensitively(resourceId.Types[3]))
            {
                return "";
            }

            return resourceId.Names[3];
        }

        public static string GetAccountSubResourceName(this ResourceId resourceId)
        {
            if (resourceId.Types.Count <= 4)
            {
                return "";
            }

            return resourceId.Names[4];
        }

        public static string GetAccountSubResourceName(this ResourceId resourceId, string subResourceType)
        {
            if (resourceId.Types.Count <= 4
                || string.IsNullOrEmpty(subResourceType)
                || !subResourceType.EqualsInsensitively(resourceId.Types[4]))
            {
                return "";
            }

            return resourceId.Names[4];
        }
    }
}
