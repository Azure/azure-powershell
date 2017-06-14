function Test_SetAzureKeyVaultManagedStorageAccountAndRawSasDefinition
{
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'mngsas1'
    $paramatersSubCommand = '-Name $($managedStorageSasDefinitionName) -Parameter @{"sasType"="service";"serviceSasType"="blob";"signedResourceTypes"="b";"signedVersion"="2016-05-31";"signedProtocols"="https";"signedIp"="168.1.5.60-168.1.5.70";"validityPeriod"="P30D";"signedPermissions"="ra";"blobName"="blob1";"containerName"="container1";"rscd"="";"rscc"=""}'
    Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition $paramatersSubCommand 
}

function Test_SetAzureKeyVaultManagedStorageAccountAndBlobSasDefinition
{
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'mngsas2'
    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName) -Blob 'blob1' -Container 'container1' -ValidityPeriod ([System.Timespan]::FromDays(30)) -Permission Read,Add -SharedAccessHeader CacheControl,ContentDisposition -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70'"
    Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition $paramatersSubCommand 
}

function Test_SetAzureKeyVaultManagedStorageAccountAndBlobStoredPolicySasDefinition
{
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'mngsas2'
    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName) -Blob 'blob1' -Container 'container1' -Policy 'policy1' -SharedAccessHeader CacheControl,ContentDisposition -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70'"
    Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition $paramatersSubCommand 
}


function Test_SetAzureKeyVaultManagedStorageAccountAndContainerSasDefinition
{
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'mngsas3'
    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName) -Container 'container1' -ValidityPeriod ([System.Timespan]::FromDays(30)) -Permission Read,Add -SharedAccessHeader CacheControl,ContentDisposition -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70'"
    Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition $paramatersSubCommand 
}

function Test_SetAzureKeyVaultManagedStorageAccountAndShareSasDefinition
{
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'mngsas4'
    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName) -Share 'share1' -ValidityPeriod ([System.Timespan]::FromDays(30)) -Permission Read,Add -SharedAccessHeader CacheControl,ContentDisposition -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70'"
    Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition $paramatersSubCommand 
}

function Test_SetAzureKeyVaultManagedStorageAccountAndFileSasDefinition
{
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'mngsas5'
    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName) -Share 'share1' -Path 'path1' -ValidityPeriod ([System.Timespan]::FromDays(30)) -Permission Read,Add -SharedAccessHeader CacheControl,ContentDisposition -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70'"
    Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition $paramatersSubCommand 
}

function Test_SetAzureKeyVaultManagedStorageAccountAndQueueSasDefinition
{
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'mngsas6'
    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName) -Queue 'queue1' -ValidityPeriod ([System.Timespan]::FromDays(30)) -Permission Read,Add -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70'"
    Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition $paramatersSubCommand 
}

function Test_SetAzureKeyVaultManagedStorageAccountAndTableSasDefinition
{
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'mngsas6'
    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName) -Table 'table' -ValidityPeriod ([System.Timespan]::FromDays(30)) -Permission Read,Add -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70' -StartPartitionKey 'spk1' -EndPartitionKey 'epk1'"
    Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition $paramatersSubCommand 
}

function Test_SetAzureKeyVaultManagedStorageAccountAndAccountSasDefinition
{
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'mngsas7'
    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName) -Service Queue,Blob -ResourceType Container,Object -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70' -ValidityPeriod ([System.Timespan]::FromDays(30)) -Permission Add,Create"
    Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition $paramatersSubCommand 
}

function Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinition
{
    param([string] $paramatersSubCommand)
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'mngSt1'
    $global:createdManagedStorageAccounts += $managedStorageAccountName
    $storageAccountResourceId = Get-KeyVaultManagedStorageResourceId

    # set key vault managed storage account
    $managedStorageAccount = Add-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName -AccountResourceId $storageAccountResourceId -ActiveKeyName 'key1' -DisableAutoRegenerateKey
    Assert-NotNull $managedStorageAccount
    
    $command = "Set-AzureKeyVaultManagedStorageSasDefinition -VaultName $($keyVault) -AccountName $($managedStorageAccountName) $($paramatersSubCommand)"  
    
    Write-Host $command
    
    $createdManagedStorageSasDefinition = Invoke-Expression $command
    Assert-NotNull $createdManagedStorageSasDefinition
   
    # Verify the secret
    Assert-NotNull $managedStorageAccount.AccountName
    Assert-NotNull $createdManagedStorageSasDefinition.Name
    $secretName = "$($managedStorageAccount.AccountName)-$($createdManagedStorageSasDefinition.Name)"
    $secret = Get-AzureKeyVaultSecret $keyVault $secretName
    Assert-NotNull $secret
    Assert-NotNull $secret.SecretValueText
}

function Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinitionPipeTest
{
    $keyVault = Get-KeyVault
    $managedStorageAccountName1 = Get-ManagedStorageAccountName 'mngSt1'
    $managedStorageAccountName2 = Get-ManagedStorageAccountName 'mngSt2'
    $global:createdManagedStorageAccounts += $managedStorageAccountName1
    $global:createdManagedStorageAccounts += $managedStorageAccountName2
    $storageAccountResourceId = Get-KeyVaultManagedStorageResourceId

    # set key vault managed storage account
    $managedStorageAccount1 = Add-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName1 -AccountResourceId $storageAccountResourceId -ActiveKeyName 'key1' -DisableAutoRegenerateKey
    Assert-NotNull $managedStorageAccount1

    $managedStorageAccount2 = Get-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName1 | Add-AzureKeyVaultManagedStorageAccount -AccountName $managedStorageAccountName2
    Assert-NotNull $managedStorageAccount2

    $managedStorageSasDefinitionName1 = Get-ManagedStorageSasDefinitionName 'mngsas8'
    $managedStorageSasDefinitionName2 = Get-ManagedStorageSasDefinitionName 'mngsas9'
    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName1) -Service Queue,Blob -ResourceType Container,Object -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70' -ValidityPeriod ([System.Timespan]::FromDays(30)) -Permission Add,Create"
    $command = "Set-AzureKeyVaultManagedStorageSasDefinition -VaultName $($keyVault) -AccountName $($managedStorageAccountName1) $($paramatersSubCommand)"
    Write-Host $command
    $createdManagedStorageSasDefinition1 = Invoke-Expression $command
    Assert-NotNull $createdManagedStorageSasDefinition1

    $createdManagedStorageSasDefinition2 = Get-AzureKeyVaultManagedStorageSasDefinition -VaultName $keyVault -AccountName $managedStorageAccountName1 -Name $managedStorageSasDefinitionName1 | Set-AzureKeyVaultManagedStorageSasDefinition -Name $managedStorageSasDefinitionName2
    Assert-NotNull $createdManagedStorageSasDefinition2

    # Verify the secret
    Assert-NotNull $managedStorageAccount1.AccountName
    Assert-NotNull $createdManagedStorageSasDefinition1.Name
    Assert-NotNull $managedStorageAccount2.AccountName
    Assert-NotNull $createdManagedStorageSasDefinition2.Name
    $secretName1 = "$($managedStorageAccount1.AccountName)-$($createdManagedStorageSasDefinition1.Name)"
    $secretName2 = "$($managedStorageAccount1.AccountName)-$($createdManagedStorageSasDefinition2.Name)"
    $secret1 = Get-AzureKeyVaultSecret $keyVault $secretName1
    $secret2 = Get-AzureKeyVaultSecret $keyVault $secretName2
    Assert-NotNull $secret1
    Assert-NotNull $secret2
    Assert-NotNull $secret1.SecretValueText
    Assert-NotNull $secret2.SecretValueText
}

function Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinitionAttribute
{
    $keyVault = Get-KeyVault
    $managedStorageAccountName1 = Get-ManagedStorageAccountName 'mngSt1'
    $managedStorageAccountName2 = Get-ManagedStorageAccountName 'mngSt2'
    $global:createdManagedStorageAccounts += $managedStorageAccountName1
    $global:createdManagedStorageAccounts += $managedStorageAccountName2
    $storageAccountResourceId = Get-KeyVaultManagedStorageResourceId
    
    # set key vault managed storage account
    $managedStorageAccount1 = Add-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName1 -AccountResourceId $storageAccountResourceId -ActiveKeyName 'key1' -DisableAutoRegenerateKey
    Assert-NotNull $managedStorageAccount1
    $managedStorageAccount2 = Get-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName1 | Add-AzureKeyVaultManagedStorageAccount -AccountName $managedStorageAccountName2 -Tag @{"tag1"="value1";"tag2"="value2"} -Disable
    Assert-NotNull $managedStorageAccount2

    Assert-True { $managedStorageAccount1.Attributes.Enabled }
    Assert-False { $managedStorageAccount2.Attributes.Enabled }
    Assert-True { $managedStorageAccount2.Tags.ContainsKey("tag1") }
    
    $managedStorageSasDefinitionName1 = Get-ManagedStorageSasDefinitionName 'mngsas8'

    $paramatersSubCommand = "-Name $($managedStorageSasDefinitionName1) -Service Queue,Blob -ResourceType Container,Object -Protocol HttpsOnly -IPAddressOrRange '168.1.5.60-168.1.5.70' -ValidityPeriod ([System.Timespan]::FromDays(30)) -Permission Add,Create"
    $command = "Set-AzureKeyVaultManagedStorageSasDefinition -VaultName $($keyVault) -AccountName $($managedStorageAccountName1) $($paramatersSubCommand) -Tag @{'tag3'='value3';'tag4'='value4'}"
    Write-Host $command
    $createdManagedStorageSasDefinition1 = Invoke-Expression $command
    Assert-NotNull $createdManagedStorageSasDefinition1
    Assert-True { $createdManagedStorageSasDefinition1.Tags.ContainsKey("tag3") }
}

