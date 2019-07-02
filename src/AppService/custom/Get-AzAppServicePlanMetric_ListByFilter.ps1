function Get-AzAppServicePlanMetric_ListByFilter {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IResourceMetric')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Profile('latest-2019-04-30')]
    param(
        [Parameter(Mandatory, HelpMessage='Name of the App Service plan.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Path')]
        [System.String]
        ${Name},

        [Parameter(Mandatory, HelpMessage='Name of the resource group to which the resource belongs.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Path')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(HelpMessage='Specify <code>true</code> to include instance details. The default is <code>false</code>.')]
        [Alias('InstanceDetails')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Query')]
        [System.Management.Automation.SwitchParameter]
        ${Detail},

        [Parameter(HelpMessage='Name(s) of the web app metric(s) to filter by.')]
        [Alias('Metrics')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Query')]
        [System.String[]]
        ${Metric},

        [Parameter(HelpMessage='Start time of the metrics to filter by.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Query')]
        [System.DateTime]
        ${StartTime},

        [Parameter(HelpMessage='End time fo the metrics to filter by.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Query')]
        [System.DateTime]
        ${EndTime},

        [Parameter(HelpMessage='Granularity of the metrics to filter by. Allow values are PT1M, PT1H, P1D.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Query')]
        [System.String]
        ${Granularity},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        $Filter = ''
        $FilterStarted = $false
        if ($PSBoundParameters.ContainsKey("Metric"))
        {
            $Filter += "name.value eq '$($Metric[0])'"
            if ($Metric.Count -gt 1)
            {
                $Filter = "(" + $Filter
                for ($Index = 1; $Index -lt $Metric.Count; $Index++)
                {
                    $Filter += " or name.value eq '$($Metric[$Index])'"
                }

                $Filter += ")"
            }

            $FilterStarted = $true
            $PSBoundParameters.Remove("Metric") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("StartTime"))
        {
            $Format = "yyyy-MM-ddTHH:mm:ssZ"
            if ($FilterStarted)
            {
                $Filter += " and "
            }

            $Filter += "startTime eq $($StartTime.ToString($Format))"
            $FilterStarted = $true
            $PSBoundParameters.Remove("StartTime") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("EndTime"))
        {
            $Format = "yyyy-MM-ddTHH:mm:ssZ"
            if ($FilterStarted)
            {
                $Filter += " and "
            }

            $Filter += "endTime eq $($EndTime.ToString($Format))"
            $FilterStarted = $true
            $PSBoundParameters.Remove("EndTime") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("Granularity"))
        {
            if ($FilterStarted)
            {
                $Filter += " and "
            }

            $Filter += "timeGrain eq duration'$Granularity'"
            $FilterStarted = $true
            $PSBoundParameters.Remove("Granularity") | Out-Null
        }

        $PSBoundParameters.Add("Filter", $Filter) | Out-Null
        Az.WebSites\Get-AzAppServicePlanMetric @PSBoundParameters
    }
}