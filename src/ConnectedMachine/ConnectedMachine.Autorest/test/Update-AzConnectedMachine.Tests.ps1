if(($null -eq $TestName) -or ($TestName -contains 'Update-AzConnectedMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConnectedMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzConnectedMachine' {
    
    It 'Update' {
        $updatedMachine = Update-AzConnectedMachine -Name $env.MachineName -ResourceGroupName $env.ResourceGroupName -PrivateLinkScopeResourceId $env.PrivateLinkScopeUri
        $updatedMachine | Should -Not -BeNullOrEmpty
    }

}
