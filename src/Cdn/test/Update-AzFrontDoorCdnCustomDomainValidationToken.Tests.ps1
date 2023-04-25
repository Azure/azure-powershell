if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnCustomDomainValidationToken'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnCustomDomainValidationToken.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnCustomDomainValidationToken'  {
    It 'Refresh' -skip {
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
        New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

        $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $profileSku = "Standard_AzureFrontDoor";
        New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

        $customDomainName = "domain-" + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use customDomainName : $($customDomainName)"
        $hostName = "pstestrefresh1.dev.cdn.azure.cn"
        $customDomain = New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
                            -HostName $hostName
        Write-Host -ForegroundColor Green "Use customDomain token : $($customDomain.ValidationPropertyValidationTokenex)"

        Update-AzFrontDoorCdnCustomDomainValidationToken -CustomDomainName $customDomainName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName
    }

    It 'RefreshViaIdentity' -skip {
        $PSDefaultParameterValues['Disabled'] = $true

        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
        New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

        $frontDoorCdnProfileName2 = 'fdp-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName2)"

        $profileSku = "Standard_AzureFrontDoor";
        New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName2 -ResourceGroupName $ResourceGroupName -Location Global

        $customDomainName2 = "domain-" + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use customDomainName : $($customDomainName2)"
        $hostName = "pstestrefresh2.dev.cdn.azure.cn"
        $customDomain = New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName2 -ProfileName $frontDoorCdnProfileName2 -ResourceGroupName $ResourceGroupName `
                            -HostName $hostName
        Write-Host -ForegroundColor Green "Use customDomain token : $($customDomain.ValidationPropertyValidationTokenex)"

        $customDomain = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName2 -CustomDomainName $customDomainName2 `
            | Update-AzFrontDoorCdnCustomDomainValidationToken
    }
}
