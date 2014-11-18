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
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Management.MediaServices.Models;
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.Utilities.MediaServices.Services.Entities
{
    [DataContract(Namespace = MediaServicesUriElements.ServiceNamespace, Name = "ServiceResource")]
    [JsonObject(Title = "ServiceResource")]
    public class MediaServiceAccount
    {

        public MediaServiceAccount(MediaServicesAccountListResponse.MediaServiceAccount response)
        {
            this.AccountId = Guid.Parse(response.AccountId);
            this.Name = response.Name;
            this.State = response.State;
        }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public Guid AccountId { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string State { get; set; }
    }
}