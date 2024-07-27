if(($null -eq $TestName) -or ($TestName -contains "AzNginxTestAll"))
{
  $loadEnvPath = Join-Path $PSScriptRoot "loadEnv.ps1"
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot "..\loadEnv.ps1"
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot "AzNginxTestAll.Recording.json"
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include "HttpPipelineMocking.ps1" -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Write-Host "test2";
Write-Host $env;

Describe "AzNginxTestAll" {
    It "CreateExpanded" {
        New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

        $ip = @{
            Name = $env.pubip
            ResourceGroupName = $env.resourceGroup
            Location = $env.location
            Sku = "Standard"
            AllocationMethod = "Static"
            IpAddressVersion = "IPv4"
            Zone = 2
        }

        $publicIp = New-AzPublicIpAddress @ip -Force

        # $vnet = @{
        #     Name = $env.vnet
        #     ResourceGroupName = $env.resourceGroup
        #     Location = $env.location
        #     AddressPrefix = "10.0.0.0/16"
        # }
        # $virtualNetwork = New-AzVirtualNetwork $vnet

        # $subnet = @{
        #     Name = $env.subnet
        #     VirtualNetwork = $virtualNetwork
        #     AddressPrefix = "10.0.0.0/24"
        # }
        # $subnetConfig = Add-AzVirtualNetworkSubnetConfig $subnet
        # $virtualNetwork | Set-AzVirtualNetwork

        # $vnet = Get-AzVirtualNetwork -Name $env.vnet -ResourceGroupName $env.resourceGroup
        # $subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.subnet -VirtualNetwork $vnet
        # $subnet = Add-AzDelegation -Name "delegation" -ServiceName $env.delegation -Subnet $subnet
        # Set-AzVirtualNetwork -VirtualNetwork $vnet

        # $publicIp = New-AzNginxPublicIPAddressObject -Id /subscriptions/e3853e83-0d02-4fb3-b88f-05b5fd21aee2/resourceGroups/az-pwsh-testrg/providers/Microsoft.Network/publicIPAddresses/testpubip
        # Write-Host "test3";
        # Write-Host $publicIp;
        # $networkProfile = New-AzNginxNetworkProfileObject -FrontEndIPConfiguration @{PublicIPAddress=@($publicIp)} -NetworkInterfaceConfiguration @{SubnetId="/subscriptions/e3853e83-0d02-4fb3-b88f-05b5fd21aee2/resourceGroups/az-pwsh-testrg/providers/Microsoft.Network/virtualNetworks/testvnet/subnets/default"}
        # Write-Host "test4";
        # Write-Host $networkProfile;
        # $nginxDeployment = New-AzNginxDeployment -Name $env.nginxDeployment2 -ResourceGroupName $env.resourceGroup -Location $env.location -NetworkProfile $networkProfile -SkuName standard_Monthly_gmz7xq9ge3py
        # Write-Host "test5";
        # Write-Host $nginxDeployment;
        # $nginxDeployment.ProvisioningState | Should -Be "Succeeded"
        # $nginxDeployment.Name | Should -Be $env.nginxDeployment2
    }
}