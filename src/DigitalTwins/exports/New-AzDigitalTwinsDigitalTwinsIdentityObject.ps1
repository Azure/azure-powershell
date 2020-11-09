
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
Create a in-memory object for DigitalTwinsIdentity
.Description
Create a in-memory object for DigitalTwinsIdentity
.Example
PS C:\> New-AzDigitalTwinsDigitalTwinsIdentityObject -Id '************' -Location eastus

EndpointName Location ResourceGroupName ResourceName SubscriptionId
------------ -------- ----------------- ------------ --------------
             eastus

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.DigitalTwinsIdentity
.Link
https://docs.microsoft.com/en-us/powershell/module/az.DigitalTwins/new-AzDigitalTwinsDigitalTwinsIdentityObject
#>
function New-AzDigitalTwinsDigitalTwinsIdentityObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.DigitalTwinsIdentity])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # Name of Endpoint Resource.
    ${EndpointName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # Resource identity path.
    ${Id},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # Location of DigitalTwinsInstance.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # The name of the resource group that contains the DigitalTwinsInstance.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # The name of the DigitalTwinsInstance.
    ${ResourceName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # The subscription identifier.
    ${SubscriptionId}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.DigitalTwins.custom\New-AzDigitalTwinsDigitalTwinsIdentityObject';
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
