if(($null -eq $TestName) -or ($TestName -contains 'AzHealthcareServiceNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHealthcareServiceNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzHealthcareServiceNameAvailability' {
    It 'CheckExpanded' {
        {
            $config = Test-AzHealthcareServiceNameAvailability -Name $env.fhirService1 -Type Microsoft.HealthcareApis/services
            $config.NameAvailable | Should -Be true
        } | Should -Not -Throw
    }
}