
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
Description for Restores a specific backup to another app (or deployment slot, if specified).
.Description
Description for Restores a specific backup to another app (or deployment slot, if specified).
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequest
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DATABASE <IDatabaseBackupSetting[]>: Collection of databases which should be restored. This list has to match the list of databases included in the backup.
  DatabaseType <DatabaseType>: Database type (e.g. SqlAzure / MySql).
  [ConnectionString <String>]: Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new database, the database name inside is the new one.
  [ConnectionStringName <String>]: Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.         This is used during restore with overwrite connection strings options.
  [Name <String>]: 

INPUTOBJECT <IFunctionsIdentity>: Identity Parameter
  [AccountName <String>]: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  [AnalysisName <String>]: Analysis Name
  [AppSettingKey <String>]: App Setting key name.
  [Authprovider <String>]: The auth provider for the users.
  [BackupId <String>]: ID of the backup.
  [BaseAddress <String>]: Module base address.
  [BlobServicesName <String>]: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  [CertificateOrderName <String>]: Name of the certificate order..
  [ContainerName <String>]: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  [DeletedSiteId <String>]: The numeric ID of the deleted app, e.g. 12345
  [DetectorName <String>]: Detector Resource Name
  [DiagnosticCategory <String>]: Diagnostic Category
  [DiagnosticsName <String>]: Name of the diagnostics item.
  [DomainName <String>]: Name of the domain.
  [DomainOwnershipIdentifierName <String>]: Name of domain ownership identifier.
  [EntityName <String>]: Name of the hybrid connection.
  [FunctionName <String>]: Function name.
  [GatewayName <String>]: Name of the gateway. Currently, the only supported string is "primary".
  [HostName <String>]: Hostname in the hostname binding.
  [HostingEnvironmentName <String>]: Name of the hosting environment.
  [Id <String>]: Deployment ID.
  [Id1 <String>]: Resource identity path
  [ImmutabilityPolicyName <String>]: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  [Instance <String>]: Name of the instance in the multi-role pool.
  [InstanceId <String>]: 
  [KeyId <String>]: The API Key ID. This is unique within a Application Insights component.
  [KeyName <String>]: The name of the key.
  [KeyType <String>]: The type of host key.
  [Location <String>]: 
  [ManagementPolicyName <ManagementPolicyName?>]: The name of the Storage Account Management Policy. It should always be 'default'
  [Name <String>]: Name of the certificate.
  [NamespaceName <String>]: The namespace for this hybrid connection.
  [OperationId <String>]: GUID of the operation.
  [PrId <String>]: The stage site identifier.
  [PremierAddOnName <String>]: Add-on name.
  [PrivateEndpointConnectionName <String>]: 
  [ProcessId <String>]: PID.
  [PublicCertificateName <String>]: Public certificate name.
  [PurgeId <String>]: In a purge status request, this is the Id of the operation the status of which is returned.
  [RelayName <String>]: The relay name for this hybrid connection.
  [ResourceGroupName <String>]: Name of the resource group to which the resource belongs.
  [ResourceName <String>]: The name of the Application Insights component resource.
  [RouteName <String>]: Name of the Virtual Network route.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SiteExtensionId <String>]: Site extension name.
  [SiteName <String>]: Site Name
  [Slot <String>]: Slot Name
  [SnapshotId <String>]: The ID of the snapshot to read.
  [SourceControlType <String>]: Type of source control
  [SubscriptionId <String>]: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Userid <String>]: The user id of the user.
  [View <String>]: The type of view. This can either be "summary" or "detailed".
  [VnetName <String>]: Name of the virtual network.
  [WebJobName <String>]: Name of Web Job.
  [WorkerName <String>]: Name of worker machine, which typically starts with RD.
  [WorkerPoolName <String>]: Name of the worker pool.

