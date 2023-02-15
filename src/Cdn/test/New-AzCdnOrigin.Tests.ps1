if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnOrigin' -Tag 'LiveOnly' {
    It 'CreateExpanded' {
        { 
            $subId = $env.SubscriptionId
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName)"
                
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                $originId = "/subscriptions/$subId/resourcegroups/$ResourceGroupName/providers/Microsoft.Cdn/profiles/$cdnProfileName/endpoints/$endpointName/origins/$($origin.Name)"
                $originGroup = @{
                    Name = "originGroup1"
                    HealthProbeSettingProbeIntervalInSecond = 240
                    HealthProbeSettingProbePath = "/health.aspx"
                    HealthProbeSettingProbeProtocol = "Https"
                    HealthProbeSettingProbeRequestType = "GET" 
                    Origin = @(@{
                        Id = $originId
                    })
                }
                $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$ResourceGroupName/providers/Microsoft.Cdn/profiles/$cdnProfileName/endpoints/$endpointName/origingroups/$($originGroup.Name)"
                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location `
                    -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup

                $origin = New-AzCdnOrigin -Name "origin2" -HostName "host2.hello.com" -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName

                $origin.Name | Should -Be "origin2"
                $origin.HostName | Should -Be "host2.hello.com"
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
