
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
Creates a new backup policy in a given backup vault
.Description
Creates a new backup policy in a given backup vault
.Example
PS C:\> $defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk
PS C:\> New-AzDataProtectionBackupPolicy -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -Name "MyPolicy" -Policy $defaultPol

Name              Type
----              ----
MyPolicy       Microsoft.DataProtection/backupVaults/backupPolicies

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBaseBackupPolicyResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

POLICY <IBackupPolicy>: Policy Request Object
  DatasourceType <String[]>: Type of datasource for the backup management
  ObjectType <String>: 
  PolicyRule <IBasePolicyRule[]>: Policy rule dictionary that contains rules for each backuptype i.e Full/Incremental/Logs etc
    Name <String>: 
    ObjectType <String>: 
    DataStoreObjectType <String>: Type of Datasource object, used to initialize the right inherited type
    DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
    TriggerObjectType <String>: Type of the specific object - used for deserializing
    Lifecycle <ISourceLifeCycle[]>: 
      DeleteAfterDuration <String>: Duration of deletion after given timespan
      DeleteAfterObjectType <String>: Type of the specific object - used for deserializing
      SourceDataStoreObjectType <String>: Type of Datasource object, used to initialize the right inherited type
      SourceDataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
      [TargetDataStoreCopySetting <ITargetCopySetting[]>]: 
        CopyAfterObjectType <String>: Type of the specific object - used for deserializing
        DataStoreObjectType <String>: Type of Datasource object, used to initialize the right inherited type
        DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
    [BackupParameterObjectType <String>]: Type of the specific object - used for deserializing
    [IsDefault <Boolean?>]: 
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionbackuppolicy
#>
function New-AzDataProtectionBackupPolicy {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBaseBackupPolicyResource])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Resource Group Name
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Vault Name
    ${VaultName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Policy Name
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupPolicy]
    # Policy Request Object
    # To construct, see NOTES section for POLICY properties and create a hash table.
    ${Policy},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Subscription Id
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Management.Automation.SwitchParameter]
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
            __AllParameterSets = 'Az.DataProtection.custom\New-AzDataProtectionBackupPolicy';
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
