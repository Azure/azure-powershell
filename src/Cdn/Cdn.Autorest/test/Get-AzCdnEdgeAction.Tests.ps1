if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnEdgeAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnEdgeAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnEdgeAction' {
    BeforeAll {
        $script:EdgeActionName = "eaget"
        $script:TestResourceGroup = $env.ResourceGroupName
        
        # Create test edge action for Get tests
        New-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
    }
    
    AfterAll {
        try {
            Remove-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -NoWait -ErrorAction SilentlyContinue
        } catch {
            # Ignore cleanup errors
        }
    }

    It 'List' {
        # Test listing all edge actions in resource group
        $result = Get-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup
        
        # Should return a collection containing our test edge action
        $result | Should -Not -BeNullOrEmpty
        $ourAction = $result | Where-Object { $_.Name -eq $script:EdgeActionName }
        $ourAction | Should -Not -BeNullOrEmpty
        $ourAction.Name | Should -Be $script:EdgeActionName
    }

    It 'Get' {
        # Test getting specific edge action by name
        $result = Get-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName
        
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $script:EdgeActionName
        $result.ResourceGroupName | Should -Be $script:TestResourceGroup
    }

    It 'List1' -skip {
    }
}
