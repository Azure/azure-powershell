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
    # Follow random strings will be used in the test directly, so add it to $env
    $rstr4 = RandomString -allChars $false -len 6
    $rstr5 = RandomString -allChars $false -len 6
    $null = $env.Add("rstr4", $rstr4)
    $null = $env.Add("rstr5", $rstr5)

    # Extra resources created through deployment templates.
    $virtualNetwork = "databricks-test-vn"

    # Create the test group
    write-host "start to create test group"
    $resourceGroup = "testgroup" + $rstr1
    $null = $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $resourceGroup -Location eastus

    # Deploy virtual network and network security group for test
    $subscriptionId = $env.SubscriptionId
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\security-network-group\template.json -TemplateParameterFile .\test\deployment-templates\security-network-group\parameters.json -Name nsg -ResourceGroupName $resourceGroup
    $null = $env.Add("virtualNetwork", "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$virtualNetwork")
    $vnPara = Get-Content .\test\deployment-templates\virtual-network\parameters.json | ConvertFrom-Json
    $vnPara.parameters.networkSecurityGroups_dolaulinsg_externalid.value = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Network/networkSecurityGroups/databricks-test-nsg"
    set-content -Path .\test\deployment-templates\virtual-network\parameters.json -Value (ConvertTo-Json $vnPara)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\virtual-network\template.json -TemplateParameterFile .\test\deployment-templates\virtual-network\parameters.json -Name vn -ResourceGroupName $resourceGroup

    # create two Databricks workspaces for test
    $testWorkspace1 = "workspace" + $rstr2
    New-AzDatabricksWorkspace -Name $testWorkspace1 -ResourceGroupName $resourceGroup -Location eastus -Sku standard
    $null = $env.Add("testWorkspace1", $testWorkspace1)
    $testWorkspace2 = "workspace" + $rstr3
    New-AzDatabricksWorkspace -Name $testWorkspace2 -ResourceGroupName $resourceGroup -Location eastus -Sku standard
    $null = $env.Add("testWorkspace2", $testWorkspace2)

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

