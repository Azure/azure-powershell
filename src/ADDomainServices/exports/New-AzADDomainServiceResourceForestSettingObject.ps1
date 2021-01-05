
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
Create a in-memory object for ResourceForestSettings
.Description
Create a in-memory object for ResourceForestSettings
.Example
PS C:\> New-AzADDomainServiceResourceForestSettingObject -ResourceForest resourcetest

ResourceForest
--------------
resourcetest

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

FORESTTRUST <IForestTrust[]>: List of settings for Resource Forest.
  [FriendlyName <String>]: Friendly Name
  [RemoteDnsIP <String>]: Remote Dns ips
  [TrustDirection <String>]: Trust Direction
  [TrustPassword <String>]: Trust Password
  [TrustedDomainFqdn <String>]: Trusted Domain FQDN
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServicesResourceForestSettingsObject
#>
function New-AzADDomainServiceResourceForestSettingObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Resource Forest.
    ${ResourceForest},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[]]
    # List of settings for Resource Forest.
    # To construct, see NOTES section for FORESTTRUST properties and create a hash table.
    ${ForestTrust}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.ADDomainServices.custom\New-AzADDomainServiceResourceForestSettingObject';
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
