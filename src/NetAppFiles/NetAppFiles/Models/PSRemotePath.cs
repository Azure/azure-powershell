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

using Microsoft.Azure.Management.NetApp.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// The full path to a volume that is to be migrated into ANF. Required for
    /// Migration volumes
    /// </summary>
    public class PSRemotePath
    {
        /// <summary>
        /// Gets or sets the Path to a ONTAP Host
        /// </summary>        
        public string ExternalHostName { get; set; }

        /// <summary>
        /// Gets or sets the name of a server on the ONTAP Host
        /// </summary>        
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of a volume on the server
        /// </summary>        
        public string VolumeName { get; set; }

    }
}
