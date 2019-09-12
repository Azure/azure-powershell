function Get-AzBudget {
    [Alias('Get-AzConsumptionBudget')]
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api201901.IBudget')]
    [CmdletBinding(DefaultParameterSetName='ListBySubscription', PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Description('Gets the budget for the scope by budget name.')]
    param(
        [Parameter(ParameterSetName='ListBySubscription', Mandatory, HelpMessage='The id of the subscription to scope the budgets to.')]
        [Parameter(ParameterSetName='ListByResourceGroup', Mandatory, HelpMessage='The id of the subscription to scope the budgets to.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The id of the subscription to scope the budgets to.
        ${SubscriptionId},

        [Parameter(ParameterSetName='ListByResourceGroup', Mandatory, HelpMessage='The resource group name to scope the budgets to.')]
        [System.String]
        # The resource group name to scope the budgets to.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ListByBillingAccount', Mandatory, HelpMessage='The id of the billing account to scope the budgets to.')]
        [Parameter(ParameterSetName='ListByDepartment', Mandatory, HelpMessage='The id of the billing account to scope the budgets to.')]
        [Parameter(ParameterSetName='ListByEnrollmentAccount', Mandatory, HelpMessage='The id of the billing account to scope the budgets to.')]
        [Parameter(ParameterSetName='ListByBillingProfile', Mandatory, HelpMessage='The id of the billing account to scope the budgets to.')]
        [Parameter(ParameterSetName='ListByInvoiceSection', Mandatory, HelpMessage='The id of the billing account to scope the budgets to.')]
        [System.String]
        # The id of the billing account to scope the budgets to.
        ${BillingAccountId},

        [Parameter(ParameterSetName='ListByDepartment', Mandatory, HelpMessage='The id of the department to scope the budgets to.')]
        [System.String]
        # The id of the department to scope the budgets to.
        ${DepartmentId},

        [Parameter(ParameterSetName='ListByEnrollmentAccount', Mandatory, HelpMessage='The id of the enrollment account to scope the budgets to.')]
        [System.String]
        # The id of the enrollment account to scope the budgets to.
        ${EnrollmentAccountId},

        [Parameter(ParameterSetName='ListByBillingProfile', Mandatory, HelpMessage='The id of the billing profile to scope the budgets to.')]
        [System.String]
        # The id of the billing profile to scope the budgets to.
        ${BillingProfileId},

        [Parameter(ParameterSetName='ListByInvoiceSection', Mandatory, HelpMessage='The id of the invoice section to scope the budgets to.')]
        [System.String]
        # The id of the invoice section to scope the budgets to.
        ${InvoiceSectionId},

        [Parameter(ParameterSetName='ListByManagementGroup', Mandatory, HelpMessage='The id of the management group to scope the budgets to.')]
        [System.String]
        # The id of the management group to scope the budgets to.
        ${ManagementGroupId},

        [Parameter(ParameterSetName='ListBySubscription', HelpMessage='Budget Name.')]
        [Parameter(ParameterSetName='ListByResourceGroup', HelpMessage='Budget Name.')]
        [Alias('BudgetName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='budgetName', Required, PossibleTypes=([System.String]), Description='Budget Name.')]
        [System.String]
        # Budget Name.
        ${Name},

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
        $Scope = $null
        if ($PSBoundParameters.ContainsKey("SubscriptionId"))
        {
            $Scope = "/subscriptions/$SubscriptionId"
            $null = $PSBoundParameters.Remove("SubscriptionId")
            if ($PSBoundParameters.ContainsKey("ResourceGroupName"))
            {
                $Scope += "/resourceGroups/$ResourceGroupName"
                $null = $PSBoundParameters.Remove("ResourceGroupName")
            }
        }

        if ($PSBoundParameters.ContainsKey("BillingAccountId"))
        {
            $Scope = "/providers/Microsoft.Billing/billingAccounts/$BillingAccountId"
            $null = $PSBoundParameters.Remove("BillingAccountId")
            if ($PSBoundParameters.ContainsKey("DepartmentId"))
            {
                $Scope += "/departments/$DepartmentId"
                $null = $PSBoundParameters.Remove("DepartmentId")
            }

            if ($PSBoundParameters.ContainsKey("EnrollmentAccountId"))
            {
                $Scope += "/enrollmentAccounts/$EnrollmentAccountId"
                $null = $PSBoundParameters.Remove("EnrollmentAccountId")
            }

            if ($PSBoundParameters.ContainsKey("BillingProfileId"))
            {
                $Scope += "/billingProfiles/$BillingProfileId"
                $null = $PSBoundParameters.Remove("BillingProfileId")
            }

            if ($PSBoundParameters.ContainsKey("InvoiceSectionId"))
            {
                $Scope += "/invoiceSections/$InvoiceSectionId"
                $null = $PSBoundParameters.Remove("InvoiceSectionId")
            }
        }

        if ($PSBoundParameters.ContainsKey("ManagementGroupId"))
        {
            $Scope = "/providers/Microsoft.Management/managementGroups/$ManagementGroupId"
            $null = $PSBoundParameters.Remove("ManagementGroupId")
        }

        $null = $PSBoundParameters.Add("Scope", $Scope)
        Az.Billing\Get-AzBudget @PSBoundParameters
    }
}