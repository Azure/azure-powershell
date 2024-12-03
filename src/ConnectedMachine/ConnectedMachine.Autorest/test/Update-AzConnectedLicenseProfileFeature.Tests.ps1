if(($null -eq $TestName) -or ($TestName -contains 'Update-AzConnectedLicenseProfileFeature'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConnectedLicenseProfileFeature.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzConnectedLicenseProfileFeature' {
    It '__AllParameterSets' {
        $productfeature = Update-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"
        $productfeature | Should -Not -BeNullOrEmpty
    }
}
