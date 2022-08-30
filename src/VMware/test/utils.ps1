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

    $privateCloudName1 = "azps_test_cloud" + (RandomString -allChars $false -len 4)
    $privateCloudName2 = "azps_test_cloud" + (RandomString -allChars $false -len 4)
    $privateCloudName3 = "azps_test_cloud" + (RandomString -allChars $false -len 4)

    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6
    $rstr4 = RandomString -allChars $false -len 6

    $env.Add("privateCloudName1", $privateCloudName1)
    $env.Add("privateCloudName2", $privateCloudName2)
    $env.Add("privateCloudName3", $privateCloudName3)
    
    $env.Add("rstr1", $rstr1)
    $env.Add("rstr2", $rstr2)
    $env.Add("rstr3", $rstr3)
    $env.Add("rstr4", $rstr4)

    $env.Add("policy1", "policy1")
    $env.Add("policy2", "policy2")

    $env.Add("location1", "centralus")
    $env.Add("location2", "westcentralus")

    # Create the test group
    write-host "start to create test group"
    $resourceGroup1 = "testgroup" + $env.rstr4
    $resourceGroup2 = "testgroup" + $env.rstr4
    $resourceGroup3 = "testgroup" + $env.rstr4
    $env.Add("resourceGroup1", $resourceGroup1)
    $env.Add("resourceGroup2", $resourceGroup2)
    $env.Add("resourceGroup3", $resourceGroup3)
    
    # Use mock environment, so we donnot run this cmdlet.
    # New-AzResourceGroup -Name $env.resourceGroup1 -Location $env.location1
    # New-AzResourceGroup -Name $env.resourceGroup2 -Location $env.location1
    # New-AzResourceGroup -Name $env.resourceGroup3 -Location $env.location1

    # New-AzVMwarePrivateCloud -Name $env.privateCloudName1 `
    #     -ResourceGroupName $env.resourceGroup1 -NetworkBlock 192.168.48.0/22 `
    #     -Sku av36 -ManagementClusterSize 3 -Location $env.location1 -AcceptEULA
    # New-AzVMwareAuthorization -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 `
    #     -ResourceGroupName $env.resourceGroup1
    
    # New-AzVMwarePrivateCloud -Name $env.privateCloudName2 `
    #     -ResourceGroupName $env.resourceGroup2 -NetworkBlock 192.168.48.0/22 `
    #     -Sku av36 -ManagementClusterSize 3 -Location $env.location1 -AcceptEULA
    # New-AzVMwareAuthorization -Name $env.rstr1 -PrivateCloudName $env.privateCloudName2 `
    #     -ResourceGroupName $env.resourceGroup2

    # New-AzVMwarePrivateCloud -Name $env.privateCloudName3 `
    #     -ResourceGroupName $env.resourceGroup3 -NetworkBlock 192.168.48.0/22 `
    #     -Sku av36 -ManagementClusterSize 3 -Location $env.location2 -AcceptEULA
    # New-AzVMwareAuthorization -Name $env.rstr1 -PrivateCloudName $env.privateCloudName3 `
    #     -ResourceGroupName $env.resourceGroup3
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.resourceGroup1
    # Remove-AzResourceGroup -Name $env.resourceGroup2
    # Remove-AzResourceGroup -Name $env.resourceGroup3
}