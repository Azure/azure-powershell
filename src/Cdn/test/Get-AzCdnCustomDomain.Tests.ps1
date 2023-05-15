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
    # BeforeAll {
    #     $subId = $env.SubscriptionId
    #     # Hard-coding host and endpoint names due to requirement for DNS CNAME
    #     $classicCdnEndpointName = 'aa-powershell-20230425-oigr9w'
    #     $customDomainHostName = 'aa-powershell-20230425-oigr9w.cdne2e.azfdtest.xyz'
    #     $customDomainName = 'cd-' + (RandomString -allChars $false -len 6);
    #     $location = "westus"
    #     $origin = @{
    #         Name = "origin1"
    #         HostName = "host1.hello.com"
    #     };
        
    #     Write-Host -ForegroundColor Green "Create endpointName : $($classicCdnEndpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"
    #     New-AzCdnEndpoint -Name $classicCdnEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
    #         -Origin $origin  | Out-Null

    #     Write-Host -ForegroundColor Green "Create customDomain : $($customDomainName), customDomain HostName : $($customDomainHostName)"
    #     $customDomain = New-AzCdnCustomDomain -EndpointName $classicCdnEndpointName -Name $customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $customDomainHostName
    # }
    
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
        $PSDefaultParameterValues['Disabled'] = $true
        $customDomain = Get-AzCdnCustomDomain -SubscriptionId $env.SubscriptionId -EndpointName $env.ClassicEndpointName -Name $env.ClassicCustomDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Get-AzCdnCustomDomain

        $customDomain.Name | Should -Be $env.ClassicCustomDomainName
        $customDomain.HostName | Should -Be $env.ClassicCustomDomainHostName
    }
}
