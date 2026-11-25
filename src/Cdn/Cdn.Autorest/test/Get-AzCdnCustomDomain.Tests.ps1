if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadCdnEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadCdnEnv.ps1'
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

Describe 'Get-AzCdnCustomDomain' {
    BeforeAll {
        $script:customDomainName = $null
        $endpoints = Get-AzCdnEndpoint -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName
        foreach ($endpoint in $endpoints) {
            $domain = Get-AzCdnCustomDomain -EndpointName $endpoint.Name -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName | Select-Object -First 1
            if ($domain) {
                $script:classicCdnEndpointName = $endpoint.Name
                $script:customDomainName = $domain.Name
                $script:customDomainHostName = $domain.HostName
                break
            }
        }
        if (-not $script:customDomainName) {
            throw 'The configured Classic CDN profile must contain an existing custom domain for query tests.'
        }
    }

    It 'List' {
        $customDomains = Get-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName
        $customDomains.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $getDomain = Get-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName
        $getDomain.Name | Should -Be $script:customDomainName
        $getDomain.HostName | Should -Be $script:customDomainHostName
    }

    It 'GetViaIdentity' {
        $getDomain = Get-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName
        $getDomain2 = Get-AzCdnCustomDomain -InputObject $getDomain
        $getDomain2.Name | Should -Be $script:customDomainName
    }

    It 'GetViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityEndpoint' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
