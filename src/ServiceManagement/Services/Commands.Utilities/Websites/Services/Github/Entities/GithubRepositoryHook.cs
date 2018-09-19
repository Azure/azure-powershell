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
    public class GithubRepositoryHookConfig
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "insure_ssl")]
        public string InsecureSsl { get; set; }

        [DataMember(Name = "content_type")]
        public string ContentType { get; set; }
    }

    [DataContract]
    public class GithubRepositoryHook
    {
        [DataMember(Name = "url", IsRequired = false, EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "updated_at", IsRequired = false, EmitDefaultValue = false)]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "events", IsRequired = false, EmitDefaultValue = false)]
        public IList<string> Events { get; set; }

        [DataMember(Name = "active", IsRequired = false, EmitDefaultValue = false)]
        public bool Active { get; set; }

        [DataMember(Name = "config", IsRequired = false, EmitDefaultValue = false)]
        public GithubRepositoryHookConfig Config { get; set; }

        [DataMember(Name = "id", IsRequired = false, EmitDefaultValue = false)]
        public string Id { get; set; }
    }
}
