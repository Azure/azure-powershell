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

       New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location

       # ACT
       Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME

       # ASSERT 
        {Get-AzDnsResolverPolicy  -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw
   }

   It 'Delete a DNS resolver policy via identity, expected DNS resolver policy deleted' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname66";

        New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location

        # ACT
        Get-AzDnsResolverPolicy  -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME | Remove-AzDnsResolverPolicy

        # ASSERT
        {Get-AzDnsResolverPolicy  -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw
    }
}
