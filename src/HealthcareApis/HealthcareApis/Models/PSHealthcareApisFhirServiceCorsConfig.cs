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

using Microsoft.Azure.Management.HealthcareApis.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HealthcareApis.Models
{
    public class PSHealthcareApisFhirServiceCorsConfig
    {
        public PSHealthcareApisFhirServiceCorsConfig(ServiceCorsConfigurationInfo serviceCorsConfigurationInfo)
        {
            this.Origins = serviceCorsConfigurationInfo.Origins;
            this.Headers = serviceCorsConfigurationInfo.Headers;
            this.Methods = serviceCorsConfigurationInfo.Methods;
            this.MaxAge = serviceCorsConfigurationInfo.MaxAge;
            this.AllowCredentials = serviceCorsConfigurationInfo.AllowCredentials;
        }

        public IList<string> Origins { get; private set; }

        public IList<string> Headers { get; private set; }

        public IList<string> Methods { get; private set; }

        public int? MaxAge { get; private set; }

        public bool? AllowCredentials { get; private set; }
    }
}
