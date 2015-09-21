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

using System.Diagnostics.CodeAnalysis;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    /// <summary>
    /// Represents resource / vault credentials.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public class ResourceCredentials
    {
        /// <summary>
        /// Gets or sets the name of the resource name.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the cloud service name.
        /// </summary>
        public string CloudServiceName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ResourceNameSpace { get; set; }

        public string ResourceType { get; set; }

        public string StampId { get; set; }

        public string ResourceId { get; set; }

        public string BackendStampId { get; set; }

        public string ResourceState { get; set; }
    }
}
