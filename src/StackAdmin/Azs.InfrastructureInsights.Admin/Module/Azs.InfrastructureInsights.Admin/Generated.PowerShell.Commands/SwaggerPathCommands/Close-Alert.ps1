<#
The MIT License (MIT)

Copyright (c) 2017 Microsoft

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
#>

Import-Module -Name (Join-Path -Path $PSScriptRoot -ChildPath .. | Join-Path -ChildPath .. | Join-Path -ChildPath "GeneratedHelpers.psm1")
<#
.DESCRIPTION
    Close an alert.

.PARAMETER Alert
    Updated Alert Parameter.

.PARAMETER Location
    Location name.

.PARAMETER AlertName
    Name of the alert.

.PARAMETER User
    The username used to perform the operation.

.EXAMPLE

Close-AzsAlert -Location local -User  AlertCloseTests -AlertName db1a20c7-08f4-4453-96b5-0d73461a8cac -Alert $myAlert


#>
function Close-Alert
{
    [OutputType([Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert])]
    [CmdletBinding(DefaultParameterSetName='Alerts_Close')]
    param(    
        [Parameter(Mandatory = $true, ParameterSetName = 'Alerts_Close')]
        [Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert]
        $Alert,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Alerts_Close')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Alerts_Close')]
        [System.String]
        $AlertName,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Alerts_Close')]
        [System.String]
        $User
    )

    Begin 
    {
	}

    Process {
    
    $ErrorActionPreference = 'Stop'

    $InfrastructureInsightsAdminClient = Get-ServiceClient

    $skippedCount = 0
    $returnedCount = 0
    if ('Alerts_Close' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation CloseWithHttpMessagesAsync on $InfrastructureInsightsAdminClient.'
        $taskResult = $InfrastructureInsightsAdminClient.Alerts.CloseWithHttpMessagesAsync($Location, $AlertName, $User, $Alert)
    } else {
        Write-Verbose -Message 'Failed to map parameter set to operation method.'
        throw 'Module failed to find operation to execute.'
    }

    if ($TaskResult) {
        $result = $null
        $ErrorActionPreference = 'Stop'
                    
        $null = $taskResult.AsyncWaitHandle.WaitOne()
                    
        Write-Debug -Message "$($taskResult | Out-String)"

        if($taskResult.IsFaulted)
        {
            Write-Verbose -Message 'Operation failed.'
            Throw "$($taskResult.Exception.InnerExceptions | Out-String)"
        } 
        elseif ($taskResult.IsCanceled)
        {
            Write-Verbose -Message 'Operation got cancelled.'
            Throw 'Operation got cancelled.'
        }
        else
        {
            Write-Verbose -Message 'Operation completed successfully.'

            if($taskResult.Result -and
                (Get-Member -InputObject $taskResult.Result -Name 'Body') -and
                $taskResult.Result.Body)
            {
                $result = $taskResult.Result.Body
                Write-Debug -Message "$($result | Out-String)"
                $result
            }
        }
        
    }
    }

    End {
    }
}
