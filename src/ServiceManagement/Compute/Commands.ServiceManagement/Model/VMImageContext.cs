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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class VMImageContext : OSImageContext
    {
        public override string ImageName { get; set; }
        public override string Label { get; set; }
        public override string Category { get; set; }
        public override string Description { get; set; }

        public override string OS
        {
            get
            {
                return this.OSDiskConfiguration == null ? null : this.OSDiskConfiguration.OS;
            }

            set
            {
                if (this.OSDiskConfiguration == null)
                {
                    this.OSDiskConfiguration = new OSDiskConfiguration();
                }

                this.OSDiskConfiguration.OS = value;
            }
        }

        public OSDiskConfiguration OSDiskConfiguration { get; set; }
        public DataDiskConfigurationList DataDiskConfigurations { get; set; }

        public string ServiceName { get; set; }
        public string DeploymentName { get; set; }
        public string RoleName { get; set; }
        public override string AffinityGroup { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }

        public string Language { get; set; }
        public override string ImageFamily { get; set; }
        public override string RecommendedVMSize { get; set; }
        public override bool? IsPremium { get; set; }
        public override string Eula { get; set; }
        public override string IconUri { get; set; }
        public override string SmallIconUri { get; set; }
        public override Uri PrivacyUri { get; set; }
        public override string PublisherName { get; set; }
        public override DateTime? PublishedDate { get; set; }
        public override bool? ShowInGui { get; set; }
        public Uri PricingDetailLink { get; set; }
    }
}