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
        # Create endpoint for custom domain validation testing
        $endpointName = 'end-cdvalid01'
        Write-Host -ForegroundColor Green "Create FrontDoor endpoint for custom domain validation test: $endpointName"
        New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null

        $hostName = "test.dev.cdn.azure.cn"
        Test-AzFrontDoorCdnEndpointCustomDomain -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $hostName

        # ViaIdentity
        $endpointObject = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        Test-AzFrontDoorCdnEndpointCustomDomain -HostName $hostName -InputObject $endpointObject

        # Cleanup
        Remove-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }
}
