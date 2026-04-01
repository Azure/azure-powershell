if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnEndpoint' {
    It 'CreateExpanded' {
        $endpointName = 'e-clipstest040'

        # New
        Write-Host -ForegroundColor Green "New AzFrontDoorCdnEndpoint: $($endpointName)"
        $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        $endpoint.Name | Should -Be $endpointName
        $endpoint.Location | Should -Be "Global"

        # Get - List
        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnEndpoint - List"
        $endpoints = Get-AzFrontDoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName
        $endpoints.Count | Should -BeGreaterOrEqual 1

        # Get - by name
        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnEndpoint - by name"
        $getEndpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        $getEndpoint.Name | Should -Be $endpointName

        # Get - ViaIdentity
        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnEndpoint - ViaIdentity"
        $getEndpoint2 = Get-AzFrontDoorCdnEndpoint -InputObject $getEndpoint
        $getEndpoint2.Name | Should -Be $endpointName

        # Update
        Write-Host -ForegroundColor Green "Update AzFrontDoorCdnEndpoint"
        Update-AzFrontDoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName -EnabledState "Disabled"
        $updatedEndpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        $updatedEndpoint.EnabledState | Should -Be "Disabled"

        # Update - ViaIdentity
        Write-Host -ForegroundColor Green "Update AzFrontDoorCdnEndpoint - ViaIdentity"
        $endObject = Get-AzFrontDoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        Update-AzFrontDoorCdnEndpoint -EnabledState "Enabled" -InputObject $endObject
        $updatedEndpoint2 = Get-AzFrontDoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        $updatedEndpoint2.EnabledState | Should -Be "Enabled"

        # Remove
        Write-Host -ForegroundColor Green "Remove AzFrontDoorCdnEndpoint: $($endpointName)"
        Remove-AzFrontDoorCdnEndpoint -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
    }
}
