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

namespace Microsoft.Azure.Commands.AzureStack
{
    using System;
    using Microsoft.Azure.Commands.AzureStack.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common;

    /// <summary>
    /// The base class for all Microsoft Azure Redis Cache Management Cmdlets
    /// </summary>
    public abstract class AzureStackCmdletBase : AzureRMCmdlet
    {
        private AzureStackClient azsClient;

        public AzureStackClient AzsClient
        {
            get
            {
                if (azsClient == null)
                {
                    azsClient = new AzureStackClient(DefaultProfile.DefaultContext);
                }
                return azsClient;
            }

            set
            {
                azsClient = value;
            }
        }

        protected static void ValidateResourceGroupName(string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName) || resourceGroupName.Contains("/"))
            {
                throw new ArgumentException(Resources.InvalidResourceGroupName);
            }
        }

        protected static void ValidateResourceName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains("/") || name.Contains("."))
            {
                throw new ArgumentException(Resources.InvalidRegistrationName);
            }
        }
    }
}