REQUEST <IRestoreRequest>: Description of a restore request.
  Overwrite <Boolean>: <code>true</code> if the restore operation can overwrite target app; otherwise, <code>false</code>. <code>true</code> is needed if trying to restore over an existing app.
  StorageAccountUrl <String>: SAS URL to the container.
  [Kind <String>]: Kind of resource.
  [AdjustConnectionString <Boolean?>]: <code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.
  [AppServicePlan <String>]: Specify app service plan that will own restored site.
  [BlobName <String>]: Name of a blob which contains the backup.
  [Database <IDatabaseBackupSetting[]>]: Collection of databases which should be restored. This list has to match the list of databases included in the backup.
    DatabaseType <DatabaseType>: Database type (e.g. SqlAzure / MySql).
    [ConnectionString <String>]: Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new database, the database name inside is the new one.
    [ConnectionStringName <String>]: Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.         This is used during restore with overwrite connection strings options.
    [Name <String>]: 
  [HostingEnvironment <String>]: App Service Environment name, if needed (only when restoring an app to an App Service Environment).
  [IgnoreConflictingHostName <Boolean?>]: Changes a logic when restoring an app with custom domains. <code>true</code> to remove custom domains automatically. If <code>false</code>, custom domains are added to         the app's object when it is being restored, but that might fail due to conflicts during the operation.
  [IgnoreDatabase <Boolean?>]: Ignore the databases and only restore the site content
  [OperationType <BackupRestoreOperationType?>]: Operation type.
  [SiteName <String>]: Name of an app.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/restore-azfunctionapp
#>
function Restore-AzFunctionApp {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='RestoreExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Restore', Mandatory)]
    [Parameter(ParameterSetName='RestoreExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # ID of the backup.
    ${BackupId},

    [Parameter(ParameterSetName='Restore', Mandatory)]
    [Parameter(ParameterSetName='RestoreExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the app.
    ${Name},

    [Parameter(ParameterSetName='Restore', Mandatory)]
    [Parameter(ParameterSetName='RestoreExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Restore')]
    [Parameter(ParameterSetName='RestoreExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter(ParameterSetName='RestoreViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Restore', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='RestoreViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRestoreRequest]
    # Description of a restore request.
    # To construct, see NOTES section for REQUEST properties and create a hash table.
    ${Request},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.
    ${AdjustConnectionString},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Specify app service plan that will own restored site.
    ${AppServicePlan},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Name of a blob which contains the backup.
    ${BlobName},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[]]
    # Collection of databases which should be restored.
    # This list has to match the list of databases included in the backup.
    # To construct, see NOTES section for DATABASE properties and create a hash table.
    ${Database},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # App Service Environment name, if needed (only when restoring an app to an App Service Environment).
    ${HostingEnvironment},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Changes a logic when restoring an app with custom domains.
    # <code>true</code> to remove custom domains automatically.
    # If <code>false</code>, custom domains are added to the app's object when it is being restored, but that might fail due to conflicts during the operation.
    ${IgnoreConflictingHostName},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Ignore the databases and only restore the site content
    ${IgnoreDatabase},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Kind of resource.
    ${Kind},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupRestoreOperationType]
    # Operation type.
    ${OperationType},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if the restore operation can overwrite target app; otherwise, <code>false</code>.
    # <code>true</code> is needed if trying to restore over an existing app.
    ${Overwrite},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Name of an app.
    ${SiteName},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # SAS URL to the container.
    ${StorageAccountUrl},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            Restore = 'Az.Functions.private\Restore-AzFunctionApp_Restore';
            RestoreExpanded = 'Az.Functions.private\Restore-AzFunctionApp_RestoreExpanded';
            RestoreViaIdentity = 'Az.Functions.private\Restore-AzFunctionApp_RestoreViaIdentity';
            RestoreViaIdentityExpanded = 'Az.Functions.private\Restore-AzFunctionApp_RestoreViaIdentityExpanded';
        }
        if (('Restore', 'RestoreExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
