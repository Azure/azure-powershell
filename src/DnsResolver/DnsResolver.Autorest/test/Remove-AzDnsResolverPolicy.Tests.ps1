if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDnsResolverPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDnsResolverPolicy' {
    It 'Delete a DNS resolver policy by name, expected DNS resolver policy deleted' {
        # ARRANGE
       $dnsResolverPolicyName = "psdnsresolverpolicyname65";
       $resourceGroupName = "powershell-test-rg-debug-remove";
       $location = "westus2";

       New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location

       # ACT
       Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName

       # ASSERT 
        {Get-AzDnsResolverPolicy  -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName } | Should -Throw
   }

   It 'Delete a DNS resolver policy via identity, expected DNS resolver policy deleted' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname66";
        $resourceGroupName = "powershell-test-rg-debug-remove";
        $location = "westus2";

        New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location

        # ACT
        Get-AzDnsResolverPolicy  -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName | Remove-AzDnsResolverPolicy

        # ASSERT
        {Get-AzDnsResolverPolicy  -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName } | Should -Throw
    }
}
