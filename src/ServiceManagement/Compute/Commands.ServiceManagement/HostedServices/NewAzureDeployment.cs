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
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    using PVM = Model;
    using Hyak.Common;

    /// <summary>
    /// Create a new deployment. Note that there shouldn't be a deployment 
    /// of the same name or in the same slot when executing this command.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureDeployment", DefaultParameterSetName = "PaaS"), OutputType(typeof(ManagementOperationContext))]
    public class NewAzureDeploymentCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Cloud service name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Package location. This parameter specifies the path or URI to a .cspkg in blob storage. The storage account must belong to the same subscription as the deployment.")]
        [ValidateNotNullOrEmpty]
        public string Package
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true,  HelpMessage = "Configuration file path. This parameter should specifiy a .cscfg file on disk.")]
        [ValidateNotNullOrEmpty]
        public string Configuration
        {
            get;
            set;
        }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment slot [Staging | Production].")]
        [ValidateSet(Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DeploymentSlotType.Staging, Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "Label for the new deployment.")]
        [ValidateNotNullOrEmpty]
        public string Label
        {
            get;
            set;
        }

        [Parameter(Position = 5, HelpMessage = "Deployment name.")]
        [Alias("DeploymentName")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }
        
        [Parameter(Mandatory = false, HelpMessage = "Do not start deployment upon creation.")]
        public SwitchParameter DoNotStart
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, HelpMessage = "Indicates whether to treat package validation warnings as errors.")]
        public SwitchParameter TreatWarningsAsError
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Extension configurations.")]
        public ExtensionConfigurationInput[] ExtensionConfiguration
        {
            get;
            set;
        }

        public virtual void NewPaaSDeploymentProcess()
        {
            bool removePackage = false;

            AssertNoPersistenVmRoleExistsInDeployment(PVM.DeploymentSlotType.Production);
            AssertNoPersistenVmRoleExistsInDeployment(PVM.DeploymentSlotType.Staging);

            var storageName = Profile.Context.Subscription.GetStorageAccountName();

            Uri packageUrl;
            if (this.Package.StartsWith(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                this.Package.StartsWith(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
            {
                packageUrl = new Uri(this.Package);
            }
            else
            {
                if (string.IsNullOrEmpty(storageName))
                {
                    throw new ArgumentException(Resources.CurrentStorageAccountIsNotSet);
                }

                var progress = new ProgressRecord(0, Resources.WaitForUploadingPackage, Resources.UploadingPackage);
                WriteProgress(progress);
                removePackage = true;
                packageUrl = this.RetryCall(s =>
                    AzureBlob.UploadPackageToBlob(
                    this.StorageClient,
                    storageName,
                    this.Package,
                    null));
            }

            ExtensionConfiguration extConfig = null;
            if (ExtensionConfiguration != null)
            {
                string errorConfigInput = null;
                if (!ExtensionManager.Validate(ExtensionConfiguration, out errorConfigInput))
                {
                    throw new Exception(string.Format(Resources.ServiceExtensionCannotApplyExtensionsInSameType, errorConfigInput));
                }

                foreach (ExtensionConfigurationInput context in ExtensionConfiguration)
                {
                    if (context != null && context.X509Certificate != null)
                    {
                        ExecuteClientActionNewSM(
                            null,
                            string.Format(Resources.ServiceExtensionUploadingCertificate, CommandRuntime, context.X509Certificate.Thumbprint),
                            () => this.ComputeClient.ServiceCertificates.Create(this.ServiceName, CertUtilsNewSM.Create(context.X509Certificate)));
                    }
                }

                Func<DeploymentSlot, DeploymentGetResponse> func = t =>
                {
                    DeploymentGetResponse d = null;
                    try
                    {
                        d = this.ComputeClient.Deployments.GetBySlot(this.ServiceName, t);
                    }
                    catch (CloudException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound && IsVerbose() == false)
                        {
                            WriteExceptionError(ex);
                        }
                    }

                    return d;
                };

                var slotType = (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), this.Slot, true);
                DeploymentGetResponse currentDeployment = null;
                InvokeInOperationContext(() => currentDeployment = func(slotType));

                var peerSlottype = slotType == DeploymentSlot.Production ? DeploymentSlot.Staging : DeploymentSlot.Production;
                DeploymentGetResponse peerDeployment = null;
                InvokeInOperationContext(() => peerDeployment = func(peerSlottype));

                ExtensionManager extensionMgr = new ExtensionManager(this, ServiceName);
                extConfig = extensionMgr.Set(currentDeployment, peerDeployment, ExtensionConfiguration, this.Slot);
            }
            
            var deploymentInput = new DeploymentCreateParameters
            {
                PackageUri = packageUrl,
                Configuration = GeneralUtilities.GetConfiguration(this.Configuration),
                ExtensionConfiguration = extConfig,
                Label = this.Label,
                Name = this.Name,
                StartDeployment = !this.DoNotStart.IsPresent,
                TreatWarningsAsError = this.TreatWarningsAsError.IsPresent,
            };

            InvokeInOperationContext(() =>
            {
                try
                {
                    var progress = new ProgressRecord(0, Resources.WaitForUploadingPackage, Resources.CreatingNewDeployment);
                    WriteProgress(progress);

                    ExecuteClientActionNewSM(
                        deploymentInput,
                        CommandRuntime.ToString(),
                        () => this.ComputeClient.Deployments.Create(
                            this.ServiceName,
                            (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), this.Slot, true),
                            deploymentInput));

                    if (removePackage == true)
                    {
                        this.RetryCall(s => AzureBlob.DeletePackageFromBlob(
                            this.StorageClient,
                            storageName,
                            packageUrl));
                    }
                }
                catch (CloudException ex)
                {
                    WriteExceptionError(ex);
                }
            });
        }

        private void AssertNoPersistenVmRoleExistsInDeployment(string slot)
        {
            InvokeInOperationContext(() =>
            {
                try
                {
                    var currentDeployment = this.ComputeClient.Deployments.GetBySlot(this.ServiceName, (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), slot, true));
                    if (currentDeployment.Roles != null)
                    {
                        if (string.Compare(currentDeployment.Roles[0].RoleType, "PersistentVMRole", StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            throw new ArgumentException(String.Format(Resources.CanNotCreateNewDeploymentWhileVMsArePresent, slot));
                        }
                    }
                }
                catch (CloudException ex)
                {
                    if (ex.Response.StatusCode != HttpStatusCode.NotFound && IsVerbose() == false)
                    {
                        WriteExceptionError(ex);
                    }
                }
            });
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            this.ValidateParameters();
            this.NewPaaSDeploymentProcess();
        }

        protected virtual void ValidateParameters()
        {
            if (string.IsNullOrEmpty(this.Slot))
            {
                this.Slot = PVM.DeploymentSlotType.Production;
            }

            if (string.IsNullOrEmpty(this.Name))
            {
                 this.Name = Guid.NewGuid().ToString();
            }

            if (string.IsNullOrEmpty(this.Label))
            {
                this.Label = this.Name;
            }
        }
    }
}
