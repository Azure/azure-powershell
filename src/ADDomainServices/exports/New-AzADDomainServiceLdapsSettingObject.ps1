
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
Create a in-memory object for LdapsSettings
.Description
Create a in-memory object for LdapsSettings
.Example
PS C:\> $secstr = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
New-AzADDomainServiceLdapsSettingObject -ExternalAccess Enabled -Ldaps Enabled -PfxCertificatePath sahg -PfxCertificatePassword $secstr

CertificateNotAfter CertificateThumbprint ExternalAccess Ldaps    PfxCertificate PfxCertificatePassword PublicCertificate
------------------- --------------------- -------------- ----    -------------- ---------------------- -----------------
                                          Enabled        Enabled                Password

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServicesLdapsSettingsObject
#>
function New-AzADDomainServiceLdapsSettingObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
    ${ExternalAccess},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not Secure LDAP is enabled or disabled.
    ${Ldaps},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # The path of certificate required to configure Secure LDAP.
    ${PfxCertificatePath},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.Security.SecureString]
    # The password to decrypt the provided Secure LDAP certificate pfx file.
    ${PfxCertificatePassword}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.ADDomainServices.custom\New-AzADDomainServiceLdapsSettingObject';
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
