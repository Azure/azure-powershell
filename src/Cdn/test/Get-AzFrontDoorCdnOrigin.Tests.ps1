if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnOrigin'  {
    BeforeAll {
        $originGroupName = 'org' + (RandomString -allChars $false -len 6);
        $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
        -ProbeProtocol "Https" -ProbeRequestType "GET"
        $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
        -SampleSize 5 -SuccessfulSamplesRequired 4
        New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting

        Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName

        $hostName = "en.wikipedia.org";
        $originName = 'ori' + (RandomString -allChars $false -len 6);

        Write-Host -ForegroundColor Green "Start to create origin."    
        New-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName `
            -OriginName $originName -OriginHostHeader $hostName -HostName $hostName `
            -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000
    }

    It 'List' {
        Write-Host -ForegroundColor Green "Get origin."   
        $origins = Get-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $origins.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $origin = Get-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName
        $origin.Name | Should -Be $originName
    }

    It 'GetViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $origin = Get-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName | Get-AzFrontDoorCdnOrigin
        $origin.Name | Should -Be $originName
    }
}
