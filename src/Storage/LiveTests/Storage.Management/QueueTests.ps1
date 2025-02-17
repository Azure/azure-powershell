Invoke-LiveTestScenario -Name "Queue basics" -Description "Test queue basic operation" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $storageAccountName = New-LiveTestStorageAccountName
    $queueName = New-LiveTestResourceName
    $queueName2 = New-LiveTestResourceName
    $location = $rg.Location
    $account = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Location $location -SkuName Standard_GRS -AllowSharedKeyAccess $true -Tag @{"Az.Sec.DisableAllowSharedKeyAccess::Skip" = "For Powershell test."}
    $ctx = $account.Context 
    $ctx1 = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey (Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $storageAccountName)[0].Value

    $q = New-AzStorageQueue -Name $queueName -Context $ctx 
    Assert-AreEqual $queueName $q.Name 
    $q = Get-AzStorageQueue -Name $queueName -Context $ctx 
    Assert-AreEqual $queueName $q.Name 
    Assert-AreEqual 0 $q.ApproximateMessageCount
    Assert-AreEqual 0 $q.QueueProperties.ApproximateMessagesCount

    $q = New-AzStorageQueue -Name $queueName2 -Context $ctx1 
    $qs = Get-AzStorageQueue -Context $ctx1 
    Assert-AreEqual 2 $qs.Count

    $sas = New-AzStorageAccountSASToken -Service Queue -ResourceType Container,Object,Service -Permission rwdl -ExpiryTime 3000-01-01 -Context $ctx 
    $ctxaccountsas = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas 
    $qs = Get-AzStorageQueue -Context $ctxaccountsas 
    Assert-AreEqual 2 $qs.Count

    $sas = New-AzStorageQueueSASToken -Name $queueName -Context $ctx1 -Permission ruap 
    $sasctx = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas 
    $q = Get-AzStorageQueue -Name $queueName -Context $sasctx 
    Assert-AreEqual $queueName $q.Name

    $sas = New-AzStorageQueueSASToken -Name $queueName -Context $ctx -Permission rap -StartTime 2023-04-20 -ExpiryTime 2223-08-05
    $sasctx = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
    $q = Get-AzStorageQueue -Name $queuename -Context $sasctx
    Assert-AreEqual $queueName $q.Name

    $sas = New-AzStorageQueueSASToken -Name $queueName -Context $ctx -Permission raup -Protocol HttpsOnly -ExpiryTime 2223-08-05
    $sasctx = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas 
    $q = Get-AzStorageQueue -Name $queuename -Context $sasctx
    Assert-AreEqual $queueName $q.Name

    $sas = New-AzStorageQueueSASToken -Name $queueName -Context $ctx -Permission raup -ExpiryTime 2223-08-05 -FullUri

    $policyName1 = New-LiveTestResourceName
    $policyName2 = New-LiveTestResourceName
    $p = New-AzStorageQueueStoredAccessPolicy -Queue $queueName -Policy $policyName1 -Permission ruap -StartTime 2023-5-1 -ExpiryTime 2223-08-05 -Context $ctx 

    $p = Set-AzStorageQueueStoredAccessPolicy -Queue $queueName -Policy $policyName1 -Permission rau -NoStartTime -NoExpiryTime -Context $ctx
    Assert-AreEqual $policyName1 $p.Policy 
    Assert-Null $p.ExpiryTime
    Assert-Null $p.StartTime
    Assert-AreEqual "rau" $p.Permissions

    $p = New-AzStorageQueueStoredAccessPolicy -Queue $queueName -Policy $policyName2 -Permission ruap -Context $ctx1
    $p = Get-AzStorageQueueStoredAccessPolicy -Queue $queueName -Context $ctx 
    Assert-AreEqual 2 $p.Count
    $p = Get-AzStorageQueueStoredAccessPolicy -Queue $queueName -Policy $policyName1 -Context $ctx1
    Assert-AreEqual $policyName1 $p.Policy

    Remove-AzStorageQueueStoredAccessPolicy -Queue $queueName -Policy $policyName1 -Context $ctx
    Remove-AzStorageQueue -Name $queueName -Context $ctx -Force 
    $q2 = Get-AzStorageQueue -Name $queueName2 -Context $ctx
    $q2 | Remove-AzStorageQueue -Force
}