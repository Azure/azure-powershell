function Test-AzResourceMove_ValidateByComponents {
    [OutputType('System.Boolean')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(SupportsShouldProcess, PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, HelpMessage='The name of the resource group containing the resources to move.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${SourceResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${SubscriptionId},

        [Parameter(HelpMessage='When specified, PassThru will force the cmdlet return a ''bool'' given that there isn''t a return type by default.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${PassThru},

        [Parameter(HelpMessage='The IDs of the resources.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String[]]
        ${Resource},

        [Parameter(HelpMessage='The target subscription id. If not value is provided, the subscription id of the current context will be used.')]
        [Alias("DestinationSubscriptionId")]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${TargetSubscriptionId},

        [Parameter(Mandatory, HelpMessage='The target resource group name.')]
        [Alias("DestinationResourceGroupName")]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${TargetResourceGroupName},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(HelpMessage='Run the command as a job')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${AsJob},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        $DestinationSubscriptionId = (Get-AzContext).Subscription.Id
        if ($PSBoundParameters.ContainsKey("TargetSubscriptionId"))
        {
            $DestinationSubscriptionId = $TargetSubscriptionId
            $PSBoundParameters.Remove("TargetSubscriptionId") | Out-Null
        }

        $TargetResourceGroup = "/subscriptions/{0}/resourceGroups/{1}" -f $DestinationSubscriptionId, $TargetResourceGroupName
        $PSBoundParameters.Add("TargetResourceGroup", $TargetResourceGroup) | Out-Null
        $PSBoundParameters.Remove("TargetResourceGroupName") | Out-Null
        Az.Resources\Test-AzResourceMove @PSBoundParameters
    }
}