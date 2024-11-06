if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDnsResolverPolicyVirtualNetworkLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverPolicyVirtualNetworkLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDnsResolverPolicyVirtualNetworkLink' {
    It 'Deletes a dns resolver policy virtual network link' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforlinkname7sadjfa";
        $dnsResolverPolicyLinkName = "psdnsresolverpolicylinkname7sadjfa";
        $virtualNetworkName = "psvirtualnetworkforlinkname7sadjfa";
        $resourceGroupName = "powershell-test-rg-debug-remove";
        $location = "westus2";
        $subscriptionId = "91ab65d2-c73f-4768-89d0-b061815f258b";
        $virtualNetworkId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet
        }

        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location
        $resolverPolicyLink = New-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -VirtualNetworkId $virtualNetworkId

        # ACT
        $updatedDnsResolverPolicyLink = Remove-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName

        # ASSERT
        { Get-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName } | Should -Throw
    }

    It 'Deletes a dns resolver policy virtual network link via identity' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforlinkname353hj35";
        $dnsResolverPolicyLinkName = "psdnsresolverpolicylinkname353hj35";
        $virtualNetworkName = "psvirtualnetworkforlinkname353hj35";
        $resourceGroupName = "powershell-test-rg-debug-remove";
        $location = "westus2";
        $subscriptionId = "91ab65d2-c73f-4768-89d0-b061815f258b";
        $virtualNetworkId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet
        }

        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location
        $resolverPolicyLink = New-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -VirtualNetworkId $virtualNetworkId

        # ACT - ASSERT
        Get-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName | Remove-AzDnsResolverPolicyVirtualNetworkLink

        # ASSERT
        { Get-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName } | Should -Throw
    }
}
