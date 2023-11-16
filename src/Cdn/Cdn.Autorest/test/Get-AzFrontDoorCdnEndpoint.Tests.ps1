if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnEndpoint'  {
    It 'List'  {
        $endpoints = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName
        $endpoints.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get'  {
        $endpoint = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $env.FrontDoorEndpointName
        $endpoint.Name | Should -Be $env.FrontDoorEndpointName
        $endpoint.Location | Should -Be "Global"
    }

    It 'GetViaIdentity' {
        $endpointObject = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $env.FrontDoorEndpointName
        $endpoint = Get-AzFrontdoorCdnEndpoint -InputObject $endpointObject
        
        $endpoint.Name | Should -Be $env.FrontDoorEndpointName
        $endpoint.Location | Should -Be "Global"
    }
}
