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
    Get a list of all volumes at a location.

.PARAMETER Filter
    OData filter parameter.

.PARAMETER StorageSubSystem
    Name of the storage system.

.PARAMETER Skip
    Skip the first N items as specified by the parameter value.

.PARAMETER Volume
    Name of the volume.

.PARAMETER Location
    Location of the resource.

.PARAMETER Top
    Return the top N items as specified by the parameter value. Applies after the -Skip parameter.

.PARAMETER StoragePool
    Storage pool name.

.EXAMPLE

Get-AzsInfrastructureVolume -Location local -StoragePool SU1_Pool -StorageSubSystem S-Cluster.azurestack.local

Type                                                                          FileSystem RemainingSizeGB Name     SizeGB
----                                                                          ---------- --------------- ----     ------
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems/storagePools/volumes CSVFS_ReFS 2201            a42d219b 2525
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems/storagePools/volumes CSVFS_ReFS 1220            a42d219c 2525

.EXAMPLE

Get-AzsInfrastructureVolume -Location local -StoragePool SU1_Pool -StorageSubSystem S-Cluster.azurestack.local -Volume a42d219b

Type                                                                          FileSystem RemainingSizeGB Name     SizeGB
----                                                                          ---------- --------------- ----     ------
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems/storagePools/volumes CSVFS_ReFS 2201            a42d219b 2525

#>
function Get-InfrastructureVolume
{
    [OutputType([Microsoft.AzureStack.Management.Fabric.Admin.Models.Volume])]
    [CmdletBinding(DefaultParameterSetName='InfrastructureVolumes_List')]
    param(    
        [Parameter(Mandatory = $false, ParameterSetName = 'InfrastructureVolumes_List')]
        [string]
        $Filter,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'InfrastructureVolumes_Get')]
        [Parameter(Mandatory = $true, ParameterSetName = 'InfrastructureVolumes_List')]
        [System.String]
        $StorageSubSystem,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'InfrastructureVolumes_List')]
        [int]
        $Skip = -1,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'InfrastructureVolumes_Get')]
        [System.String]
        $Volume,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'InfrastructureVolumes_Get')]
        [Parameter(Mandatory = $true, ParameterSetName = 'InfrastructureVolumes_List')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'InfrastructureVolumes_List')]
        [int]
        $Top = -1,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'InfrastructureVolumes_Get')]
        [Parameter(Mandatory = $true, ParameterSetName = 'InfrastructureVolumes_List')]
        [System.String]
        $StoragePool
    )

    Begin 
    {
	}

    Process {
    
    $ErrorActionPreference = 'Stop'
    
    $FabricAdminClient = Get-ServiceClient

    $oDataQuery = ""
    if ($Filter) { $oDataQuery += "&`$Filter=$Filter" }
    $oDataQuery = $oDataQuery.Trim("&")
    
    

    $skippedCount = 0
    $returnedCount = 0
    if ('InfrastructureVolumes_Get' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $FabricAdminClient.'
        $taskResult = $FabricAdminClient.Volumes.GetWithHttpMessagesAsync($Location, $StorageSubSystem, $StoragePool, $Volume)
    } elseif ('InfrastructureVolumes_List' -eq $PsCmdlet.ParameterSetName ) {
        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $FabricAdminClient.'
        $taskResult = $FabricAdminClient.Volumes.ListWithHttpMessagesAsync($Location, $StorageSubSystem, $StoragePool, $(if ($oDataQuery) { New-Object -TypeName "Microsoft.Rest.Azure.OData.ODataQuery``1[Microsoft.AzureStack.Management.Fabric.Admin.Models.Volume]" -ArgumentList $oDataQuery } else { $null }))
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
                if ($result -is [Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.Fabric.Admin.Models.Volume]]) {
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
            $taskResult = $FabricAdminClient.Volumes.ListNextWithHttpMessagesAsync($result.nextLink)
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
                if ($result -is [Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.Fabric.Admin.Models.Volume]]) {
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
