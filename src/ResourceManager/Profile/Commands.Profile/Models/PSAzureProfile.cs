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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Credential and environment data for connecting with an Azure instance in the current session.
    /// </summary>
    public class PSAzureProfile
    {
        private Dictionary<string, PSAzureEnvironment> _env = new Dictionary<string, PSAzureEnvironment>();

        /// <summary>
        /// Convert between implementations of AzureProfile.
        /// </summary>
        /// <param name="profile">The profile to convert.</param>
        /// <returns>The converted profile.</returns>
        public static implicit operator PSAzureProfile(AzureRMProfile profile)
        {
            if (profile == null)
            {
                return null;
            }

            var result = new PSAzureProfile
            {
                Context = profile.Context
            };

            profile.Environments
                .ForEach((e) => result.Environments[e.Key] = (PSAzureEnvironment)e.Value);
            return result;
        }

        /// <summary>
        /// Convert between implementations of AzureProfile.
        /// </summary>
        /// <param name="profile">The profile to convert.</param>
        /// <returns>The converted profile.</returns>
        public static implicit operator AzureRMProfile(PSAzureProfile profile)
        {
            if (profile == null)
            {
                return null;
            }

            var result = new AzureRMProfile
            {
                Context = profile.Context
            };
            profile.Environments.ForEach((e) => result.Environments[e.Key] = (AzureEnvironment)e.Value);
            return result;
        }

        /// <summary>
        /// The set of AzureCloud environments.
        /// </summary>
        public IDictionary<string, PSAzureEnvironment> Environments
        {
            get { return _env; }
        }

        /// <summary>
        /// The current credentials and metadata for connecting with the current Azure cloud instance.
        /// </summary>
        public PSAzureContext Context { get; set; }

        public override string ToString()
        {
            return Context != null ? Context.ToString() : null;
        }
    }
}