function Test_UpdateAzureKeyVaultManagedStorageAccount
{
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'mngSt1'
    $global:createdManagedStorageAccounts += $managedStorageAccountName
    $storageAccountResourceId = Get-KeyVaultManagedStorageResourceId
    
    # set key vault managed storage account
    $managedStorageAccount = Add-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName -AccountResourceId $storageAccountResourceId -ActiveKeyName 'key1' -RegenerationPeriod ([System.Timespan]::FromDays(30))
    Assert-NotNull $managedStorageAccount

    $managedStorageAccountUpdate = Update-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName -ActiveKeyName 'key2' -Tag @{"tag3"="value3"} -PassThru
    Assert-NotNull $managedStorageAccountUpdate

    Assert-True { $managedStorageAccountUpdate.ActiveKeyName.Equals("key2") }
    Assert-True { $managedStorageAccountUpdate.Tags.ContainsKey("tag3") }
}

function Test_RegenerateAzureKeyVaultManagedStorageAccountAndSasDefinition
{
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'mngSt1'
    $global:createdManagedStorageAccounts += $managedStorageAccountName
    $storageAccountResourceId = Get-KeyVaultManagedStorageResourceId
    
    # set key vault managed storage account
    $managedStorageAccount = Add-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName -AccountResourceId $storageAccountResourceId -ActiveKeyName 'key1' -RegenerationPeriod ([System.Timespan]::FromDays(30))
    Assert-NotNull $managedStorageAccount

    $managedStorageAccountUpdate = Update-AzureKeyVaultManagedStorageAccountKey -VaultName $keyVault -AccountName $managedStorageAccountName -KeyName 'key2' -Force -Confirm:$false -PassThru
    Assert-NotNull $managedStorageAccountUpdate

    Assert-True { $managedStorageAccountUpdate.ActiveKeyName.Equals("key2") }
}

function Test_ListKeyVaultAzureKeyVaultManagedStorageAccounts
{
    $keyVault = Get-KeyVault
    $managedStorageAccountName01 = Get-ManagedStorageAccountName 'listmngSt1'
    $storageAccountResourceId = Get-KeyVaultManagedStorageResourceId
    
    $createdmanagedStorageAccountName01 = Add-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName01 -AccountResourceId $storageAccountResourceId -ActiveKeyName 'key1' -RegenerationPeriod ([System.Timespan]::FromDays(30))
    Assert-NotNull $createdmanagedStorageAccountName01

    $managedStorageAccountName02 = Get-ManagedStorageAccountName 'listmngSt2'
    $createdmanagedStorageAccountName02 = Add-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName02 -AccountResourceId $storageAccountResourceId -ActiveKeyName 'key1' -RegenerationPeriod ([System.Timespan]::FromDays(30))
    Assert-NotNull $createdmanagedStorageAccountName02

    $managedStorageAccounts = Get-AzureKeyVaultManagedStorageAccount $keyVault
    Assert-NotNull $managedStorageAccounts

    Assert-True { $managedStorageAccounts.Count -ge 2 }

    $item01 = $managedStorageAccounts | where { Equal-String $_.AccountName $managedStorageAccountName01 } | Select -First 1
    Assert-NotNull $item01

    $item02 = $managedStorageAccounts | where { Equal-String $_.AccountName $managedStorageAccountName02 } | Select -First 1
    Assert-NotNull $item02
}