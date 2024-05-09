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
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.File;
    using Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using global::Azure.Storage.Blobs.Models;
    using global::Azure.Storage.Files.Shares.Models;
    using global::Azure.Storage.Queues.Models;

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
        /// <param name="noStartTime"></param>
        /// <param name="noExpiryTime"></param>
        internal static void SetupAccessPolicy<T>(T policy, DateTime? startTime, DateTime? expiryTime, string permission, bool noStartTime = false, bool noExpiryTime = false)
        {
            if (!(typeof(T) == typeof(SharedAccessTablePolicy) ||
                typeof(T) == typeof(SharedAccessFilePolicy) ||
                typeof(T) == typeof(SharedAccessBlobPolicy)))
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

        internal static PSObject ConstructPolicyOutputPSObject<T>(T identifier)
        {
            if (!(typeof(T) == typeof(BlobSignedIdentifier) ||
               typeof(T) == typeof(ShareSignedIdentifier) ||
               (typeof(T) == typeof(QueueSignedIdentifier))))
            {
                throw new ArgumentException("Access policy type is invalid, only BlobSignedIdentifier, ShareSignedIdentifier, and QueueSignedIdentifier are supported.");
            }

            var accessPolicy = (identifier).GetType().GetProperty("AccessPolicy").GetValue(identifier);
            string policyStartsOn = typeof(T) == typeof(QueueSignedIdentifier) ? "StartsOn" : "PolicyStartsOn";
            string policyExpiresOn = typeof(T) == typeof(QueueSignedIdentifier) ? "ExpiresOn" : "PolicyExpiresOn";

            return PowerShellUtilities.ConstructPSObject(
                typeof(PSObject).FullName,
                "Policy",
                (identifier).GetType().GetProperty("Id").GetValue(identifier),
                "Permissions",
                (accessPolicy).GetType().GetProperty("Permissions").GetValue(accessPolicy) is null ? null: (accessPolicy).GetType().GetProperty("Permissions").GetValue(accessPolicy).ToString(),
                "StartTime",
                (accessPolicy).GetType().GetProperty(policyStartsOn).GetValue(accessPolicy),
                "ExpiryTime",
                (accessPolicy).GetType().GetProperty(policyExpiresOn).GetValue(accessPolicy));
        }

        /// <summary>
        /// Sort characters of rawPermission in the order of fullPermission
        /// </summary>
        /// <param name="fullPermission"></param>
        /// <param name="rawPermission"></param>
        /// <returns></returns>
        internal static string OrderPermission(string fullPermission, string rawPermission)
        {
            string orderedPermission = "";
            int rawLength = rawPermission.Length;
            foreach (char c in fullPermission)
            {
                if (rawPermission.Contains(c.ToString()))
                {
                    orderedPermission += c.ToString();
                    rawLength--;
                }
            }
            if (rawLength == 0)
            {
                return orderedPermission;
            }
            else // some permission in rawstringLength not in current full permission list, so can't order. will use the raw permission string to try best to set permission.
            {
                return rawPermission;
            }
        }

        /// <summary>
        /// Order Blob permission
        /// </summary>
        public static string OrderBlobPermission(string rawPermission)
        {
            string fullBlobPermission = "racwdxyltfmeopi";
            return OrderPermission(fullBlobPermission, rawPermission);
        }

        /// <summary>
        /// Order Queue permission
        /// </summary>
        public static string OrderQueuePermission(string rawPermission)
        {
            string fullQueuePermission = "raup";
            return OrderPermission(fullQueuePermission, rawPermission);
        }
    }
}
