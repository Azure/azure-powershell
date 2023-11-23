if(($null -eq $TestName) -or ($TestName -contains 'Test-AzPeeringRegisteredPrefix'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzPeeringRegisteredPrefix.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzPeeringRegisteredPrefix' {
    It 'Validate' {
        {
            $test = Test-AzPeeringRegisteredPrefix -Name accessibilityTesting2 -PeeringName DemoPeering -ResourceGroupName DemoRG
            $test.Name | Should -Be "accessibilityTesting2"
        } | Should -Not -Throw
    }
}
