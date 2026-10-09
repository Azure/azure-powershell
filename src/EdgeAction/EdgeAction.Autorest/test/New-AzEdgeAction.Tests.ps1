if(($null -eq $TestName) -or ($TestName -contains 'New-AzEdgeAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEdgeAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEdgeAction' {
    BeforeAll { Initialize-EdgeActionTestScenario {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eatestdec01"
    } }

    AfterAll {
        Complete-EdgeActionTestScenario -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
    }

    It 'CreateExpanded' {
        # Test creating edge action with expanded parameters
        $result = New-EdgeActionTestResource -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
        
        $result.Name | Should -Be $edgeActionName
        $result.Location | Should -Be "global"
        $result.ProvisioningState | Should -Be "Succeeded"
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
