if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPeeringRpUnbilledPrefix'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnvDogfood.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPeeringRpUnbilledPrefix.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPeeringRpUnbilledPrefix' {
    It 'List' {
        {
            $prefixes =  Get-AzPeeringRpUnbilledPrefix -PeeringName CdnPeering -ResourceGroupName Seattle
            $prefixes.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
