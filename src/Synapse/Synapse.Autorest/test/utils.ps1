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

    # Create Storage Account and Workspace
    $storageName = "storage" + $rstr1
    $fileSystemName = "filesystem" + $rstr1
    $workspaceName = "workspace" + $rstr1
    Write-Host "Start to create Workspace" $workspaceName
    $null = $env.Add("storageName", $storageName)
    $null = $env.Add("fileSystemName", $fileSystemName)
    $null = $env.Add("workspaceName", $workspaceName)
    $workspaceParams = Get-Content .\test\deployment-templates\workspace\parameters.json | ConvertFrom-Json
    $workspaceParams.parameters.defaultDataLakeStorageAccountName.value = $storageName
    $workspaceParams.parameters.defaultDataLakeStorageFilesystemName.value = $fileSystemName
    $workspaceParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\workspace\parameters.json -Value (ConvertTo-Json $workspaceParams)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\workspace\template.json -TemplateParameterFile .\test\deployment-templates\workspace\parameters.json -Name workspace -ResourceGroupName $resourceGroupName
    
    # Deploy kusto pool
    $kustoPoolName = "testkustopool" + $rstr1
    $databaseName = "testdatabase" + $rstr1
    Write-Host "Start to create a Kusto pool" $kustoPoolName
    $null = $env.Add("kustopoolName", $kustoPoolName)
    $null = $env.Add("databaseName", $databaseName)
    New-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $kustoPoolName -Location $env.location -SkuName $env.skuName -SkuSize $env.skuSize
    Write-Host "Start to create a database" $databaseName
    $softDeletePeriodInDaysUpdated = New-TimeSpan -Days 4
    $hotCachePeriodInDaysUpdated = New-TimeSpan -Days 2
    New-AzSynapseKustoPoolDatabase -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Name $databaseName -Kind ReadWrite -Location $env.location -SoftDeletePeriod $softDeletePeriodInDaysUpdated -HotCachePeriod $hotCachePeriodInDaysUpdated

    # Note, for *Principal* tests, AzADApplication was created, see principalAssignmentName, principalId and principalAssignmentName1, principalId1 for details
    New-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -PrincipalAssignmentName $env.principalAssignmentName -PrincipalId $env.principalId -PrincipalType $env.principalType -Role $env.principalRole
    New-AzSynapseKustoPoolDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -PrincipalAssignmentName $env.principalAssignmentName -DatabaseName $databaseName -PrincipalId $env.principalId -PrincipalType $env.principalType -Role $env.databasePrincipalRole

    # Deploy follower kusto pool for test
    $subscriptionId = $env.SubscriptionId
    $followerKustoPoolName = "testfkustopool" + $rstr2
    $attachedDatabaseConfigurationName = "testdbconf" + $rstr2
    Write-Host "Start to create a follower kusto pool" $followerKustoPoolName
    $null = $env.Add("followerKustoPoolName", $followerKustoPoolName)
    $null = $env.Add("attachedDatabaseConfigurationName", $attachedDatabaseConfigurationName)
    New-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $followerKustoPoolName -Location $env.location -SkuName $env.skuName -SkuSize $env.skuSize
    $clusterResourceId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Synapse/workspaces/$workspaceName/kustoPools/$kustoPoolName"
    New-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $followerKustoPoolName -Name $attachedDatabaseConfigurationName -Location $env.location -KustoPoolResourceId $clusterResourceId -DatabaseName $databaseName -DefaultPrincipalsModificationKind $env.defaultPrincipalsModificationKind

    # Deploy 2nd kusto pool for test
    $kustoPoolName = "testkustopool" + $rstr3
    Write-Host "Start to create 2nd Kusto pool" $kustoPoolName
    $null = $env.Add("plainKustoPoolName", $kustoPoolName)
    New-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $kustoPoolName -Location $env.location -SkuName $env.skuName -SkuSize $env.skuSize
    
    # Create event hub and Iot hub to test data connection
    $eventhubNS = "eventhubNS" + $rstr1
    $eventhub = "eventhub" + $rstr1
    $eventgrid = "eventgrid" + $rstr1
    Write-Host "Start to create Event Hub under" $eventhubNS
    $null = $env.Add("eventhubNS", $eventhubNS)
    $null = $env.Add("eventhub", $eventhub)
    $null = $env.Add("eventgrid", $eventgrid)
    $eventhubParams = Get-Content .\test\deployment-templates\event-hub\parameters.json | ConvertFrom-Json
    $eventhubParams.parameters.eventhub_namespace.value = $eventhubNS
    $eventhubParams.parameters.eventhub_name.value = $eventhub
    $eventhubParams.parameters.eventgrid_name.value = $eventgrid
    set-content -Path .\test\deployment-templates\event-hub\parameters.json -Value (ConvertTo-Json $eventhubParams)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\event-hub\template.json -TemplateParameterFile .\test\deployment-templates\event-hub\parameters.json -Name eventhub -ResourceGroupName $resourceGroupName

    $iothub = "iothub" + $rstr1
    Write-Host "Start to create Iot Hub" $iothub
    $null = $env.Add("iothub", $iothub)
    $iothubParams = Get-Content .\test\deployment-templates\iot-hub\parameters.json | ConvertFrom-Json
    $iothubParams.parameters.hubname.value = $iothub
    set-content -Path .\test\deployment-templates\iot-hub\parameters.json -Value (ConvertTo-Json $iothubParams)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\iot-hub\template.json -TemplateParameterFile .\test\deployment-templates\iot-hub\parameters.json -Name iothub -ResourceGroupName $resourceGroupName
    
    $null = $env.Add("dataConnectionName", "testdataconnection" + $rstr1)
    
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.followerKustoPoolName
    Remove-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.kustoPoolName
    Remove-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.plainKustoPoolName
    Remove-AzResourceGroup -Name $env.resourceGroupName
}

