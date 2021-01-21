
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
Create a in-memory object for CheckNameRequest
.Description
Create a in-memory object for CheckNameRequest
.Example
PS C:\> New-AzDigitalTwinsCheckNameRequestObject -name youriTestName

Name          Type
----          ----
youriTestName Microsoft.DigitalTwins/digitalTwinsInstances

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.CheckNameRequest
.Link
https://docs.microsoft.com/en-us/powershell/module/az.DigitalTwins/new-AzDigitalTwinsCheckNameRequestObject
#>
function New-AzDigitalTwinsCheckNameRequestObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.CheckNameRequest])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # Resource name.
    ${Name}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.DigitalTwins.custom\New-AzDigitalTwinsCheckNameRequestObject';
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
