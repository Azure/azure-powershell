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

namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    /// <summary>
    /// The generated ToString() returns the full JSON payload, so the Option list of
    /// Get-AzAIInfraOptimizationVMSkuRecommendation output renders as a large JSON block.
    /// Return the virtual machine size instead; ToJsonString() still returns the JSON.
    /// </summary>
    public partial class RecommendVMSkuOption
    {
        partial void OverrideToString(ref string stringResult, ref bool returnNow)
        {
            if (!string.IsNullOrEmpty(VMSize))
            {
                stringResult = VMSize;
                returnNow = true;
            }
        }
    }
}
