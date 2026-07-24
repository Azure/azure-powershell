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

using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSTemplateSpecArtifact
    {
        public string Path { get; set; }

        protected PSTemplateSpecArtifact(LinkedTemplateArtifact artifact)
        {
            this.Path = artifact.Path;
        }
    }

    public class PSTemplateSpecTemplateArtifact : PSTemplateSpecArtifact
    {
        public string Template { get; set; }

        protected PSTemplateSpecTemplateArtifact(
            LinkedTemplateArtifact artifact
            ) : base(artifact)
        {
            // Note: Cast is redundant, but present for clarity reasons:
            this.Template = ((JToken)artifact.Template).ToString();
        }

        internal static PSTemplateSpecTemplateArtifact FromAzureSDKTemplateSpecTemplateArtifact(
            LinkedTemplateArtifact artifact)
        {
            return artifact != null 
                ? new PSTemplateSpecTemplateArtifact(artifact)
                : null;
        }
    }
}
