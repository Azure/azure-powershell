if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnEndpoint'  {
    BeforeAll {
        $endpointName = 'end-pstest100'
        Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
        New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $endpoint = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        $endpoint.EnabledState | Should -Be "Enabled"
    }
    It 'UpdateExpanded'  {
        Update-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName -EnabledState "Disabled"
        $updatedEndpoint = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        $updatedEndpoint.EnabledState | Should -Be "Disabled"
    }

    It 'UpdateViaIdentityExpanded' {
        $endObject = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        Update-AzFrontdoorCdnEndpoint -EnabledState "Enabled" -InputObject $endObject
        $updatedEndpoint = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        $updatedEndpoint.EnabledState | Should -Be "Enabled"
    }
}
