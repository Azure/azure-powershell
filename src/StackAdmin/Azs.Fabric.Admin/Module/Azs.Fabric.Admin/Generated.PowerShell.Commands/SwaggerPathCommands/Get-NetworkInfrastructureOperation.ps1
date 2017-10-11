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
    Get the status of a network fabric operation.

.PARAMETER Provider
    Name of the provider.

.PARAMETER Location
    Location of the resource.

.PARAMETER NetworkOperationResult
    Id of a network fabric operation.

.EXAMPLE

Get-NetworkInfrastructureOperation -Location "local" -Provider "Microsoft.Fabric.Admin" -NetworkOperationResult "fdcdefb6-6fd0-402c-8b0c-5765b8fc4dc1"

ProvisioningState
-----------------------
Succeeded

#>
function Get-NetworkInfrastructureOperation
{
    [OutputType([Microsoft.AzureStack.Management.Fabric.Admin.Models.OperationStatus])]
    [CmdletBinding(DefaultParameterSetName='NetworkFabricOperations_Get')]
    param(    
        [Parameter(Mandatory = $true, ParameterSetName = 'NetworkFabricOperations_Get')]
        [System.String]
        $Provider,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'NetworkFabricOperations_Get')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'NetworkFabricOperations_Get')]
        [System.String]
        $NetworkOperationResult
    )

    Begin 
    {
	}

    Process {
    
    $ErrorActionPreference = 'Stop'
    
    $FabricAdminClient = Get-ServiceClient

    $skippedCount = 0
    $returnedCount = 0
    if ('NetworkFabricOperations_Get' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $FabricAdminClient.'
        $taskResult = $FabricAdminClient.NetworkFabricOperations.GetWithHttpMessagesAsync($Location, $Provider, $NetworkOperationResult)
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
