Invoke-LiveTestScenario -Name "Table basics" -Description "Test Table basic operation" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $storageAccountName = New-LiveTestStorageAccountName
    $tableName = New-LiveTestResourceName
    $tableName2 = New-LiveTestResourceName
    $location = $rg.Location
    $account = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Location $location -SkuName Standard_GRS -AllowSharedKeyAccess $true -Tag @{"Az.Sec.DisableAllowSharedKeyAccess::Skip" = "For Powershell test."}
    $ctx = $account.Context 
    $ctx1 = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey (Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $storageAccountName)[0].Value

    # Create Table
    New-AzStorageTable -Name $tableName -Context $ctx
    $table =Get-AzStorageTable -Name $tableName -Context $ctx
    Assert-AreEqual $table.Count 1
    Assert-AreEqual $table[0].Name $tableName
    New-AzStorageTable -Name $tableName2 -Context $ctx1
    $table2 =Get-AzStorageTable -Name $tableName2 -Context $ctx1
    Assert-AreEqual $table2.Count 1
    Assert-AreEqual $table2[0].Name $tableName2

    #Test run Table query - Insert Entity
    $partitionKey = "p123"
    $rowKey = "row123"
    $tableRow = [Azure.Data.Tables.TableEntity]::new($partitionKey, $rowKey)
    $tableRow.Add("Name", "name1")      
    $tableRow.Add("ID", 4567)            
    $methodAddEntity = [Azure.Data.Tables.TableClient].GetMethods() | Where-Object Name -eq "AddEntity"
    $methodAddEntity = $methodAddEntity.MakeGenericMethod([Azure.Data.Tables.TableEntity])
    $methodAddEntity.Invoke($table.TableClient, @([Azure.Data.Tables.TableEntity]$tableRow, $null))

    # Create Table Object - which reference to exist Table with SAS
    $tableSASUri = New-AzStorageTableSASToken -Name $tablename  -Permission "raud" -ExpiryTime (([DateTime]::UtcNow.AddDays(10))) -FullUri -Context $ctx
    $uri = [System.Uri]$tableSASUri
    $sasTable = New-Object -TypeName Azure.Data.Tables.TableClient $uri 

    #Get Entity
    $methodGetEntity = [Azure.Data.Tables.TableClient].GetMethods() | Where-Object Name -eq "GetEntity"
    $methodGetEntity = $methodGetEntity.MakeGenericMethod([Azure.Data.Tables.TableEntity])
    $entity = $methodGetEntity.Invoke($sasTable, @($partitionKey,$rowKey, $null, $null)).Value
    Assert-AreEqual $partitionKey $entity["PartitionKey"]
    Assert-AreEqual $rowKey $entity["RowKey"]
    Assert-AreEqual "name1" $entity["Name"]
    Assert-AreEqual 4567 $entity["ID"]

    # Get/Remove Table
    $tableCount1 = (Get-AzStorageTable -Context $ctx).Count
    Assert-AreEqual $tableCount1 2
    Remove-AzStorageTable -Name $tableName -Force -Context $ctx
    $tableCount2 = (Get-AzStorageTable -Context $ctx1).Count  
    Assert-AreEqual $tableCount2 1
    $table2 | Remove-AzStorageTable -Force
    $tableCount3 = (Get-AzStorageTable -Context $ctx1).Count 
    Assert-AreEqual $tableCount3 0
}