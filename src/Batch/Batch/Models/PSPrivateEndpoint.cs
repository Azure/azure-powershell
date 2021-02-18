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
using System.Text;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class PSPrivateEndpoint
    {
        /// <summary>
        /// Gets the ARM resource identifier of the private endpoint. This is
        /// of the form
        /// /subscriptions/{subscription}/resourceGroups/{group}/providers/Microsoft.Network/privateEndpoints/{privateEndpoint}.
        /// </summary>
        public string Id { get; }

        public PSPrivateEndpoint(string id)
        {
            Id = id;
        }

        internal static PSPrivateEndpoint CreateFromPrivateEndpoint(PrivateEndpoint privateEndpoint)
        {
            if (privateEndpoint == null)
            {
                return null;
            }

            return new PSPrivateEndpoint(privateEndpoint.Id);
        }
    }
}
