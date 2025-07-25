if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzMLWorkspaceDiagnose'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzMLWorkspaceDiagnose.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzMLWorkspaceDiagnose' {
    It 'DiagnoseExpanded' {
        { Invoke-AzMLWorkspaceDiagnose -ResourceGroupName $env.TestGroupName -Name $env.mainWorkspace -ApplicationInsightId @{'key1'=$env.InsightsID1} } | Should -Not -Throw
    }
}
