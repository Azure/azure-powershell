if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPeeringServiceLocation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPeeringServiceLocation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPeeringServiceLocation' {
    It 'List' {
        {
            $locations = Get-AzPeeringServiceLocation
            $locations.Count | Should -BeGreaterThan 0

            $jpLocations = Get-AzPeeringServiceLocation -Country Japan
            $jpLocations.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
