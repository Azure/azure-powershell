function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    #Preload subscriptionId and tenant from context, which will be used in test
    #as default. You could change them if needed.
    Write-Host "Did i lost context"
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    Write-Host "Did i lost context nooo" $env.SubscriptionId "abc"
    $resourceGroup = 'databox-pwsh-rg-' + (RandomString -allChars $false -len 2)
    New-AzResourceGroup -Name $resourceGroup -Location WestUS
    Write-Host "RG created"
    $env.Add("StorageAccountId", "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/dhja/providers/Microsoft.Storage/storageAccounts/dhjapowershellstorage" )

    $env.Add("ResourceGroup",$resourceGroup)
    $env.Add("KekUrl", "https://sdkkeyvault.vault.azure.net/keys/SSDKEY/")
    $env.Add("UserAssignedResourceId", "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/akvenkat/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdkIdentity")
    $env.Add("KekVaultResourceId", "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/akvenkat/providers/Microsoft.KeyVault/vaults/SDKKeyVault")

    #Create job for all other operation except New
    $jobName = "powershellRandom" + (RandomString -allChars $false -len 4)

    $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("dhja@microsoft.com") -Phone "1234567891"

    $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

    $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/dhja/providers/Microsoft.Storage/storageAccounts/dhjapowershellstorage"

    $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} )-ContactDetail $contactDetail -ShippingAddress $ShippingDetails
    
    Write-Host -ForegroundColor Green "Just did " + $jobName

    New-AzDataBoxJob -Name $jobName -SubscriptionId "fa68082f-8ff7-4a25-95c7-ce9da541242f" -ResourceGroupName $resourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" 

    Write-Host -ForegroundColor Green "Create completed" 
    $env.Add("JobName",$jobName)
    $env.Add("JobNameImport","powershell" + (RandomString -allChars $false -len 4))
    $env.Add("JobNameUAI", "powershellUAI" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameExport", "powershellExport" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameScheduleOrder", "powershellSchedule" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameManagedDisk", "managedDisk" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameDisk", "PwshDisk" +(RandomString -allChars $false -len 4))
    $env.Add("JobNameHeavy", "PwshHeavy" +(RandomString -allChars $false -len 4))

    $env.Add("ContactName", "random")
    $env.Add("EmailList", @("dhja@microsoft.com"))
    $env.Add("Phone", "1234567891")

    $env.Add("StreetAddress1", "101 TOWNSEND ST")
    $env.Add("City", "San Francisco")
    $env.Add("StateOrProvince", "CA")
    $env.Add("Country", "US")
    $env.Add("AddressType", "Commercial")
    $env.Add("PostalCode", "94107")

    $env.Add("StagingStorageAccount", "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/dhja/providers/Microsoft.Storage/storageAccounts/manageddiskstrg")
    $env.Add("ManagedDiskRg", "/subscriptions/fa68082f-8ff7-4a25-95c7-ce9da541242f/resourceGroups/randommanagedisk1")

    #For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    Stop-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId
    Remove-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId   
    Write-Host -ForegroundColor Green "Just did " + $env.ResourceGroup
    Remove-AzResourceGroup -Name $env.ResourceGroup
}

