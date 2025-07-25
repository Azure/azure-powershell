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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

#if NETSTANDARD
namespace Microsoft.Azure.Commands.Profile.Models.Core
#else
namespace Microsoft.Azure.Commands.Profile.Models
#endif
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
        public static implicit operator PSAzureProfile(AzureRmProfile profile)
        {
            if (profile == null)
            {
                return null;
            }

            var result = new PSAzureProfile
            {
                Context = new PSAzureContext(profile.DefaultContext)
            };

            profile.EnvironmentTable
                .ForEach((e) => result.Environments[e.Key] = new PSAzureEnvironment(e.Value));
            return result;
        }

        /// <summary>
        /// Convert between implementations of AzureProfile.
        /// </summary>
        /// <param name="profile">The profile to convert.</param>
        /// <returns>The converted profile.</returns>
        public static implicit operator AzureRmProfile(PSAzureProfile profile)
        {
            if (profile == null)
            {
                return null;
            }

            var result = new AzureRmProfile
            {
                DefaultContext = profile.Context
            };
            profile.Environments.ForEach((e) => result.EnvironmentTable[e.Key] = (IAzureEnvironment)e.Value);
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
        [Ps1Xml(Label = "Subscription name", Target = ViewControl.Table, ScriptBlock = "if($null -ne $_.Context.Subscription.Name){$_.Context.Subscription.Name}else{$_.Context.Subscription.Id}", Position = 0)]
        [Ps1Xml(Label = "Tenant", Target = ViewControl.Table, ScriptBlock = "if($null -ne $_.Context.Tenant.Name){$_.Context.Tenant.Name}else{$_.Context.Tenant.Id}", Position = 1)]
        public PSAzureContext Context { get; set; }

        public override string ToString()
        {
            return Context != null ? Context.ToString() : null;
        }
    }
}
