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
    It 'CreateExpanded' {
        $subId = $env.SubscriptionId
        # Hard-coding host and endpoint names due to requirement for DNS CNAME
        $classicCdnEndpointName = 'ps2025-0601-domain1'
        $customDomainHostName = 'ps2025-0601-domain1.ps.cdne2e.azfdtest.xyz'
        $customDomainInvalidHostName = 'ps2025-0601-domain1e.ps.cdne2e.azfdtest.xyz'
        $customDomainName = 'cd-pstest010'
        $location = "westus"
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        }
        $originId = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$classicCdnEndpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET"
        $originGroup = @{
            Name = "originGroup1"
            healthProbeSetting = $healthProbeParametersObject
            Origin = @(@{ Id = $originId })
        }
        $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$classicCdnEndpointName/origingroups/$($originGroup.Name)"

        Write-Host -ForegroundColor Green "Create endpoint: $classicCdnEndpointName"
        New-AzCdnEndpoint -Name $classicCdnEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup | Out-Null

        # New
        Write-Host -ForegroundColor Green "New-AzCdnCustomDomain: $customDomainName"
        $customDomain = New-AzCdnCustomDomain -EndpointName $classicCdnEndpointName -Name $customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $customDomainHostName
        $customDomain.Name | Should -Be $customDomainName
        $customDomain.HostName | Should -Be $customDomainHostName

        # Validate endpoint custom domain
        Write-Host -ForegroundColor Green "Test-AzCdnEndpointCustomDomain - valid"
        $validateResult = Test-AzCdnEndpointCustomDomain -EndpointName $classicCdnEndpointName -HostName $customDomainHostName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $validateResult.CustomDomainValidated | Should -BeTrue

        Write-Host -ForegroundColor Green "Test-AzCdnEndpointCustomDomain - invalid"
        $validateResult = Test-AzCdnEndpointCustomDomain -EndpointName $classicCdnEndpointName -HostName $customDomainInvalidHostName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $validateResult.CustomDomainValidated | Should -BeFalse

        # Get - List
        Write-Host -ForegroundColor Green "Get-AzCdnCustomDomain - List"
        $customDomains = Get-AzCdnCustomDomain -EndpointName $classicCdnEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $customDomains.Count | Should -BeGreaterOrEqual 1

        # Get - by name
        Write-Host -ForegroundColor Green "Get-AzCdnCustomDomain - by name"
        $getDomain = Get-AzCdnCustomDomain -EndpointName $classicCdnEndpointName -Name $customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $getDomain.Name | Should -Be $customDomainName
        $getDomain.HostName | Should -Be $customDomainHostName

        # Get - ViaIdentity
        Write-Host -ForegroundColor Green "Get-AzCdnCustomDomain - ViaIdentity"
        $getDomain2 = Get-AzCdnCustomDomain -InputObject $getDomain
        $getDomain2.Name | Should -Be $customDomainName

        # Remove
        Write-Host -ForegroundColor Green "Remove-AzCdnCustomDomain: $customDomainName"
        Remove-AzCdnCustomDomain -EndpointName $classicCdnEndpointName -Name $customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }
}


