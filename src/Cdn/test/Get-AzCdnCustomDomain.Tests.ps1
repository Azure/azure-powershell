if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnCustomDomain'  {
    It 'List' {
        $customDomains = Get-AzCdnCustomDomain -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        Write-Host -ForegroundColor Green "customDomains.Count : $($customDomains.Count)"
        $customDomains.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $customDomain = Get-AzCdnCustomDomain -EndpointName $env.ClassicEndpointName -Name $env.ClassicCustomDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName

        $customDomain.Name | Should -Be $env.ClassicCustomDomainName
        $customDomain.HostName | Should -Be $env.ClassicCustomDomainHostName
    }

    It 'GetViaIdentity' {
        $customDomainObject = Get-AzCdnCustomDomain -EndpointName $env.ClassicEndpointName -Name $env.ClassicCustomDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $customDomain =  Get-AzCdnCustomDomain -InputObject $customDomainObject

        $customDomain.Name | Should -Be $env.ClassicCustomDomainName
        $customDomain.HostName | Should -Be $env.ClassicCustomDomainHostName
    }
}
