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

    public class PSService
    {
        public PSService(Service service)
        {
            this.TargetLocation = service.TargetLocation;
            this.TargetSubscriptionId = service.TargetSubscriptionId;
            this.Name = service.Name;
            this.ServiceUnits = service.ServiceUnits?.Select(su => new PSServiceUnit(su)).ToList();
        }

		/// <summary>
		/// Gets or sets the Azure location to which the resources in the
		/// service belong to.
		/// </summary>
		public string TargetLocation
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the subscription to which the resources in the service
		/// belong to.
		/// </summary>
		public string TargetSubscriptionId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets name of the service.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the detailed information about the units that make up
		/// the service.
		/// </summary>
		public IList<PSServiceUnit> ServiceUnits
		{
			get;
			set;
		}

    }
}
