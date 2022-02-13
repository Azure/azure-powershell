
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
Returns a BotService specified by the parameters.
.Description
Returns a BotService specified by the parameters.
.Example
PS C:\> Publish-AzBotServiceApp -ResourceGroupName youriBotTest -CodeDir D:\zips\MyEchoBot -Name youriechobottest


.Link
https://docs.microsoft.com/powershell/module/az.botservice/publish-azbotserviceapp
#>
function Publish-AzBotServiceApp {
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # This parameter defines the name of the bot.
    ${Name},

    [Parameter(Mandatory)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # This parameter defines the Path of the ZIP
    ${CodeDir}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.BotService.custom\Publish-AzBotServiceApp';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
