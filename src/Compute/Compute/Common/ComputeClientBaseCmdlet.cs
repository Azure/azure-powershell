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
using System.Globalization;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Compute
{
    public abstract class ComputeClientBaseCmdlet : AzureRMCmdlet
    {
        protected const string VirtualMachineExtensionType = "Microsoft.Compute/virtualMachines/extensions";

        protected override bool IsUsageMetricEnabled => true;
        protected DateTime StartTime;

        private ComputeClient computeClient;

        public ComputeClient ComputeClient
        {
            get
            {
                if (computeClient == null)
                {
                    computeClient = new ComputeClient(DefaultProfile.DefaultContext);
                }

                this.computeClient.VerboseLogger = WriteVerboseWithTimestamp;
                this.computeClient.ErrorLogger = WriteErrorWithTimestamp;
                return computeClient;
            }

            set { computeClient = value; }
        }

        public override void ExecuteCmdlet()
        {
            StartTime = DateTime.Now;
            base.ExecuteCmdlet();
        }

        protected void ExecuteClientAction(Action action)
        {
            try
            {
                action();
            }
            catch (Rest.Azure.CloudException ex)
            {
                try
                {
                    base.EndProcessing();
                }
                catch
                {
                    // Ignore exceptions during end processing
                }

                throw new ComputeCloudException(ex);
            }
        }

        protected void ThrowInvalidArgumentError(string errorMessage, string arg)
        {
            ThrowTerminatingError
                (new ErrorRecord(
                    new ArgumentException(string.Format(CultureInfo.InvariantCulture,
                        errorMessage, arg)),
                    "InvalidArgument",
                    ErrorCategory.InvalidArgument,
                    null));
        }

        protected string GetDiskNameFromId(string Id)
        {
            return Id.Substring(Id.LastIndexOf('/') + 1);
        }

        public static string GetOperationIdFromUrlString(string Url)
        {
            Regex r = new Regex(@"(.*?)operations/(?<id>[a-f0-9]{8}[-]([a-f0-9]{4}[-]){3}[a-f0-9]{12})", RegexOptions.IgnoreCase);
            Match m = r.Match(Url);
            return m.Success ? m.Groups["id"].Value : null;
        }

        public static ManagedDiskParameters SetManagedDisk(string managedDiskId, string diskEncryptionSetId, string storageAccountType, ManagedDiskParameters managedDisk = null)
        {
            if (string.IsNullOrWhiteSpace(managedDiskId) && string.IsNullOrWhiteSpace(diskEncryptionSetId) && string.IsNullOrWhiteSpace(storageAccountType))
            {
                return managedDisk;
            }

            managedDisk = new ManagedDiskParameters();

            if (!string.IsNullOrWhiteSpace(managedDiskId))
            {
                managedDisk.Id = managedDiskId;
            }

            if (!string.IsNullOrWhiteSpace(diskEncryptionSetId))
            {
                managedDisk.DiskEncryptionSet = new DiskEncryptionSetParameters(diskEncryptionSetId);
            }

            if (!string.IsNullOrWhiteSpace(storageAccountType))
            {
                managedDisk.StorageAccountType = storageAccountType;
            }

            return managedDisk;
        }

        private ResourceManagementClient _armClient;

        public ResourceManagementClient ArmClient
        {
            get
            {
                return this._armClient ??
                       (this._armClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                           context: this.DefaultContext,
                           endpoint: AzureEnvironment.Endpoint.ResourceManager));
            }
            set
            {
                this._armClient = value;
            }
        }
    }
}

