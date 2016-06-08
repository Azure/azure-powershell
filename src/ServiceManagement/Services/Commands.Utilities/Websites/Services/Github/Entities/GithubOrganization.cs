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

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github.Entities
{
    [DataContract]
    public class GithubOrganization
    {
        [DataMember(Name = "url", IsRequired = false)]
        public string Url { get; set; }

        [DataMember(Name = "login", IsRequired = false)]
        public string Login { get; set; }

        [DataMember(Name = "avatar_url", IsRequired = false)]
        public string AvatarUrl { get; set; }

        [DataMember(Name = "gravatar_id", IsRequired = false)]
        public string GravatarId { get; set; }

        [DataMember(Name = "id", IsRequired = false)]
        public string Id { get; set; }
    }
}
