if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDnsResolverPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDnsResolverPolicy' {
    It 'Get single DNS resolver policy by name, expect DNS resolver policy by name retrieved' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname62";
        $resourceGroupName = "powershell-test-rg-debug-get";
        
        New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location

        # ACT
        $dnsResolver =  Get-AzDnsResolverPolicy -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName

        # ASSERT
        $dnsResolver | Should -BeSuccessfullyCreated
    }

    It 'List DNS resolver policies in a resource group, expected least number of DNS resolver policies retrieved' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname63";
        $resourceGroupName = "powershell-test-rg-debug-get";

        New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location

        # ACT
        $dnsResolvers =  Get-AzDnsResolverPolicy -ResourceGroupName $resourceGroupName

        # ASSERT
        $dnsResolvers.Count | Should -BeGreaterThan 0
    }

    It 'List DNS resolver policies in a subscription, expected least number of DNS resolver policies retrieved' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname64";
        $resourceGroupName = "powershell-test-rg-debug-get";

        New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location

        # ACT
        $dnsResolvers =  Get-AzDnsResolverPolicy

        # ASSERT
        $dnsResolvers.Count | Should -BeGreaterThan 0
    }
}
