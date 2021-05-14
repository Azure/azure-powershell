
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
Create a in-memory object for Extension
.Description
Create a in-memory object for Extension
.Example
PS C:\> $extension = New-AzCloudServiceExtensionObject -Name "GenevaExtension" -Publisher "Microsoft.Azure.Geneva" -Type "GenevaMonitoringPaaS" -TypeHandlerVersion "2.14.0.2"

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.Extension
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudserviceextensionobject
#>
function New-AzCloudServiceExtensionObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.Extension])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Boolean]
    # Explicitly specify whether CRP can automatically upgrade typeHandlerVersion to higher minor versions when they become available.
    ${AutoUpgradeMinorVersion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name.
    ${Name},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Protected settings for the extension which are encrypted before sent to the VM.
    ${ProtectedSetting},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Publisher.
    ${Publisher},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String[]]
    # RolesAppliedTo.
    ${RolesAppliedTo},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Public settings for the extension.
    ${Setting},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Type.
    ${Type},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # TypeHandlerVersion.
    ${TypeHandlerVersion}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.CloudService.custom\New-AzCloudServiceExtensionObject';
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
