<#
.Synopsis
Gets information about a RedisEnterprise cluster and its associated database
.Description
Gets information about a RedisEnterprise cluster and its associated database
.Example
PS C:\> Get-AzRedisEnterpriseCache -ResourceGroupName "MyGroup" -Name "MyCache"

Location Name    Type                            Zone
-------- ----    ----                            ----
East US  MyCache Microsoft.Cache/redisEnterprise

ClientProtocol    : Encrypted
ClusteringPolicy  : OSSCluster
EvictionPolicy    : VolatileLRU
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache/databases/default
Module            :
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases

.Example
PS C:\> Get-AzRedisEnterpriseCache -ResourceGroupName "MyGroup"

Location Name     Type                            Zone
-------- ----     ----                            ----
East US  MyCache1 Microsoft.Cache/redisEnterprise

ClientProtocol    : Encrypted
ClusteringPolicy  : OSSCluster
EvictionPolicy    : VolatileLRU
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache1/databases/default
Module            :
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases

East US  MyCache2 Microsoft.Cache/redisEnterprise {1, 2, 3}

ClientProtocol    : Plaintext
ClusteringPolicy  : EnterpriseCluster
EvictionPolicy    : NoEviction
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache2/databases/default
Module            : {RedisBloom, RedisTimeSeries, RediSearch}
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.ICluster
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IDatabase
.Link
https://docs.microsoft.com/en-us/powershell/module/az.redisenterprisecache/get-azredisenterprisecache
#>

function Get-AzRedisEnterpriseCache {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.ICluster],[Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IDatabase])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory, HelpMessage='The name of the resource group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},

        [Parameter(HelpMessage='The name of the RedisEnterprise cluster.')]
        [Alias('ClusterName')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the RedisEnterprise cluster.
        ${Name},

        [Parameter(HelpMessage='Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        if ($PSBoundParameters.ContainsKey("Name"))
        {
            Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCache @PSBoundParameters

            $clusterName = $PSBoundParameters["Name"]
            $null = $PSBoundParameters.Remove("Name")
            $null = $PSBoundParameters.Add("ClusterName", $clusterName)
            Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCacheDatabase @PSBoundParameters
        }
        else
        {
            $Clusters = Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCache @PSBoundParameters

            foreach ($clusterName in $Clusters.Name)
            {
                $GetPSBoundParameters = @{} + $PSBoundParameters
                $null = $GetPSBoundParameters.Add("ClusterName", $clusterName)
                Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCache @GetPSBoundParameters
                Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCacheDatabase @GetPSBoundParameters
            }
        }
    }
}
