if(($null -eq $TestName) -or ($TestName -contains 'Update-AzEdgeActionExecutionFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzEdgeActionExecutionFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzEdgeActionExecutionFilter' {
    BeforeAll {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eaupdfilter" + (RandomString $false 8)
        $script:version1 = "v1"
        $script:version2 = "v2"
        $script:filterName = "filterupdate"
        $script:testFilePath = Join-Path $PSScriptRoot 'test_handler.js'
        
        # Create edge action, versions, and filter for testing
        New-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName `
            -SkuName "Standard" `
            -SkuTier "Standard" `
            -Location "global"
        
        New-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version1 `
            -DeploymentType "file" `
            -IsDefaultVersion $true `
            -Location "global"
        
        New-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2 `
            -DeploymentType "file" `
            -IsDefaultVersion $false `
            -Location "global"
        
        # Deploy code to both versions (required for execution filter)
        # Deploy is an LRO that waits for completion
        Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version1 `
            -FilePath $script:testFilePath
        
        Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2 `
            -FilePath $script:testFilePath
        
        # Verify both deployments completed before proceeding with tests
        $v1Status = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version1
        $v2Status = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2
        if ($v1Status.ProvisioningState -ne "Succeeded" -or $v2Status.ProvisioningState -ne "Succeeded" -or 
            $v1Status.ValidationStatus -ne "Succeeded" -or $v2Status.ValidationStatus -ne "Succeeded") {
            throw "Deploy did not complete successfully for both versions. V1: $($v1Status.ProvisioningState)/$($v1Status.ValidationStatus), V2: $($v2Status.ProvisioningState)/$($v2Status.ValidationStatus)"
        }
        
        # Store the version resource IDs for execution filter
        $script:version1Id = $v1Status.Id
        $script:version2Id = $v2Status.Id
        
        New-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilter $script:filterName `
            -Version $script:version1Id `
            -Location "global" `
            -ExecutionFilterIdentifierHeaderName "X-Filter-Id" `
            -ExecutionFilterIdentifierHeaderValue "test-filter-value"
    }

    AfterAll {
        # Clean up test edge action
        Remove-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' -skip {
        # Test updating execution filter to point to different version
        # Skipping: Update cmdlet doesn't have -Version parameter
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityEdgeActionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
