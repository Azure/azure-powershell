if(($null -eq $TestName) -or ($TestName -contains 'New-AzPeeringCheckServiceProviderAvailabilityInputObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPeeringCheckServiceProviderAvailabilityInputObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPeeringCheckServiceProviderAvailabilityInputObject' {
    It '__AllParameterSets' {
        {
            $providerAvailability = New-AzPeeringCheckServiceProviderAvailabilityInputObject -PeeringServiceLocation Osaka -PeeringServiceProvider IIJ
            $providerAvailability.PeeringServiceLocation | Should -Be "Osaka"
        } | Should -Not -Throw
    }
}
