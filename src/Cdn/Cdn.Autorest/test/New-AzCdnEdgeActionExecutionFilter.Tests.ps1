if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnEdgeActionExecutionFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnEdgeActionExecutionFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnEdgeActionExecutionFilter' {
    It 'CreateExpanded' {
        $resourceGroupName = $env.ResourceGroupName
        $edgeActionName = "eaefnew" 
        $version = "v1"
        $executionFilter = "efnew"

        New-AzCdnEdgeAction -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"

        New-AzCdnEdgeActionVersion -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -Version $version -DeploymentType "zip" -IsDefaultVersion $false -Location "global"

        New-AzCdnEdgeActionExecutionFilter -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -VersionId $version -ExecutionFilter $executionFilter -Location "global" -ExecutionFilterIdentifierHeaderName "N" -ExecutionFilterIdentifierHeaderValue "V"

        Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName

        # Poll for ProvisioningState until it becomes Succeeded
        $maxWaitTime = 20 * 60  # 20 minutes maximum wait time
        $pollInterval = 5 * 60  # 5 minutes polling interval
        $elapsedTime = 0
        $provisioningState = $null
        
        do {
            try {
                $filter = Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -ExecutionFilter $executionFilter
                $provisioningState = $filter.ProvisioningState
                Write-Host "Current ProvisioningState: $provisioningState (Elapsed: $($elapsedTime / 60) minutes)"
                
                if ($provisioningState -eq "Succeeded") {
                    break
                }
            } catch {
                Write-Host "Failed to get execution filter, continuing to wait..."
            }
            
            if ($elapsedTime -ge $maxWaitTime) {
                throw "Timeout waiting for ProvisioningState to become Succeeded after $($maxWaitTime / 60) minutes"
            }
            
            Start-Sleep $pollInterval
            $elapsedTime += $pollInterval
            
        } while ($provisioningState -ne "Succeeded")
        
        # Now update the execution filter
        Update-AzCdnEdgeActionExecutionFilter -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -ExecutionFilter $executionFilter -ExecutionFilterIdentifierHeaderName "N1" -ExecutionFilterIdentifierHeaderValue "V1" -VersionId $version

        # Cleanup
        Remove-AzCdnEdgeActionExecutionFilter -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -ExecutionFilter $executionFilter
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
