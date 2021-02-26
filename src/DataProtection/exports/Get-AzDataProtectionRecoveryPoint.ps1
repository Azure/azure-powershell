
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
Gets a Recovery Point using recoveryPointId for a Datasource.
.Description
Gets a Recovery Point using recoveryPointId for a Datasource.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPointResource
.Outputs
System.Management.Automation.PSObject
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IDataProtectionIdentity>: Identity Parameter
  [BackupInstanceName <String>]: The name of the backup instance
  [BackupPolicyName <String>]: 
  [Id <String>]: Resource identity path
  [JobId <String>]: The Job ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Location <String>]: 
  [OperationId <String>]: 
  [RecoveryPointId <String>]: 
  [ResourceGroupName <String>]: The name of the resource group where the backup vault is present.
  [SubscriptionId <String>]: The subscription Id.
  [VaultName <String>]: The name of the backup vault.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/get-azdataprotectionrecoverypoint
#>
function Get-AzDataProtectionRecoveryPoint {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPointResource], [PSObject])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup instance
    ${BackupInstanceName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('RecoveryPointId')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # .
    ${Id},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup vault.
    ${VaultName},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='GetViaIdentity')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(ParameterSetName='Get', DontShow)]
    [Parameter(ParameterSetName='GetViaIdentity', DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(ParameterSetName='Get', DontShow)]
    [Parameter(ParameterSetName='GetViaIdentity', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(ParameterSetName='Get', DontShow)]
    [Parameter(ParameterSetName='GetViaIdentity', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(ParameterSetName='Get', DontShow)]
    [Parameter(ParameterSetName='GetViaIdentity', DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(ParameterSetName='Get', DontShow)]
    [Parameter(ParameterSetName='GetViaIdentity', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(ParameterSetName='Get', DontShow)]
    [Parameter(ParameterSetName='GetViaIdentity', DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.DataProtection.private\Get-AzDataProtectionRecoveryPoint_Get';
            GetViaIdentity = 'Az.DataProtection.private\Get-AzDataProtectionRecoveryPoint_GetViaIdentity';
            List = 'Az.DataProtection.custom\Get-AzDataProtectionRecoveryPoint_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
