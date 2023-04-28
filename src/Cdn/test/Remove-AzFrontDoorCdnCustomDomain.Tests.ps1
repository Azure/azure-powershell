if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoorCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoorCdnCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoorCdnCustomDomain'  {
    It 'Delete' {
        $customDomainName = "domain-" + (RandomString -allChars $false -len 6);
        New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -HostName "removedomain.dev.cdn.azure.cn" 

        Remove-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $customDomainName
    }

    It 'DeleteViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $customDomainName = "domain-" + (RandomString -allChars $false -len 6);
        New-AzFrontDoorCdnCustomDomain -SubscriptionId $env.SubscriptionId -CustomDomainName $customDomainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -HostName "removedomain.dev.cdn.azure.cn" 

        Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $customDomainName | Remove-AzFrontDoorCdnCustomDomain
    }
}
