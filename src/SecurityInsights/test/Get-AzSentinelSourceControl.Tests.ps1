if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelSourceControl'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelSourceControl.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelSourceControl' {
    It 'List' -skip {
        $sourceControls = Get-AzSentinelsourceControl -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $sourceControls.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' -skip {
        $sourceControl = Get-AzSentinelsourceControl -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetsourceControlId
        $sourceControl.Name | Should -Be $env.GetsourceControlId
    }

    It 'GetViaIdentity' -skip {
        $sourceControl = Get-AzSentinelsourceControl -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetsourceControlId
        $sourceControlViaId = $sourceControl | Get-AzSentinelonboardingState
        $sourceControlViaId.Name | Should -Be $env.GetsourceControlId
    }
}
