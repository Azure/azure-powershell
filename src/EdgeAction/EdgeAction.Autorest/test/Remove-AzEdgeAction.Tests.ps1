if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEdgeAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEdgeAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEdgeAction' {
    BeforeAll { Initialize-EdgeActionTestScenario {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eadeletedec01"
        New-EdgeActionTestResource -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
    } }

    AfterAll {
        Complete-EdgeActionTestScenario -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
    }

    It 'Delete' {
        # Test deleting edge action
        # Delete the edge action
        { Remove-AzEdgeAction -ResourceGroupName $resourceGroupName `
            -Name $edgeActionName } | Should -Not -Throw
        
        $remaining = Invoke-EdgeActionTestCommand 'Get-AzEdgeAction' @{
            ResourceGroupName = $script:resourceGroupName; Name = $script:edgeActionName
        } "parent '$($script:edgeActionName)'" -AllowNotFound
        $remaining.NotFound | Should -Be $true
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
