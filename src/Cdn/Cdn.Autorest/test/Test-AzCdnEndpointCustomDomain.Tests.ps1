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
    It 'ValidateExpanded' {
        # Hard-coding host and endpoint names due to requirement for DNS CNAME
        $endpointName = 'e-20220418-sec26q'
        $customDomainHostName = 'e-20220418-sec26q.ps.cdne2e.azfdtest.xyz'
        $customDomainInvalidHostName = 'e-20220418-sec26w.ps.cdne2e.azfdtest.xyz'
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $location = "westus"
        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

        New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location -Origin $origin
        $validateResult = Test-AzCdnEndpointCustomDomain -EndpointName $endpointName -HostName $customDomainHostName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName

        $validateResult.CustomDomainValidated | Should -BeTrue

        $validateResult = Test-AzCdnEndpointCustomDomain -EndpointName $endpointName -HostName $customDomainInvalidHostName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName

        $validateResult.CustomDomainValidated | Should -BeFalse
    }

    It 'ValidateViaIdentityExpanded' {  
        # Hard-coding host and endpoint names due to requirement for DNS CNAME
        $endpointName = 'e-20220418-ems6vw'
        $customDomainHostName = 'e-20220418-ems6vw.ps.cdne2e.azfdtest.xyz'
        $customDomainInvalidHostName = 'e-20220418-ems5vw.ps.cdne2e.azfdtest.xyz'
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $location = "westus"
        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

        $endpoint = New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location -Origin $origin
        $validateResult = Test-AzCdnEndpointCustomDomain -HostName $customDomainHostName -InputObject $endpoint

        $validateResult.CustomDomainValidated | Should -BeTrue

        $validateResult = Test-AzCdnEndpointCustomDomain -HostName $customDomainInvalidHostName -InputObject $endpoint

        $validateResult.CustomDomainValidated | Should -BeFalse
    }
}
