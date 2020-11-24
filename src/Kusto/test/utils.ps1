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
    $rstr6 = RandomString -allChars $false -len 6
    $null = $env.Add("rstr4", $rstr4)
    $null = $env.Add("rstr5", $rstr5)
    $null = $env.Add("rstr6", $rstr6)

    # Some constants
    $constants = Get-Content .\test\constants.json | ConvertFrom-Json
    $constants.psobject.Properties | ForEach-Object { $env[$_.Name] = $_.Value }

    # Create the test group
    $resourceGroupName = "testgroup" + $rstr1
    Write-Host "Start to create test resource group" $resourceGroupName
    $null = $env.Add("resourceGroupName", $resourceGroupName)
    New-AzResourceGroup -Name $resourceGroupName -Location $env.location


    # Create Storage Account
    $storageName = "storage" + $rstr1
    Write-Host "Start to create Storage Account" $storageName
    $null = $env.Add("storageName", $storageName)
    $storageParams = Get-Content .\test\deployment-templates\storage-account\parameters.json | ConvertFrom-Json
    $storageParams.parameters.storageAccounts_sdkpsstorage_name.value = $storageName
    set-content -Path .\test\deployment-templates\storage-account\parameters.json -Value (ConvertTo-Json $storageParams)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\storage-account\template.json -TemplateParameterFile .\test\deployment-templates\storage-account\parameters.json -Name storage -ResourceGroupName $resourceGroupName

    # Deploy cluster + database 
    $SubscriptionId = $env.SubscriptionId
    $clusterName = "testcluster" + $rstr1
    $databaseName = "testdatabase" + $rstr1
    $dataConnectionName = "testdataconnection" + $rstr1
    Write-Host "Start to create a cluster" $clusterName
    $null = $env.Add("clusterName", $clusterName)
    $null = $env.Add("databaseName", $databaseName)
    $null = $env.Add("databaseName1", $databaseName1)
    $null = $env.Add("dataConnectionName", $dataConnectionName)
    New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $env.location -SkuName $env.skuName -SkuTier $env.skuTier
    Write-Host "Start to create a database" $databaseName
    $softDeletePeriodInDaysUpdated = New-TimeSpan -Days 4
    $hotCachePeriodInDaysUpdated = New-TimeSpan -Days 2
    New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated

    # Note, for *Principal* tests, AzADApplication was created, see principalAssignmentName, principalId and principalAssignmentName1, principalId1 for details
    New-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $env.principalAssignmentName -PrincipalId $env.principalId -PrincipalType $env.principalType -Role $env.principalRole
    New-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $env.principalAssignmentName -DatabaseName $databaseName -PrincipalId $env.principalId -PrincipalType $env.principalType -Role $env.databasePrincipalRole

   
    # Deploy follower cluster for test
    $followerClusterName = "testfcluster" + $rstr2
    $attachedDatabaseConfigurationName = "testdbconf" + $rstr2
    Write-Host "Start to create a follower cluster" $followerClusterName
    $null = $env.Add("followerClusterName", $followerClusterName)
    $null = $env.Add("attachedDatabaseConfigurationName", $attachedDatabaseConfigurationName)
    New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $followerClusterName -Location $env.location -SkuName $env.skuName -SkuTier $env.skuTier
    $clusterResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$clusterName"
    New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $env.location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $env.defaultPrincipalsModificationKind

    # Deploy 2nd cluster for test
    $clusterName = "testcluster" + $rstr3
    Write-Host "Start to create 2nd cluster" $clusterName
    $null = $env.Add("PlainClusterName", $clusterName)
    New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $env.location -SkuName $env.skuName -SkuTier $env.skuTier

    # Adding constans for data-connetction tests
    $env.Add("locationfordc","Australia Central")
    $env.Add("resourceGroupNamefordc","test-clients-rg")
    $env.Add("clusterNamefordc","eventgridclienttest")
    $env.Add("databaseNamefordc","databasetest")
    $env.Add("iothubNamefordc","test-clients-iot")
    $env.Add("storageNamefordc","testclients")
    $env.Add("eventhubNSNameForEventGridfordc","testclientsns")
    $env.Add("eventhubNameForEventGridfordc","testclientseg")
    $env.Add("eventhubNamefordc","testclientseh")
    $env.Add("eventhubNSNamefordc","testclientsns")

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # Clean resources you create for testing
    # Removing resourcegroup will clean all the resources created for testing.
    Remove-AzResourceGroup -Name $env.resourceGroupName
}
