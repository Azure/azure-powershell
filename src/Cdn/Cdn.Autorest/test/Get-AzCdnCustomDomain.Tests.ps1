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

Describe 'Get-AzCdnCustomDomain' {
    BeforeAll {
        $script:subId = $env.SubscriptionId
        $script:classicCdnEndpointName = 'ps2025-0601-get-domain'
        $script:customDomainHostName = 'ps2025-0601-get-domain.ps.cdne2e.azfdtest.xyz'
        $script:customDomainName = 'cd-pstest-get'
        $location = "westus"
        $origin = @{ Name = "origin1"; HostName = "host1.hello.com" }
        $originId = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:classicCdnEndpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET"
        $originGroup = @{ Name = "originGroup1"; healthProbeSetting = $healthProbeParametersObject; Origin = @(@{ Id = $originId }) }
        $defaultOriginGroup = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:classicCdnEndpointName/origingroups/$($originGroup.Name)"

        New-AzCdnEndpoint -Name $script:classicCdnEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup | Out-Null
        New-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $script:customDomainHostName | Out-Null
    }

    AfterAll {
        Remove-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        Remove-AzCdnEndpoint -Name $script:classicCdnEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $customDomains = Get-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $customDomains.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $getDomain = Get-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $getDomain.Name | Should -Be $script:customDomainName
        $getDomain.HostName | Should -Be $script:customDomainHostName
    }

    It 'GetViaIdentity' {
        $getDomain = Get-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
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
