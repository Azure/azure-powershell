if(($null -eq $TestName) -or ($TestName -contains 'Update-AzEdgeAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzEdgeAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzEdgeAction' {
    BeforeAll {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eaupdatefixed01"
        
        # Create edge action for testing
        New-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName `
            -SkuName "Standard" `
            -SkuTier "Standard" `
            -Location "global"
    }

    AfterAll {
        # Clean up test edge action
        Remove-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
