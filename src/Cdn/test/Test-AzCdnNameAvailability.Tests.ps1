if(($null -eq $TestName) -or ($TestName -contains 'Test-AzCdnNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzCdnNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzCdnNameAvailability'  {
    It 'CheckExpanded' {
        $endpointName = 'e-ndpstest110'
        $resourceType = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ResourceType]::MicrosoftCdnProfilesEndpoints
        
        $nameAvailability = Test-AzCdnNameAvailability -Name $endpointName -Type $resourceType
        $nameAvailability.NameAvailable | Should -BeTrue

        $nameAvailability = Test-AzCdnNameAvailability -Name $env.ClassicEndpointName -Type $resourceType
        $nameAvailability.NameAvailable | Should -BeFalse
    }

    It 'CheckExpanded1' {
        $endpointName = 'e-ndpstest111'
        $resourceType = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ResourceType]::MicrosoftCdnProfilesEndpoints
        
        $nameAvailability = Test-AzCdnNameAvailability -Name $endpointName -Type $resourceType
        $nameAvailability.NameAvailable | Should -BeTrue

        $nameAvailability = Test-AzCdnNameAvailability -Name $env.ClassicEndpointName -Type $resourceType
        $nameAvailability.NameAvailable | Should -BeFalse
    }
}
