function Get-AzPriceSheet_ListExpandedFilter {
    [Alias('Get-AzConsumptionPriceSheet')]
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181001.IPriceSheetResult')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Description('Gets the price sheet for a scope by subscriptionId. Price sheet is available via this API only for May 1, 2014 or later.')]
    param(
        [Parameter(Mandatory, HelpMessage='Azure Subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='Azure Subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Azure Subscription ID.
        ${SubscriptionId},

        [Parameter(HelpMessage='Billing Period Name.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='billingPeriodName', Required, PossibleTypes=([System.String]), Description='Billing Period Name.')]
        [System.String]
        # Billing Period Name.
        ${BillingPeriodName},

        [Parameter(HelpMessage='If set, signals to expand the price sheets based on meter details.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='$expand', PossibleTypes=([System.String]), Description='May be used to expand the properties/meterDetails within a price sheet. By default, these fields are not included when returning price sheet.')]
        [System.String]
        # If set, signals to expand the price sheets based on meter details.
        ${ExpandMeterDetail},

        [Parameter(HelpMessage='May be used to limit the number of results to the top N results.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='$top', PossibleTypes=([System.Int32]), Description='May be used to limit the number of results to the top N results.')]
        [System.Int32]
        # May be used to limit the number of results to the top N results.
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
        $null = $PSBoundParameters.Remove("ExpandMeterDetail")
        $null = $PSBoundParameters.Add("Expand", "properties/meterDetails")
        Az.Billing\Get-AzPriceSheet @PSBoundParameters
    }
}