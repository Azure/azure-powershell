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
        $script:edgeActionName = "ea-delfilter-" + (RandomString $false 8)
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
        Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version `
            -FilePath $script:testFilePath
    }

    AfterAll {
        # Clean up test edge action
        Remove-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName -ErrorAction SilentlyContinue
    }

    It 'Delete' {
        # Test deleting execution filter
        $filterName = "filter-delete"
        
        # Create filter to delete
        New-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilterName $filterName `
            -Version $script:version `
            -Location "global"
        
        # Delete the filter
        { Remove-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilterName $filterName } | Should -Not -Throw
        
        # Verify it's deleted
        { Get-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilterName $filterName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
