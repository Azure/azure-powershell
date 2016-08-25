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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using AutoMapper;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.PersistentVMs
{
    [Cmdlet(VerbsCommon.New, ProfileNouns.VirtualMachine, DefaultParameterSetName = ExistingServiceParameterSet), OutputType(typeof(ManagementOperationContext))]
    public class NewAzureVMCommand : IaaSDeploymentManagementCmdletBase
    {
        private const string CreateServiceParameterSet = "CreateService";
        private const string ExistingServiceParameterSet = "ExistingService";
        private bool createdDeployment;

        [Parameter(Mandatory = true, ParameterSetName = CreateServiceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Service Name")]
        [Parameter(Mandatory = true, ParameterSetName = ExistingServiceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Service Name")]
        [ValidateNotNullOrEmpty]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = CreateServiceParameterSet, HelpMessage = "Required if AffinityGroup is not specified. The data center region where the cloud service will be created.")]
        [ValidateNotNullOrEmpty]
        public string Location
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateServiceParameterSet, HelpMessage = "Required if Location is not specified. The name of an existing affinity group associated with this subscription.")]
        [ValidateNotNullOrEmpty]
        public string AffinityGroup
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateServiceParameterSet, HelpMessage = "The label may be up to 100 characters in length. Defaults to Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceLabel
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateServiceParameterSet, HelpMessage = "Dns address to which the cloud service’s IP address resolves when queried using a reverse Dns query.")]
        [ValidateNotNullOrEmpty]
        public string ReverseDnsFqdn
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateServiceParameterSet, HelpMessage = "A description for the cloud service. The description may be up to 1024 characters in length.")]
        [ValidateNotNullOrEmpty]
        public string ServiceDescription
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = CreateServiceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment Label. Will default to service name if not specified.")]
        [Parameter(Mandatory = false, ParameterSetName = ExistingServiceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment Label. Will default to service name if not specified.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentLabel
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = CreateServiceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment Name. Will default to service name if not specified.")]
        [Parameter(Mandatory = false, ParameterSetName = ExistingServiceParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment Name. Will default to service name if not specified.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = CreateServiceParameterSet, HelpMessage = "Virtual network name.")]
        [Parameter(Mandatory = false, ParameterSetName = ExistingServiceParameterSet, HelpMessage = "Virtual network name.")]
        public string VNetName
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = CreateServiceParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "DNS Settings for Deployment.")]
        [Parameter(Mandatory = false, ParameterSetName = ExistingServiceParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "DNS Settings for Deployment.")]
        [ValidateNotNullOrEmpty]
        public Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DnsServer[] DnsSettings
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = CreateServiceParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ILB Settings for Deployment.")]
        [Parameter(Mandatory = false, ParameterSetName = ExistingServiceParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ILB Settings for Deployment.")]
        [ValidateNotNullOrEmpty]
        public Model.InternalLoadBalancerConfig InternalLoadBalancerConfig
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = CreateServiceParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "List of VMs to Deploy.")]
        [Parameter(Mandatory = true, ParameterSetName = ExistingServiceParameterSet, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "List of VMs to Deploy.")]
        [ValidateNotNullOrEmpty]
        public Model.PersistentVM[] VMs
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, HelpMessage = "Waits for VM to boot")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter WaitForBoot
        {
            get;
            set;
        }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the reserved IP.")]
        [ValidateNotNullOrEmpty]
        public string ReservedIPName
        {
            get;
            set;
        }

        protected Tuple<Model.PersistentVM, bool, bool>[] VMTuples;

        public void NewAzureVMProcess()
        {
            AzureSubscription currentSubscription = Profile.Context.Subscription;
            CloudStorageAccount currentStorage = null;
            try
            {
                currentStorage = currentSubscription.GetCloudStorageAccount(Profile);
            }
            catch (Exception ex) // couldn't access
            {
                throw new ArgumentException(Resources.CurrentStorageAccountIsNotAccessible, ex);
            }

            if (currentStorage == null) // not set
            {
                throw new ArgumentException(Resources.CurrentStorageAccountIsNotSet);
            }

            if (this.ParameterSetName.Equals("CreateService", StringComparison.OrdinalIgnoreCase))
            {
                var parameter = new HostedServiceCreateParameters
                {
                    AffinityGroup = this.AffinityGroup,
                    Location = this.Location,
                    ServiceName = this.ServiceName,
                    Description = this.ServiceDescription ?? String.Format(
                                      "Implicitly created hosted service{0}",
                                      DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm")),
                    Label = this.ServiceLabel ?? this.ServiceName,
                    ReverseDnsFqdn = this.ReverseDnsFqdn
                };

                try
                {
                    this.ComputeClient.HostedServices.Create(parameter);
                }
                catch (CloudException ex)
                {
                    if (string.Equals(ex.Error.Code, "ConflictError"))
                    {
                        HostedServiceGetResponse existingService = this.ComputeClient.HostedServices.Get(this.ServiceName);

                        if (existingService == null || existingService.Properties == null)
                        {
                            // The same service name is already used by another subscription.
                            WriteExceptionError(ex);
                            return;
                        }
                        else if ((string.IsNullOrEmpty(existingService.Properties.Location) &&
                            string.Compare(existingService.Properties.AffinityGroup, this.AffinityGroup, StringComparison.InvariantCultureIgnoreCase) == 0)
                            || (string.IsNullOrEmpty(existingService.Properties.AffinityGroup) &&
                            string.Compare(existingService.Properties.Location, this.Location, StringComparison.InvariantCultureIgnoreCase) == 0))
                        {
                            // The same service name is already created under the same subscription,
                            // and its affinity group or location is matched with the given parameter.
                            this.WriteWarning(ex.Error.Message);
                        }
                        else
                        {
                            // The same service name is already created under the same subscription,
                            // but its affinity group or location is not matched with the given parameter.
                            this.WriteWarning("Location or AffinityGroup name is not matched with the existing service");
                            WriteExceptionError(ex);
                            return;
                        }
                    }
                    else
                    {
                        WriteExceptionError(ex);
                        return;
                    }
                }
            }

            foreach (var vm in from v in VMs let configuration = v.ConfigurationSets.OfType<Model.WindowsProvisioningConfigurationSet>().FirstOrDefault() where configuration != null select v)
            {
                if (vm.WinRMCertificate != null)
                {
                    if(!CertUtilsNewSM.HasExportablePrivateKey(vm.WinRMCertificate))
                    {
                        throw new ArgumentException(Resources.WinRMCertificateDoesNotHaveExportablePrivateKey);
                    }

                    var operationDescription = string.Format(Resources.AzureVMUploadingWinRMCertificate, CommandRuntime, vm.WinRMCertificate.Thumbprint);
                    var parameters = CertUtilsNewSM.Create(vm.WinRMCertificate);

                    ExecuteClientActionNewSM(
                        null,
                        operationDescription,
                        () => this.ComputeClient.ServiceCertificates.Create(this.ServiceName, parameters),
                        (s, r) => ContextFactory<OperationStatusResponse, ManagementOperationContext>(r, s));

                }

                var certificateFilesWithThumbprint = from c in vm.X509Certificates
                    select new
                           {
                               c.Thumbprint,
                               CertificateFile = CertUtilsNewSM.Create(c, vm.NoExportPrivateKey)
                           };

                foreach (var current in certificateFilesWithThumbprint.ToList())
                {
                    var operationDescription = string.Format(Resources.AzureVMCommandUploadingCertificate, CommandRuntime, current.Thumbprint);
                    ExecuteClientActionNewSM(
                        null,
                        operationDescription,
                        () => this.ComputeClient.ServiceCertificates.Create(this.ServiceName, current.CertificateFile),
                        (s, r) => ContextFactory<OperationStatusResponse, ManagementOperationContext>(r, s));
                }
            }

            var persistentVMs = this.VMs.Select((vm, index) => CreatePersistentVMRole(VMTuples[index], currentStorage)).ToList();

            // If the current deployment doesn't exist set it create it
            if (CurrentDeploymentNewSM == null)
            {
                try
                {
                    var parameters = new VirtualMachineCreateDeploymentParameters
                    {
                        DeploymentSlot = DeploymentSlot.Production,
                        Name = this.DeploymentName ?? this.ServiceName,
                        Label = this.DeploymentLabel ?? this.ServiceName,
                        VirtualNetworkName = this.VNetName,
                        Roles = { persistentVMs[0] },
                        ReservedIPName = ReservedIPName
                    };

                    if (this.DnsSettings != null)
                    {
                        parameters.DnsSettings = new Management.Compute.Models.DnsSettings();

                        foreach (var dns in this.DnsSettings)
                        {
                            parameters.DnsSettings.DnsServers.Add(
                                new Microsoft.WindowsAzure.Management.Compute.Models.DnsServer
                                {
                                    Name = dns.Name,
                                    Address = dns.Address
                                });
                        }
                    }

                    if (this.InternalLoadBalancerConfig != null)
                    {
                        parameters.LoadBalancers = new LoadBalancer[1]
                        {
                            new LoadBalancer
                            {
                                Name = this.InternalLoadBalancerConfig.InternalLoadBalancerName,
                                FrontendIPConfiguration = new FrontendIPConfiguration
                                {
                                    Type = FrontendIPConfigurationType.Private,
                                    SubnetName = this.InternalLoadBalancerConfig.SubnetName,
                                    StaticVirtualNetworkIPAddress = this.InternalLoadBalancerConfig.IPAddress
                                }
                            }
                        };
                    }

                    var operationDescription = string.Format(Resources.AzureVMCommandCreateDeploymentWithVM, CommandRuntime, persistentVMs[0].RoleName);
                    ExecuteClientActionNewSM(
                        parameters,
                        operationDescription,
                        () => this.ComputeClient.VirtualMachines.CreateDeployment(this.ServiceName, parameters));

                    if(this.WaitForBoot.IsPresent)
                    {
                        WaitForRoleToBoot(persistentVMs[0].RoleName);
                    }
                }
                catch (CloudException ex)
                {
                    if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception(Resources.ServiceDoesNotExistSpecifyLocationOrAffinityGroup);
                    }
                    else
                    {
                        WriteExceptionError(ex);
                    }

                    return;
                }

                this.createdDeployment = true;
            }
            else
            {
                if (this.VNetName != null || this.DnsSettings != null || !string.IsNullOrEmpty(this.DeploymentLabel) || !string.IsNullOrEmpty(this.DeploymentName))
                {
                    WriteWarning(Resources.VNetNameDnsSettingsDeploymentLabelDeploymentNameCanBeSpecifiedOnNewDeployments);
                }
            }

            if (this.createdDeployment == false && CurrentDeploymentNewSM != null)
            {
                this.DeploymentName = CurrentDeploymentNewSM.Name;
            }

            int startingVM = this.createdDeployment ? 1 : 0;

            for (int i = startingVM; i < persistentVMs.Count; i++)
            {
                var operationDescription = string.Format(Resources.AzureVMCommandCreateVM, CommandRuntime, persistentVMs[i].RoleName);
                
                var parameter = new VirtualMachineCreateParameters
                {
                    AvailabilitySetName = persistentVMs[i].AvailabilitySetName,
                    OSVirtualHardDisk = VMTuples[i].Item3 ? null : persistentVMs[i].OSVirtualHardDisk,
                    RoleName = persistentVMs[i].RoleName,
                    RoleSize = persistentVMs[i].RoleSize,
                    ProvisionGuestAgent = persistentVMs[i].ProvisionGuestAgent,
                    ResourceExtensionReferences = persistentVMs[i].ProvisionGuestAgent != null && persistentVMs[i].ProvisionGuestAgent.Value ? persistentVMs[i].ResourceExtensionReferences : null,
                    VMImageName = VMTuples[i].Item3 ? persistentVMs[i].VMImageName : null,
                    MediaLocation = VMTuples[i].Item3 ? persistentVMs[i].MediaLocation : null,
                    LicenseType = persistentVMs[i].LicenseType
                };

                if (parameter.OSVirtualHardDisk != null)
                {
                    parameter.OSVirtualHardDisk.IOType = null;
                }

                if (persistentVMs[i].DataVirtualHardDisks != null && persistentVMs[i].DataVirtualHardDisks.Any())
                {
                    persistentVMs[i].DataVirtualHardDisks.ForEach(c => parameter.DataVirtualHardDisks.Add(c));
                    parameter.DataVirtualHardDisks.ForEach(d => d.IOType = null);
                }

                persistentVMs[i].ConfigurationSets.ForEach(c => parameter.ConfigurationSets.Add(c));

                ExecuteClientActionNewSM(
                    persistentVMs[i],
                    operationDescription,
                    () => this.ComputeClient.VirtualMachines.Create(this.ServiceName, this.DeploymentName ?? this.ServiceName, parameter));
            }

            if(this.WaitForBoot.IsPresent)
            {
                for (int i = startingVM; i < persistentVMs.Count; i++)
                {
                    WaitForRoleToBoot(persistentVMs[i].RoleName);
                }
            }
        }

        private Management.Compute.Models.Role CreatePersistentVMRole(Tuple<Model.PersistentVM, bool, bool> tuple, CloudStorageAccount currentStorage)
        {
            Model.PersistentVM persistentVM = tuple.Item1;
            bool isVMImage = tuple.Item3;

            var mediaLinkFactory = new MediaLinkFactory(currentStorage, this.ServiceName, persistentVM.RoleName);

            if (!isVMImage)
            {
                if (persistentVM.OSVirtualHardDisk.MediaLink == null && string.IsNullOrEmpty(persistentVM.OSVirtualHardDisk.DiskName))
                {
                    persistentVM.OSVirtualHardDisk.MediaLink = mediaLinkFactory.Create();
                }
            }

            foreach (var datadisk in persistentVM.DataVirtualHardDisks.Where(d => d.MediaLink == null && string.IsNullOrEmpty(d.DiskName)))
            {
                datadisk.MediaLink = mediaLinkFactory.Create();
            }

            var result = new Management.Compute.Models.Role
            {
                AvailabilitySetName = persistentVM.AvailabilitySetName,
                OSVirtualHardDisk = isVMImage ? null : Mapper.Map(persistentVM.OSVirtualHardDisk, new Management.Compute.Models.OSVirtualHardDisk()),
                RoleName = persistentVM.RoleName,
                RoleSize = persistentVM.RoleSize,
                RoleType = persistentVM.RoleType,
                Label = persistentVM.Label,
                ProvisionGuestAgent = persistentVM.ProvisionGuestAgent,
                ResourceExtensionReferences = persistentVM.ProvisionGuestAgent != null && persistentVM.ProvisionGuestAgent.Value ? Mapper.Map<List<ResourceExtensionReference>>(persistentVM.ResourceExtensionReferences) : null,
                VMImageName = isVMImage ? persistentVM.OSVirtualHardDisk.SourceImageName : null,
                MediaLocation = isVMImage ? persistentVM.OSVirtualHardDisk.MediaLink : null,
                LicenseType = persistentVM.LicenseType
            };

            if (persistentVM.VMImageInput != null)
            {
                result.VMImageInput = isVMImage ? PersistentVMHelper.MapVMImageInput(persistentVM.VMImageInput) : null;
            }

            if (result.OSVirtualHardDisk != null)
            {
                result.OSVirtualHardDisk.IOType = null;
            }

            if (persistentVM.DataVirtualHardDisks != null && persistentVM.DataVirtualHardDisks.Any())
            {
                persistentVM.DataVirtualHardDisks.ForEach(c =>
                {
                    var dataDisk = Mapper.Map(c, new Microsoft.WindowsAzure.Management.Compute.Models.DataVirtualHardDisk());
                    dataDisk.LogicalUnitNumber = dataDisk.LogicalUnitNumber;
                    result.DataVirtualHardDisks.Add(dataDisk);
                });
                result.DataVirtualHardDisks.ForEach(d => d.IOType = null);
            }
            else
            {
                result.DataVirtualHardDisks = null;
            }

            if (persistentVM.ConfigurationSets != null)
            {
                PersistentVMHelper.MapConfigurationSets(persistentVM.ConfigurationSets).ForEach(c => result.ConfigurationSets.Add(c));
            }

            if (persistentVM.DebugSettings != null)
            {
                result.DebugSettings = new DebugSettings
                {
                    BootDiagnosticsEnabled = persistentVM.DebugSettings.BootDiagnosticsEnabled
                };
            }
            return result;
        }

        protected override void ProcessRecord()
        {
            try
            {
                ServiceManagementProfile.Initialize();
                this.ValidateParameters();
                base.ProcessRecord();
                this.NewAzureVMProcess();
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }

        protected void ValidateParameters()
        {
            if (ParameterSetName.Equals(CreateServiceParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrEmpty(Location) && string.IsNullOrEmpty(AffinityGroup))
                {
                    throw new ArgumentException(Resources.LocationOrAffinityGroupRequiredWhenCreatingNewCloudService);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Location) && !string.IsNullOrEmpty(AffinityGroup))
                {
                    throw new ArgumentException(Resources.LocationOrAffinityGroupCanOnlyBeSpecifiedWhenNewCloudService);
                }
                if (!string.IsNullOrEmpty(ReverseDnsFqdn))
                {
                    throw new ArgumentException(Resources.ReverseDnsFqdnCanOnlyBeSpecifiedWhenNewCloudService);
                }
            }

            if (this.ParameterSetName.Equals(CreateServiceParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                if (this.DnsSettings != null && string.IsNullOrEmpty(this.VNetName))
                {
                    throw new ArgumentException(Resources.VNetNameRequiredWhenSpecifyingDNSSettings);
                }
            }

            if (!string.IsNullOrEmpty(this.VNetName))
            {
                List<string> vmNames = new List<string>();
                foreach (Model.PersistentVM VM in this.VMs)
                {
                    Model.NetworkConfigurationSet networkConfig = VM.ConfigurationSets.OfType<Model.NetworkConfigurationSet>().SingleOrDefault();
                    if (networkConfig == null || networkConfig.SubnetNames == null ||
                        networkConfig.SubnetNames.Count == 0)
                    {
                        vmNames.Add(VM.RoleName);
                    }
                }

                if (vmNames.Count != 0)
                {
                    WriteWarning(string.Format(Resources.SubnetShouldBeSpecifiedIfVnetPresent, string.Join(", ", vmNames)));
                }
            }

            this.VMTuples = new Tuple<Model.PersistentVM, bool, bool>[this.VMs.Count()];
            int index = 0;
            foreach (var pVM in this.VMs)
            {
                bool isOSImage = false;
                bool isVMImage = false;

                if (pVM.OSVirtualHardDisk != null && !string.IsNullOrEmpty(pVM.OSVirtualHardDisk.SourceImageName))
                {
                    var imageType = new VirtualMachineImageHelper(this.ComputeClient).GetImageType(
                        pVM.OSVirtualHardDisk.SourceImageName);
                    isOSImage = imageType.HasFlag(Model.VirtualMachineImageType.OSImage);
                    isVMImage = imageType.HasFlag(Model.VirtualMachineImageType.VMImage);
                }

                if (isOSImage && isVMImage)
                {
                    throw new ArgumentException(
                        string.Format(Resources.DuplicateNamesFoundInBothVMAndOSImages, pVM.OSVirtualHardDisk.SourceImageName));
                }

                this.VMTuples[index++] = new Tuple<Model.PersistentVM, bool, bool>(pVM, isOSImage, isVMImage);

                var provisioningConfiguration = pVM.ConfigurationSets
                    .OfType<Model.ProvisioningConfigurationSet>()
                    .SingleOrDefault();
                
                if (isOSImage && provisioningConfiguration == null && pVM.OSVirtualHardDisk.SourceImageName != null)
                {
                    throw new ArgumentException(string.Format(Resources.VMMissingProvisioningConfiguration, pVM.RoleName));
                }
            }
        }
    }
}