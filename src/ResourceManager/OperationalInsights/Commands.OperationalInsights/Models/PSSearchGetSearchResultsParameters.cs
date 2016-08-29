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

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSSearchGetSearchResultsParameters : OperationalInsightsParametersBase
    {
        public long Top { get; set; }
        public long Skip { get; set; }
        public PSHighlight Highlight { get; set; }
        public bool IncludeArchive { get; set; }
        public string Query { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
