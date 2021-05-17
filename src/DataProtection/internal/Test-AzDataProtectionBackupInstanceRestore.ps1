
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
Validates if Restore can be triggered for a DataSource
.Description
Validates if Restore can be triggered for a DataSource
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IValidateRestoreRequestObject
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationJobExtendedInfo
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IDataProtectionIdentity>: Identity Parameter
  [BackupInstance <String>]: 
  [BackupInstanceName <String>]: The name of the backup instance
  [BackupPolicyName <String>]: 
  [Id <String>]: Resource identity path
  [JobId <String>]: The Job ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Location <String>]: The location in which uniqueness will be verified.
  [OperationId <String>]: 
  [RecoveryPointId <String>]: 
  [ResourceGroupName <String>]: The name of the resource group where the backup vault is present.
  [SubscriptionId <String>]: The subscription Id.
  [VaultName <String>]: The name of the backup vault.

PARAMETER <IValidateRestoreRequestObject>: Validate restore request object
  RestoreRequestObjectSourceDataStoreType <SourceDataStoreType>: Gets or sets the type of the source data store.
  RestoreRequestObjectType <String>: 
  RestoreTargetInfoObjectType <String>: Type of Datasource object, used to initialize the right inherited type
  [RestoreTargetInfoRestoreLocation <String>]: Target Restore region
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/test-azdataprotectionbackupinstancerestore
#>
function Test-AzDataProtectionBackupInstanceRestore {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationJobExtendedInfo])]
[CmdletBinding(DefaultParameterSetName='ValidateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Validate', Mandatory)]
    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup instance
    ${BackupInstanceName},

    [Parameter(ParameterSetName='Validate', Mandatory)]
    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Validate')]
    [Parameter(ParameterSetName='ValidateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Validate', Mandatory)]
    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup vault.
    ${VaultName},

    [Parameter(ParameterSetName='ValidateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Validate', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ValidateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IValidateRestoreRequestObject]
    # Validate restore request object
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded', Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType])]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType]
    # Gets or sets the type of the source data store.
    ${RestoreRequestObjectSourceDataStoreType},

    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # .
    ${RestoreRequestObjectType},

    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Type of Datasource object, used to initialize the right inherited type
    ${RestoreTargetInfoObjectType},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Target Restore region
    ${RestoreTargetInfoRestoreLocation},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
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
            Validate = 'Az.DataProtection.private\Test-AzDataProtectionBackupInstanceRestore_Validate';
            ValidateExpanded = 'Az.DataProtection.private\Test-AzDataProtectionBackupInstanceRestore_ValidateExpanded';
            ValidateViaIdentity = 'Az.DataProtection.private\Test-AzDataProtectionBackupInstanceRestore_ValidateViaIdentity';
            ValidateViaIdentityExpanded = 'Az.DataProtection.private\Test-AzDataProtectionBackupInstanceRestore_ValidateViaIdentityExpanded';
        }
        if (('Validate', 'ValidateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
