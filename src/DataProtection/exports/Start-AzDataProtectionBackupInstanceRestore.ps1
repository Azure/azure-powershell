
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
Triggers restore for a BackupInstance
.Description
Triggers restore for a BackupInstance
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequest
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
.Outputs
System.Boolean
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

PARAMETER <IAzureBackupRestoreRequest>: Azure backup restore request
  ObjectType <String>: 
  RestoreTargetInfoObjectType <String>: Type of Datasource object, used to initialize the right inherited type
  SourceDataStoreType <SourceDataStoreType>: Gets or sets the type of the source data store.
  [RestoreTargetInfoRestoreLocation <String>]: Target Restore region

RECOVERYPOINT <IAzureBackupRecoveryPointResource>: Storage Type of the vault
  ObjectType <String>: 

TARGETINFO <IRestoreTargetInfoBase>: DataStore Type of the vault
  ObjectType <String>: Type of Datasource object, used to initialize the right inherited type
  [RestoreLocation <String>]: Target Restore region
.Link
https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/start-azdataprotectionbackupinstancerestore
#>
function Start-AzDataProtectionBackupInstanceRestore {
[OutputType([System.Boolean], [PSObject])]
[CmdletBinding(DefaultParameterSetName='TriggerExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Trigger', Mandatory)]
    [Parameter(ParameterSetName='TriggerExpanded', Mandatory)]
    [Parameter(ParameterSetName='platform', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup instance
    ${BackupInstanceName},

    [Parameter(ParameterSetName='Trigger', Mandatory)]
    [Parameter(ParameterSetName='TriggerExpanded', Mandatory)]
    [Parameter(ParameterSetName='platform', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Trigger')]
    [Parameter(ParameterSetName='TriggerExpanded')]
    [Parameter(ParameterSetName='platform')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Trigger', Mandatory)]
    [Parameter(ParameterSetName='TriggerExpanded', Mandatory)]
    [Parameter(ParameterSetName='platform', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup vault.
    ${VaultName},

    [Parameter(ParameterSetName='TriggerViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Trigger', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='TriggerViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequest]
    # Azure backup restore request
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='TriggerExpanded', Mandatory)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # .
    ${ObjectType},

    [Parameter(ParameterSetName='TriggerExpanded', Mandatory)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Type of Datasource object, used to initialize the right inherited type
    ${RestoreTargetInfoObjectType},

    [Parameter(ParameterSetName='TriggerExpanded', Mandatory)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType])]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType]
    # Gets or sets the type of the source data store.
    ${SourceDataStoreType},

    [Parameter(ParameterSetName='TriggerExpanded')]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Target Restore region
    ${RestoreTargetInfoRestoreLocation},

    [Parameter(ParameterSetName='platform', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # DataStore Type of the vault
    ${DataSourceType},

    [Parameter(ParameterSetName='platform', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
    # DataStore Type of the vault
    ${SourceDataStore},

    [Parameter(ParameterSetName='platform', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBase]
    # DataStore Type of the vault
    # To construct, see NOTES section for TARGETINFO properties and create a hash table.
    ${TargetInfo},

    [Parameter(ParameterSetName='platform')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPointResource]
    # Storage Type of the vault
    # To construct, see NOTES section for RECOVERYPOINT properties and create a hash table.
    ${RecoveryPoint},

    [Parameter(ParameterSetName='platform')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreRequestType]
    # DataStore Type of the vault
    ${RecoveryRequestType},

    [Parameter(ParameterSetName='Trigger')]
    [Parameter(ParameterSetName='TriggerExpanded')]
    [Parameter(ParameterSetName='TriggerViaIdentity')]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(ParameterSetName='Trigger')]
    [Parameter(ParameterSetName='TriggerExpanded')]
    [Parameter(ParameterSetName='TriggerViaIdentity')]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(ParameterSetName='Trigger', DontShow)]
    [Parameter(ParameterSetName='TriggerExpanded', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentity', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(ParameterSetName='Trigger', DontShow)]
    [Parameter(ParameterSetName='TriggerExpanded', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentity', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(ParameterSetName='Trigger', DontShow)]
    [Parameter(ParameterSetName='TriggerExpanded', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentity', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(ParameterSetName='Trigger')]
    [Parameter(ParameterSetName='TriggerExpanded')]
    [Parameter(ParameterSetName='TriggerViaIdentity')]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(ParameterSetName='Trigger')]
    [Parameter(ParameterSetName='TriggerExpanded')]
    [Parameter(ParameterSetName='TriggerViaIdentity')]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(ParameterSetName='Trigger', DontShow)]
    [Parameter(ParameterSetName='TriggerExpanded', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentity', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(ParameterSetName='Trigger', DontShow)]
    [Parameter(ParameterSetName='TriggerExpanded', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentity', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(ParameterSetName='Trigger', DontShow)]
    [Parameter(ParameterSetName='TriggerExpanded', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentity', DontShow)]
    [Parameter(ParameterSetName='TriggerViaIdentityExpanded', DontShow)]
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
            Trigger = 'Az.DataProtection.private\Start-AzDataProtectionBackupInstanceRestore_Trigger';
            TriggerExpanded = 'Az.DataProtection.private\Start-AzDataProtectionBackupInstanceRestore_TriggerExpanded';
            TriggerViaIdentity = 'Az.DataProtection.private\Start-AzDataProtectionBackupInstanceRestore_TriggerViaIdentity';
            TriggerViaIdentityExpanded = 'Az.DataProtection.private\Start-AzDataProtectionBackupInstanceRestore_TriggerViaIdentityExpanded';
            platform = 'Az.DataProtection.custom\Start-AzDataProtectionBackupInstanceRestore_platform';
        }
        if (('Trigger', 'TriggerExpanded', 'platform') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
