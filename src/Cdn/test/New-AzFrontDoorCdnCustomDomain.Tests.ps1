if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnCustomDomain'  {
    It 'CreateExpanded' {
        $subId = $env.SubscriptionId
        $secretName = "se-" + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use secretName : $($secretName)"

        $customDomainName = "domain-" + (RandomString -allChars $false -len 6);
        $hostName = "pstestnew.dev.cdn.azure.cn"
        New-AzFrontDoorCdnCustomDomain -CustomDomainName $customDomainName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
        -HostName $hostName
    }
}
