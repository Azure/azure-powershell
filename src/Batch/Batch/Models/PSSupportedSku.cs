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

using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    /// <summary>
    /// The quotas of a subscription in the Batch Service.
    /// </summary>
    public class PSSupportedSku
    {
        public PSSupportedSku(string name, string familyName, IList<PSSkuCapability> capabilities)
        {
            Name = name;
            FamilyName = familyName;
            Capabilities = capabilities;
        }

        /// <summary>
        /// The number of the SKU.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The family name of the SKU.
        /// </summary>
        public string FamilyName { get; private set; }

        /// <summary>
        /// Gets a collection of capabilities which this SKU supports.
        /// </summary>
        public IList<PSSkuCapability> Capabilities { get; private set; }
    }
}
