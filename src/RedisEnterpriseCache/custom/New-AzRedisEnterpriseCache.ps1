<#
.Synopsis
Creates or updates an existing (overwrite/recreate, with potential downtime) cache cluster with 'default' database
.Description
Creates or updates an existing (overwrite/recreate, with potential downtime) cache cluster with 'default' database
.Example
PS C:\> New-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -Location "West US" -SkuName "Enterprise_E10" -Zones "1","2","3" -Modules "{name:RedisBloom, args:`"ERROR_RATE 0.00 INITIAL_SIZE 400`"}","{name:RedisTimeSeries, args:`"RETENTION_POLICY 20`"}","{name:RediSearch}"

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.ICluster
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

MODULES <IModule[]>: Optional set of redis modules to enable in this database - modules can only be added at creation time.
  Name <String>: The name of the module, e.g. 'RedisBloom', 'RediSearch', 'RedisTimeSeries'
  [Args <String>]: Configuration options for the module, e.g. 'ERROR_RATE 0.00 INITIAL_SIZE 400'.

.Link
https://docs.microsoft.com/en-us/powershell/module/az.redisenterprisecache/new-azredisenterprisecache
#>

function New-AzRedisEnterpriseCache {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.ICluster])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage='The name of the RedisEnterprise cluster.')]
        [Alias('ClusterName')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the RedisEnterprise cluster.
        ${Name},

        [Parameter(Mandatory, HelpMessage='The name of the resource group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},

        [Parameter(HelpMessage='Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The geo-location where the resource lives')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # The geo-location where the resource lives
        ${Location},

        [Parameter(Mandatory, HelpMessage='The type of RedisEnterprise cluster to deploy. Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName])]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName]
        # The type of RedisEnterprise cluster to deploy.
        # Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)
        ${SkuName},

        [Parameter(HelpMessage='The minimum TLS version for the cluster to support, e.g. 1.2')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # The minimum TLS version for the cluster to support, e.g.
        # '1.2'
        ${MinimumTlsVersion},

        [Parameter(HelpMessage='The size of the RedisEnterprise cluster. Defaults to 2 or 3 depending on SKU. Valid values are (2, 4, 6, ...) for Enterprise SKUs and (3, 9, 15, ...) for Flash SKUs.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.Int32]
        # The size of the RedisEnterprise cluster.
        # Defaults to 2 or 3 depending on SKU.
        # Valid values are (2, 4, 6, ...) for Enterprise SKUs and (3, 9, 15, ...) for Flash SKUs.
        ${SkuCapacity},

        [Parameter(HelpMessage='Resource tags.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.ITrackedResourceTags]))]
        [System.Collections.Hashtable]
        # Resource tags.
        ${Tag},

        [Parameter(HelpMessage='The zones where this cluster will be deployed.')]
        [Alias('Zone')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String[]]
        # The zones where this cluster will be deployed.
        ${Zones},

        [Parameter(HelpMessage='Optional set of redis modules to enable in this database - modules can only be added at creation time.')]
        [Alias('Module')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IModule[]]
        # Optional set of redis modules to enable in this database - modules can only be added at creation time.
        # To construct, see NOTES section for MODULES properties and create a hash table.
        ${Modules},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(HelpMessage='Run the command as a job')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

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

        [Parameter(HelpMessage='Run the command asynchronously')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

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
        $clusterName = $PSBoundParameters["Name"]
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Add("ClusterName", $clusterName)

        $GetPSBoundParameters = @{} + $PSBoundParameters
        $null = $GetPSBoundParameters.Remove("Modules")
        Az.RedisEnterpriseCache.internal\New-AzRedisEnterpriseCache @GetPSBoundParameters

        $null = $PSBoundParameters.Remove("Location")
        $null = $PSBoundParameters.Remove("SkuName")
        $null = $PSBoundParameters.Remove("MinimumTlsVersion")
        $null = $PSBoundParameters.Remove("SkuCapacity")
        $null = $PSBoundParameters.Remove("Tag")
        $null = $PSBoundParameters.Remove("Zones")
        $null = $PSBoundParameters.Add("DatabaseName", "default")
        Az.RedisEnterpriseCache.internal\New-AzRedisEnterpriseCacheDatabase @PSBoundParameters
    }
}
