if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDnsResolverDomainList'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverDomainList.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDnsResolverDomainList' {
    It 'Delete a DNS resolver domain list by name, expected DNS resolver domain list deleted' {
        # ARRANGE
       $dnsResolverDomainListName = "psdnsresolverdomainlistname65";
       $resourceGroupName = "powershell-test-rg-debug-remove";
       $location = "westus2";

       New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")

       # ACT
       Remove-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName

       # ASSERT 
        {Get-AzDnsResolverDomainList  -DnsResolverDomainListName $dnsResolverDomainListName -ResourceGroupName $resourceGroupName } | Should -Throw
   }

   It 'Delete a DNS resolver domain list via identity, expected DNS resolver domain list deleted' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname66";
        $resourceGroupName = "powershell-test-rg-debug-remove";
        $location = "westus2";

        New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")

        # ACT
        Get-AzDnsResolverDomainList  -DnsResolverDomainListName $dnsResolverDomainListName -ResourceGroupName $resourceGroupName | Remove-AzDnsResolverDomainList

        # ASSERT
        {Get-AzDnsResolverDomainList  -DnsResolverDomainListName $dnsResolverDomainListName -ResourceGroupName $resourceGroupName } | Should -Throw
    }
}
