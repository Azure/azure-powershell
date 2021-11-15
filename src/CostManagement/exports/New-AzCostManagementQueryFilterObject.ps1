
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for QueryFilter
.Description
Create a in-memory object for QueryFilter
.Example
PS C:\> $orDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Value @('East US', 'West Europe')
PS C:\> $orTag = New-AzCostManagementQueryComparisonExpressionObject -Name 'Environment' -Value @('UAT', 'Prod')
PS C:\> New-AzCostManagementQueryFilterObject -or @((New-AzCostManagementQueryFilterObject -Dimension $orDimension), (New-AzCostManagementQueryFilterObject -Tag $orTag))

And       :
Dimension : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryComparisonExpression
Not       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryFilter
Or        : {Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryFilter, Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryFilter}
Tag       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryComparisonExpression

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryFilter
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

AND <IQueryFilter[]>: The logical "AND" expression. Must have at least 2 items.
  [And <IQueryFilter[]>]: The logical "AND" expression. Must have at least 2 items.
  [Dimensions <IQueryComparisonExpression>]: Has comparison expression for a dimension
    Name <String>: The name of the column to use in comparison.
    Value <String[]>: Array of values to use for comparison
  [Not <IQueryFilter>]: The logical "NOT" expression.
  [Or <IQueryFilter[]>]: The logical "OR" expression. Must have at least 2 items.
  [Tag <IQueryComparisonExpression>]: Has comparison expression for a tag

DIMENSIONS <IQueryComparisonExpression>: Has comparison expression for a dimensions.
  Name <String>: The name of the column to use in comparison.
  Value <String[]>: Array of values to use for comparison

NOT <IQueryFilter>: The logical "NOT" expression.
  [And <IQueryFilter[]>]: The logical "AND" expression. Must have at least 2 items.
  [Dimensions <IQueryComparisonExpression>]: Has comparison expression for a dimension
    Name <String>: The name of the column to use in comparison.
    Value <String[]>: Array of values to use for comparison
  [Not <IQueryFilter>]: The logical "NOT" expression.
  [Or <IQueryFilter[]>]: The logical "OR" expression. Must have at least 2 items.
  [Tag <IQueryComparisonExpression>]: Has comparison expression for a tag

OR <IQueryFilter[]>: The logical "OR" expression. Must have at least 2 items.
  [And <IQueryFilter[]>]: The logical "AND" expression. Must have at least 2 items.
  [Dimensions <IQueryComparisonExpression>]: Has comparison expression for a dimension
    Name <String>: The name of the column to use in comparison.
    Value <String[]>: Array of values to use for comparison
  [Not <IQueryFilter>]: The logical "NOT" expression.
  [Or <IQueryFilter[]>]: The logical "OR" expression. Must have at least 2 items.
  [Tag <IQueryComparisonExpression>]: Has comparison expression for a tag

TAG <IQueryComparisonExpression>: Has comparison expression for a tag.
  Name <String>: The name of the column to use in comparison.
  Value <String[]>: Array of values to use for comparison
.Link
https://docs.microsoft.com/en-us/powershell/module/az.CostManagement/new-AzCostManagementQueryFilterObject
#>
function New-AzCostManagementQueryFilterObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryFilter])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter[]]
    # The logical "AND" expression.
    # Must have at least 2 items.
    # To construct, see NOTES section for AND properties and create a hash table.
    ${And},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryComparisonExpression]
    # Has comparison expression for a dimensions.
    # To construct, see NOTES section for DIMENSIONS properties and create a hash table.
    ${Dimensions},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter]
    # The logical "NOT" expression.
    # To construct, see NOTES section for NOT properties and create a hash table.
    ${Not},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter[]]
    # The logical "OR" expression.
    # Must have at least 2 items.
    # To construct, see NOTES section for OR properties and create a hash table.
    ${Or},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryComparisonExpression]
    # Has comparison expression for a tag.
    # To construct, see NOTES section for TAG properties and create a hash table.
    ${Tag}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.CostManagement.custom\New-AzCostManagementQueryFilterObject';
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
