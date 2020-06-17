using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Profile.Rest
{
    public class Utils
    {
        private const string Subscriptions = "subscriptions";

        private const string ResourceGroups = "resourceGroups";

        private const string Providers = "providers";

        private const string slash = "/";

        internal static readonly string API_VERSION = "api-version";

        public static string ConstructPath(string sub, string rg, string rp, string[] types, string[] names)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(slash + Subscriptions);
            sb.Append(slash + sub);

            if (rg != null && rg.Length != 0)
            {
                sb.Append(slash + ResourceGroups);
                sb.Append(slash + rg);
            }

            if (rp != null && rp.Length != 0)
            {
                sb.Append(slash + Providers);
                sb.Append(slash + rp);
            }

            if (types != null && types.Length != 0)
            {
                for (int i = 0; i < types.Length; i++)
                {
                    sb.Append(slash + types[i]);
                    sb.Append(slash + names[i]);
                }
            }
            return sb.ToString();
        }
    }
}
