function Get-AzEnrollmentAccount_ListExpandedFilter {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IEnrollmentAccount', 'Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20180301Preview.IEnrollmentAccount', 'Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IEnrollmentAccountListResult')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Description('Get the enrollment account by id.')]
    param(
        [Parameter(Mandatory, HelpMessage='billing Account Id.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='billingAccountName', Required, PossibleTypes=([System.String]), Description='billing Account Id.')]
        [System.String]
        # billing Account Id.
        ${BillingAccountName},

        [Parameter(HelpMessage='Enrollment Account Id.')]
        [Alias('EnrollmentAccountName', 'ObjectId')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='enrollmentAccountName', Required, PossibleTypes=([System.String]), Description='Enrollment Account Id.')]
        [System.String]
        # Enrollment Account Id.
        ${Name},

        [Parameter(HelpMessage='The tag of the enrollment account(s) to filter.')]
        [System.String]
        # The tag of the enrollment account(s) to filter.
        ${Tag},

        [Parameter(HelpMessage='If set, signals to expand the department on the returned enrollment account(s).')]
        [System.Management.Automation.SwitchParameter]
        # If set, signals to expand the department on the returned enrollment account(s).
        ${ExpandDepartment},

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
        if ($PSBoundParameters.ContainsKey("Tag"))
        {
            $Filter = "properties/tag eq '$Tag'"
            $null = $PSBoundParameters.Add("Filter", $Filter)
            $null = $PSBoundParameters.Remove("Tag")
        }

        if ($PSBoundParameters.ContainsKey("ExpandDepartment"))
        {
            $Expand = "properties/department"
            $null = $PSBoundParameters.Add("Expand", $Expand)
            $null = $PSBoundParameters.Remove("ExpandDepartment")
        }

        Az.Billing\Get-AzEnrollmentAccount @PSBoundParameters
    }
}