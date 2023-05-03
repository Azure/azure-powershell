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

Describe 'New-AzCdnCustomDomain'  {
    It 'CreateExpanded' {
        $subId = $env.SubscriptionId
        # Hard-coding host and endpoint names due to requirement for DNS CNAME
        $classicCdnEndpointName = 'aa-powershell-20230422-oigr9w'
        $customDomainHostName = 'aa-powershell-20230422-oigr9w.cdne2e.azfdtest.xyz'
        $customDomainName = 'cd-' + (RandomString -allChars $false -len 6);
        $location = "westus"
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $originId = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$classicCdnEndpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET" 
        $originGroup = @{
            Name = "originGroup1"
            healthProbeSetting = $healthProbeParametersObject 
            Origin = @(@{
                Id = $originId
            })
        }
        $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$classicCdnEndpointName/origingroups/$($originGroup.Name)"
        
        Write-Host -ForegroundColor Green "Create endpointName : $($classicCdnEndpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"
        New-AzCdnEndpoint -Name $classicCdnEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup | Out-Null

        Write-Host -ForegroundColor Green "Create customDomain : $($customDomainName), customDomain HostName : $($customDomainHostName)"
        $customDomain = New-AzCdnCustomDomain -EndpointName $classicCdnEndpointName -Name $customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $customDomainHostName

        $customDomain.Name | Should -Be $customDomainName
        $customDomain.HostName | Should -Be $customDomainHostName

        # /Remove-AzCdnCustomDomain -EndpointName $classicCdnEndpointName -Name $customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }
}


