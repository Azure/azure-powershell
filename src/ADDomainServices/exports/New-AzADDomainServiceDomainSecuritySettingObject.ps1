
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
Create a in-memory object for DomainSecuritySettings
.Description
Create a in-memory object for DomainSecuritySettings
.Example
PS C:\> New-AzADDomainServiceDomainSecuritySettingObject -NtlmV1 Disabled -SyncKerberosPassword Disabled -SyncNtlmPassword Disabled -SyncOnPremPassword Disabled -TlsV1 Disabled

NtlmV1   SyncKerberosPassword SyncNtlmPassword SyncOnPremPassword TlsV1
------   -------------------- ---------------- ------------------ -----
Disabled Disabled             Disabled         Disabled           Disabled

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServicesDomainSecuritySettingsObject
#>
function New-AzADDomainServiceDomainSecuritySettingObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not NtlmV1 is enabled or disabled.
    ${NtlmV1},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    ${SyncKerberosPassword},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.
    ${SyncNtlmPassword},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.
    ${SyncOnPremPassword},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not TlsV1 is enabled or disabled.
    ${TlsV1}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.ADDomainServices.custom\New-AzADDomainServiceDomainSecuritySettingObject';
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
