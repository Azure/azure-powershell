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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.File;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;

    internal class AccessPolicyHelper
    {
        /// <summary>
        /// Set the shared access policy
        /// </summary>
        /// <typeparam name="T">SharedAccessTablePolicy, SharedAccessBlobPolicy or SharedAccessQueuePolicy</typeparam>
        /// <param name="policy">the policy object</param>
        /// <param name="startTime">start time of the policy</param>
        /// <param name="expiryTime">end time of the policy</param>
        /// <param name="permission">the permission of the policy</param>
        internal static void SetupAccessPolicy<T>(T policy, DateTime? startTime, DateTime? expiryTime, string permission, bool noStartTime = false, bool noExpiryTime = false)
        {
            if (!(typeof(T) == typeof(SharedAccessTablePolicy) ||
                typeof(T) == typeof(SharedAccessFilePolicy) ||
                typeof(T) == typeof(SharedAccessBlobPolicy) ||
                (typeof(T) == typeof(SharedAccessQueuePolicy))))
            {
                throw new ArgumentException(Resources.InvalidAccessPolicyType);
            }

            if (noStartTime && startTime != null)
            {
                throw new ArgumentException(Resources.StartTimeParameterConflict);
            }

            if (noExpiryTime && expiryTime != null)
            {
                throw new ArgumentException(Resources.ExpiryTimeParameterConflict);
            }

            DateTimeOffset? accessStartTime;
            DateTimeOffset? accessExpiryTime;
            SetupAccessPolicyLifeTime(startTime, expiryTime,
                out accessStartTime, out accessExpiryTime);

            if (startTime != null || noStartTime)
            {
                policy.GetType().GetProperty("SharedAccessStartTime").SetValue(policy, accessStartTime);
            }

            if (expiryTime != null || noExpiryTime)
            {
                policy.GetType().GetProperty("SharedAccessExpiryTime").SetValue(policy, accessExpiryTime);
            }

            SetupAccessPolicyPermission<T>(policy, permission);
        }

        /// <summary>
        /// Set up the shared access policy lift time
        /// </summary>
        /// <param name="startTime">start time of the shared access policy</param>
        /// <param name="expiryTime">end time of the shared access policy</param>
        /// <param name="SharedAccessStartTime">the converted value of start time</param>
        /// <param name="SharedAccessExpiryTime">the converted value of end time</param>
        internal static void SetupAccessPolicyLifeTime(DateTime? startTime, DateTime? expiryTime,
            out DateTimeOffset? SharedAccessStartTime, out DateTimeOffset? SharedAccessExpiryTime)
        {
            SharedAccessStartTime = null;
            SharedAccessExpiryTime = null;

            if (startTime != null)
            {
                SharedAccessStartTime = startTime.Value.ToUniversalTime();
            }

            if (expiryTime != null)
            {
                SharedAccessExpiryTime = expiryTime.Value.ToUniversalTime();
            }

            if (SharedAccessStartTime != null && SharedAccessExpiryTime.HasValue
                && SharedAccessExpiryTime <= SharedAccessStartTime)
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.ExpiryTimeGreatThanStartTime,
                    SharedAccessExpiryTime.ToString(), SharedAccessStartTime.ToString()));
            }
        }

        internal static void SetupAccessPolicyPermission<T>(T policy, string permission)
        {
            //set permission as none if passed-in value is empty
            if (permission == null)
                return;
            if (string.IsNullOrEmpty(permission))
            {
                if (typeof(T) == typeof(SharedAccessTablePolicy))
                {
                    ((SharedAccessTablePolicy)(Object)policy).Permissions = SharedAccessTablePermissions.None;
                }
                else if (typeof(T) == typeof(SharedAccessFilePolicy))
                {
                    ((SharedAccessFilePolicy)(Object)policy).Permissions = SharedAccessFilePermissions.None;
                }
                else if (typeof(T) == typeof(SharedAccessBlobPolicy))
                {
                    ((SharedAccessBlobPolicy)(Object)policy).Permissions = SharedAccessBlobPermissions.None;
                }
                else if ((typeof(T) == typeof(SharedAccessQueuePolicy)))
                {
                    ((SharedAccessQueuePolicy)(Object)policy).Permissions = SharedAccessQueuePermissions.None;
                }
                else
                {
                    throw new ArgumentException(Resources.InvalidAccessPolicyType);
                }
                return;
            }
            permission = permission.ToLower(CultureInfo.InvariantCulture);
            try
            {
                if (typeof(T) == typeof(SharedAccessTablePolicy))
                {
                    //PowerShell will convert q to r in genreate table SAS. Add this to avoid regression
                    string convertedPermission = permission.Replace('q', 'r');
                    ((SharedAccessTablePolicy)(Object)policy).Permissions = SharedAccessTablePolicy.PermissionsFromString(convertedPermission);
                }
                else if (typeof(T) == typeof(SharedAccessFilePolicy))
                {
                    ((SharedAccessFilePolicy)(Object)policy).Permissions = SharedAccessFilePolicy.PermissionsFromString(permission);
                }
                else if (typeof(T) == typeof(SharedAccessBlobPolicy))
                {
                    ((SharedAccessBlobPolicy)(Object)policy).Permissions = SharedAccessBlobPolicy.PermissionsFromString(permission);
                }
                else if ((typeof(T) == typeof(SharedAccessQueuePolicy)))
                {
                    ((SharedAccessQueuePolicy)(Object)policy).Permissions = SharedAccessQueuePolicy.PermissionsFromString(permission);
                }
                else
                {
                    throw new ArgumentException(Resources.InvalidAccessPolicyType);
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPermission, permission));
            }
        }

        internal static PSObject ConstructPolicyOutputPSObject<T>(IDictionary<string, T> sharedAccessPolicies, string policyName)
        {
            if (!(typeof(T) == typeof(SharedAccessTablePolicy) ||
               typeof(T) == typeof(SharedAccessBlobPolicy) ||
               (typeof(T) == typeof(SharedAccessQueuePolicy)) ||
               (typeof(T) == typeof(SharedAccessFilePolicy))))
            {
                throw new ArgumentException(Resources.InvalidAccessPolicyType);
            }

            return PowerShellUtilities.ConstructPSObject(
                typeof(PSObject).FullName,
                "Policy",
                policyName,
                "Permissions",
                (sharedAccessPolicies[policyName]).GetType().GetProperty("Permissions").GetValue(sharedAccessPolicies[policyName]),
                "StartTime",
                (sharedAccessPolicies[policyName]).GetType().GetProperty("SharedAccessStartTime").GetValue(sharedAccessPolicies[policyName]),
                "ExpiryTime",
                (sharedAccessPolicies[policyName]).GetType().GetProperty("SharedAccessExpiryTime").GetValue(sharedAccessPolicies[policyName]));
        }

    }
}
