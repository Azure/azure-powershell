
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
Creates a Redis Enterprise cache.
.Description
Creates or updates an existing (overwrite/recreate, with potential downtime) cache cluster with an associated database.
.Example
PS C:\> New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "West US" -Sku "Enterprise_E10"

Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}

.Example
PS C:\> New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "East US" -Sku "Enterprise_E20" -Capacity 4 -MinimumTlsVersion "1.2" -Zone "1","2","3" -Tag @{"tag1" = "value1"} -Module "{name:RedisBloom, args:`"ERROR_RATE 0.00 INITIAL_SIZE 400`"}","{name:RedisTimeSeries, args:`"RETENTION_POLICY 20`"}","{name:RediSearch}" -ClientProtocol "Plaintext" -EvictionPolicy "NoEviction" -ClusteringPolicy "EnterpriseCluster" -AofPersistenceEnabled -AofPersistenceFrequency "1s"

Location Name    Type                            Zone      Database
-------- ----    ----                            ----      --------
East US  MyCache Microsoft.Cache/redisEnterprise {1, 2, 3} {default}

.Example
PS C:\> New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "East US" -Sku "EnterpriseFlash_F300" -NoDatabase

Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
East US  MyCache Microsoft.Cache/redisEnterprise      {}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ICluster
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

MODULE <IModule[]>: Optional set of redis modules to enable in this database - modules can only be added at creation time.
  Name <String>: The name of the module, e.g. 'RedisBloom', 'RediSearch', 'RedisTimeSeries'
  [Arg <String>]: Configuration options for the module, e.g. 'ERROR_RATE 0.00 INITIAL_SIZE 400'.

