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

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet(VerbsCommon.New, StorageNouns.AccountSas), OutputType(typeof(String))]
    public class NewAzureStorageAccountSasTokenCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Service type that this SAS token applies to.")]
        public SharedAccessAccountServices Service { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Resource type that this SAS token applies to.")]
        public SharedAccessAccountResourceTypes ResourceType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Permissions.")]
        [ValidateNotNullOrEmpty]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol can be used in the request with this SAS token.")]
        [ValidateNotNull]
        public SharedAccessProtocol? Protocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "IP, or IP range ACL (access control list) that the request would be accepted by Azure Storage.")]
        [ValidateNotNullOrEmpty]
        public string IPAddressOrRange { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Start Time")]
        [ValidateNotNull]
        public DateTime? StartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expiry Time")]
        [ValidateNotNull]
        public DateTime? ExpiryTime { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageAccountSasTokenCommand class.
        /// </summary>
        public NewAzureStorageAccountSasTokenCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageAccountSasTokenCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageAccountSasTokenCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            var sharedAccessPolicy = new SharedAccessAccountPolicy()
            {
                Permissions = SetupAccessPolicyPermission(this.Permission),
                Services = Service,
                ResourceTypes = ResourceType,
                Protocols = Protocol,
                IPAddressOrRange = Util.SetupIPAddressOrRangeForSAS(this.IPAddressOrRange)
            };

            DateTimeOffset? accessStartTime;
            DateTimeOffset? accessEndTime;
            SasTokenHelper.SetupAccessPolicyLifeTime(StartTime, ExpiryTime,
                out accessStartTime, out accessEndTime, true);
            sharedAccessPolicy.SharedAccessStartTime = accessStartTime;
            sharedAccessPolicy.SharedAccessExpiryTime = accessEndTime;

            this.WriteObject(Channel.GetStorageAccountSASToken(sharedAccessPolicy));
        }

        /// <summary>
        /// Set up access policy permission
        /// </summary>
        /// <param name="policy">SharedAccessBlobPolicy object</param>
        /// <param name="permission">Permisson</param>
        internal SharedAccessAccountPermissions SetupAccessPolicyPermission(string permission)
        {
            if (string.IsNullOrEmpty(permission)) return SharedAccessAccountPermissions.None;

            SharedAccessAccountPermissions accountPermission = SharedAccessAccountPermissions.None;
            permission = permission.ToLower();
            foreach (char op in permission)
            {
                switch (op)
                {
                    case StorageNouns.Permission.Read:
                    case StorageNouns.Permission.Query:
                        accountPermission |= SharedAccessAccountPermissions.Read;
                        break;
                    case StorageNouns.Permission.Process:
                        accountPermission |= SharedAccessAccountPermissions.ProcessMessages;
                        break;
                    case StorageNouns.Permission.Write:
                        accountPermission |= SharedAccessAccountPermissions.Write;
                        break;
                    case StorageNouns.Permission.Add:
                        accountPermission |= SharedAccessAccountPermissions.Add;
                        break;
                    case StorageNouns.Permission.Create:
                        accountPermission |= SharedAccessAccountPermissions.Create;
                        break;
                    case StorageNouns.Permission.Update:
                        accountPermission |= SharedAccessAccountPermissions.Update;
                        break;
                    case StorageNouns.Permission.Delete:
                        accountPermission |= SharedAccessAccountPermissions.Delete;
                        break;
                    case StorageNouns.Permission.List:
                        accountPermission |= SharedAccessAccountPermissions.List;
                        break;
                    default:
                        throw new ArgumentException(string.Format(Resources.InvalidAccessPermission, op));
                }
            }

            return accountPermission;
        }
    }
}
