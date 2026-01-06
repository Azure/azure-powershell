if(($null -eq $TestName) -or ($TestName -contains 'Switch-AzEdgeActionVersionDefault'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Switch-AzEdgeActionVersionDefault.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Switch-AzEdgeActionVersionDefault' {
    # All tests skipped - known bug.
    # BeforeAll and AfterAll removed to avoid resource creation for skipped tests

    It 'Swap' -skip {
        # Verify initial state: v1 is default, v2 is not
        $v1Before = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version1
        $v2Before = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2
        
        $v1Before.IsDefaultVersion | Should -Be "True"
        $v2Before.IsDefaultVersion | Should -Be "False"
        
        # Switch default version from v1 to v2
        # Switch is an LRO that waits for completion
        Switch-AzEdgeActionVersionDefault -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2
        
        # Verify final state: v1 is not default, v2 is default
        $v1After = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version1
        $v2After = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2
        
        $v1After.IsDefaultVersion | Should -Be "False"
        $v2After.IsDefaultVersion | Should -Be "True"
    }

    It 'SwapViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwapViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
