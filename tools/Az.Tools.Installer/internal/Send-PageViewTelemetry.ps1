function Send-PageViewTelemetry
{

    [CmdletBinding()]
    Param
    (
        [Parameter(
            Mandatory=$true,
            HelpMessage='Specify the page or operation name.')]
        [System.Management.Automation.CommandInfo]
        [ValidateNotNullOrEmpty()]
        $CommandInfo,

        [Parameter(
            Mandatory=$false,
            HelpMessage='Specify the start time when cmdlet is invoked.')]
        [System.DateTime]
        [ValidateNotNull()]
        $StartDateTime,

        [Parameter(
            Mandatory=$false,
            HelpMessage='Specify the duration (time elapsed) that view or operation took.')]
        [System.TimeSpan]
        [ValidateNotNull()]
        $Duration,

        [Parameter(Mandatory=$false)]
        [Hashtable]
        $CustomProperties
    )
    Process
    {
        if($null -eq [Constants]::TelemetryClient) 
        {
            $TelemetryClient = New-Object Microsoft.ApplicationInsights.TelemetryClient
            $TelemetryClient.InstrumentationKey = [Constants]::PublicTelemetryInstrumentationKey
            $TelemetryClient.Context.Session.Id = $CurrentSessionId
            $TelemetryClient.Context.Device.OperatingSystem = [System.Environment]::OSVersion.ToString()
            [Constants]::TelemetryClient = $TelemetryClient
        }

        $client = [Constants]::TelemetryClient

        $page = New-Object Microsoft.ApplicationInsights.DataContracts.PageViewTelemetry
        $page.Name = "cmdletInvocation"
        $page.Duration = $Duration

        $page.Properties["IsSuccess"] = $True.ToString()
        $page.Properties["OS"] = [System.Environment]::OSVersion.ToString()

        $page.Properties["x-ms-client-request-id"]= [Constants]::CurrentSessionId
        $page.Properties["PowerShellVersion"]= $PSVersionTable.PSVersion.ToString();
        
        if($null -ne $MyInvocation.MyCommand)
        {
            $page.Properties["ModuleName"] = $MyInvocation.MyCommand.ModuleName
            if($null -ne $MyInvocation.MyCommand.Module -and $null -ne $MyInvocation.MyCommand.Module.Version)
            {
                $page.Properties["ModuleVersion"] = $MyInvocation.MyCommand.Module.Version.ToString()
            }
        }
        $page.Properties["start-time"]= $StartDateTime
        $page.Properties["end-time"]= (Get-Date).ToUniversalTime().ToString("o")
        $page.Properties["duration"]= $Duration.ToString("c");
        
        # prepare custom properties
        # convert the hashtable to a custom object, if properties were supplied.

        if ($PSBoundParameters.ContainsKey('CustomProperties') -and $CustomProperties.Count -gt 0) 
        {
            foreach ($Key in $CustomProperties.Keys) 
            {
                $page.Properties[$Key] = $CustomProperties[$Key]
            }
        }

        foreach ($Key in $page.Properties) 
        {
            Write-Debug "collect telemetry data[$Key]=$($CustomProperties[$Key])"
        }

        $client.TrackPageView($page)

        try
        {
            //$client.Flush()
        }
        catch 
        {
            Write-Warning -Message "Encountered exception while trying to flush telemetry events: $_"
        }
    }
}