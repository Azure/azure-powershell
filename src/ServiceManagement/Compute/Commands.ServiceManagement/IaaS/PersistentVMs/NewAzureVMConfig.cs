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
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.New, "AzureVMConfig", DefaultParameterSetName = ImageNameParamterSet), OutputType(typeof(PersistentVM))]
    public class NewAzureVMConfigCommand : ServiceManagementBaseCmdlet
    {
        private const string ImageNameParamterSet = "ImageName";
        private const string DiskNameParamterSet = "DiskName";
        private const string RoleType = "PersistentVMRole";

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Represents the size of the machine.")]
        [ValidateNotNullOrEmpty]
        public string InstanceSize
        {
            get;
            set;
        }

        [Parameter(Position = 2, HelpMessage = "Controls the platform caching behavior of the OS disk.")]
        [ValidateSet("ReadWrite", "ReadOnly", IgnoreCase = true)]
        public string HostCaching
        {
            get;
            set;
        }

        [Parameter(Position = 3, HelpMessage = "The name of the availability set.")]
        [ValidateNotNullOrEmpty]
        public string AvailabilitySetName
        {
            get;
            set;
        }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The VM label.")]
        [ValidateNotNullOrEmpty]
        public string Label
        {
            get;
            set;
        }

        [Parameter(Position = 5, Mandatory = true, ParameterSetName = DiskNameParamterSet, HelpMessage = "Friendly name of the OS disk in the disk repository.")]
        [ValidateNotNullOrEmpty]
        public string DiskName
        {
            get;
            set;
        }

        [Parameter(Position = 5, Mandatory = true, ParameterSetName = ImageNameParamterSet, HelpMessage = "Reference to a platform stock image or a user image from the image repository.")]
        [ValidateNotNullOrEmpty]
        public string ImageName
        {
            get;
            set;
        }

        [Parameter(Position = 6, Mandatory = false, ParameterSetName = ImageNameParamterSet, HelpMessage = "Location of the where the VHD should be created. This link refers to a blob in a storage account. If not specified the VHD will be created in the default storage account with the following format :vhds/servicename-vmname-year-month-day-ms")]
        [ValidateNotNullOrEmpty]
        public string MediaLocation
        {
            get;
            set;
        }

        [Parameter(Position = 7, Mandatory = false, ParameterSetName = ImageNameParamterSet, HelpMessage = "Label of the new disk to be created.")]
        [ValidateNotNullOrEmpty]
        public string DiskLabel
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.VMBootDiagnosticsDisable)]
        public SwitchParameter DisableBootDiagnostics
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.VMLicenseType)]
        [ValidateSet("Windows_Client", "Windows_Server", IgnoreCase = true)]
        public string LicenseType
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            ValidateParameters();

            var role = new PersistentVM
            {
                AvailabilitySetName = this.AvailabilitySetName,
                ConfigurationSets = new Collection<ConfigurationSet>(),
                DataVirtualHardDisks = new Collection<DataVirtualHardDisk>(),
                RoleName = this.Name,
                RoleSize = this.InstanceSize,
                RoleType = RoleType,
                Label = this.Label,
                ProvisionGuestAgent = true,
                DebugSettings = new DebugSettings(),
                LicenseType = this.LicenseType
            };

            role.OSVirtualHardDisk = new OSVirtualHardDisk()
            {
                DiskName = this.DiskName,
                SourceImageName = this.ImageName,
                MediaLink = string.IsNullOrEmpty(MediaLocation) ? null : new Uri(this.MediaLocation),
                HostCaching = this.HostCaching,
                DiskLabel = string.IsNullOrEmpty(DiskLabel) ? null : this.DiskLabel
            };

            role.DebugSettings.BootDiagnosticsEnabled = !(this.DisableBootDiagnostics.IsPresent);
            WriteObject(role, true);
        }

        protected void ValidateParameters()
        {
            AzureSubscription currentSubscription = Profile.Context.Subscription;
            if ((currentSubscription == null || string.IsNullOrEmpty(currentSubscription.GetProperty(AzureSubscription.Property.StorageAccount))) && string.IsNullOrEmpty(MediaLocation))
            {
                throw new ArgumentException(Resources.MustSpecifyMediaLocationOrHaveCurrentStorageAccount);
            }

            if (string.IsNullOrEmpty(Label))
            {
                Label = Name;
            }
        }
    }
}