if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDnsResolverPolicyVirtualNetworkLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverPolicyVirtualNetworkLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDnsResolverPolicyVirtualNetworkLink' {
    It 'Gets a virtual network link by name, expected virtual network link returned' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforlinknameafa9789a";
        $dnsResolverPolicyLinkName = "psdnsresolverpolicylinknameafa9789a";
        $virtualNetworkName = "psvirtualnetworkforlinknameafa9789a";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
        }

        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location
        $resolverPolicyLink = New-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -VirtualNetworkId $virtualNetworkId

        # ACT
        $dnsResolverPolicyLink = Get-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsResolverPolicyLink | Should -Not -BeNullOrEmpty
    
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }

    It 'List virtual network links, expected virtual network links returned' {
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
        $dnsResolverPolicyLinks = Get-AzDnsResolverPolicyVirtualNetworkLink -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsResolverPolicyLinks.Count | Should -BeGreaterThan 0
    
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicyVirtualNetworkLink -Name $dnsResolverPolicyLinkName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }
}
