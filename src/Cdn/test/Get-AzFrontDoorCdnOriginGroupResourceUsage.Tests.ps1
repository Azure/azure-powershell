if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnOriginGroupResourceUsage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnOriginGroupResourceUsage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnOriginGroupResourceUsage' -Tag 'LiveOnly' {
    It 'List' {
        { 
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

                $originGroupUsage = Get-AzFrontDoorCdnOriginGroupResourceUsage -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName
                $originGroupUsage | Should -not -BeNullOrEmpty
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
