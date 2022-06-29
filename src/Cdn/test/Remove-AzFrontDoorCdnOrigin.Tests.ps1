if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoorCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoorCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoorCdnOrigin' -Tag 'LiveOnly' {
    It 'Delete' {
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        try
        {
            Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
            New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

            $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

            $profileSku = "Standard_AzureFrontDoor";
            New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

            $originGroupName = 'org' + (RandomString -allChars $false -len 6);
            $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
            -ProbeProtocol "Https" -ProbeRequestType "GET"
            $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
            -SampleSize 5 -SuccessfulSamplesRequired 4
            New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
            -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting

            Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName

            $hostName = "en.wikipedia.org";
            $originName = 'ori' + (RandomString -allChars $false -len 6);
            New-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName `
            -OriginName $originName -OriginHostHeader $hostName -HostName $hostName `
            -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000

            Remove-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }

    It 'DeleteViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        try
        {
            Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
            New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

            $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

            $profileSku = "Standard_AzureFrontDoor";
            New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

            $originGroupName = 'org' + (RandomString -allChars $false -len 6);
            $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
            -ProbeProtocol "Https" -ProbeRequestType "GET"
            $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
            -SampleSize 5 -SuccessfulSamplesRequired 4
            New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
            -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting

            Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName

            $hostName = "en.wikipedia.org";
            $originName = 'ori' + (RandomString -allChars $false -len 6);
            New-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName `
            -OriginName $originName -OriginHostHeader $hostName -HostName $hostName `
            -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000

            Get-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName | Remove-AzFrontDoorCdnOrigin
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }
}
