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
    public class PSHealthcareApisFhirServiceCosmosDbConfig
    {
        internal static readonly int defaultOfferThroughput = 400;
        public PSHealthcareApisFhirServiceCosmosDbConfig(ServiceCosmosDbConfigurationInfo serviceCosmosDbConfigurationInfo)
        {
            this.OfferThroughput = serviceCosmosDbConfigurationInfo.OfferThroughput;
            this.KeyVaultKeyUri = serviceCosmosDbConfigurationInfo.KeyVaultKeyUri;
        }

        public string KeyVaultKeyUri { get; private set; }

        public int? OfferThroughput { get; private set; }
    }
}
