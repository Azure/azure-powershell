if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoorCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoorCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoorCdnEndpoint'  {
    It 'Delete' {
        $endpointName = 'end-pstest070'
        Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
        $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $endpoint.Name | Should -Be $endpointName
        $endpoint.Location | Should -Be "Global"
        
        Remove-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
    }

    It 'DeleteViaIdentity' {
        $endpointName = 'end-pstest071'
        Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
        $endpoint = New-AzFrontDoorCdnEndpoint -SubscriptionId $env.SubscriptionId -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $endpoint.Name | Should -Be $endpointName
        $endpoint.Location | Should -Be "Global"
        $endpointObject = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        Remove-AzFrontdoorCdnEndpoint -InputObject $endpointObject
    }
}
