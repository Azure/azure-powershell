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
    using System.Collections;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public abstract class PSResource
    {
        protected PSResource()
        {
        }

        protected PSResource(TrackedResource trackedResource)
        {
            this.Name = trackedResource.Name;
            this.Type = trackedResource.Type;
            this.Id = trackedResource.Id;
            this.Location = trackedResource.Location;
            this.Tags = TagsConversionHelper.CreateTagHashtable(trackedResource.Tags);
        }

		/// <summary>
		/// Gets or sets the resource name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the resource type.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the resource location.
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the resource Id.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the resource tags.
		/// </summary>
		public Hashtable Tags { get; set; }
    }
}
