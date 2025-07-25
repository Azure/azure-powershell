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

using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Newtonsoft.Json;
using RestAzureNS = Microsoft.Rest.Azure;
using RestAzureODataNS = Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        
        /// <summary>
        /// Returns whether Archive smart tiering is enabled on the current subscription
        /// </summary>        
        /// <returns>true/false</returns>
        public bool IsArchiveFeatureSupported()
        {
            return FeatureAdapter.Client.Features.GetWithHttpMessagesAsync("Microsoft.RecoveryServices", "ArchiveV1SmartTiering").Result.Body.Properties.State.ToLower() == "registered";
        }
    }
}