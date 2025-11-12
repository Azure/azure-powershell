if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnEdgeActionVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnEdgeActionVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnEdgeActionVersion' {
    BeforeAll {
        $script:EdgeActionName = "eavget"
        $script:Version = "v1"
        $script:TestResourceGroup = $env.ResourceGroupName
        
        # Create test edge action and version for Get tests
        New-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
        New-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $script:Version -DeploymentType "zip" -IsDefaultVersion $false -Location "global"
    }

    It 'List' {
        # Test listing all edge action versions
        $result = Get-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName
        
        # Should return a collection containing our test version
        $result | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        # Test getting specific edge action version by name
        $result = Get-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $script:Version
        
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $script:Version
    }
}
