if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnEndpointResourceUsage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnEndpointResourceUsage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnEndpointResourceUsage'  {
    It 'List' {
        # Create endpoint for resource usage testing
        $endpointName = 'e-resusage01'
        $profileName = $env.ClassicCdnProfileName
        $origin = @{ Name = "origin1"; HostName = "host1.hello.com" }
        Write-Host -ForegroundColor Green "Create endpoint for resource usage test: $endpointName"
        New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $profileName -Location $env.location -Origin $origin | Out-Null

        $endpointResourceUsages = Get-AzCdnEndpointResourceUsage -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $env.ResourceGroupName
        $geofilterUsage = $endpointResourceUsages | Where-Object -Property ResourceType -eq 'geofilter'
        
        $endpointResourceUsages.Count | Should -Be 8
        $geofilterUsage.Limit | Should -Be 25
        $geofilterUsage.CurrentValue | Should -Be 0

        $geofilters = @(
            @{
                RelativePath = "/" 
                Action =  "Allow"
                CountryCode = "AU"
            })
        Update-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $profileName -GeoFilter $geofilters
        $endpointResourceUsages = Get-AzCdnEndpointResourceUsage -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $env.ResourceGroupName
        $geofilterUsage = $endpointResourceUsages | Where-Object -Property ResourceType -eq 'geofilter'

        $endpointResourceUsages.Count | Should -Be 8
        $geofilterUsage.Limit | Should -Be 25
        $geofilterUsage.CurrentValue | Should -Be 1

        # Cleanup
        Remove-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $profileName -ErrorAction SilentlyContinue
    }
}
