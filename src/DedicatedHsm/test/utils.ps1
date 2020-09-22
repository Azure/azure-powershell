function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.resourceGroup = 'dedicatedhsm-rg-' + (RandomString -allChars $false -len 6)
    $env.location = 'eastus'
    
    $dedicatedHsmName01 = 'hsm-' + (RandomString -allChars $false -len 6)
    $dedicatedHsmName02 = 'hsm-' + (RandomString -allChars $false -len 6)
    $dedicatedHsmName03 = 'hsm-' + (RandomString -allChars $false -len 6)
    $env.Add('dedicatedHsmName01', $dedicatedHsmName01)
    $env.Add('dedicatedHsmName02', $dedicatedHsmName02)
    $env.Add('dedicatedHsmName03', $dedicatedHsmName03)
    Write-Host "start to create test group"
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # Deploy public ip address
    Write-Host -ForegroundColor Green "Deploying public ip address"
    $publicIpName = "publicip" + (RandomString -allChars $false -len 6)
    $publicIpPara = Get-Content .\test\deployment-templates\public-ipaddress\parameters.json | ConvertFrom-Json
    $publicIpPara.parameters.publicIPAddresses_GWIP_name.Value = $publicIpName
    Set-Content -Path .\test\deployment-templates\public-ipaddress\parameters.json -Value (ConvertTo-Json $publicIpPara)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\public-ipaddress\template.json -TemplateParameterFile .\test\deployment-templates\public-ipaddress\parameters.json -Name $publicIpName -ResourceGroupName $env.resourceGroup
    $env.publicIpAddressId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/publicIPAddresses/$publicIpName"
    Write-Host -ForegroundColor Green "Deploy public ip address completed."

    # Deploy network security group for test
    Write-Host -ForegroundColor Green "Deploying network security group"
    $vnetSecurityName = "vnetSecurityGroup" + (RandomString -allChars $false -len 6)
    $vnetSecurityPara = Get-Content .\test\deployment-templates\security-network-group\parameters.json | ConvertFrom-Json
    $vnetSecurityPara.parameters.networkSecurityGroups_myHSM_vnet_compute_NRMS_name.Value = $vnetSecurityName
    Set-Content -Path .\test\deployment-templates\security-network-group\parameters.json -Value (ConvertTo-Json $vnetSecurityPara)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\security-network-group\template.json -TemplateParameterFile .\test\deployment-templates\security-network-group\parameters.json -Name $vnetSecurityName -ResourceGroupName $env.resourceGroup
    $env.vnetSecurityId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/networkSecurityGroups/$vnetSecurityName"
    Write-Host -ForegroundColor Green "Deploy network security group completed."

    # Deploy virtual network for test
    Write-Host -ForegroundColor Green "Deploying virtual network"
    $vnetName = "vnet" + (RandomString -allChars $false -len 6)
    $vnetPara = Get-Content .\test\deployment-templates\virtual-network\parameters.json | ConvertFrom-Json
    $vnetPara.parameters.virtualNetworks_myHSM_vnet_name.value = $vnetName
    $vnetPara.parameters.networkSecurityGroups_myHSM_vnet_compute_NRMS_externalid.value = $env.vnetSecurityId
    Set-Content -Path .\test\deployment-templates\virtual-network\parameters.json -Value (ConvertTo-Json $vnetPara)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\virtual-network\template.json -TemplateParameterFile .\test\deployment-templates\virtual-network\parameters.json -Name $vnetName -ResourceGroupName $env.resourceGroup
    $env.virtulaNetworkId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$vnetName"
    Write-Host -ForegroundColor Green "Deploy virtual network completed."

    # Deploy virtual network gateway for test
    Write-Host -ForegroundColor Green "Deploying virtual network gateway"
    $vnetGatewayName = "vnetGateway" + (RandomString -allChars $false -len 6)
    $vnetGatewa = Get-Content .\test\deployment-templates\virtual-network-gateway\parameters.json | ConvertFrom-Json
    $vnetGatewa.parameters.virtualNetworkGateways_GW_name.value = $vnetGatewayName
    $vnetGatewa.parameters.publicIPAddresses_GWIP_externalid.value = $env.publicIpAddressId
    $vnetGatewa.parameters.virtualNetworks_myHSM_vnet_externalid.value = $env.virtulaNetworkId
    Set-Content -Path .\test\deployment-templates\virtual-network-gateway\parameters.json -Value (ConvertTo-Json $vnetGatewa)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\virtual-network-gateway\template.json -TemplateParameterFile .\test\deployment-templates\virtual-network-gateway\parameters.json -Name $vnetGatewayName -ResourceGroupName $env.resourceGroup
    $env.vnetGatewayId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworkGateways/$vnetGatewayName"
    Write-Host -ForegroundColor Green "Deploy virtual network gateway completed."

    # Virtual network subnet id
    $env.vnetSubnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/hsmsubnet";
    # Create Dedicated Hsm for test.
    Write-Host -ForegroundColor Green "Create Dedicated Hsm for test"
    New-AzDedicatedHsm -Name  $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId $env.vnetSubnetId -NetworkInterface @{PrivateIPAddress = '10.2.1.120' }

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Removing resourcegroup will clean all the resources created for testing.
    Remove-AzResourceGroup -Name $env.resourceGroup
}

