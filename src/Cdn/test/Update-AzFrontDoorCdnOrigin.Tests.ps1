if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnOrigin' {
    It 'UpdateExpanded' {
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
            New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
            -LoadBalancingSettingSampleSize 5 `
            -LoadBalancingSettingSuccessfulSamplesRequired 4 `
            -LoadBalancingSettingAdditionalLatencyInMillisecond 200 `
            -HealthProbeSettingProbeIntervalInSecond 1 `
            -HealthProbeSettingProbePath "/" `
            -HealthProbeSettingProbeProtocol $([Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ProbeProtocol]::Https) `
            -HealthProbeSettingProbeRequestType $([Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.HealthProbeRequestType]::Get) `

            Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName

            $hostName = "en.wikipedia.org";
            $originName = 'ori' + (RandomString -allChars $false -len 6);
            New-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName `
            -OriginName $originName -OriginHostHeader $hostName -HostName $hostName `
            -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000

            $origin = Get-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName
            $origin.Weight | Should -Be 1000

            Update-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName -Weight 999
            $origin = Get-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName
            $origin.Weight | Should -Be 999
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }

    It 'UpdateViaIdentityExpanded' {
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
            New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
            -LoadBalancingSettingSampleSize 5 `
            -LoadBalancingSettingSuccessfulSamplesRequired 4 `
            -LoadBalancingSettingAdditionalLatencyInMillisecond 200 `
            -HealthProbeSettingProbeIntervalInSecond 1 `
            -HealthProbeSettingProbePath "/" `
            -HealthProbeSettingProbeProtocol $([Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ProbeProtocol]::Https) `
            -HealthProbeSettingProbeRequestType $([Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.HealthProbeRequestType]::Get) `

            Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName

            $hostName = "en.wikipedia.org";
            $originName = 'ori' + (RandomString -allChars $false -len 6);
            New-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName `
            -OriginName $originName -OriginHostHeader $hostName -HostName $hostName `
            -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000

            $origin = Get-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName
            $origin.Weight | Should -Be 1000

            Get-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName | `
            Update-AzFrontDoorCdnOrigin -Weight 999
            $origin = Get-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName -OriginName $originName
            $origin.Weight | Should -Be 999
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }
}
