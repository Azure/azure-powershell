if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceComputeKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceComputeKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceComputeKey' {
    # Specify compute type support get key. Aml compute unsupport.
    It 'List' -skip {
        { Get-AzMLWorkspaceComputeKey -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name v-diya1 } | Should -Not -Throw
    }
}
