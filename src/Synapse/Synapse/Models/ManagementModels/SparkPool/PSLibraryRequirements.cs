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

using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLibraryRequirements
    {
        public PSLibraryRequirements(LibraryRequirements libraryRequirements)
        {
            this.Time = libraryRequirements?.Time;
            this.Content = libraryRequirements?.Content;
            this.Filename = libraryRequirements?.Filename;
        }

        /// <summary>
        /// Gets the last update time of the library requirements file.
        /// </summary>
        public System.DateTime? Time { get; set; }

        /// <summary>
        /// Gets the library requirements.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets the filename of the library requirements file.
        /// </summary>
        public string Filename { get; set; }
    }
}