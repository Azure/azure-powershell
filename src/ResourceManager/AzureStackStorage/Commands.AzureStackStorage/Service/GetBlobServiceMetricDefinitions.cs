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

using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Gets the properties of the metric definitions exposed by the Blob service.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminBlobServiceMetricDefinition)]
    [Alias("Get-ACSBlobServiceMetricDefinition")]
    public sealed class GetBlobServiceMetricDefinitions : AdminMetricDefinitionCmdlet
    {
        protected override MetricDefinitionsResult GetMetricDefinitionsResult(string filter)
        {
            return Client.BlobService.GetMetricDefinitions(ResourceGroupName, FarmName, filter);
        }
    }
}