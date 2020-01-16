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

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using Microsoft.Azure.Management.DeploymentManager.Models;
    using System;
    using System.Collections.Generic;

    public class PSRestResponseRegex
    {
        public PSRestResponseRegex()
        {
        }

        public PSRestResponseRegex(RestResponseRegex restResponseRegex)
        {
            this.MatchQuantifier = (PSRestMatchQuantifier)Enum.Parse(typeof(PSRestMatchQuantifier), restResponseRegex.MatchQuantifier.ToString(), ignoreCase: true);
            this.Matches = restResponseRegex.Matches;
        }

        public IList<string> Matches { get; set; }

        public PSRestMatchQuantifier MatchQuantifier { get; set; }

        internal RestResponseRegex ToSdkType()
        {
            return new RestResponseRegex(
                matches: this.Matches,
                matchQuantifier: (RestMatchQuantifier)Enum.Parse(typeof(RestMatchQuantifier), this.MatchQuantifier.ToString(), ignoreCase: true));
        }
    }
}
