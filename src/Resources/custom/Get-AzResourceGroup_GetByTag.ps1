function Get-AzResourceGroup_GetByTag {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourceGroup')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, HelpMessage='The tag hashtable to filter resource groups by. The single key-value pair should be the tag name and value, respectively, to filter by.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(HelpMessage='The number of results to return. If null is passed, returns all resource groups.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.Int32]
        ${Top},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        $TagName = ''
        $TagValue = ''
        if ($Tag.Keys.Count -eq 1)
        {
            $TagName = $Tag.Keys | ForEach-Object { $_ }
            $TagValue = $Tag[$TagName]
        }

        $Filter = ""
        if (-not [string]::IsNullOrEmpty($TagName))
        {
            $Filter += "tagName eq '$TagName'"
        }

        if (-not [string]::IsNullOrEmpty($TagValue))
        {
            if (-not [string]::IsNullOrEmpty($TagName))
            {
                $Filter += " and "
            }

            $Filter += "tagValue eq '$TagValue'"
        }

        $PSBoundParameters.Add("Filter", $Filter) | Out-Null
        $PSBoundParameters.Remove("Tag") | Out-Null
        Az.Resources\Get-AzResourceGroup @PSBoundParameters
    }
}