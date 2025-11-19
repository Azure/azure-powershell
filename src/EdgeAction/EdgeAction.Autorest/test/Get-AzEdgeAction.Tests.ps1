if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeAction' {
    BeforeAll {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "ea-get-" + (RandomString $false 8)
        
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

    It 'List' {
        # Test listing all edge actions in subscription
        $results = Get-AzEdgeAction
        $results | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        # Test getting specific edge action
        $result = Get-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName
        
        $result.Name | Should -Be $script:edgeActionName
        $result.Location | Should -Be "global"
        $result.ProvisioningState | Should -Be "Succeeded"
    }

    It 'List1' {
        # Test listing edge actions in resource group
        $results = Get-AzEdgeAction -ResourceGroupName $script:resourceGroupName
        $results | Should -Not -BeNullOrEmpty
        $results.Name | Should -Contain $script:edgeActionName
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
