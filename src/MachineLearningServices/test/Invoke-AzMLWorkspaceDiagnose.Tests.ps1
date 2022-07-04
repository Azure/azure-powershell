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
        { Invoke-AzMLWorkspaceDiagnose -ResourceGroupName ml-rg-test -Name mlworkspace-cli01 -ApplicationInsightId @{'key1'="/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.insights/components/mlworkspacecli3073090957"} } | Should -Not -Throw
    }
}
