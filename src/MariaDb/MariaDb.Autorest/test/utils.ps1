. ("$PSScriptRoot\helper.ps1")
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
    $env.Location = 'eastus'
    $env.RepLocation = 'eastus2'
    $env.AdminLogin = 'adminuser'
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $env.AdminLoginPassword = 'Passw0rd01!!'
    #Generate some strings for use in the test.
    $rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr02 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr03 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr04 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr05 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr06 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr07 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr08 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $null = $env.add('rstr01', $rstr01)
    $null = $env.add('rstr02', $rstr02)
    $null = $env.add('rstr03', $rstr03)
    $null = $env.add('rstr04', $rstr04)
    $null = $env.add('rstr05', $rstr05)
    $null = $env.add('rstr06', $rstr06)
    $null = $env.add('rstr07', $rstr07)
    $null = $env.add('rstr08', $rstr08)
    
    # Create test resource group.
    $resourceGroup = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    Write-Host -ForegroundColor Green "Start to creating resource group for test..."
    New-AzResourceGroup -Name $resourceGroup -Location $env.Location
    $null = $env.Add('ResourceGroup', $resourceGroup)
    Write-Host -ForegroundColor Green "Resource group created successfully."
    # For any resources you created for test, you should add it to $env here.
 
    # create mariadb for test  
    Write-Host -ForegroundColor Green "Start to creating mariadb for test..."
    $rstrbc01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstrbc02 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstrgp01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstrgp02 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstrdel01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstrdel02 = 'mariadb-test-' + (RandomString -allChars $false -len 6)

    $mariaDbParam01 = @{Name=$rstrbc01; SkuName='B_Gen5_1'; AdminLogin=$env.AdminLogin; AdminLoginPassword=$env.AdminLoginPassword}
    $mariaDbParam02 = @{Name=$rstrbc02; SkuName='B_Gen5_1'; AdminLogin=$env.AdminLogin; AdminLoginPassword=$env.AdminLoginPassword}
    $mariaDbParam03 = @{Name=$rstrgp01; SkuName='GP_Gen5_4'; AdminLogin=$env.AdminLogin; AdminLoginPassword=$env.AdminLoginPassword}
    $mariaDbParam04 = @{Name=$rstrgp02; SkuName='GP_Gen5_4'; AdminLogin=$env.AdminLogin; AdminLoginPassword=$env.AdminLoginPassword}
    $mariaDbParam05 = @{Name=$rstrdel01; SkuName='B_Gen5_1'; AdminLogin=$env.AdminLogin; AdminLoginPassword=$env.AdminLoginPassword}
    $mariaDbParam06 = @{Name=$rstrdel02; SkuName='B_Gen5_1'; AdminLogin=$env.AdminLogin; AdminLoginPassword=$env.AdminLoginPassword}

    GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam01 -ResourceGroup $resourceGroup
    GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam02 -ResourceGroup $resourceGroup
    GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam03 -ResourceGroup $resourceGroup
    GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam04 -ResourceGroup $resourceGroup
    GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam05 -ResourceGroup $resourceGroup
    GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam06 -ResourceGroup $resourceGroup
    
    $null = $env.add('rstrbc01', $rstrbc01)
    $null = $env.add('rstrbc02', $rstrbc02)
    $null = $env.add('rstrgp01', $rstrgp01)
    $null = $env.add('rstrgp02', $rstrgp02)
    $null = $env.add('rstrdel01', $rstrdel01)
    $null = $env.add('rstrdel02', $rstrdel02)
    Write-Host -ForegroundColor Green "MariaDB created successfully."

    Write-Host -ForegroundColor Green "Start to creating replica mariadb for test..."
    $rstrrep01 = $rstrgp01 + '-rep' + (RandomNumber -len 3)
    New-AzMariaDbReplica -Name $rstrrep01 -ServerName $rstrgp01 -ResourceGroupName $resourceGroup
    $null = $env.add('rstrrep01', $rstrrep01)
    Write-Host -ForegroundColor Green "Replica mariaDB created successfully."

    Write-Host -ForegroundColor Green "Start to creating firewall rule for test..."
    $firewallName01 = 'fr-' + (RandomString -allChars $false -len 6)
    $firewallName02 = 'fr-' + (RandomString -allChars $false -len 6)
    $endIPAddress = '0.0.0.125'
    $startIPAddress = '0.0.0.1'
    New-AzMariaDbFirewallRule -Name $firewallName01 -ResourceGroupName $resourceGroup -ServerName $rstrbc02 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
    New-AzMariaDbFirewallRule -Name $firewallName02 -ResourceGroupName $resourceGroup -ServerName $rstrbc02 -EndIPAddress $endIPAddress -StartIPAddress $startIPAddress
    $null = $env.add('firewallName01', $firewallName01)
    $null = $env.add('firewallName02', $firewallName02)
    Write-Host -ForegroundColor Green "Firewall rule created successfully."

    $restorePointInTime = (Get-Date)
    $null = $env.add('restorePointInTime', $restorePointInTime)

    # Deploy virtual network for test
    Write-Host -ForegroundColor Green "Start deploying virtual network for test..."
    $vnetTemplate = Get-Content .\test\deployment-templates\virtual-network\template.json | ConvertFrom-Json
    $vnetPara = Get-Content .\test\deployment-templates\virtual-network\parameters.json | ConvertFrom-Json
    $vnetName = $vnetPara.parameters.virtualNetworks_vent_name.value
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\virtual-network\template.json -TemplateParameterFile .\test\deployment-templates\virtual-network\parameters.json -Name $vnetName -ResourceGroupName $resourceGroup
    $subnet01 = $vnetTemplate.resources.properties.subnets[0].name
    $subnet02 = $vnetTemplate.resources.properties.subnets[1].name
    $subnet03 = $vnetTemplate.resources.properties.subnets[2].name
    $subscriptionId = $env.SubscriptionId
    $env.subnet01 = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnet01"
    $env.subnet02 = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnet02"
    $env.subnet03 = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnet03"
    Write-Host -ForegroundColor Green "Virtual network created successfully."

    Write-Host -ForegroundColor Green "Start to creating mariadb virtual network for test..."
    $vnetRuleName01 = 'vnetrule-' + (RandomLetters -len 6)
    $vnetRuleName02 = 'vnetrule-' + (RandomLetters -len 6)
    New-AzMariaDbVirtualNetworkRule -ServerName $rstrgp02 -ResourceGroupName $resourceGroup -Name $vnetRuleName01 -SubnetId $env.subnet01 -IgnoreMissingVnetServiceEndpoint
    New-AzMariaDbVirtualNetworkRule -ServerName $rstrgp02 -ResourceGroupName $resourceGroup -Name $vnetRuleName02 -SubnetId $env.subnet02 -IgnoreMissingVnetServiceEndpoint
    $null = $env.add('vnetRuleName01', $vnetRuleName01)
    $null = $env.add('vnetRuleName02', $vnetRuleName02)
    Write-Host -ForegroundColor Green "Mariadb virtual network created successfully."

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroup
}


