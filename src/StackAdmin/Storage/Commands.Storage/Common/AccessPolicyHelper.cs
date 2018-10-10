﻿// ----------------------------------------------------------------------------------
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
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.File;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Table;

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
            if (typeof(T) == typeof(SharedAccessTablePolicy))
            {
                SetupAccessPolicyPermission((SharedAccessTablePolicy)(Object)policy, permission);
            }
            else if (typeof(T) == typeof(SharedAccessFilePolicy))
            {
                SetupAccessPolicyPermission((SharedAccessFilePolicy)(Object)policy, permission);
            }
            else if (typeof(T) == typeof(SharedAccessBlobPolicy))
            {
                SetupAccessPolicyPermission((SharedAccessBlobPolicy)(Object)policy, permission);
            }
            else if ((typeof(T) == typeof(SharedAccessQueuePolicy)))
            {
                SetupAccessPolicyPermission((SharedAccessQueuePolicy)(Object)policy, permission);
            }
            else
            {
                throw new ArgumentException(Resources.InvalidAccessPolicyType);
            }
        }

        /// <summary>
        /// Set up shared access policy permission for SharedAccessTablePolicy
        /// </summary>
        /// <param name="policy">SharedAccessTablePolicy object</param>
        /// <param name="permission">Permission</param>
        internal static void SetupAccessPolicyPermission(SharedAccessTablePolicy policy, string permission)
        {
            //skip set the permission if passed-in value is null
            if (permission == null) return;

            policy.Permissions = SharedAccessTablePermissions.None;

            //set permission as none if passed-in value is empty
            if (string.IsNullOrEmpty(permission)) return;

            permission = permission.ToLower();
            foreach (char op in permission)
            {
                switch (op)
                {
                    case StorageNouns.Permission.Add:
                        policy.Permissions |= SharedAccessTablePermissions.Add;
                        break;
                    case StorageNouns.Permission.Update:
                        policy.Permissions |= SharedAccessTablePermissions.Update;
                        break;
                    case StorageNouns.Permission.Delete:
                        policy.Permissions |= SharedAccessTablePermissions.Delete;
                        break;
                    case StorageNouns.Permission.Read:
                    case StorageNouns.Permission.Query:
                        policy.Permissions |= SharedAccessTablePermissions.Query;
                        break;
                    default:
                        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPermission, op));
                }
            }
        }

        /// <summary>
        /// Set up shared access policy permission for SharedAccessFilePolicy
        /// </summary>
        /// <param name="policy">SharedAccessFilePolicy object</param>
        /// <param name="permission">Permission</param>
        internal static void SetupAccessPolicyPermission(SharedAccessFilePolicy policy, string permission)
        {
            //skip set the permission if passed-in value is null
            if (permission == null) return;

            policy.Permissions = SharedAccessFilePermissions.None;

            //set permission as none if passed-in value is empty
            if (string.IsNullOrEmpty(permission)) return;

            permission = permission.ToLower();
            foreach (char op in permission)
            {
                switch (op)
                {
                    case StorageNouns.Permission.Read:
                        policy.Permissions |= SharedAccessFilePermissions.Read;
                        break;
                    case StorageNouns.Permission.Write:
                        policy.Permissions |= SharedAccessFilePermissions.Write;
                        break;
                    case StorageNouns.Permission.Delete:
                        policy.Permissions |= SharedAccessFilePermissions.Delete;
                        break;
                    case StorageNouns.Permission.List:
                        policy.Permissions |= SharedAccessFilePermissions.List;
                        break;
                    default:
                        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPermission, op));
                }
            }
        }

        /// <summary>
        /// Set up shared access policy permission for SharedAccessBlobPolicy
        /// </summary>
        /// <param name="policy">SharedAccessBlobPolicy object</param>
        /// <param name="permission">Permission</param>
        internal static void SetupAccessPolicyPermission(SharedAccessBlobPolicy policy, string permission)
        {
            //skip set the permission if passed-in value is null
            if (permission == null) return;

            policy.Permissions = SharedAccessBlobPermissions.None;

            //set permission as none if passed-in value is empty
            if (string.IsNullOrEmpty(permission)) return;

            permission = permission.ToLower();
            foreach (char op in permission)
            {
                switch (op)
                {
                    case StorageNouns.Permission.Read:
                        policy.Permissions |= SharedAccessBlobPermissions.Read;
                        break;
                    case StorageNouns.Permission.Write:
                        policy.Permissions |= SharedAccessBlobPermissions.Write;
                        break;
                    case StorageNouns.Permission.Delete:
                        policy.Permissions |= SharedAccessBlobPermissions.Delete;
                        break;
                    case StorageNouns.Permission.List:
                        policy.Permissions |= SharedAccessBlobPermissions.List;
                        break;
                    default:
                        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPermission, op));
                }
            }
        }

        /// <summary>
        /// Set up shared access policy permission for SharedAccessQueuePolicy
        /// </summary>
        /// <param name="policy">SharedAccessQueuePolicy object</param>
        /// <param name="permission">Permisson</param>
        internal static void SetupAccessPolicyPermission(SharedAccessQueuePolicy policy, string permission)
        {
            //skip set the permission if passed-in value is null
            if (permission == null) return;

            policy.Permissions = SharedAccessQueuePermissions.None;

            //set permission as none if passed-in value is empty
            if (string.IsNullOrEmpty(permission)) return;

            permission = permission.ToLower();
            foreach (char op in permission)
            {
                switch (op)
                {
                    case StorageNouns.Permission.Read:
                        policy.Permissions |= SharedAccessQueuePermissions.Read;
                        break;
                    case StorageNouns.Permission.Add:
                        policy.Permissions |= SharedAccessQueuePermissions.Add;
                        break;
                    case StorageNouns.Permission.Update:
                        policy.Permissions |= SharedAccessQueuePermissions.Update;
                        break;
                    case StorageNouns.Permission.Process:
                        policy.Permissions |= SharedAccessQueuePermissions.ProcessMessages;
                        break;
                    default:
                        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPermission, op));
                }
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
