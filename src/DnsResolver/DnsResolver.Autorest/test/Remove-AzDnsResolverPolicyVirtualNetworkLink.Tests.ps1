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
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
        }

        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location
        $resolverPolicyLink = New-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -VirtualNetworkId $virtualNetworkId

        # ACT
        $updatedDnsResolverPolicyLink = Remove-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        { Get-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw
    
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }

    It 'Deletes a dns resolver policy virtual network link via identity' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforlinkname353hj35";
        $dnsResolverPolicyLinkName = "psdnsresolverpolicylinkname353hj35";
        $virtualNetworkName = "psvirtualnetworkforlinkname353hj35";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
        }

        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location
        $resolverPolicyLink = New-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -VirtualNetworkId $virtualNetworkId

        # ACT - ASSERT
        Get-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME | Remove-AzDnsResolverPolicyVirtualNetworkLink

        # ASSERT
        { Get-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw
    
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }
}
