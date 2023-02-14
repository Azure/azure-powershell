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

using Microsoft.Azure.Management.ContainerRegistry.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSImportSource
    {
        public PSImportSource(string sourceImage, string resourceId = default(string), string registryUri = default(string), PSImportSourceCredentials credentials = default(PSImportSourceCredentials))
        {
            ResourceId = resourceId;
            RegistryUri = registryUri;
            Credentials = credentials;
            SourceImage = sourceImage;
            Validate();
        }

        public string ResourceId { get; set; }

        public string RegistryUri { get; set; }

        public PSImportSourceCredentials Credentials { get; set; }

        public string SourceImage { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="PSArgumentNullException">
        /// Thrown if validation fails
        /// </exception>
        private void Validate()
        {
            if (SourceImage == null)
            {
                throw new PSArgumentNullException("SourceImage for Import Source cannot be null");
            }
        }

        public ImportSource GetImportSource()
        {
            return new ImportSource
            {
                ResourceId = this.ResourceId,
                RegistryUri = this.RegistryUri,
                Credentials = this.Credentials?.GetImportSourceCredentials(),
                SourceImage = this.SourceImage
            };
        }
    }
}
