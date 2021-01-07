
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
Get the connection string according to client connection provider.
.Description
Get the connection string according to client connection provider.
.Example
PS C:\> Get-AzMySqlConnectionString -Client ADO.NET -Name mysql-test -ResourceGroupName PowershellMySqlTest

Server=mysql-test.mysql.database.azure.com; Port=3306; Database={your_database}; Uid=mysql_test@mysql-test; Pwd={your_password};
.Example
PS C:\> Get-AzMySqlServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Get-AzMySqlConnectionString -Client PHP

$con=mysqli_init(); mysqli_real_connect($con, "mysql-test.mysql.database.azure.com", "mysql_test@mysql-test", {your_password}, {your_database}, 3306);

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer
.Outputs
System.String
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IServer>: The server for the connection string.
  Location <String>: The geo-location where the resource lives
  [Tag <ITrackedResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [AdministratorLogin <String>]: The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation).
  [EarliestRestoreDate <DateTime?>]: Earliest restore point creation time (ISO8601 format)
  [FullyQualifiedDomainName <String>]: The fully qualified domain name of a server.
  [IdentityType <IdentityType?>]: The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory principal for the resource.
  [InfrastructureEncryption <InfrastructureEncryption?>]: Status showing whether the server enabled infrastructure encryption.
  [MasterServerId <String>]: The master server id of a replica server.
  [MinimalTlsVersion <MinimalTlsVersionEnum?>]: Enforce a minimal Tls version for the server.
  [PublicNetworkAccess <PublicNetworkAccessEnum?>]: Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled' or 'Disabled'
  [ReplicaCapacity <Int32?>]: The maximum number of replicas that a master server can have.
  [ReplicationRole <String>]: The replication role of the server.
  [SkuCapacity <Int32?>]: The scale up/out capacity, representing server's compute units.
  [SkuFamily <String>]: The family of hardware.
  [SkuName <String>]: The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
  [SkuSize <String>]: The size code, to be interpreted by resource as appropriate.
  [SkuTier <SkuTier?>]: The tier of the particular SKU, e.g. Basic.
  [SslEnforcement <SslEnforcementEnum?>]: Enable ssl enforcement or not when connect to server.
  [StorageProfileBackupRetentionDay <Int32?>]: Backup retention days for the server.
  [StorageProfileGeoRedundantBackup <GeoRedundantBackup?>]: Enable Geo-redundant or not for server backup.
  [StorageProfileStorageAutogrow <StorageAutogrow?>]: Enable Storage Auto Grow.
  [StorageProfileStorageMb <Int32?>]: Max storage allowed for a server.
  [UserVisibleState <ServerState?>]: A state of a server that is visible to user.
  [Version <ServerVersion?>]: Server version.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mysql/get-azmysqlconnectionstring
#>
function Get-AzMySqlConnectionString {
[OutputType([System.String])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
    [System.String]
    # Client connection provider.
    ${Client},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('ServerName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
    [System.String]
    # The name of the server.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource, You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer]
    # The server for the connection string.
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach.
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
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
            Get = 'Az.MySql.custom\Get-AzMySqlConnectionString';
            GetViaIdentity = 'Az.MySql.custom\Get-AzMySqlConnectionString';
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
