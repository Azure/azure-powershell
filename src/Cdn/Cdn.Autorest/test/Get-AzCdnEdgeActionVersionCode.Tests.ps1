if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnEdgeActionVersionCode'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnEdgeActionVersionCode.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnEdgeActionVersionCode' {
    BeforeAll {
        $script:EdgeActionName = "eavcget"
        $script:Version = "v1"
        $script:TestResourceGroup = $env.ResourceGroupName
        
        # Create test edge action and version for Get tests
        New-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
        New-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $script:Version -DeploymentType "file" -IsDefaultVersion $false -Location "global"
    }

    It 'GetExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        # Test getting specific edge action version by name
        $result = Get-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $script:Version
        
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $script:Version
    }

    It 'GetViaIdentityEdgeActionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
