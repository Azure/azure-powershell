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

Describe 'Get-AzCdnEndpointResourceUsage' -Tag 'LiveOnly' {
    It 'List' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Akamai";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin
                $endpointResourceUsages = Get-AzCdnEndpointResourceUsage -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
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
                Update-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -GeoFilter $geofilters
                $endpointResourceUsages = Get-AzCdnEndpointResourceUsage -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
                $geofilterUsage = $endpointResourceUsages | Where-Object -Property ResourceType -eq 'geofilter'

                $endpointResourceUsages.Count | Should -Be 3
                $geofilterUsage.Limit | Should -Be 25
                $geofilterUsage.CurrentValue | Should -Be 2
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
