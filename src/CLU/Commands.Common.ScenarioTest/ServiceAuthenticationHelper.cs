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
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Examples.Test;
using Microsoft.Azure.Commands.ScenarioTest;

namespace Commands.Common.ScenarioTest
{
    public class ServiceAuthenticationHelper : IScriptEnvironmentHelper
    {    
        string _spn;
        string _secret;
        const string SecretKey = "secret";
        const string SPNKey = "spn";
        public ServiceAuthenticationHelper(string spn, string secret)
        {
            _spn = spn;
            _secret = secret;
        }

        public bool TrySetupScriptEnvironment(TestContext testContext, IClientFactory clientFactory, IDictionary<string, string> settings)
        {
            Logger.Instance.WriteMessage($"Logging in using ServicePrincipal: {_spn}");
            settings[SPNKey] = _spn;
            settings[SecretKey] = _secret;
            return true;
        }
    }
}
