# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------
function Send-PageViewTelemetry
{

    [CmdletBinding()]
    Param
    (
        [Parameter(
            Mandatory=$true,
            HelpMessage='Specify the source cmdlet object.')]
        [System.Management.Automation.PSCmdlet]
        [ValidateNotNullOrEmpty()]
        $SourcePSCmdlet,

        [Parameter(
            Mandatory=$false,
            HelpMessage='Specify the parameter set name.')]
        [System.Boolean]
        $IsSuccess,

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
        if ('false' -eq $env:Azure_PS_Data_Collection) {
            Write-Debug -Message 'Skip telemtry because of environment setting'
            return
        }

        if ($null -eq [Constants]::TelemetryClient) {
            Write-Debug -Message 'Initialize telemetry client'
            $TelemetryClient = New-Object Microsoft.ApplicationInsights.TelemetryClient
            $TelemetryClient.InstrumentationKey = [Constants]::PublicTelemetryInstrumentationKey
            $TelemetryClient.Context.Session.Id = [Constants]::CurrentSessionId
            $TelemetryClient.Context.Device.OperatingSystem = [System.Environment]::OSVersion.ToString()
            [Constants]::TelemetryClient = $TelemetryClient
        }

        if ([string]::IsNullOrWhiteSpace([Constants]::HashMacAddress)) {
            $macAddress = ''
            $nics = [System.Net.NetworkInformation.NetworkInterface]::GetAllNetworkInterfaces()
            foreach ($nic in $nics) {
                if($nic.OperationalStatus -eq 'Up' -and -not [string]::IsNullOrWhiteSpace($nic.GetPhysicalAddress())) {
                    $macAddress = $nic.GetPhysicalAddress().ToString()
                    break
                }
            }

            if ($macAddress -ne '') {
                $bytes = [System.Text.Encoding]::UTF8.GetBytes($macAddress)
                $sha256 = New-Object -TypeName System.Security.Cryptography.SHA256CryptoServiceProvider
                $macAddress = [System.BitConverter]::ToString($sha256.ComputeHash($bytes))
                $macAddress = $macAddress.Replace('-', '').ToLowerInvariant()
            }
            [Constants]::HashMacAddress = $macAddress
        }

        $client = [Constants]::TelemetryClient

        $page = New-Object Microsoft.ApplicationInsights.DataContracts.PageViewTelemetry
        $page.Name = "cmdletInvocation"
        $page.Duration = $Duration

        if ($PSBoundParameters.ContainsKey('IsSuccess')) {
            $page.Properties['IsSuccess'] = $PSBoundParameters['IsSuccess'].ToString()
        } else {
            $page.Properties['IsSuccess'] = $true.ToString()
        }
        $page.Properties['x-ms-client-request-id'] = [Constants]::CurrentSessionId
        $page.Properties['OS'] = [System.Environment]::OSVersion.ToString()
        $page.Properties['HostVersion'] = $PSCmdlet.Host.Version
        $page.Properties['HashMacAddress'] = [Constants]::HashMacAddress
        $page.Properties['PowerShellVersion'] = $PSVersionTable.PSVersion.ToString()
        $page.Properties['Command'] = $SourcePSCmdlet.MyInvocation.MyCommand.Name
        $page.Properties['CommandParameterSetName'] = $SourcePSCmdlet.ParameterSetName
        $page.Properties['CommandInvocationName'] = $SourcePSCmdlet.MyInvocation.InvocationName

        if($null -ne $SourcePSCmdlet.MyInvocation.BoundParameters) {
            $parameters = ""
            foreach ($Key in $SourcePSCmdlet.MyInvocation.BoundParameters.Keys) {
                $parameters += "-$Key *** "
            }            
            $page.Properties['CommandParameters'] = $parameters
        }
        
        if($null -ne $MyInvocation.MyCommand)
        {
            $page.Properties["ModuleName"] = $MyInvocation.MyCommand.ModuleName
            if($null -ne $MyInvocation.MyCommand.Module -and $null -ne $MyInvocation.MyCommand.Module.Version)
            {
                $page.Properties["ModuleVersion"] = $MyInvocation.MyCommand.Module.Version.ToString()
            }
        }
        $page.Properties["start-time"]= $StartDateTime.ToUniversalTime().ToString("o")
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

        $client.TrackPageView($page)
        Write-Debug -Message "Finish sending metric"
        
        try
        {
            $client.Flush()
        }
        catch 
        {
            Write-Warning -Message "Encountered exception while trying to flush telemetry events: $_"
        }
    }
}