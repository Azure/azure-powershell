<#
.Synopsis
Exports a database file from target database.
.Description
Exports a database file from target database.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Boolean
.Link
https://docs.microsoft.com/en-us/powershell/module/az.redisenterprisecache/export-azredisenterprisecachedatabase
#>
function Export-AzRedisEnterpriseCacheDatabase {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='ExportExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('ClusterName')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the RedisEnterprise cluster.
        ${Name},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # SAS Uri for the target directory to export to
        ${SasUri},

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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru},

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
        $clusterName = $PSBoundParameters["Name"]
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Add("ClusterName", $clusterName)
        $null = $PSBoundParameters.Add("DatabaseName", "default")
        Az.RedisEnterpriseCache.internal\Export-AzRedisEnterpriseCacheDatabase @PSBoundParameters
    }
}
