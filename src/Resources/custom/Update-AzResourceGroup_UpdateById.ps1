function Update-AzResourceGroup_UpdateById {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourceGroup')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(SupportsShouldProcess, PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The ID of the resource group.')]
        [Alias('ResourceId')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${Id},

        [Parameter(HelpMessage='The ID of the resource that manages this resource group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${ManagedBy},

        [Parameter(HelpMessage='The tags attached to the resource group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourceGroupTags]
        ${Tag},

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
        $Tokens = $Id.Split("/", [System.StringSplitOptions]::RemoveEmptyEntries)
        $PSBoundParameters.Add("Name", $Tokens[3]) | Out-Null
        $PSBoundParameters.Add("ResourceGroupName", $Tokens[3]) | Out-Null
        $PSBoundParameters.Remove("Id") | Out-Null
        Az.Resources\Update-AzResourceGroup @PSBoundParameters
    }
}