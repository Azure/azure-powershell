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
namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    using Microsoft.Azure.Management.NetApp.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Volume group properties
    /// </summary>
    public class PSNetAppFilesVolumeGroupMetaData
    {
        /// <summary>
        /// Gets or sets group Description
        /// </summary>
        public string GroupDescription { get; set; }

        /// <summary>
        /// Gets or sets application Type. Possible values include: 'SAP-HANA'
        /// </summary>
        public string ApplicationType { get; set; }

        /// <summary>
        /// Gets or sets application specific identifier
        /// </summary>        
        public string ApplicationIdentifier { get; set; }

        /// <summary>
        /// Gets or sets global volume placement rules
        /// </summary>
        /// <remarks>
        /// Application specific placement rules for the volume group
        /// </remarks>        
        public IList<PlacementKeyValuePairs> GlobalPlacementRules { get; set; }

        /// <summary>
        /// Gets or sets application specific identifier of deployment rules
        /// for the volume group
        /// </summary>        
        public string DeploymentSpecId { get; set; }

        /// <summary>
        /// Gets number of volumes in volume group
        /// </summary>
        public long? VolumesCount { get; set; }
    }
}
