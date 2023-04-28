if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnCustomDomain'  {
    It 'List' {
        $customDomains = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName
        $customDomains.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $customDomain = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $env.FrontDoorCustomDomainName
        $customDomain.Name | Should -Be $env.FrontDoorCustomDomainName
    }

    It 'GetViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $customDomain = Get-AzFrontDoorCdnCustomDomain -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -CustomDomainName $env.FrontDoorCustomDomainName | Get-AzFrontDoorCdnCustomDomain
        $customDomain.Name | Should -Be $env.FrontDoorCustomDomainName
    }
}
