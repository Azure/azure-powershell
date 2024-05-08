if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
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

Describe 'Remove-AzCdnCustomDomain'  {
    BeforeAll {
        # Hard-coding host and endpoint names due to requirement for DNS CNAME
        $endpointName = 'ps-20240402-domain040'
        $customDomainHostName = 'ps-20240402-domain040.ps.cdne2e.azfdtest.xyz'
        $customDomainName = 'cd-pstest020'

        $endpointName2 = 'ps-20240402-domain041'
        $customDomainHostName2 = 'ps-20240402-domain041.ps.cdne2e.azfdtest.xyz'
        $customDomainName2 = 'cd-pstest021'
        
        $origin = @{
            Name = "origin2"
            HostName = "host2.hello.com"
        };
        $location = "westus"

        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"
        New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location -Origin $origin
        New-AzCdnCustomDomain -EndpointName $endpointName -Name $customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $customDomainHostName

        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName2), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"
        New-AzCdnEndpoint -Name $endpointName2 -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location -Origin $origin
        New-AzCdnCustomDomain -EndpointName $endpointName2 -Name $customDomainName2 -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -HostName $customDomainHostName2
    }

    It 'Delete' {
        Remove-AzCdnCustomDomain -EndpointName $endpointName -Name $customDomainName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'DeleteViaIdentity' {
        $domainObject = Get-AzCdnCustomDomain -EndpointName $endpointName2 -Name $customDomainName2 -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        Remove-AzCdnCustomDomain -InputObject $domainObject
    }
}
