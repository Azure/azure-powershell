if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPeering'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPeering.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPeering' {
    It 'UpdateExpanded' {
        {
            $tags=@{hello='world'}
            $peering = Update-AzPeering -Name DemoPeering -ResourceGroupName DemoRG -Tag $tags
            $peering.Name | Should -Be "DemoPeering"
        } | Should -Not -Throw
    }
}
