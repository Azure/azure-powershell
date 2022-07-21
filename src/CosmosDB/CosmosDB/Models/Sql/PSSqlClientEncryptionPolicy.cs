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
using Microsoft.Azure.Management.CosmosDB.Models;
using System;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{

    public class PSSqlClientEncryptionPolicy : PSClientEncryptionPolicy
    {
        public PSSqlClientEncryptionPolicy() : base()
        {
        }

        public PSSqlClientEncryptionPolicy(ClientEncryptionPolicy clientEncryptionPolicy) : base(PSSqlClientEncryptionPolicy.SetSupportedPolicyVersionOnClientEncryptionPolicy(clientEncryptionPolicy, clientEncryptionPolicy.PolicyFormatVersion))
        {
        }

        private static ClientEncryptionPolicy SetSupportedPolicyVersionOnClientEncryptionPolicy(ClientEncryptionPolicy clientEncryptionPolicy, int? policyFormatVersion = null)
        {
            if (policyFormatVersion == null)
            {
                clientEncryptionPolicy.PolicyFormatVersion = 1;
            }
            else
            {
                if(policyFormatVersion > 2 || policyFormatVersion < 1)
                {
                    throw new ArgumentException($"Supported versions of client encryption policy are 1 and 2. ");
                }

                clientEncryptionPolicy.PolicyFormatVersion = policyFormatVersion;
            }

            return clientEncryptionPolicy;
        }
    }
}