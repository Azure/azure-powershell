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
    It 'Refresh' {
        $customDomainName = "domain-" + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use customDomainName : $($customDomainName)"
        $hostName = "pstestrefresh1.dev.cdn.azure.cn"
        $customDomain = New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -HostName $hostName
        Write-Host -ForegroundColor Green "Use customDomain token : $($customDomain.ValidationPropertyValidationTokenex)"

        Update-AzFrontDoorCdnCustomDomainValidationToken -CustomDomainName $customDomainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'RefreshViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $customDomainName = "domain-" + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use customDomainName : $($customDomainName)"
        $hostName = "pstestrefresh2.dev.cdn.azure.cn"
        $customDomain = New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -HostName $hostName
        Write-Host -ForegroundColor Green "Use customDomain token : $($customDomain.ValidationPropertyValidationTokenex)"

        $customDomain = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $customDomainName `
        | Update-AzFrontDoorCdnCustomDomainValidationToken
    }
}
