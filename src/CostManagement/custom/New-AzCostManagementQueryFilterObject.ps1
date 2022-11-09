
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
Create a in-memory object for QueryFilter
.Description
Create a in-memory object for QueryFilter

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.QueryFilter
.Link
https://docs.microsoft.com/powershell/module/az.CostManagement/new-AzCostManagementQueryFilterObject
#>
function New-AzCostManagementQueryFilterObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.QueryFilter')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="The logical `"AND`" expression. Must have at least 2 items.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryFilter[]]
        $And,
        [Parameter(HelpMessage="Has comparison expression for a dimensions.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryComparisonExpression]
        $Dimensions,
        [Parameter(HelpMessage="The logical `"NOT`" expression.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryFilter]
        $Not,
        [Parameter(HelpMessage="The logical `"OR`" expression. Must have at least 2 items.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryFilter[]]
        $Or,
        [Parameter(HelpMessage="Has comparison expression for a tag.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryComparisonExpression]
        $Tag
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.QueryFilter]::New()

        $Object.And = $And
        $Object.Dimensions = $Dimensions
        $Object.Not = $Not
        $Object.Or = $Or
        $Object.Tag = $Tag
        return $Object
    }
}

