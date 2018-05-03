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
using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public class PSProject
    {
        private Project project;
        private DmsResourceIdentifier ids;

        public PSProject(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException("project");
            }

            this.project = project;
            this.ids = new DmsResourceIdentifier(project.Id);
            this.ResourceGroupName = ids.ResourceGroupName;
            this.ServiceName = ids.ServiceName;
        }

        public Project Project => project;

        public string ResourceGroupName { get; private set; }

        public string ServiceName { get; private set; }

        public string Location
        {
            get
            {
                return project.Location;
            }
        }

        public string Name
        {
            get
            {
                return Project.Name;
            }
        }
    }
}
