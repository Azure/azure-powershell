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

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSArtifactSource : PSResource
    {
        public PSArtifactSource() : base()
        {
        }

        public PSArtifactSource(string resourceGroupName, ArtifactSource artifactSource) : base(artifactSource)
        {
            this.ResourceGroupName = resourceGroupName;
            this.SourceType = artifactSource.SourceType;
            this.ArtifactRoot = artifactSource.ArtifactRoot;
            this.Authentication = new PSSasAuthentication((SasAuthentication)artifactSource.Authentication);
        }

        /// <summary>
        /// Gets or sets the resource group to which the service unit belongs.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the artifact source type.
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// Gets or sets the root folder under which the artifacts are to be found.
        /// </summary>
        public string ArtifactRoot { get; set; }

        /// <summary>
        /// Gets or sets the authentication information to access the artifact store.
        /// </summary>
        public PSAuthentication Authentication { get; set; }

        internal ArtifactSource ToSdkType()
        {
            var sasAuthentication = new SasAuthentication(((PSSasAuthentication)this.Authentication)?.SasUri);
            return new ArtifactSource(
                this.Location, 
                this.SourceType, 
                sasAuthentication, 
                this.Name, 
                this.Type, 
                this.Id, 
                TagsConversionHelper.CreateTagDictionary(this.Tags, validate: true),
                this.ArtifactRoot);
        }
    }
}
