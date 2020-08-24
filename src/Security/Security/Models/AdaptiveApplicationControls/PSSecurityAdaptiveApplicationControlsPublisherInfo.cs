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

namespace Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveApplicationControls
{
    public class PSSecurityAdaptiveApplicationControlsPublisherInfo
    {
        /// <summary>
        /// The Subject field of the x.509 certificate used to sign the code,
        /// using the following fields - O = Organization, L = Locality, S = State or Province, and C = Country
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// The product name taken from the file's version resource.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The "OriginalName" field taken from the file's version resource.
        /// </summary>
        public string BinaryName { get; set; }

        /// <summary>
        /// The binary file version taken from the file's version resource.
        /// </summary>
        public string Version { get; set; }
    }
}
