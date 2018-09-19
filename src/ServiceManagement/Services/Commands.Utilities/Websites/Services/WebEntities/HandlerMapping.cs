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

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class HandlerMapping
    {
        /// <summary>
        /// Requests with this extension will be handled using the specified FastCGI application.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Extension { get; set; }

        /// <summary>
        /// The path to the FastCGI application.
        /// </summary>
        // TODO: Relative or Absolute?
        [DataMember(IsRequired = true)]
        public string ScriptProcessor { get; set; }

        /// <summary>
        /// Command-line arguments to be passed to the script processor.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Arguments { get; set; }
    }
}
