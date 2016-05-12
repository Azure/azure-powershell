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

using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSSearchGetSearchResultsResponse
    {
        public PSSearchGetSearchResultsResponse()
        {
        }

        public PSSearchGetSearchResultsResponse(SearchGetSearchResultsResponse response)
        {
            if (response != null)
            {
                this.Id = response.Id;
                this.Metadata = new PSSearchMetadata(response.Metadata);
                this.Value = response.Value;
                this.Error = new PSSearchError(response.Error);
            }
        }
        public string Id { get; set; }
        public PSSearchMetadata Metadata { get; set; }
        public IEnumerable<Object> Value { get; set; }
        public PSSearchError Error { get; set; }
    }
}
