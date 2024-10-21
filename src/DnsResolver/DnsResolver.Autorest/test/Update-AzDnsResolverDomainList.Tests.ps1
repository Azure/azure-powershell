if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDnsResolverDomainList'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverDomainList.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDnsResolverDomainList' {
    It 'Update DNS Resolver Policy by adding tag, expect DNS resolver policy updated' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname47";
        $resourceGroupName = "powershell-test-rg-debug-update";
        $location = "westus2";

        $originalDnsResolverDomainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")

        $tag  = GetRandomHashtable -size 5

        # ACT
        $updatedDnsResolverDomainList = Update-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Tag $tag

        # ASSERT
        $updatedDnsResolverDomainList | Should -BeSuccessfullyCreated
        $updatedDnsResolverDomainList | Should -BeSameAsExpected -ExpectedValue $originalDnsResolverDomainList
        $updatedDnsResolverDomainList.Tag.Count | Should -Be $tag.Count
    }
}
