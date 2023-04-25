if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnOrigin'  {
    BeforeAll {
        $subId = $env.SubscriptionId
        $endpointName = 'e-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName)"
        
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $location = "westus"
        $originId = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName/origins/$($origin.Name)"
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
        $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName/origingroups/$($originGroup.Name)"
        New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup
        New-AzCdnOrigin -Name "origin2" -HostName "host2.hello.com" -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName

        $endpointName2 = 'e-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName2)"
        
        $originId2 = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName2/origins/$($origin.Name)"
        $originGroup2 = @{
            Name = "originGroup1"
            HealthProbeSettingProbeIntervalInSecond = 240
            HealthProbeSettingProbePath = "/health.aspx"
            HealthProbeSettingProbeProtocol = "Https"
            HealthProbeSettingProbeRequestType = "GET" 
            Origin = @(@{
                Id = $originId2
            })
        }
        $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName2/origingroups/$($originGroup2.Name)"
        New-AzCdnEndpoint -Name $endpointName2 -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup2 -DefaultOriginGroupId $defaultOriginGroup
        New-AzCdnOrigin -Name "origin3" -HostName "host2.hello.com" -EndpointName $endpointName2 -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'Delete' {        
        Remove-AzCdnOrigin -Name "origin2" -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'DeleteViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        Get-AzCdnOrigin -Name "origin3" -EndpointName $endpointName2 -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Remove-AzCdnOrigin
    }
}
