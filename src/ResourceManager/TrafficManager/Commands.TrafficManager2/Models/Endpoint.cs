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

namespace Microsoft.Azure.Commands.TrafficManager.Models
{
    using System;
    using Microsoft.Azure.Commands.TrafficManager.Utilities;

    public class Endpoint
    {
        public string Name { get; set; }

        private string type;

        public string Type
        {
            get { return this.type; }

            set
            {
                if (!value.StartsWith(Constants.ProfileType, StringComparison.OrdinalIgnoreCase))
                {
                    this.type = string.Format("{0}/{1}", Constants.ProfileType, value);
                }
            }
        }

        public string Target { get; set; }

        public string EndpointStatus { get; set; }

        public uint? Weight { get; set; }

        public uint? Priority { get; set; }

        public string Location { get; set; }
    }
}
