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
using System.Collections.Generic;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSWorkspace
    {
        private readonly Workspace workspace;

        public PSWorkspace()
        {
            workspace = new Workspace();
        }

        public PSWorkspace(Workspace workspace)
        {
            if (workspace == null)
            {
                throw new ArgumentNullException("workspace");
            }

            this.workspace = workspace;
        }

        public string Name
        {
            get
            {
                return workspace.Name;
            }
            set
            {
                workspace.Name = value;
            }
        }

        public string ResourceGroupName { get; set; }

        public string Location
        {
            get
            {
                return workspace.Location;
            }
            set
            {
                workspace.Location = value;
            }
        }

        public IDictionary<string, string> Tags
        {
            get
            {
                return workspace.Tags;
            }
            set
            {
                workspace.Tags = value;
            }
        }

        public WorkspaceProperties Properties
        {
            get
            {
                return workspace.Properties;
            }
            set
            {
                workspace.Properties = value;
            }
        }
    }
}
