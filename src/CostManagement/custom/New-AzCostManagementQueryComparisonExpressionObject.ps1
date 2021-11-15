
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for QueryComparisonExpression
.Description
Create a in-memory object for QueryComparisonExpression

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryComparisonExpression
.Link
https://docs.microsoft.com/en-us/powershell/module/az.CostManagement/new-AzCostManagementQueryComparisonExpressionObject
#>
function New-AzCostManagementQueryComparisonExpressionObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryComparisonExpression')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory, HelpMessage="The name of the column to use in comparison.")]
        [string]
        $Name,
        [Parameter(Mandatory, HelpMessage="The operator to use for comparison.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.OperatorType]
        $Operator,
        [Parameter(Mandatory, HelpMessage="Array of values to use for comparison.")]
        [string[]]
        $Value
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryComparisonExpression]::New()

        $Object.Name = $Name
        # Description: The type of the Operator is enum,but it only contains one value,so the parameter is not exposed now.
        # $Object.Operator = $Operator
        $Object.Value = $Value
        return $Object
    }
}

