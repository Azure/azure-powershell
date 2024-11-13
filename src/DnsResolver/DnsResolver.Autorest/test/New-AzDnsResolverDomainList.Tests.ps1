if(($null -eq $TestName) -or ($TestName -contains 'New-AzDnsResolverDomainList'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverDomainList.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDnsResolverDomainList' {
    It 'Create DNS resolver domain list' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname0j0cdzg";
        $resourceGroupName = "powershell-test-rg-debug-new";
        $location = "westus2";

        # ACT
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")

        # ASSERT
        $domainList | Should -BeSuccessfullyCreated
    }

    It 'Update DNS Resolver domain list with new tags.' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname4c7glpm";
        $resourceGroupName = "powershell-test-rg-debug-new";
        $location = "westus2";

        New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")
        $tag = GetRandomHashtable -size 2

        # ACT
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.") -Tag $tag

        # ASSERT
        $domainList.ProvisioningState  | Should -Be "Succeeded"
        $domainList.Tag.Count | Should -Be $tag.Count
    }
}
