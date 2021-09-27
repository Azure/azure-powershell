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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedIdentitySqlControlSettingsModel : PSSynapseResource
    {
        public PSManagedIdentitySqlControlSettingsModel(ManagedIdentitySqlControlSettingsModel model)
            :base(model?.Id, model?.Name, model?.Type)
        {
            this.DesiredState = model?.GrantSqlControlToManagedIdentity?.DesiredState;
            this.ActualState = model?.GrantSqlControlToManagedIdentity?.ActualState;
        }

        public string DesiredState { get; set; }

        public string ActualState { get; }
    }
}
