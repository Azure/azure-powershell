// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
using Microsoft.Azure.Management.ManagedServices.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices
{
    public static class ManagedServicesExtensions
    {
        public static string GetSubscriptionId(this string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new PSArgumentException("resourceId cannot be null.");
            }

            var entries = resourceId.Split('/');
            return entries[2];
        }

        public static string GetResourceName(this string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new PSArgumentException("resourceId cannot be null.");
            }

            var entries = resourceId.Split('/');
            return entries[entries.Length - 1];
        }

        public static bool IsGuid(this string input)
        {
            return Guid.TryParse(input, out Guid result);
        }

        public static string ToSubscriptionResourceId(this string subscriptionId)
        {
            return $"/subscriptions/{subscriptionId}";
        }
    }
}
