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
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github.Entities
{
    [DataContract]
    public class GithubPermissions
    {
        [DataMember(Name = "admin")]
        public bool Admin { get; set; }

        [DataMember(Name = "pull")]
        public bool Pull { get; set; }

        [DataMember(Name = "push")]
        public bool Push { get; set; }
    }

    [DataContract]
    public class GithubRepository : IComparable
    {
        [DataMember(Name = "clone_url", IsRequired = false)]
        public string CloneUrl { get; set; }

        [DataMember(Name = "forks_count", IsRequired = false)]
        public int ForksCount { get; set; }

        [DataMember(Name = "url", IsRequired = false)]
        public string Url { get; set; }

        [DataMember(Name = "watchers", IsRequired = false)]
        public int Watchers { get; set; }

        [DataMember(Name = "has_issues", IsRequired = false)]
        public bool HasIssues { get; set; }

        [DataMember(Name = "open_issues_count", IsRequired = false)]
        public int OpenIssuesCount { get; set; }
        
        [DataMember(Name = "owner", IsRequired = false)]
        public GithubOrganization Owner { get; set; }
        
        [DataMember(Name = "full_name", IsRequired = false)]
        public string FullName { get; set; }

        [DataMember(Name = "has_wiki", IsRequired = false)]
        public bool HasWiki { get; set; }

        [DataMember(Name = "mirror_url", IsRequired = false)]
        public string MirrorUrl { get; set; }

        [DataMember(Name = "permissions", IsRequired = false)]
        public GithubPermissions Permissions { get; set; }

        [DataMember(Name = "created_at", IsRequired = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "homepage", IsRequired = false)]
        public string Homepage { get; set; }

        [DataMember(Name = "svn_url", IsRequired = false)]
        public string SvnUrl { get; set; }

        [DataMember(Name = "open_issues", IsRequired = false)]
        public string OpenIssues { get; set; }

        [DataMember(Name = "pushed_at", IsRequired = false)]
        public string PushedAt { get; set; }

        [DataMember(Name = "forks", IsRequired = false)]
        public int Forks { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string Description { get; set; }

        [DataMember(Name = "ssh_url", IsRequired = false)]
        public string SshUrl { get; set; }

        [DataMember(Name = "size", IsRequired = false)]
        public int Size { get; set; }

        [DataMember(Name = "fork", IsRequired = false)]
        public bool Fork { get; set; }

        [DataMember(Name = "updated_at", IsRequired = false)]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "git_url", IsRequired = false)]
        public string GitUrl { get; set; }

        [DataMember(Name = "name", IsRequired = false)]
        public string Name { get; set; }

        [DataMember(Name = "has_downloads", IsRequired = false)]
        public string HasDownloads { get; set; }

        [DataMember(Name = "private", IsRequired = false)]
        public bool Private { get; set; }

        [DataMember(Name = "id", IsRequired = false)]
        public string Id { get; set; }

        [DataMember(Name = "watchers_count", IsRequired = false)]
        public string WatchersCount { get; set; }

        [DataMember(Name = "language", IsRequired = false)]
        public string Language { get; set; }

        [DataMember(Name = "html_url", IsRequired = false)]
        public string HtmlUrl { get; set; }

        public int CompareTo(object obj)
        {
            return string.Compare(Name, ((GithubRepository) obj).Name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
