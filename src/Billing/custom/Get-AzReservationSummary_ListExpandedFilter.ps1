function Get-AzReservationSummary_ListExpandedFilter {
    [Alias('Get-AzConsumptionReservationSummary')]
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181001.IReservationSummary')]
    [CmdletBinding(DefaultParameterSetName='ListExpandedFilter', PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Billing.Description('Lists the reservations summaries for daily or monthly grain.')]
    param(
        [Parameter(Mandatory, HelpMessage='Order Id of the reservation')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='reservationOrderId', Required, PossibleTypes=([System.String]), Description='Order Id of the reservation')]
        [System.String]
        # Order Id of the reservation
        ${ReservationOrderId},

        [Parameter(HelpMessage='Id of the reservation')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='reservationId', Required, PossibleTypes=([System.String]), Description='Id of the reservation')]
        [System.String]
        # Id of the reservation
        ${ReservationId},

        [Parameter(Mandatory, HelpMessage='Can be daily or monthly')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Billing.Support.Datagrain])]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Runtime.Info(SerializedName='grain', Required, PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Billing.Support.Datagrain]), Description='Can be daily or monthly')]
        [Microsoft.Azure.PowerShell.Cmdlets.Billing.Support.Datagrain]
        # Can be daily or monthly
        ${Grain},

        [Parameter(HelpMessage='The start date (YYYY-MM-DD) in UTC of the reservation summary.')]
        [System.DateTime]
        # The start date (YYYY-MM-DD) in UTC of the reservation summary.
        ${StartDate},

        [Parameter(HelpMessage='The end date (YYYY-MM-DD) in UTC of the reservation summary.')]
        [System.DateTime]
        # The end date (YYYY-MM-DD) in UTC of the reservation summary.
        ${EndDate},

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
        $DateTimeParameterFormat = "yyyy-MM-dd"
        $Filter = $null
        if ($PSBoundParameters.ContainsKey("StartDate"))
        {
            $From = $StartDate.ToString($DateTimeParameterFormat)
            $Filter = "properties/UsageDate ge $From"
            $null = $PSBoundParameters.Remove("StartDate")
        }

        if ($PSBoundParameters.ContainsKey("EndDate"))
        {
            $To = $EndDate.ToString($DateTimeParameterFormat)
            if ($null -ne $Filter)
            {
                $Filter += " and "
            }

            $Filter += "properties/UsageDate le $To"
            $null = $PSBoundParameters.Remove("EndDate")
        }

        $null = $PSBoundParameters.Add("Filter", $Filter)
        Az.Billing\Get-AzReservationSummary @PSBoundParameters
    }
}