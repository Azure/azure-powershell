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

using Microsoft.Azure.ContainerRegistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSAcrManifest
    {
        public PSAcrManifest(string registry = default(string), string imageName = default(string), IList<PSManifestAttributeBase> manifestsAttributes = default(IList<PSManifestAttributeBase>))
        {
            Registry = registry;
            ImageName = imageName;
            ManifestsAttributes = manifestsAttributes;
        }

        public PSAcrManifest(AcrManifests manifest)
        {
            Registry = manifest?.Registry;
            ImageName = manifest?.Registry;
            if (manifest != null && manifest.ManifestsAttributes != null)
            {
                ManifestsAttributes = manifest.ManifestsAttributes.Select(x => new PSManifestAttributeBase(x)).ToList();
            }
        }

        public string Registry { get; set; }

        public string ImageName { get; set; }

        public IList<PSManifestAttributeBase> ManifestsAttributes { get; set; }
    }
}
