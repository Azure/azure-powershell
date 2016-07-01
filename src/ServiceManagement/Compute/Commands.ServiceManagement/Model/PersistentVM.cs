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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class PersistentVM : IPersistentVM
    {
        public string AvailabilitySetName
        {
            get;
            set;
        }

        public Collection<ConfigurationSet> ConfigurationSets
        {
            get;
            set;
        }

        public Collection<DataVirtualHardDisk> DataVirtualHardDisks
        {
            get;
            set;
        }

        public string Label
        {
            get;
            set;
        }

        public OSVirtualHardDisk OSVirtualHardDisk
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }

        public string RoleSize
        {
            get;
            set;
        }

        public string RoleType
        {
            get;
            set;
        }

        [XmlIgnore]
        public X509Certificate2 WinRMCertificate
        {
            get;
            set;
        }

        [XmlIgnore]
        public List<X509Certificate2> X509Certificates
        {
            get;
            set;
        }

        public bool NoExportPrivateKey
        {
            get;
            set;
        }

        public bool NoRDPEndpoint
        {
            get;
            set;
        }

        public bool NoSSHEndpoint
        {
            get;
            set;
        }

        public string DefaultWinRmCertificateThumbprint
        {
            get;
            set;
        }


        public bool? ProvisionGuestAgent
        {
            get;
            set;
        }

        public ResourceExtensionReferenceList ResourceExtensionReferences
        {
            get;
            set;
        }

        [XmlIgnore]
        public Collection<DataVirtualHardDisk> DataVirtualHardDisksToBeDeleted
        {
            get;
            set;
        }

        [XmlIgnore]
        public VMImageInput VMImageInput
        {
            get;
            set;
        }

        public DebugSettings DebugSettings
        {
            get;
            set;
        }

        public string MigrationState
        {
            get;
            set;
        }

        public string LicenseType
        {
            get;
            set;
        }

        public PersistentVM GetInstance()
        {
            return this;
        }

    }
}

