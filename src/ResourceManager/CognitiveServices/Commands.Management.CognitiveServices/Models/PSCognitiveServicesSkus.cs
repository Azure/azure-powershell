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

using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using CognitiveServicesModels = Microsoft.Azure.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices.Models
{
    public class PSCognitiveServicesSkus
    {
        public PSCognitiveServicesSkus(CognitiveServicesModels.CognitiveServicesAccountEnumerateSkusResult enumerateSkusResult)
        {
            this.List = enumerateSkusResult.Value.Select(x => x.Sku.Name.ToString());
        }

        public IEnumerable<string> List { get; private set; }
    }
}
