if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadCdnEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadCdnEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnCustomDomain' {
    BeforeAll {
        $script:subId = $env.SubscriptionId
        $script:classicCdnEndpointName = 'ps2025-0601-rm-domain'
        $script:customDomainName = 'cd-pstest-rm'
        $location = "westus"
        $origin = @{ Name = "origin1"; HostName = "host1.hello.com" }
        $originId = "/subscriptions/$script:subId/resourcegroups/$($env.ClassicCdnResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:classicCdnEndpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET"
        $originGroup = @{ Name = "originGroup1"; healthProbeSetting = $healthProbeParametersObject; Origin = @(@{ Id = $originId }) }
        $defaultOriginGroup = "/subscriptions/$script:subId/resourcegroups/$($env.ClassicCdnResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:classicCdnEndpointName/origingroups/$($originGroup.Name)"

        New-AzCdnEndpoint -Name $script:classicCdnEndpointName -ResourceGroupName $env.ClassicCdnResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup | Out-Null
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:classicCdnEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'DeleteMissingDomain' {
        Remove-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName -PassThru | Should -Be $true
        { Get-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityEndpoint' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
