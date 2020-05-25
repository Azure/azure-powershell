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
    # Generate some random strings for use in the test.
    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6
    $rstr4 = RandomString -allChars $false -len 6
    $env.Add("rstr1", $rstr1)
    $env.Add("rstr2", $rstr2)
    $env.Add("rstr3", $rstr3)
    $env.Add("rstr4", $rstr4)

    # Create the test group
    write-host "start to create test group"
    $resourceGroup = "testgroup" + $env.rstr1
    $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $resourceGroup -Location eastus
    
    # Create the test blockchain member
    $passwd = 'strongMemberAccountPassword@1' | ConvertTo-SecureString -AsPlainText -Force
    $csPasswd = 'strongConsortiumManagementPassword@1' | ConvertTo-SecureString -AsPlainText -Force
    $env.Add("passwd", $passwd)
    $env.Add("csPasswd", $csPasswd)
    $env.Add("blockchainMember", "myblockchain" + $rstr1)
    New-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup -Consortium ('consortium' + $env.rstr1) -ConsortiumManagementAccountPassword $csPasswd -Location eastus -Password $passwd -Protocol Quorum -Sku S0
    New-AzBlockchainMember -Name ("myblockchain" + $rstr4) -ResourceGroupName $env.resourceGroup -Consortium ('consortium' + $env.rstr4) -ConsortiumManagementAccountPassword $csPasswd -Location eastus -Password $passwd -Protocol Quorum -Sku S0

    # Create the test blockchain transaction node
    $env.Add("blockchainTransactionNode", "tranctionnode" + $rstr1)
    New-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name $env.blockchainTransactionNode -ResourceGroupName $env.resourceGroup -Location eastus -Password $passwd -confirm:$false
    New-AzBlockchainTransactionNode -BlockchainMemberName $env.blockchainMember -Name ("tranctionnode" + $rstr4) -ResourceGroupName $env.resourceGroup -Location eastus -Password $passwd -confirm:$false

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

