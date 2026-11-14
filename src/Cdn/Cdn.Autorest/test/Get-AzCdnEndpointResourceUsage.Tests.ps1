if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnEndpointResourceUsage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadCdnEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadCdnEnv.ps1'
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
    BeforeAll {
        $script:endpointName = 'e-resusage01'
        $script:profileName = $env.ClassicCdnProfileName
        $origin = @{ Name = "origin1"; HostName = "host1.hello.com" }
        Write-Host -ForegroundColor Green "Create endpoint for resource usage test: $endpointName"
        New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ClassicCdnResourceGroupName -ProfileName $profileName -Location $env.location -Origin $origin | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ClassicCdnResourceGroupName -ProfileName $profileName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $endpointResourceUsages = Get-AzCdnEndpointResourceUsage -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $env.ClassicCdnResourceGroupName
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
        Update-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ClassicCdnResourceGroupName -ProfileName $profileName -GeoFilter $geofilters
        $endpointResourceUsages = Get-AzCdnEndpointResourceUsage -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $env.ClassicCdnResourceGroupName
        $geofilterUsage = $endpointResourceUsages | Where-Object -Property ResourceType -eq 'geofilter'

        $endpointResourceUsages.Count | Should -Be 8
        $geofilterUsage.Limit | Should -Be 25
        $geofilterUsage.CurrentValue | Should -Be 1

    }
}
