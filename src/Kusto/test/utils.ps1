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
	Write-Host "sub id = " $env.SubscriptionId
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
    $env["rstr4"] = $rstr4
    $env["rstr5"] = $rstr5
    $env["rstr6"] = $rstr6

    # Some constants
    $constants = Get-Content .\test\constants.json | ConvertFrom-Json
    $constants.psobject.Properties | ForEach-Object { $env[$_.Name] = $_.Value }

    # Add network module
    Import-Module -Name Az.Network
    $env["virtualNetworkName"] = "test-clients-vnet"
    $env["clusterNetwork"] = "testclusternetwork3"
    $env["resourceGroupNamefordc"] = "test-clients-rg"
    $env["subnetName"] = "default"
    $env["networkClustersTestsSubscriptionId"] = "e8257c73-24c5-4791-94dc-8b7901c90dbf"
    $env["privateEndpointConnectionName"] = "testprivateconnection"
    $env["groupId"] = "cluster"
    $env["locationNetworking"] = "australiacentral"    
    $clusterName = $env.clusterNetwork
    $ResourceGroupName = $env.resourceGroupNamefordc
    $virtualNetwork = Get-AzVirtualNetwork -ResourceName $env.virtualNetworkName -ResourceGroupName $env.resourceGroupNamefordc
    $subnet = $virtualNetwork | Select-Object -ExpandProperty subnets | Where-Object Name -eq $env.subnetName
    $privateLinkServiceId = "/subscriptions/" +  $env.networkClustersTestsSubscriptionId + "/resourceGroups/" + $env.resourceGroupNamefordc + "/providers/Microsoft.Kusto/Clusters/" + $env.clusterNetwork
    $PrivateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $env.privateEndpointConnectionName -PrivateLinkServiceId $privateLinkServiceId -GroupId $env.groupId
    $env["privateLinkServiceConnection"] = $PrivateLinkServiceConnection
    New-AzPrivateEndpoint -Name $env.privateEndpointConnectionName -ResourceGroupName $env.resourceGroupNamefordc -Location $env.locationNetworking -PrivateLinkServiceConnection $env.privateLinkServiceConnection -Subnet $subnet -Force
    
    # Create the test group
    $resourceGroupName = "testgroup" + $rstr1
    Write-Host "Start to create test resource group" $resourceGroupName
    $env["resourceGroupName"] = $resourceGroupName
    New-AzResourceGroup -Name $resourceGroupName -Location $env.location

    # Create Storage Account
    $storageName = "storage" + $rstr1
    Write-Host "Start to create Storage Account" $storageName
    $env["storageName"] = $storageName
    $storageParams = Get-Content .\test\deployment-templates\storage-account\parameters.json | ConvertFrom-Json
    $storageParams.parameters.storageAccounts_sdkpsstorage_name.value = $storageName
    set-content -Path .\test\deployment-templates\storage-account\parameters.json -Value (ConvertTo-Json $storageParams)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\storage-account\template.json -TemplateParameterFile .\test\deployment-templates\storage-account\parameters.json -Name storage -ResourceGroupName $resourceGroupName
	
	$SubscriptionId = $env.SubscriptionId
	Write-Host "sub id = " $SubscriptionId
    # Deploy cluster + database 
    
    $clusterName = "testcluster" + $rstr1
    $databaseName = "testdatabase" + $rstr1
    $dataConnectionName = "testdataconnection" + $rstr1
    Write-Host "Start to create a cluster" $clusterName
    $env["clusterName"] = $clusterName
    $env["databaseName"] = $databaseName
    $env["databaseName1"] = $databaseName1
    $env["dataConnectionName"] = $dataConnectionName
    New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $env.location -SkuName $env.skuName -SkuTier $env.skuTier
    Write-Host "Start to create a database" $databaseName
    $softDeletePeriodInDaysUpdated = New-TimeSpan -Days 4
    $hotCachePeriodInDaysUpdated = New-TimeSpan -Days 2
    New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated -Subscription $SubscriptionId

    # Note, for *Principal* tests, AzADApplication was created, see principalAssignmentName, principalId and principalAssignmentName1, principalId1 for details
    New-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $env.principalAssignmentName -PrincipalId $env.principalId -PrincipalType $env.principalType -Role $env.principalRole
    New-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $env.principalAssignmentName -DatabaseName $databaseName -PrincipalId $env.principalId -PrincipalType $env.principalType -Role $env.databasePrincipalRole

    # Deploy follower cluster for test
    $followerClusterName = "testfcluster" + $rstr2
    $attachedDatabaseConfigurationName = "testdbconf" + $rstr2
    Write-Host "Start to create a follower cluster" $followerClusterName
    $env["followerClusterName"] = $followerClusterName
    $env["attachedDatabaseConfigurationName"] = $attachedDatabaseConfigurationName
    New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $followerClusterName -Location $env.location -SkuName $env.skuName -SkuTier $env.skuTier
    $clusterResourceId = "/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.Kusto/Clusters/$clusterName"
    New-AzKustoAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -ClusterName $followerClusterName -Name $attachedDatabaseConfigurationName -Location $env.location -ClusterResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $env.defaultPrincipalsModificationKind

    # Deploy 2nd cluster for test
    $clusterName = "testcluster" + $rstr3
    Write-Host "Start to create 2nd cluster" $clusterName
    $env["PlainClusterName"] = $clusterName
    New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $env.location -SkuName $env.skuName -SkuTier $env.skuTier

    # Adding constans for data-connetction tests
    $env["locationfordc"] = "Australia Central"
    $env["resourceGroupNamefordc"] = "test-clients-rg"
    $env["clusterNamefordc"] = "eventgridclienttest2"
    $env["databaseNamefordc"] = "databasetest"
    $env["iothubNamefordc"] = "test-clients-iot"
    $env["storageNamefordc"] = "testclients"
    $env["eventhubNSNameForEventGridfordc"] = "testclientsns22"
    $env["eventhubNameForEventGridfordc"] = "testclientseg"
    $env["eventhubNamefordc"] = "testclientseh"
    $env["eventhubNSNamefordc"] = "testclientsns22"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # Clean resources you create for testing
    # Removing resourcegroup will clean all the resources created for testing.
    # Remove-AzResourceGroup -Name $env.resourceGroupName
    $clusterName = $env.clusterNetwork
    $ResourceGroupName = $env.resourceGroupNamefordc    
    Remove-AzPrivateEndpoint -Name $env.privateEndpointConnectionName -ResourceGroupName $env.resourceGroupNamefordc -Force
}
