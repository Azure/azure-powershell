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
// ---------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github.Entities
{
    [DataContract]
    public class GithubApp
    {
        [DataMember(Name = "url", IsRequired = false)]
        public string Url { get; set; }

        [DataMember(Name = "name", IsRequired = false)]
        public string Name { get; set; }
    }

    [DataContract]
    public class GithubAuthorization
    {
        [DataMember(Name = "id", IsRequired = false)]
        public string Id { get; set; }

        [DataMember(Name = "url", IsRequired = false)]
        public string Url { get; set; }

        [DataMember(Name = "scopes", IsRequired = false)]
        public IList<string> Scopes { get; set; }

        [DataMember(Name = "token", IsRequired = false)]
        public string Token { get; set; }

        [DataMember(Name = "app", IsRequired = false)]
        public GithubApp App { get; set; }

        [DataMember(Name = "note", IsRequired = false)]
        public string Note { get; set; }

        [DataMember(Name = "note_url", IsRequired = false)]
        public string NoteUrl { get; set; }

        [DataMember(Name = "created_at", IsRequired = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at", IsRequired = false)]
        public string UpdatedAt { get; set; }
    }
}
