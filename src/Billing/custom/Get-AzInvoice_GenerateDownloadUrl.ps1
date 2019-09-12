function Get-AzInvoice_GenerateDownloadUrl {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IInvoiceSummary', 'Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20180301Preview.IInvoice', 'Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IInvoiceListResult')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Description('Get the invoice by name.')]
    param(
        [Parameter(Mandatory, HelpMessage='Azure Subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='Azure Subscription ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Azure Subscription ID.
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='If set, signals to generate the download URL of the invoice(s).')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='$expand', PossibleTypes=([System.String]), Description='May be used to expand the downloadUrl property within a list of invoices. This enables download links to be generated for multiple invoices at once. By default, downloadURLs are not included when listing invoices.')]
        [System.Management.Automation.SwitchParameter]
        # If set, signals to generate the download URL of the invoice(s).
        ${GenerateDownloadUrl},

        [Parameter(HelpMessage='May be used to limit the number of results to the most recent N invoices.')]
        [Alias('MaxCount')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='$top', PossibleTypes=([System.Int32]), Description='May be used to limit the number of results to the most recent N invoices.')]
        [System.Int32]
        # May be used to limit the number of results to the most recent N invoices.
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
        $null = $PSBoundParameters.Remove("GenerateDownloadUrl")
        $null = $PSBoundParameters.Add("Expand", "downloadUrl")
        Az.Billing\Get-AzInvoice @PSBoundParameters
    }
}