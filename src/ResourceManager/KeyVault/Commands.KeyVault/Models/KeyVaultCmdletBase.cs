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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyVaultCmdletBase : AzureRMCmdlet
    {
        internal IKeyVaultDataServiceClient DataServiceClient
        {
            get
            {
                if (dataServiceClient == null)
                {
                    this.dataServiceClient = new KeyVaultDataServiceClient(
                        AzureSession.Instance.AuthenticationFactory,
                        DefaultContext);
                }

                return this.dataServiceClient;
            }
            set
            {
                this.dataServiceClient = value;
            }
        }


        private IKeyVaultDataServiceClient dataServiceClient;

        /// <summary>
        /// Utility function that will continually iterate over the updated KeyVaultObjectFilterOptions until the options
        /// NextLink is null, and writes all the retrieved objects.
        /// </summary>
        /// <typeparam name="TObject">The object type to write.</typeparam>
        /// <param name="options">The KeyVaultObjectFilterOptions</param>
        /// <param name="getObjects">Function that takes the options and returns a list of objects.</param>
        protected void GetAndWriteObjects<TObject>(KeyVaultObjectFilterOptions options, Func<KeyVaultObjectFilterOptions, IEnumerable<TObject>> getObjects)
        {
            do
            {
                var pageResults = getObjects(options);
                WriteObject(pageResults, true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }
    }
}
