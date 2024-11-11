if(($null -eq $TestName) -or ($TestName -contains 'Set-AzConnectedLicenseProfileFeature'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzConnectedLicenseProfileFeature.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzConnectedLicenseProfileFeature' {
    It '__AllParameterSets' {
        $productfeature = Set-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"
        $productfeature | Should -Not -BeNullOrEmpty
    }
}
