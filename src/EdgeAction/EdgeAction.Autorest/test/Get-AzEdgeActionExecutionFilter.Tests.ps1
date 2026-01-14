if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeActionExecutionFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeActionExecutionFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeActionExecutionFilter' {
    BeforeAll {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eagetfilterfixed01"
        $script:version = "v1"
        $script:filterName = "filterget"
        $script:testFilePath = Join-Path $PSScriptRoot 'test_handler.js'
        
        # Create edge action, version, and filter for testing
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
        
        # Verify deployment completed before creating filter
        $versionStatus = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version
        if ($versionStatus.ProvisioningState -ne "Succeeded" -or $versionStatus.ValidationStatus -ne "Succeeded") {
            throw "Deploy did not complete successfully. ProvisioningState: $($versionStatus.ProvisioningState), ValidationStatus: $($versionStatus.ValidationStatus)"
        }
        
        # Store the version resource ID for execution filter
        $script:versionId = $versionStatus.Id
        
        New-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilter $script:filterName `
            -Version $script:versionId `
            -Location "global" `
            -ExecutionFilterIdentifierHeaderName "X-Filter-Id" `
            -ExecutionFilterIdentifierHeaderValue "test-filter-value"
    }

    AfterAll {
        # Clean up test edge action
        Remove-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName -ErrorAction SilentlyContinue
    }

    It 'List' {
        # Test listing all execution filters
        $results = Get-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName
        
        $results | Should -Not -BeNullOrEmpty
        $results.Name | Should -Contain $script:filterName
    }

    It 'Get' {
        # Test getting specific execution filter
        $result = Get-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilter $script:filterName
        
        $result.Name | Should -Be $script:filterName
        # Note: Execution filter may still be in "Provisioning" state even after creation completes
        # The LRO cmdlet returns when the PUT is accepted, but background provisioning continues
        # Only validate the immutable properties (name and header configuration)
        $result.ExecutionFilterIdentifierHeaderName | Should -Be "X-Filter-Id"
        $result.ExecutionFilterIdentifierHeaderValue | Should -Be "test-filter-value"
    }

    It 'GetViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
