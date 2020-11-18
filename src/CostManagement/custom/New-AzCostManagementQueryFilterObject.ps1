
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
Create a in-memory object for QueryFilter. On a QueryFilter one and only one of and/or/not/dimension/tag can be set.
.Description
Create a in-memory object for QueryFilter. On a QueryFilter one and only one of and/or/not/dimension/tag can be set.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryFilter
.Link
https://docs.microsoft.com/en-us/powershell/module/az.CostManagement/new-AzCostManagementQueryFilterObject
#>
function New-AzCostManagementQueryFilterObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryFilter')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="The logical `"AND`" expression. Must have at least 2 items.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter[]]
        $And,
        [Parameter(HelpMessage="Has comparison expression for a dimension.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryComparisonExpression]
        $Dimension,
        [Parameter(HelpMessage="The logical `"NOT`" expression.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter]
        $Not,
        [Parameter(HelpMessage="The logical `"OR`" expression. Must have at least 2 items.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter[]]
        $Or,
        [Parameter(HelpMessage="Has comparison expression for a tag.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryComparisonExpression]
        $Tag
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryFilter]::New()

        $Object.And = $And
        $Object.Dimension = $Dimension
        $Object.Not = $Not
        $Object.Or = $Or
        $Object.Tag = $Tag
        return $Object
    }
}

