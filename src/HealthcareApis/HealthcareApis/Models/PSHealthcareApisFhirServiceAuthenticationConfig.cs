﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.HealthcareApis.Models
{
    public class PSHealthcareApisFhirServiceAuthenticationConfig
    {
        private static readonly string defaultAudience = "https://{0}.azurehealthcareapis.com";
        internal static readonly string defaultAuthorityPrefix = "https://login.microsoftonline.com/";

        internal static string getDefaultAudience(string name)
        {
            return System.String.Format(defaultAudience, name);
        }
        public PSHealthcareApisFhirServiceAuthenticationConfig(ServiceAuthenticationConfigurationInfo serviceAuthenticationConfigurationInfo)
        {
            this.Authority = serviceAuthenticationConfigurationInfo.Authority;
            this.Audience = serviceAuthenticationConfigurationInfo.Audience;
            this.SmartProxyEnabled = serviceAuthenticationConfigurationInfo.SmartProxyEnabled;
        }

        public string Authority { get; private set; }

        public string Audience { get; private set; }

        public bool? SmartProxyEnabled { get; private set; }

    }
}
