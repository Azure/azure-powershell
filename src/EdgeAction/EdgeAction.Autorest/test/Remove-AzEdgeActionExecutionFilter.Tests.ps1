if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEdgeActionExecutionFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEdgeActionExecutionFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEdgeActionExecutionFilter' {
    BeforeAll {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eadelfilter" + (RandomString $false 8)
        $script:version = "v1"
        $script:testFilePath = Join-Path $PSScriptRoot 'test_handler.js'
        
        # Create edge action and version for testing
        New-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName `
            -SkuName "Standard" `
            -SkuTier "Standard" `
            -Location "global"
        
        New-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version `
            -DeploymentType "file" `
            -IsDefaultVersion $true `
            -Location "global"
        
        # Deploy code to version (required for execution filter)
        # Deploy is an LRO that waits for completion
        Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version `
            -FilePath $script:testFilePath
        
        # Verify deployment completed before proceeding with tests
        $versionStatus = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version
        if ($versionStatus.ProvisioningState -ne "Succeeded" -or $versionStatus.ValidationStatus -ne "Succeeded") {
            throw "Deploy did not complete successfully. ProvisioningState: $($versionStatus.ProvisioningState), ValidationStatus: $($versionStatus.ValidationStatus)"
        }
        
        # Store the version resource ID for execution filter
        $script:versionId = $versionStatus.Id
        
        # Create an execution filter to test deletion
        $script:filterName = "filter" + (RandomString $false 8)
        New-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilter $script:filterName `
            -Version $script:versionId `
            -Location "global" `
            -ExecutionFilterIdentifierHeaderName "X-Filter-Id" `
            -ExecutionFilterIdentifierHeaderValue "test-filter-value"
        
        # Wait for execution filter to reach Succeeded state (required before deletion)
        # Execution filter creation is an LRO and may take several minutes
        $maxWaitMinutes = 10
        $startTime = Get-Date
        $filterReady = $false
        
        while (((Get-Date) - $startTime).TotalMinutes -lt $maxWaitMinutes) {
            $filterStatus = Get-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
                -EdgeActionName $script:edgeActionName `
                -ExecutionFilter $script:filterName
            
            if ($filterStatus.ProvisioningState -eq "Succeeded") {
                $filterReady = $true
                break
            }
            
            Start-Sleep -Seconds 10
        }
        
        if (-not $filterReady) {
            throw "Execution filter did not reach Succeeded state within $maxWaitMinutes minutes. Current state: $($filterStatus.ProvisioningState)"
        }
    }

    AfterAll {
        # Clean up test edge action
        Remove-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName -ErrorAction SilentlyContinue
    }

    It 'Delete' {
        # Test deleting execution filter
        # Note: BeforeAll waits for filter to reach "Succeeded" state (up to 10 minutes)
        # This is required because the API rejects deletion if filter is in "Provisioning" state
        Remove-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilter $script:filterName
        
        # Verify deletion by trying to get the filter (should not exist)
        $filter = Get-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilter $script:filterName -ErrorAction SilentlyContinue
        $filter | Should -BeNullOrEmpty
    }

    It 'DeleteViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
