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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public sealed class DiskContext : ManagementOperationContext
    {
        public string AffinityGroup { get; set; }

        public RoleReference AttachedTo { get; set; }

        public bool IsCorrupted { get; set; }

        public string Label { get; set; }

        public string Location { get; set; }

        public int DiskSizeInGB { get; set; }

        public Uri MediaLink { get; set; }

        public string DiskName { get; set; }

        public string SourceImageName { get; set; }

        public string OS { get; set; }

        public string IOType { get; set; }

        public class RoleReference
        {
            public string DeploymentName { get; set; }

            public string HostedServiceName { get; set; }

            public string RoleName { get; set; }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "RoleName: {0} \n\rDeploymentName: {1} \n\rHostedServiceName: {2}",
                    this.RoleName,
                    this.DeploymentName,
                    this.HostedServiceName);
            }
        }
    }
}
