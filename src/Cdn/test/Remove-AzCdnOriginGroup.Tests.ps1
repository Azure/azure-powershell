if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnOriginGroup'  {
    It 'Delete' {
        $subId = $env.SubscriptionId
        $endpointName = 'e-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName)"
        
        $location = "westus"
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $originId = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET" 
        $originGroup = @{
            Name = "originGroup1"
            healthProbeSetting = $healthProbeParametersObject 
            Origin = @(@{
                Id = $originId
            })
        }
        $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName/origingroups/$($originGroup.Name)"
        $createdEndpoint = New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup

        $originGroupName2 = "originGroup2"
        $probeInterval2 = 120
        $probePath2 = "/check-health.aspx"
        $probeProtocol2 = "Http"
        $probeRequestType2 = "HEAD"
        $healthProbeParametersObject2 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond $probeInterval2 `
            -ProbePath $probePath2 -ProbeProtocol $probeProtocol2 -ProbeRequestType $probeRequestType2 

        New-AzCdnOriginGroup -EndpointName $endpointName -Name $originGroupName2 -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HealthProbeSetting $healthProbeParametersObject2 -Origin @(@{ Id = $originId })

        Remove-AzCdnOriginGroup -EndpointName $endpointName -Name $originGroupName2 -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'DeleteViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $subId = $env.SubscriptionId
        $endpointName2 = 'e-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName2)"
        
        $location = "westus"
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $originId2 = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName2/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET" 
        $originGroup2 = @{
            Name = "originGroup1"
            healthProbeSetting = $healthProbeParametersObject 
            Origin = @(@{
                Id = $originId2
            })
        }
        $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName2/origingroups/$($originGroup2.Name)"
        $createdEndpoint = New-AzCdnEndpoint -SubscriptionId $env.SubscriptionId -Name $endpointName2 -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup2 -DefaultOriginGroupId $defaultOriginGroup

        $originGroupName2 = "originGroup2"
        $probeInterval2 = 120
        $probePath2 = "/check-health.aspx"
        $probeProtocol2 = "Http"
        $probeRequestType2 = "HEAD"
        $healthProbeParametersObject2 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond $probeInterval2 `
            -ProbePath $probePath2 -ProbeProtocol $probeProtocol2 -ProbeRequestType $probeRequestType2 

        New-AzCdnOriginGroup -EndpointName $endpointName2 -Name $originGroupName2 -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HealthProbeSetting $healthProbeParametersObject2 -Origin @(@{ Id = $originId2 })
        
        Get-AzCdnOriginGroup -EndpointName $endpointName2 -Name $originGroupName2 -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Remove-AzCdnOriginGroup
    }
}
