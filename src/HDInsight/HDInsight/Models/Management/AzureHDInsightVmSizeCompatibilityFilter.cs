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

using Azure.ResourceManager.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightVmSizeCompatibilityFilter
    {
        public AzureHDInsightVmSizeCompatibilityFilter(HDInsightVmSizeCompatibilityFilterV2 vmSizeCompatibilityFilter)
        {
            this.FilterMode = vmSizeCompatibilityFilter?.FilterMode.ToString();
            this.Regions = vmSizeCompatibilityFilter?.Regions.ToList();
            this.ClusterFlavors = vmSizeCompatibilityFilter?.ClusterFlavors.ToList();
            this.NodeTypes = vmSizeCompatibilityFilter?.NodeTypes.ToList();
            this.ClusterVersions = vmSizeCompatibilityFilter?.ClusterVersions.ToList();
            this.Vmsizes = vmSizeCompatibilityFilter?.VmSizes.ToList();
        }
        public string FilterMode { get; set; }
        public IList<string> Regions { get; set; }
        public IList<string> ClusterFlavors { get; set; }
        public IList<string> NodeTypes { get; set; }
        public IList<string> ClusterVersions { get; set; }
        public IList<string> Vmsizes { get; set; }
    }
}
