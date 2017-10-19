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
Get the health of services.Get a list of all services healthGet a list of all services health

.PARAMETER Filter
    OData filter parameter.

.PARAMETER Skip
    Skip the first N items as specified by the parameter value.

.PARAMETER Location
    Location name.

.PARAMETER Top
    Return the top N items as specified by the parameter value. Applies after the -Skip parameter.

.PARAMETER ServiceHealth
    Service Health name.

.EXAMPLE

Get-AzsServiceHealth -Location "local"

HealthState Type                                                                Name                                 InfraURI
----------- ----                                                                ----                                 --------
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 0a2df6d8-4570-4cf5-8c8f-8d96dc1fd2a9 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.KeyVault.Admin/locations/local/infraRoles/Key Vault
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 12bf0da4-e310-4767-bc5f-5d31c0414062 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Storage.Admin/farms/f1031738-a8c7-4528-99f2-b712b7...
Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 2f2fc564-8714-41c3-89ea-ab7f9bf8483b /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Update.Admin/updateLocations/local/infraRoles/Updates
Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 423f8608-0c64-4d87-8c07-811adfb7cc41 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Compute.Admin/infraRoles/Compute
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 98751379-f9fe-4791-bc6f-f77eb1de3440 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Network.Admin/infraRoles/Network
Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths bb58377f-3d7d-4d7f-b3b3-d433d422bf9e /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.InfrastructureInsights.Admin/regionHealths/local/i...
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/infraRoles/Capa...

.EXAMPLE

Get-AzsServiceHealth -Location local -ServiceHealth 98751379-f9fe-4791-bc6f-f77eb1de3440

HealthState Type                                                                Name                                 InfraURI                                                                                                                             RegistrationId
----------- ----                                                                ----                                 --------                                                                                                                             --------------
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 98751379-f9fe-4791-bc6f-f77eb1de3440 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Network.Admin/infraRoles/Network 98751379-f9fe-479...

#>
function Get-ServiceHealth
{
    [OutputType([Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ServiceHealth])]
    [CmdletBinding(DefaultParameterSetName='ServiceHealths_List')]
    param(    
        [Parameter(Mandatory = $false, ParameterSetName = 'ServiceHealths_List')]
        [string]
        $Filter,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'ServiceHealths_List')]
        [int]
        $Skip = -1,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'ServiceHealths_List')]
        [Parameter(Mandatory = $true, ParameterSetName = 'ServiceHealths_Get')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'ServiceHealths_List')]
        [int]
        $Top = -1,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'ServiceHealths_Get')]
        [System.String]
        $ServiceHealth
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
    if ('ServiceHealths_List' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $InfrastructureInsightsAdminClient.'
        $taskResult = $InfrastructureInsightsAdminClient.ServiceHealths.ListWithHttpMessagesAsync($Location, $(if ($oDataQuery) { New-Object -TypeName "Microsoft.Rest.Azure.OData.ODataQuery``1[Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ServiceHealth]" -ArgumentList $oDataQuery } else { $null }))
    } elseif ('ServiceHealths_Get' -eq $PsCmdlet.ParameterSetName ) {
        Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $InfrastructureInsightsAdminClient.'
        $taskResult = $InfrastructureInsightsAdminClient.ServiceHealths.GetWithHttpMessagesAsync($Location, $ServiceHealth)
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
                if ($result -is [Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ServiceHealth]]) {
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
            $taskResult = $InfrastructureInsightsAdminClient.ServiceHealths.ListNextWithHttpMessagesAsync($result.nextLink)
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
                if ($result -is [Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ServiceHealth]]) {
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
