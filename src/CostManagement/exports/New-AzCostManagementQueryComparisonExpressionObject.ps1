
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
Create a in-memory object for QueryComparisonExpression
.Description
Create a in-memory object for QueryComparisonExpression
.Example
PS C:\> New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Value @('East US', 'West Europe')

Name             Operator Value
----             -------- -----
ResourceLocation In       {East US, West Europe}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryComparisonExpression
.Link
https://docs.microsoft.com/en-us/powershell/module/az.CostManagement/new-AzCostManagementQueryComparisonExpressionObject
#>
function New-AzCostManagementQueryComparisonExpressionObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryComparisonExpression])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The name of the column to use in comparison.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.OperatorType]
    # The operator to use for comparison.
    ${Operator},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String[]]
    # Array of values to use for comparison.
    ${Value}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.CostManagement.custom\New-AzCostManagementQueryComparisonExpressionObject';
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
