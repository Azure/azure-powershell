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
    Stop maintenance mode for a scale unit node.

.PARAMETER ScaleUnitNode
    Name of the scale unit node.

.PARAMETER Location
    Location of the resource.

.EXAMPLE

Enable-AzsScaleUnitNode -Location "local" -ScaleUnitNode "HC1n25r2236"

ProvisioningState
-----------------------
Succeeded


#>
function Enable-ScaleUnitNode
{
    [OutputType([Microsoft.AzureStack.Management.Fabric.Admin.Models.OperationStatus])]
    [CmdletBinding(DefaultParameterSetName='ScaleUnitNodes_StopMaintenanceMode')]
    param(    
        [Parameter(Mandatory = $true, ParameterSetName = 'ScaleUnitNodes_StopMaintenanceMode')]
        [System.String]
        $ScaleUnitNode,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'ScaleUnitNodes_StopMaintenanceMode')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $false)]
        [switch]
        $AsJob
    )

    Begin 
    {
	}

    Process {
    
    $ErrorActionPreference = 'Stop'
    
    $FabricAdminClient = Get-ServiceClient

    $skippedCount = 0
    $returnedCount = 0
    if ('ScaleUnitNodes_StopMaintenanceMode' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation StopMaintenanceModeWithHttpMessagesAsync on $FabricAdminClient.'
        $taskResult = $FabricAdminClient.ScaleUnitNodes.StopMaintenanceModeWithHttpMessagesAsync($Location, $ScaleUnitNode)
    } else {
        Write-Verbose -Message 'Failed to map parameter set to operation method.'
        throw 'Module failed to find operation to execute.'
    }

    Write-Verbose -Message "Waiting for the operation to complete."

    $PSSwaggerJobScriptBlock = {
        [CmdletBinding()]
        param(    
            [Parameter(Mandatory = $true)]
            [System.Threading.Tasks.Task]
            $TaskResult
        )
        if ($TaskResult) {
            $result = $null
        $ErrorActionPreference = 'Stop'
                    
        $null = $taskResult.AsyncWaitHandle.WaitOne()
                    
        Write-Debug -Message "$($taskResult | Out-String)"

        $hasBody = $taskResult.Result -and (Get-Member -InputObject $taskResult.Result -Name 'Body') -and $taskResult.Result.Body

        if($taskResult.IsFaulted -and -not $hasBody)
        {
            Write-Verbose -Message 'Operation failed.'
            Throw "$($taskResult.Exception.InnerExceptions | Out-String)"
        } 
        elseif ($taskResult.IsCanceled -and -not $hasBody)
        {
            Write-Verbose -Message 'Operation got cancelled.'
            Throw 'Operation got cancelled.'
        }
        else
        {
            Write-Verbose -Message 'Operation completed successfully.'

            if($hasBody)
            {
                $result = $taskResult.Result.Body
                Write-Debug -Message "$($result | Out-String)"
                $result
            }
        }
            
        }
    }

    $PSCommonParameters = Get-PSCommonParameter -CallerPSBoundParameters $PSBoundParameters

    if($AsJob)
    {
        $ScriptBlockParameters = New-Object -TypeName 'System.Collections.Generic.Dictionary[string,object]'
        $ScriptBlockParameters['TaskResult'] = $TaskResult
        $ScriptBlockParameters['AsJob'] = $AsJob
        $PSCommonParameters.GetEnumerator() | ForEach-Object { $ScriptBlockParameters[$_.Name] = $_.Value }

        Start-PSSwaggerJobHelper -ScriptBlock $PSSwaggerJobScriptBlock `
                                     -CallerPSBoundParameters $ScriptBlockParameters `
                                     -CallerPSCmdlet $PSCmdlet `
                                     @PSCommonParameters
    }
    else
    {
        Invoke-Command -ScriptBlock $PSSwaggerJobScriptBlock `
                       -ArgumentList $taskResult `
                       @PSCommonParameters
    }
    }

    End {
    }
}
