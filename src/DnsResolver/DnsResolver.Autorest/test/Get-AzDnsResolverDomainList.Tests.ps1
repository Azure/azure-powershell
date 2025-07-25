if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDnsResolverDomainList'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverDomainList.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDnsResolverDomainList' {
    It 'Get single DNS resolver domain list by name, expect DNS resolver domain list by name retrieved' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname62";
        $resourceGroupName = "powershell-test-rg-debug-get";
        
        New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")

        # ACT
        $dnsResolver =  Get-AzDnsResolverDomainList -DnsResolverDomainListName $dnsResolverDomainListName -ResourceGroupName $resourceGroupName

        # ASSERT
        $dnsResolver | Should -BeSuccessfullyCreated
    }

    It 'List DNS resolver domain lists in a resource group, expected least number of DNS resolver domain lists retrieved' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname63";
        $resourceGroupName = "powershell-test-rg-debug-get";

        New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")

        # ACT
        $dnsResolvers =  Get-AzDnsResolverDomainList -ResourceGroupName $resourceGroupName

        # ASSERT
        $dnsResolvers.Count | Should -BeGreaterThan 0
    }

    It 'List DNS resolver domain lists in a subscription, expected least number of DNS resolver domain lists retrieved' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname64";
        $resourceGroupName = "powershell-test-rg-debug-get";

        New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")

        # ACT
        $dnsResolvers =  Get-AzDnsResolverDomainList

        # ASSERT
        $dnsResolvers.Count | Should -BeGreaterThan 0
    }
}
