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
    Get a list of resources?.

.PARAMETER ServiceRegistrationId
    Service registration id.

.PARAMETER Filter
    OData filter parameter.

.PARAMETER Skip
    Skip the first N items as specified by the parameter value.

.PARAMETER ResourceRegistrationId
    Resource registration id.

.PARAMETER Location
    Location name.

.PARAMETER Top
    Return the top N items as specified by the parameter value. Applies after the -Skip parameter.


#>
function Get-ResourceHealth
{
    [OutputType([Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ResourceHealth])]
    [CmdletBinding(DefaultParameterSetName='ResourceHealths_List')]
    param(    
        [Parameter(Mandatory = $true, ParameterSetName = 'ResourceHealths_Get')]
        [Parameter(Mandatory = $true, ParameterSetName = 'ResourceHealths_List')]
        [System.String]
        $ServiceRegistrationId,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceHealths_Get')]
        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceHealths_List')]
        [string]
        $Filter,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceHealths_List')]
        [int]
        $Skip = -1,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'ResourceHealths_Get')]
        [System.String]
        $ResourceRegistrationId,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'ResourceHealths_Get')]
        [Parameter(Mandatory = $true, ParameterSetName = 'ResourceHealths_List')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceHealths_List')]
        [int]
        $Top = -1
    )

    Begin 
    {
	    Initialize-PSSwaggerDependencies -Azure
        $tracerObject = $null
        if (('continue' -eq $DebugPreference) -or ('inquire' -eq $DebugPreference)) {
            $oldDebugPreference = $global:DebugPreference
			$global:DebugPreference = "continue"
            $tracerObject = New-PSSwaggerClientTracing
            Register-PSSwaggerClientTracing -TracerObject $tracerObject
        }
	}

    Process {
    
    $ErrorActionPreference = 'Stop'
    
    $InfrastructureInsightsAdminClient = Get-ServiceClient
    

    $oDataQuery = ""
    if ($Filter) { $oDataQuery += "&`$Filter=$Filter" }
    $oDataQuery = $oDataQuery.Trim("&")
    
    

    $skippedCount = 0
    $returnedCount = 0
    if ('ResourceHealths_List' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $InfrastructureInsightsAdminClient.'
        $taskResult = $InfrastructureInsightsAdminClient.ResourceHealths.ListWithHttpMessagesAsync($Location, $ServiceRegistrationId, $(if ($oDataQuery) { New-Object -TypeName "Microsoft.Rest.Azure.OData.ODataQuery``1[Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ResourceHealth]" -ArgumentList $oDataQuery } else { $null }))
    } elseif ('ResourceHealths_Get' -eq $PsCmdlet.ParameterSetName ) {
        Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $InfrastructureInsightsAdminClient.'
        $taskResult = $InfrastructureInsightsAdminClient.ResourceHealths.GetWithHttpMessagesAsync($Location, $ServiceRegistrationId, $ResourceRegistrationId, $(if ($PSBoundParameters.ContainsKey('Filter')) { $Filter } else { [NullString]::Value }))
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
                if ($result -is [Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ResourceHealth]]) {
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
            $taskResult = $InfrastructureInsightsAdminClient.ResourceHealths.ListNextWithHttpMessagesAsync($result.nextLink)
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
                if ($result -is [Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ResourceHealth]]) {
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
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}
