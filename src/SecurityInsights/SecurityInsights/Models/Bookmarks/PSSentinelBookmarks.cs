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
using Microsoft.Azure.Management.SecurityInsights.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks
{
    public class PSSentinelBookmark
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime? Created { get; set; }

        public PSSentinelBookmarkUserInfo CreatedBy { get; set; }

        public string DisplayName { get; set; }

        public PSSentinelBookmarkIncidentInfo IncidentInfo { get; set; }

        public IList<string> Labels { get; set; }

        public string Notes { get; set; }

        public string Query { get; set; }

        public string QueryResult { get; set; }

        public DateTime? Updated { get; set; }

        public PSSentinelBookmarkUserInfo UpdatedBy { get; set; }

    }
}
