
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
Returns resource collection belonging to a subscription.
.Description
Returns resource collection belonging to a subscription.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResource
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
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionbackupvaultresource
#>
function Get-AzDataProtectionBackupVaultResource {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResource])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='Get1')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Get1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='GetViaIdentity1', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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
            Get = 'Az.DataProtection.private\Get-AzDataProtectionBackupVaultResource_Get';
            Get1 = 'Az.DataProtection.private\Get-AzDataProtectionBackupVaultResource_Get1';
            GetViaIdentity = 'Az.DataProtection.private\Get-AzDataProtectionBackupVaultResource_GetViaIdentity';
            GetViaIdentity1 = 'Az.DataProtection.private\Get-AzDataProtectionBackupVaultResource_GetViaIdentity1';
        }
        if (('Get', 'Get1') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Returns the list of available operations.
.Description
Returns the list of available operations.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApi
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionoperation
#>
function Get-AzDataProtectionOperation {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApi])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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
            List = 'Az.DataProtection.private\Get-AzDataProtectionOperation_List';
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
Returns a list of Recovery Points for a DataSource in a vault.
.Description
Returns a list of Recovery Points for a DataSource in a vault.
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
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionrecoverypointlist
#>
function Get-AzDataProtectionRecoveryPointList {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPointResource])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup instance
    ${BackupInstanceName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Get', Mandatory)]
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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Query')]
    [System.String]
    # OData filter options.
    ${Filter},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Query')]
    [System.String]
    # skipToken Filter.
    ${SkipToken},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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
            Get = 'Az.DataProtection.private\Get-AzDataProtectionRecoveryPointList_Get';
            GetViaIdentity = 'Az.DataProtection.private\Get-AzDataProtectionRecoveryPointList_GetViaIdentity';
        }
        if (('Get') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Create or update a backup instance in a backup vault
.Description
Create or update a backup instance in a backup vault
.Example
PS C:\> $sub = "xxxx-xxx-xx"
PS C:\> $DiskId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/disks/{diskname}"
PS C:\> $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault -Name "MyPolicy"
PS C:\> $instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation $vault.Location -PolicyId $policy.Id -DatasourceId $DiskId 
PS C:\> $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = "/subscriptions/{subscription}/resourceGroups/{resourceGroup}"
PS C:\> New-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstance $instance


Name                                                       Type                                                  BackupInstanceName
----                                                       ----                                                  ------------------
sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166 Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PARAMETER <IBackupInstanceResource>: BackupInstance Resource
  [Property <IBackupInstance>]: BackupInstanceResource properties
    DataSourceInfo <IDatasource>: Gets or sets the data source information.
      ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
      [ResourceLocation <String>]: Location of datasource.
      [ResourceName <String>]: Unique identifier of the resource in the context of parent.
      [ResourceType <String>]: Resource Type of Datasource.
      [ResourceUri <String>]: Uri of the resource.
      [Type <String>]: DatasourceType of the resource.
    FriendlyName <String>: Gets or sets the Backup Instance friendly name.
    ObjectType <String>: 
    PolicyInfo <IPolicyInfo>: Gets or sets the policy information.
      PolicyId <String>: 
      [PolicyParameter <IPolicyParameters>]: Policy parameters for the backup instance
        [DataStoreParametersList <IDataStoreParameters[]>]: Gets or sets the DataStore Parameters
          DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
          ObjectType <String>: Type of the specific object - used for deserializing
    [DataSourceSetInfo <IDatasourceSet>]: Gets or sets the data source set information.
      ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      [DatasourceType <String>]: DatasourceType of the resource.
      [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
      [ResourceLocation <String>]: Location of datasource.
      [ResourceName <String>]: Unique identifier of the resource in the context of parent.
      [ResourceType <String>]: Resource Type of Datasource.
      [ResourceUri <String>]: Uri of the resource.

PROPERTY <IBackupInstance>: BackupInstanceResource properties
  DataSourceInfo <IDatasource>: Gets or sets the data source information.
    ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
    [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
    [ResourceLocation <String>]: Location of datasource.
    [ResourceName <String>]: Unique identifier of the resource in the context of parent.
    [ResourceType <String>]: Resource Type of Datasource.
    [ResourceUri <String>]: Uri of the resource.
    [Type <String>]: DatasourceType of the resource.
  FriendlyName <String>: Gets or sets the Backup Instance friendly name.
  ObjectType <String>: 
  PolicyInfo <IPolicyInfo>: Gets or sets the policy information.
    PolicyId <String>: 
    [PolicyParameter <IPolicyParameters>]: Policy parameters for the backup instance
      [DataStoreParametersList <IDataStoreParameters[]>]: Gets or sets the DataStore Parameters
        DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
        ObjectType <String>: Type of the specific object - used for deserializing
  [DataSourceSetInfo <IDatasourceSet>]: Gets or sets the data source set information.
    ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
    [DatasourceType <String>]: DatasourceType of the resource.
    [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
    [ResourceLocation <String>]: Location of datasource.
    [ResourceName <String>]: Unique identifier of the resource in the context of parent.
    [ResourceType <String>]: Resource Type of Datasource.
    [ResourceUri <String>]: Uri of the resource.
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionbackupinstance
#>
function New-AzDataProtectionBackupInstance {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('BackupInstanceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup instance
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup vault.
    ${VaultName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource]
    # BackupInstance Resource
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstance]
    # BackupInstanceResource properties
    # To construct, see NOTES section for PROPERTY properties and create a hash table.
    ${Property},

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
            Create = 'Az.DataProtection.private\New-AzDataProtectionBackupInstance_Create';
            CreateExpanded = 'Az.DataProtection.private\New-AzDataProtectionBackupInstance_CreateExpanded';
        }
        if (('Create', 'CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Creates or Updates a backup policy belonging to a backup vault
.Description
Creates or Updates a backup policy belonging to a backup vault
.Example
PS C:\> $defaultPol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk
PS C:\> New-AzDataProtectionBackupPolicy -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -Name "MyPolicy" -Policy $defaultPol

Name              Type
----              ----
MyPolicy       Microsoft.DataProtection/backupVaults/backupPolicies

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResource
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PARAMETER <IBaseBackupPolicyResource>: BaseBackupPolicy resource
  [DatasourceType <String[]>]: Type of datasource for the backup management
  [ObjectType <String>]: 
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionbackuppolicy
#>
function New-AzDataProtectionBackupPolicy {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('BackupPolicyName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # .
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup vault.
    ${VaultName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyResource]
    # BaseBackupPolicy resource
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String[]]
    # Type of datasource for the backup management
    ${DatasourceType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # .
    ${ObjectType},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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
            Create = 'Az.DataProtection.private\New-AzDataProtectionBackupPolicy_Create';
            CreateExpanded = 'Az.DataProtection.private\New-AzDataProtectionBackupPolicy_CreateExpanded';
        }
        if (('Create', 'CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Creates or updates a BackupVault resource belonging to a resource group.
.Description
Creates or updates a BackupVault resource belonging to a resource group.
.Example
PS C:\> $sub = "xxxx-xxxx-xxxxx"
PS C:\> $storagesetting = New-AzDataProtectionBackupVaultStorageSettingObject -DataStoreType VaultStore -Type LocallyRedundant
PS C:\> New-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName "MyVault" -StorageSetting $storagesetting -Location westus

ETag IdentityPrincipalId IdentityTenantId IdentityType Location Name    Type
---- ------------------- ---------------- ------------ -------- ----    ----
                                                       westus   MyVault Microsoft.DataProtection/backupVaults

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResource
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PARAMETER <IBackupVaultResource>: Backup Vault Resource
  StorageSetting <IStorageSetting[]>: Storage Settings
    [DatastoreType <StorageSettingStoreTypes?>]: Gets or sets the type of the datastore.
    [Type <StorageSettingTypes?>]: Gets or sets the type.
  [ETag <String>]: Optional ETag.
  [IdentityType <String>]: The identityType which can be either SystemAssigned or None
  [Location <String>]: Resource location.
  [Tag <IDppTrackedResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.

STORAGESETTING <IStorageSetting[]>: Storage Settings
  [DatastoreType <StorageSettingStoreTypes?>]: Gets or sets the type of the datastore.
  [Type <StorageSettingTypes?>]: Gets or sets the type.
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionbackupvault
#>
function New-AzDataProtectionBackupVault {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResource])]
[CmdletBinding(DefaultParameterSetName='Create', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the backup vault.
    ${VaultName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResource]
    # Backup Vault Resource
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting[]]
    # Storage Settings
    # To construct, see NOTES section for STORAGESETTING properties and create a hash table.
    ${StorageSetting},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Optional ETag.
    ${ETag},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # The identityType which can be either SystemAssigned or None
    ${IdentityType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Resource location.
    ${Location},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

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
            Create = 'Az.DataProtection.private\New-AzDataProtectionBackupVault_Create';
            CreateExpanded = 'Az.DataProtection.private\New-AzDataProtectionBackupVault_CreateExpanded';
        }
        if (('Create', 'CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Validate whether adhoc backup will be successful or not
.Description
Validate whether adhoc backup will be successful or not
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IValidateForBackupRequest
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationJobExtendedInfo
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

BACKUPINSTANCE <IBackupInstance>: Backup Instance
  DataSourceInfo <IDatasource>: Gets or sets the data source information.
    ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
    [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
    [ResourceLocation <String>]: Location of datasource.
    [ResourceName <String>]: Unique identifier of the resource in the context of parent.
    [ResourceType <String>]: Resource Type of Datasource.
    [ResourceUri <String>]: Uri of the resource.
    [Type <String>]: DatasourceType of the resource.
  FriendlyName <String>: Gets or sets the Backup Instance friendly name.
  ObjectType <String>: 
  PolicyInfo <IPolicyInfo>: Gets or sets the policy information.
    PolicyId <String>: 
    [PolicyParameter <IPolicyParameters>]: Policy parameters for the backup instance
      [DataStoreParametersList <IDataStoreParameters[]>]: Gets or sets the DataStore Parameters
        DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
        ObjectType <String>: Type of the specific object - used for deserializing
  [DataSourceSetInfo <IDatasourceSet>]: Gets or sets the data source set information.
    ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
    [DatasourceType <String>]: DatasourceType of the resource.
    [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
    [ResourceLocation <String>]: Location of datasource.
    [ResourceName <String>]: Unique identifier of the resource in the context of parent.
    [ResourceType <String>]: Resource Type of Datasource.
    [ResourceUri <String>]: Uri of the resource.

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

PARAMETER <IValidateForBackupRequest>: Validate for backup request
  BackupInstance <IBackupInstance>: Backup Instance
    DataSourceInfo <IDatasource>: Gets or sets the data source information.
      ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
      [ResourceLocation <String>]: Location of datasource.
      [ResourceName <String>]: Unique identifier of the resource in the context of parent.
      [ResourceType <String>]: Resource Type of Datasource.
      [ResourceUri <String>]: Uri of the resource.
      [Type <String>]: DatasourceType of the resource.
    FriendlyName <String>: Gets or sets the Backup Instance friendly name.
    ObjectType <String>: 
    PolicyInfo <IPolicyInfo>: Gets or sets the policy information.
      PolicyId <String>: 
      [PolicyParameter <IPolicyParameters>]: Policy parameters for the backup instance
        [DataStoreParametersList <IDataStoreParameters[]>]: Gets or sets the DataStore Parameters
          DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
          ObjectType <String>: Type of the specific object - used for deserializing
    [DataSourceSetInfo <IDatasourceSet>]: Gets or sets the data source set information.
      ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      [DatasourceType <String>]: DatasourceType of the resource.
      [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
      [ResourceLocation <String>]: Location of datasource.
      [ResourceName <String>]: Unique identifier of the resource in the context of parent.
      [ResourceType <String>]: Resource Type of Datasource.
      [ResourceUri <String>]: Uri of the resource.
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/test-azdataprotectionbackupinstance
#>
function Test-AzDataProtectionBackupInstance {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationJobExtendedInfo])]
[CmdletBinding(DefaultParameterSetName='ValidateViaIdentity', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
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
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IValidateForBackupRequest]
    # Validate for backup request
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstance]
    # Backup Instance
    # To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.
    ${BackupInstance},

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
            Validate = 'Az.DataProtection.private\Test-AzDataProtectionBackupInstance_Validate';
            ValidateExpanded = 'Az.DataProtection.private\Test-AzDataProtectionBackupInstance_ValidateExpanded';
            ValidateViaIdentity = 'Az.DataProtection.private\Test-AzDataProtectionBackupInstance_ValidateViaIdentity';
            ValidateViaIdentityExpanded = 'Az.DataProtection.private\Test-AzDataProtectionBackupInstance_ValidateViaIdentityExpanded';
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
API to check for resource name availability
.Description
API to check for resource name availability
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICheckNameAvailabilityRequest
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICheckNameAvailabilityResult
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

PARAMETER <ICheckNameAvailabilityRequest>: CheckNameAvailability Request
  [Name <String>]: Resource name for which availability needs to be checked
  [Type <String>]: Describes the Resource type: Microsoft.DataProtection/BackupVaults
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/test-azdataprotectionbackupvaultnameavailability
#>
function Test-AzDataProtectionBackupVaultNameAvailability {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICheckNameAvailabilityResult])]
[CmdletBinding(DefaultParameterSetName='CheckExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Check', Mandatory)]
    [Parameter(ParameterSetName='CheckExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The location in which uniqueness will be verified.
    ${Location},

    [Parameter(ParameterSetName='Check', Mandatory)]
    [Parameter(ParameterSetName='CheckExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Check')]
    [Parameter(ParameterSetName='CheckExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CheckViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CheckViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Check', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CheckViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICheckNameAvailabilityRequest]
    # CheckNameAvailability Request
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='CheckExpanded')]
    [Parameter(ParameterSetName='CheckViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Resource name for which availability needs to be checked
    ${Name},

    [Parameter(ParameterSetName='CheckExpanded')]
    [Parameter(ParameterSetName='CheckViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Describes the Resource type: Microsoft.DataProtection/BackupVaults
    ${Type},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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
            Check = 'Az.DataProtection.private\Test-AzDataProtectionBackupVaultNameAvailability_Check';
            CheckExpanded = 'Az.DataProtection.private\Test-AzDataProtectionBackupVaultNameAvailability_CheckExpanded';
            CheckViaIdentity = 'Az.DataProtection.private\Test-AzDataProtectionBackupVaultNameAvailability_CheckViaIdentity';
            CheckViaIdentityExpanded = 'Az.DataProtection.private\Test-AzDataProtectionBackupVaultNameAvailability_CheckViaIdentityExpanded';
        }
        if (('Check', 'CheckExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Validates if a feature is supported
.Description
Validates if a feature is supported
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequestBase
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
.Outputs
System.String
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

PARAMETER <IFeatureValidationRequestBase>: Base class for Backup Feature support
  ObjectType <String>: Type of the specific object - used for deserializing
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/test-azdataprotectionfeaturesupport
#>
function Test-AzDataProtectionFeatureSupport {
[OutputType([System.String])]
[CmdletBinding(DefaultParameterSetName='CheckExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Check', Mandatory)]
    [Parameter(ParameterSetName='CheckExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # .
    ${Location},

    [Parameter(ParameterSetName='Check')]
    [Parameter(ParameterSetName='CheckExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CheckViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CheckViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Check', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CheckViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequestBase]
    # Base class for Backup Feature support
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='CheckExpanded', Mandatory)]
    [Parameter(ParameterSetName='CheckViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Type of the specific object - used for deserializing
    ${ObjectType},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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
            Check = 'Az.DataProtection.private\Test-AzDataProtectionFeatureSupport_Check';
            CheckExpanded = 'Az.DataProtection.private\Test-AzDataProtectionFeatureSupport_CheckExpanded';
            CheckViaIdentity = 'Az.DataProtection.private\Test-AzDataProtectionFeatureSupport_CheckViaIdentity';
            CheckViaIdentityExpanded = 'Az.DataProtection.private\Test-AzDataProtectionFeatureSupport_CheckViaIdentityExpanded';
        }
        if (('Check', 'CheckExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
