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
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSServiceUnit
    {
        public PSServiceUnit(ServiceUnit serviceUnit)
        {
            this.Name = serviceUnit.Name;
            this.TargetResourceGroup = serviceUnit.TargetResourceGroup;
            this.DeploymentMode = serviceUnit.DeploymentMode;
            this.ParametersArtifactSourceRelativePath = serviceUnit.Artifacts?.ParametersArtifactSourceRelativePath;
            this.ParametersUri = serviceUnit.Artifacts?.ParametersUri;
            this.TemplateArtifactSourceRelativePath = serviceUnit.Artifacts?.TemplateArtifactSourceRelativePath;
            this.TemplateUri = serviceUnit.Artifacts?.TemplateUri;
            this.Steps = serviceUnit.Steps?.Select(s => new PSRolloutStep(s)).ToList();
        }
		/// <summary>
		/// Gets or sets the Azure Resource Group to which the resources in the
		/// service unit belong to.
		/// </summary>
		public string TargetResourceGroup
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets describes the type of ARM deployment to be performed
		/// on the resource. Possible values include: 'Complete', 'Incremental'
		/// </summary>
		public DeploymentMode DeploymentMode
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the full URI of the ARM template file with the SAS
		/// token.
		/// </summary>
		public string TemplateUri
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the full URI of the ARM parameters file with the SAS
		/// token.
		/// </summary>
		public string ParametersUri
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the path to the ARM template file relative to the
		/// artifact store.
		/// </summary>
		public string TemplateArtifactSourceRelativePath
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the path to the ARM parameters file relative to the
		/// artifact store.
		/// </summary>
		public string ParametersArtifactSourceRelativePath
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets name of the service unit.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets detailed step information, if present.
		/// </summary>
		public IList<PSRolloutStep> Steps
		{
			get;
			set;
		}

    }
}
