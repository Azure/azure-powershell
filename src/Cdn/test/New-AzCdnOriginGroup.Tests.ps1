if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnOriginGroup' -Tag 'LiveOnly' {
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
                
                $location = "westus"
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $originId = "/subscriptions/$subId/resourcegroups/$ResourceGroupName/providers/Microsoft.Cdn/profiles/$cdnProfileName/endpoints/$endpointName/origins/$($origin.Name)"
                $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET" 
                $originGroup = @{
                    Name = "originGroup1"
                    healthProbeSetting = $healthProbeParametersObject 
                    Origin = @(@{
                        Id = $originId
                    })
                }
                $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$ResourceGroupName/providers/Microsoft.Cdn/profiles/$cdnProfileName/endpoints/$endpointName/origingroups/$($originGroup.Name)"
                $createdEndpoint = New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location `
                    -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup

                $originGroupName2 = "originGroup2"
                $probeInterval2 = 120
                $probePath2 = "/check-health.aspx"
                $probeProtocol2 = "Http"
                $probeRequestType2 = "HEAD"
                $healthProbeParametersObject2 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond $probeInterval2 `
                 -ProbePath $probePath2 -ProbeProtocol $probeProtocol2 -ProbeRequestType $probeRequestType2 

                $createdOriginGroup = New-AzCdnOriginGroup -EndpointName $endpointName -Name $originGroupName2 -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName `
                    -HealthProbeSetting $healthProbeParametersObject2 -Origin @(@{ Id = $originId })
                
                $createdEndpoint.DefaultOriginGroupId | Should -Be $defaultOriginGroup
                $createdOriginGroup.Name | Should -Be $originGroupName2
                $createdOriginGroup.HealthProbeSetting.ProbeIntervalInSecond | Should -Be $probeInterval2
                $createdOriginGroup.HealthProbeSetting.ProbePath | Should -Be $probePath2
                $createdOriginGroup.HealthProbeSetting.ProbeProtocol | Should -Be $probeProtocol2
                $createdOriginGroup.HealthProbeSetting.ProbeRequestType | Should -Be $probeRequestType2
                $createdOriginGroup.Origin[0].Id | Should -Be $originId
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
