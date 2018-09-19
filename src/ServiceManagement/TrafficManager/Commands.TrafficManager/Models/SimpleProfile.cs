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

using Microsoft.WindowsAzure.Management.TrafficManager.Models;

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Models
{
    public class SimpleProfile
    {
        private Management.TrafficManager.Models.Profile profile { get; set; }

        public SimpleProfile(Management.TrafficManager.Models.Profile profile)
        {
            this.profile = profile;
        }

        public string Name
        {
            get { return this.profile.Name; }
            set { this.profile.Name = value; }
        }

        public string DomainName
        {
            get { return this.profile.DomainName; }
            set { this.profile.DomainName = value; }
        }

        public ProfileDefinitionStatus Status
        {
            get { return this.profile.Status; }
            set { this.profile.Status = value; }
        }
    }
}
