
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
Create a in-memory object for FilteringTag
.Description
Create a in-memory object for FilteringTag
.Example
PS C:\> New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTag
.Link
https://docs.microsoft.com/powershell/module/az.Datadog/new-AzDatadogFilteringTagObject
#>
function New-AzDatadogFilteringTagObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.FilteringTag])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.TagAction]
    # Valid actions for a filtering tag.
    # Exclusion takes priority over inclusion.
    ${Action},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # The name (also known as the key) of the tag.
    ${Name},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # The value of the tag.
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
            __AllParameterSets = 'Az.Datadog.custom\New-AzDatadogFilteringTagObject';
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
