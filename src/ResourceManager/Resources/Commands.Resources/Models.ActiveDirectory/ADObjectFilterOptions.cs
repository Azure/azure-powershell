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


namespace Microsoft.Azure.Commands.Resources.Models.ActiveDirectory
{
    public class ADObjectFilterOptions
    {
        public string SearchString { get; set; }

        public string Mail { get; set; }

        public string UPN { get; set; }

        public string SPN { get; set; }

        public string Id { get; set; }

        public bool Paging { get; set; }

        /// <summary>
        /// Used internally to track the paging for the listing, do not change manually.
        /// </summary>
        public string NextLink { get; set; }

        public bool HasFilter { get { return !string.IsNullOrEmpty(ActiveFilter); } }

        public string ActiveFilter
        {
            get
            {
                if (!string.IsNullOrEmpty(Id))
                    return Id;
                else if (!string.IsNullOrEmpty(UPN))
                    return UPN;
                else if (!string.IsNullOrEmpty(SPN))
                    return SPN;
                else if (!string.IsNullOrEmpty(Mail))
                    return Mail;
                else if (!string.IsNullOrEmpty(SearchString))
                    return SearchString;
                else
                    return null;
            }
        }
    }
}