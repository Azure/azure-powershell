function Get-AzBillingPeriod_ListExpandedFilter {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20180301Preview.IBillingPeriod')]
    [CmdletBinding(DefaultParameterSetName='ListExpandedFilter', PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Description('Gets a named billing period.  This is only supported for Azure Web-Direct subscriptions. Other subscription types which were not purchased directly through the Azure web portal are not supported through this preview API.')]
    param(
        [Parameter(Mandatory, HelpMessage='Azure Subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='Azure Subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Azure Subscription ID.
        ${SubscriptionId},

        [Parameter(HelpMessage='The end date (YYYY-MM-DD) in UTC of the billing period.')]
        [System.DateTime]
        # The end date (YYYY-MM-DD) in UTC of the billing period.
        ${EndDate},

        [Parameter(HelpMessage='May be used to limit the number of results to the most recent N billing periods.')]
        [Alias('MaxCount')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='$top', PossibleTypes=([System.Int32]), Description='May be used to limit the number of results to the most recent N billing periods.')]
        [System.Int32]
        # May be used to limit the number of results to the most recent N billing periods.
        ${Top},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        if ($PSBoundParameters.ContainsKey("EndDate"))
        {
            $DateTimeParameterFormat = "yyyy-MM-dd"
            $To = $EndDate.ToString($DateTimeParameterFormat)
            $Filter = "billingPeriodEndDate le $To"
            $null = $PSBoundParameters.Add("Filter", $Filter)
            $null = $PSBoundParameters.Remove("EndDate")
        }

        Az.Billing\Get-AzBillingPeriod @PSBoundParameters
    }
}