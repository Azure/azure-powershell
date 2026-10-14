if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFrontDoorCdnEndpointNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFrontDoorCdnEndpointNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFrontDoorCdnEndpointNameAvailability'  {
    It 'CheckExpanded' {
        $resourceType = "Microsoft.Cdn/Profiles/AfdEndpoints"

        # Create an endpoint to test name availability against
        $existingEndpointName = 'end-nameavail01'
        Write-Host -ForegroundColor Green "Create FrontDoor endpoint for name availability test: $existingEndpointName"
        New-AzFrontDoorCdnEndpoint -EndpointName $existingEndpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null

        # Non-existing name should be available
        $fakeEndpointName = 'e-clipstest140'
        $nameAvailability = Test-AzFrontDoorCdnEndpointNameAvailability -ResourceGroupName $env.ResourceGroupName -Name $fakeEndpointName -Type $resourceType
        $nameAvailability.NameAvailable | Should -BeTrue

        # Existing name should not be available
        $nameAvailability = Test-AzFrontDoorCdnEndpointNameAvailability -ResourceGroupName $env.ResourceGroupName -Name $existingEndpointName -Type $resourceType
        $nameAvailability.NameAvailable | Should -BeFalse

        # Cleanup
        Remove-AzFrontDoorCdnEndpoint -EndpointName $existingEndpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }
}
