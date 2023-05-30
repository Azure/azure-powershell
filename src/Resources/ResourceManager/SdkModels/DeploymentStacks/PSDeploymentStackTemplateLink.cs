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

using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentStackTemplateLink
    {
        public string Uri { get; set; }

        public string Id { get; set; }

        public string RelativePath { get; set; }

        public string QueryString { get; set; }

        public string ContentVersion { get; set; }

        internal PSDeploymentStackTemplateLink(DeploymentStacksTemplateLink link)
        {
            Uri = link.Uri;
            Id = link.Id;
            RelativePath = link.RelativePath;
            QueryString = link.QueryString;
            ContentVersion = link.ContentVersion; 
        }
    }
}
