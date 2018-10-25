﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure File Share specific container class.
    /// </summary>
    public class AzureFileShareContainer : AzureContainer
    {
        /// <summary>
        /// Constructor. Takes the service client object representing the container 
        /// and converts it in to the PS container model
        /// </summary>
        /// <param name="protectionContainerResource">Service client object representing the container</param>
        public AzureFileShareContainer(ProtectionContainerResource protectionContainerResource)
            : base(protectionContainerResource) { }
    }
}
