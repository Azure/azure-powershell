if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPeeringRegisteredPrefix'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPeeringRegisteredPrefix.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPeeringRegisteredPrefix' {
    It 'List' {
        {
            $prefixes = Get-AzPeeringRegisteredPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG
            $prefixes.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $prefix = Get-AzPeeringRegisteredPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG -Name accessibilityTesting1
            $prefix.Name | Should -Be "accessibilityTesting1"
        } | Should -Not -Throw
    }

}
