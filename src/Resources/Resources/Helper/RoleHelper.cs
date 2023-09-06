using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Resources.Helper
{
    public static class RoleHelper
    {
        public const string ScopeAndSubscriptionBothNull = "No subscription was found in the default profile and no scope was specified. Either specify a scope or use a tenant with a subscription to run the command.";
    }
}
