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

using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebookKernelSpec
    {
        public PSNotebookKernelSpec(NotebookKernelSpec notebookKernelSpec)
        {
            this.Name = notebookKernelSpec?.Name;
            this.DisplayName = notebookKernelSpec?.DisplayName;
            var propertiesEnum = notebookKernelSpec?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
