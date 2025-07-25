if(($null -eq $TestName) -or ($TestName -contains 'Start-AzAcatQuickEvaluation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzAcatQuickEvaluation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzAcatQuickEvaluation' {
    It 'TriggerExpanded' {
        $response = Start-AzAcatQuickEvaluation -Resources @($env.ResourceId)
        $response.QuickAssessment.Count | Should -BeGreaterOrEqual 1
    }
}
