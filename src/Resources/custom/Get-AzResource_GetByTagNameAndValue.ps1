function Get-AzResource_GetByTagNameAndValue {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IGenericResource')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, HelpMessage='The tag name to filter resources by.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.String]
        ${TagName},

        [Parameter(HelpMessage='The tag value to filter resources by.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.String]
        ${TagValue},

        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(HelpMessage='The resource group with the resources to get.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='The $expand query parameter. You can expand createdTime and changedTime. For example, to expand both properties, use $expand=changedTime,createdTime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.String]
        ${Expand},

        [Parameter(HelpMessage='The number of results to return. If null is passed, returns all resources.')]
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
        $Filter = "tagName eq '$TagName'"

        if ($PSBoundParameters.ContainsKey("TagValue"))
        {
            $Filter += " and tagValue eq '$TagValue'"
            $PSBoundParameters.Remove("TagValue") | Out-Null
        }

        $PSBoundParameters.Add("Filter", $Filter) | Out-Null
        $PSBoundParameters.Remove("TagName") | Out-Null
        Az.Resources\Get-AzResource @PSBoundParameters
    }
}