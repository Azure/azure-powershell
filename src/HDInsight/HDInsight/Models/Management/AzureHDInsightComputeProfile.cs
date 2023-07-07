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
using System.Linq;
using System.Management.Automation;
using Azure.ResourceManager.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightComputeProfile
    {
        public AzureHDInsightComputeProfile() { }

        public AzureHDInsightComputeProfile(IList<AzureHDInsightRole> roles = null)
        {
            Roles = roles;
        }

        public AzureHDInsightComputeProfile(IList<HDInsightClusterRole> roles)
        {
            Roles = roles?.Select(role => new AzureHDInsightRole(role)).ToList();
        }

        public IList<AzureHDInsightRole> Roles { get; set; }
    }
}
