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
        $script:resourceGroupName = "clitests"
        $script:edgeActionName = "ea-getfilter-" + (RandomString $false 8)
        $script:version = "v1"
        $script:filterName = "filter-get"
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
        Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version `
            -FilePath $script:testFilePath
        
        New-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilterName $script:filterName `
            -Version $script:version `
            -Location "global"
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
            -ExecutionFilterName $script:filterName
        
        $result.Name | Should -Be $script:filterName
        $result.Version | Should -Be $script:version
        $result.ProvisioningState | Should -Be "Succeeded"
    }

    It 'GetViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