.Link
https://learn.microsoft.com/powershell/module/az.redisenterprisecache/new-azredisenterprisecache
#>
function New-AzRedisEnterpriseCache {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ICluster])]
    [CmdletBinding(DefaultParameterSetName='CreateClusterWithDatabase', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the Redis Enterprise cluster.
        ${ClusterName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # The geo-location where the resource lives.
        ${Location},

        [Parameter(Mandatory)]
        [Alias('SkuName')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName]
        # The type of Redis Enterprise cluster to deploy.
        # Allowed values: Enterprise_E10, Enterprise_E20, Enterprise_E50, Enterprise_E100, EnterpriseFlash_F300, EnterpriseFlash_F700, EnterpriseFlash_F1500
        ${Sku},

        [Parameter()]
        [Alias('SkuCapacity')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.Int32]
        # The size of the Redis Enterprise cluster - defaults to 2 or 3 depending on SKU.
        # Allowed values are (2, 4, 6, ...) for Enterprise SKUs and (3, 9, 15, ...) for Flash SKUs.
        ${Capacity},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.TlsVersion])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.TlsVersion]
        # The minimum TLS version for the cluster to support - default is 1.2
        # Allowed values: 1.0, 1.1, 1.2
        ${MinimumTlsVersion},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String[]]
        # The Availability Zones where this cluster will be deployed.
        ${Zone},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api30.ITrackedResourceTags]))]
        [System.Collections.Hashtable]
        # Cluster resource tags.
        ${Tag},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.IModule[]]
        # Optional set of redis modules to enable in this database - modules can only be added at create time.
        # To construct, see NOTES section for MODULE properties and create a hash table.
        ${Module},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol]
        # Specifies whether redis clients can connect using TLS-encrypted or plaintext redis protocols - default is Encrypted
        # Allowed values: Encrypted, Plaintext
        ${ClientProtocol},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.Int32]
        # TCP port of the database endpoint - defaults to an available port
        # Specified at create time.
        ${Port},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy]
        # Redis eviction policy - default is VolatileLRU
        # Allowed values: AllKeysLFU, AllKeysLRU, AllKeysRandom, VolatileLRU, VolatileLFU, VolatileTTL, VolatileRandom, NoEviction
        ${EvictionPolicy},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # Name for the group of linked database resources
        ${GroupNickname},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILinkedDatabase[]]
        # List of database resources to link with this database
        # To construct, see NOTES section for GEOREPLICATIONLINKEDDATABASE properties and create a hash table.
        ${LinkedDatabase},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy]
        # Clustering policy - default is OSSCluster
        # Specified at create time.
        # Allowed values: EnterpriseCluster, OSSCluster
        ${ClusteringPolicy},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # Key encryption key Url versioned only. Ex: https://contosovault.vault.azure.net/keys/contosokek/562a4bb76b524a1493a6afe8e536ee78"
        ${CustomerManagedKeyEncryptionKeyUrl},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ManagedServiceIdentityType])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ManagedServiceIdentityType]
        # Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).
        ${IdentityType},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api40.IUserAssignedIdentities]))]
        [System.Collections.Hashtable]
        # The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests.
        ${IdentityUserAssignedIdentity},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.CmkIdentityType])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.CmkIdentityType]
        # Only userAssignedIdentity is supported in this API version; other types may be supported in the future
        ${KeyEncryptionKeyIdentityType},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # User assigned identity to use for accessing key encryption key Url. Ex: /subscriptions/<sub uuid>/resourceGroups/<resource group>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myId.
        ${KeyEncryptionKeyIdentityUserAssignedIdentityResourceId},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # [Preview] Sets whether AOF persistence is enabled.
        # After enabling AOF persistence, you will be unable to disable it.
        # Support for disabling AOF persistence after enabling will be added at a later date.
        ${AofPersistenceEnabled},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency]
        # [Preview] Sets the frequency at which data is written to disk if AOF persistence is enabled.
        # Allowed values: 1s, always
        ${AofPersistenceFrequency},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # [Preview] Sets whether RDB persistence is enabled.
        # After enabling RDB persistence, you will be unable to disable it.
        # Support for disabling RDB persistence after enabling will be added at a later date.
        ${RdbPersistenceEnabled},

        [Parameter(ParameterSetName='CreateClusterWithDatabase')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency]
        # [Preview] Sets the frequency at which a snapshot of the database is created if RDB persistence is enabled.
        # Allowed values: 1h, 6h, 12h
        ${RdbPersistenceFrequency},

        [Parameter(ParameterSetName='CreateClusterOnly', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Advanced - Do not automatically create a default database.
        # Warning: The cache will not be usable until you create a database.
        ${NoDatabase},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        $GetPSBoundParameters = @{} + $PSBoundParameters
        $null = $GetPSBoundParameters.Remove("NoDatabase")
        $null = $GetPSBoundParameters.Remove("Module")
        $null = $GetPSBoundParameters.Remove("ClientProtocol")
        $null = $GetPSBoundParameters.Remove("Port")
        $null = $GetPSBoundParameters.Remove("EvictionPolicy")
        $null = $GetPSBoundParameters.Remove("ClusteringPolicy")
        $null = $GetPSBoundParameters.Remove("AofPersistenceEnabled")
        $null = $GetPSBoundParameters.Remove("AofPersistenceFrequency")
        $null = $GetPSBoundParameters.Remove("RdbPersistenceEnabled")
        $null = $GetPSBoundParameters.Remove("RdbPersistenceFrequency")
        $null = $GetPSBoundParameters.Remove("GroupNickname")
        $null = $GetPSBoundParameters.Remove("LinkedDatabase")
        $cluster = Az.RedisEnterpriseCache.internal\New-AzRedisEnterpriseCache @GetPSBoundParameters

        if (('CreateClusterOnly') -contains $PSCmdlet.ParameterSetName)
        {
            $cluster.Database = @{}
            return $cluster
        }

        $null = $PSBoundParameters.Remove("NoDatabase")
        $null = $PSBoundParameters.Remove("Location")
        $null = $PSBoundParameters.Remove("Sku")
        $null = $PSBoundParameters.Remove("Capacity")
        $null = $PSBoundParameters.Remove("MinimumTlsVersion")
        $null = $PSBoundParameters.Remove("Zone")
        $null = $PSBoundParameters.Remove("Tag")
        $null = $PSBoundParameters.Remove("IdentityType")
        $null = $PSBoundParameters.Remove("IdentityUserAssignedIdentity")
        $null = $PSBoundParameters.Remove("CustomerManagedKeyEncryptionKeyUrl")
        $null = $PSBoundParameters.Remove("KeyEncryptionKeyIdentityType")
        $null = $PSBoundParameters.Remove("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId")
        $null = $PSBoundParameters.Add("DatabaseName", "default")
        $database = Az.RedisEnterpriseCache.internal\New-AzRedisEnterpriseCacheDatabase @PSBoundParameters
        $cluster.Database = @{$database.Name = $database}

        return $cluster
    }
}
