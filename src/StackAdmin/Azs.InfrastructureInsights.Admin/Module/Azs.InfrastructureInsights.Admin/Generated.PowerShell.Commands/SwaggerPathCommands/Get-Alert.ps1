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
.SYNOPSIS
    Returns the list of all alerts in a given location.

.PARAMETER Filter
    OData filter parameter.

.PARAMETER Skip
    Skip the first N items as specified by the parameter value.

.PARAMETER Location
    Location name.

.PARAMETER AlertName
    Name of the alert.

.PARAMETER Top
    Return the top N items as specified by the parameter value. Applies after the -Skip parameter.

.EXAMPLE

Get-AzsAlert -Location local

FaultTypeId                       ClosedTimestamp     ClosedByUserAlias                           Name                                 ResourceRegistrationId
-----------                       ---------------     -----------------                           ----                                 ----------------------
ServiceFabricClusterUnhealthy     08/25/2017 04:52:27                                             148820f7-807a-4edd-857b-a23c3dcb6acf ca96c335-e545-4563-9d65-058db3a8ef15
ServiceFabricApplicationUnhealthy 08/25/2017 18:48:31                                             17d030ef-7be7-4e12-a653-6158a3bc7643
AzureStackNotActivated            08/25/2017 18:21:34 admin@mycompany.com 356fd53c-b355-4522-ab5b-1a0f385381fa
ServiceFabricApplicationUnhealthy 08/25/2017 04:33:12                                             37fab95e-8981-4657-872a-d0a904308d26
ServiceFabricApplicationUnhealthy 08/25/2017 04:52:27                                             7ff5f418-75e1-41e3-85c3-229e369313a3
ServiceFabricClusterUnhealthy     08/25/2017 04:33:12                                             b8f81ea8-cf7d-4909-a9f4-0779909e15eb ca96c335-e545-4563-9d65-058db3a8ef15
AzureStackNotActivated            08/25/2017 18:16:49 admin@mycompany.com c0328148-006b-482b-9c75-ad58c454225b
AzureStackNotActivated            08/25/2017 18:29:55 admin@mycompany.com cf278262-78cd-43eb-8cd8-9c4cac5e75f7
AzureStackNotActivated                                                                            db1a20c7-08f4-4453-96b5-0d73461a8cac



.EXAMPLE

Get-AzsAlert -Location local -Alert 148820f7-807a-4edd-857b-a23c3dcb6acf

FaultTypeId                   ClosedTimestamp     ClosedByUserAlias Name                                 ResourceRegistrationId
-----------                   ---------------     ----------------- ----                                 ----------------------
ServiceFabricClusterUnhealthy 08/25/2017 04:52:27                   148820f7-807a-4edd-857b-a23c3dcb6acf ca96c335-e545-4563-9d65-058db3a8ef15

#>
function Get-Alert
{
    [OutputType([Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert])]
    [CmdletBinding(DefaultParameterSetName='Alerts_List')]
    param(    
        [Parameter(Mandatory = $false, ParameterSetName = 'Alerts_List')]
        [string]
        $Filter,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Alerts_List')]
        [int]
        $Skip = -1,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Alerts_List')]
        [Parameter(Mandatory = $true, ParameterSetName = 'Alerts_Get')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Alerts_Get')]
        [System.String]
        $AlertName,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Alerts_List')]
        [int]
        $Top = -1
    )

    Begin 
    {
	}

    Process {
    
    $ErrorActionPreference = 'Stop'
    
    $InfrastructureInsightsAdminClient = Get-ServiceClient

    $oDataQuery = ""
    if ($Filter) { $oDataQuery += "&`$Filter=$Filter" }
    $oDataQuery = $oDataQuery.Trim("&")
    
    

    $skippedCount = 0
    $returnedCount = 0
    if ('Alerts_List' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $InfrastructureInsightsAdminClient.'
        $taskResult = $InfrastructureInsightsAdminClient.Alerts.ListWithHttpMessagesAsync($Location, $(if ($oDataQuery) { New-Object -TypeName "Microsoft.Rest.Azure.OData.ODataQuery``1[Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert]" -ArgumentList $oDataQuery } else { $null }))
    } elseif ('Alerts_Get' -eq $PsCmdlet.ParameterSetName ) {
        Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $InfrastructureInsightsAdminClient.'
        $taskResult = $InfrastructureInsightsAdminClient.Alerts.GetWithHttpMessagesAsync($Location, $AlertName)
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
                if ($result -is [Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert]]) {
                    foreach ($item in $result) {
                        if ($skippedCount++ -lt $Skip) {
                        } else {
                            if (($Top -eq -1) -or ($returnedCount++ -lt $Top)) {
                                $item
                            } else {
                                break
                            }
                        }
                    }
                } else {
                    $result
                }
            }
        }
            
        Write-Verbose -Message 'Flattening paged results.'
        # Get the next page iff 1) there is a next page and 2) any result in the next page would be returned
        while ($result -and (Get-Member -InputObject $result -Name nextLink) -and $result.nextLink -and (($Top -eq -1) -or ($returnedCount -lt $Top))) {
            Write-Debug -Message "Retrieving next page: $($result.nextLink)"
            $taskResult = $InfrastructureInsightsAdminClient.Alerts.ListNextWithHttpMessagesAsync($result.nextLink)
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
                if ($result -is [Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert]]) {
                    foreach ($item in $result) {
                        if ($skippedCount++ -lt $Skip) {
                        } else {
                            if (($Top -eq -1) -or ($returnedCount++ -lt $Top)) {
                                $item
                            } else {
                                break
                            }
                        }
                    }
                } else {
                    $result
                }
            }
        }
        }
    }
    }

    End {
    }
}
