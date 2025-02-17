if(($null -eq $TestName) -or ($TestName -contains 'New-AzDnsResolverPolicyVirtualNetworkLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverPolicyVirtualNetworkLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDnsResolverPolicyVirtualNetworkLink' {
    It 'Creates a virtual network link to a DNS resolver policy.' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforlinkname0j0cdzg";
        $dnsResolverPolicyLinkName = "psdnsresolverpolicylinkname0j0cdzg";
        $virtualNetworkName = "psvirtualnetworkforlinkname0j0cdzg";
        $resourceGroupName = "powershell-test-rg-debug-new";
        $location = "westus2";

        $subscriptionId = "91ab65d2-c73f-4768-89d0-b061815f258b";
        $virtualNetworkId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet
        }

        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location

        # ACT
        $resolverPolicyLink = New-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -VirtualNetworkId $virtualNetworkId

        # ASSERT
        { Get-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName } | Should -Not -Throw
    }
}
