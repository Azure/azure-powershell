if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnCustomDomain' {
    BeforeAll {
        $script:subId = $env.SubscriptionId
        $script:classicCdnEndpointName = 'ps2025-0601-new-domain'
        $script:customDomainHostName = 'ps2025-0601-new-domain.ps.cdne2e.azfdtest.xyz'
        $script:customDomainName = 'cd-pstest-new'
        $location = "westus"
        $origin = @{ Name = "origin1"; HostName = "host1.hello.com" }
        $originId = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:classicCdnEndpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET"
        $originGroup = @{ Name = "originGroup1"; healthProbeSetting = $healthProbeParametersObject; Origin = @(@{ Id = $originId }) }
        $defaultOriginGroup = "/subscriptions/$script:subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$script:classicCdnEndpointName/origingroups/$($originGroup.Name)"

        Write-Host -ForegroundColor Green "BeforeAll: create endpoint $script:classicCdnEndpointName"
        New-AzCdnEndpoint -Name $script:classicCdnEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup | Out-Null
    }

    AfterAll {
        Write-Host -ForegroundColor Green "AfterAll: clean up custom domain + endpoint"
        Remove-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        Remove-AzCdnEndpoint -Name $script:classicCdnEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        Write-Host -ForegroundColor Green "New-AzCdnCustomDomain: $script:customDomainName"
        $customDomain = New-AzCdnCustomDomain -EndpointName $script:classicCdnEndpointName -Name $script:customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $script:customDomainHostName
        $customDomain.Name | Should -Be $script:customDomainName
        $customDomain.HostName | Should -Be $script:customDomainHostName
    }
}


