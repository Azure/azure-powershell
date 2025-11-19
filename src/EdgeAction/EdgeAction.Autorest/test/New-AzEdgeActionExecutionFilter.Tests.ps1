if(($null -eq $TestName) -or ($TestName -contains 'New-AzEdgeActionExecutionFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEdgeActionExecutionFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEdgeActionExecutionFilter' {
    BeforeAll {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "ea-filter-" + (RandomString $false 8)
        $script:version = "v1"
        $script:testFilePath = Join-Path $PSScriptRoot 'test_handler.js'
        
        # Create edge action and version (required for execution filter)
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

    It 'CreateExpanded' {
        # Test creating execution filter
        $filterName = "filter-" + (RandomString $false 8)
        
        $result = New-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -ExecutionFilterName $filterName `
            -Version $script:version `
            -Location "global"
        
        $result.Name | Should -Be $filterName
        $result.Version | Should -Be $script:version
        $result.ProvisioningState | Should -Be "Succeeded"
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityEdgeActionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
