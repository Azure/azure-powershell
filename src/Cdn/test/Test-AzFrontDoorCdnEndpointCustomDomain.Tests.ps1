if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFrontDoorCdnEndpointCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFrontDoorCdnEndpointCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFrontDoorCdnEndpointCustomDomain'  {
    It 'ValidateExpanded' {
        $hostName = "test.dev.cdn.azure.cn"
        Test-AzFrontDoorCdnEndpointCustomDomain -EndpointName $env.FrontDoorEndpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $hostName
    }

    It 'ValidateViaIdentityExpanded' {
        $hostName = "test.dev.cdn.azure.cn"
        $endpointObject = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $env.FrontDoorEndpointName 
        Test-AzFrontDoorCdnEndpointCustomDomain -HostName $hostName -InputObject $endpointObject
    }
}
