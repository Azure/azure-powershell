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
        $resourceType = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ResourceType]::MicrosoftCdnProfilesAfdEndpoints
        
        $endpointName = 'end-pstest090'
        Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"

        $nameAvailability = Test-AzFrontDoorCdnEndpointNameAvailability -ResourceGroupName $env.ResourceGroupName -Name $endpointName -Type $resourceType
        $nameAvailability.NameAvailable | Should -BeTrue
        
        $nameAvailability = Test-AzFrontDoorCdnEndpointNameAvailability -ResourceGroupName $env.ResourceGroupName -Name $env.FrontDoorEndpointName -Type $resourceType
        $nameAvailability.NameAvailable | Should -BeFalse
    }
}
