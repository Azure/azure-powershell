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
        $endpointResourceUsages = Get-AzCdnEndpointResourceUsage -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $geofilterUsage = $endpointResourceUsages | Where-Object -Property ResourceType -eq 'geofilter'
        
        $endpointResourceUsages.Count | Should -Be 3
        $geofilterUsage.Limit | Should -Be 25
        $geofilterUsage.CurrentValue | Should -Be 0

        $geofilters = @(
            @{
                RelativePath = "/mycar" 
                Action =  [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.GeoFilterActions]::Allow
                CountryCode = "AU"
            },
            @{
                RelativePath = "/mycars" 
                Action =  [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.GeoFilterActions]::Allow
                CountryCode = "AU"
            })
        Update-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName -GeoFilter $geofilters
        $endpointResourceUsages = Get-AzCdnEndpointResourceUsage -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $geofilterUsage = $endpointResourceUsages | Where-Object -Property ResourceType -eq 'geofilter'

        $endpointResourceUsages.Count | Should -Be 3
        $geofilterUsage.Limit | Should -Be 25
        $geofilterUsage.CurrentValue | Should -Be 2
    }
}
