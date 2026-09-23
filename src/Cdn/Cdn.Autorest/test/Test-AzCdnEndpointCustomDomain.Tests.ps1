if(($null -eq $TestName) -or ($TestName -contains 'Test-AzCdnEndpointCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzCdnEndpointCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzCdnEndpointCustomDomain'  {
    BeforeAll {
        $script:subId = $env.SubscriptionId
        $script:classicCdnEndpointName = 'ps2025-0601-test-domain'
        $script:customDomainHostName = 'ps2025-0601-test-domain.ps.cdne2e.azfdtest.xyz'
        $script:customDomainInvalidHostName = 'ps2025-0601-test-domain-invalid.ps.cdne2e.azfdtest.xyz'
        $location = "westus"
        $origin = @{ Name = "origin1"; HostName = "host1.hello.com" }
        $originId = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:classicCdnEndpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET"
        $originGroup = @{ Name = "originGroup1"; healthProbeSetting = $healthProbeParametersObject; Origin = @(@{ Id = $originId }) }
        $defaultOriginGroup = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:classicCdnEndpointName/origingroups/$($originGroup.Name)"

        New-AzCdnEndpoint -Name $script:classicCdnEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:classicCdnEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'ValidateExpanded - valid' {
        $validateResult = Test-AzCdnEndpointCustomDomain -EndpointName $script:classicCdnEndpointName -HostName $script:customDomainHostName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $validateResult.CustomDomainValidated | Should -BeTrue
    }

    It 'ValidateExpanded - invalid' {
        $validateResult = Test-AzCdnEndpointCustomDomain -EndpointName $script:classicCdnEndpointName -HostName $script:customDomainInvalidHostName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $validateResult.CustomDomainValidated | Should -BeFalse
    }

    It 'ValidateViaIdentityExpanded' -skip {
    }
}
