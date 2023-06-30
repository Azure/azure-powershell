if (($null -eq $TestName) -or ($TestName -contains 'Repro'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)

  # additional ceremony to support legacy tests
  . (Join-Path $PSScriptRoot 'ScenarioTests\PolicyTests.ps1')
  . (Join-Path $PSScriptRoot '..\..\..\..\tools\TestFx\Common.ps1')
  . (Join-Path $PSScriptRoot '..\..\..\..\tools\TestFx\Assert.ps1')
  . (Join-Path $PSScriptRoot 'ScenarioTests\Common.ps1')

  # end additional ceremony

  #$TestRecordingFile = Join-Path $PSScriptRoot 'Legacy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function Test-ManagementGroupParameter {
    $policyName = 'ps4e562d50e1'
    $list = Get-AzPolicyDefinition -ManagementGroupName $managementGroup | ?{ ($_.Name -eq 'test2') -or ($_.Name -eq $policyName) }
    Assert-AreEqual 2 $list.Count
}

Describe 'Repro' {
    It 'ReproTest' {
        { Test-ManagementGroupParameter } | Should -Not -Throw
    }
}
