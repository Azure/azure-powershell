$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataBoxJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataBoxJob' {
    It 'Import Job Test' {
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId $env.StorageAccountId

        $details = New-AzDataBoxJobDetailsObject -DataImportDetail @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"}) `
            -ContactDetailsContactName $env.ContactName `
            -ContactDetailEmailList $env.EmailList `
            -ContactDetailsPhone $env.Phone `
            -StreetAddress1 $env.StreetAddress1 `
            -StateOrProvince $env.StateOrProvince `
            -Country $env.Country `
            -City $env.City `
            -PostalCode $env.PostalCode `
            -ShippingAddressType $env.AddressType

        $resource = New-AzDataBoxJob -Name $env.JobNameImport -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" -SkuModel "AzureDataBox120"

        $resource.Status | Should -Be 'DeviceOrdered'
    }
    It 'Import Job with managed disk' {
        $managedDiskAccount = New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId $env.ManagedDiskRg -StagingStorageAccountId $env.StagingStorageAccount

        $details = New-AzDataBoxJobDetailsObject -DataImportDetail @(@{AccountDetail=$managedDiskAccount; AccountDetailDataAccountType = "ManagedDisk"}) `
            -ContactDetailsContactName $env.ContactName `
            -ContactDetailEmailList $env.EmailList `
            -ContactDetailsPhone $env.Phone `
            -StreetAddress1 $env.StreetAddress1 `
            -StateOrProvince $env.StateOrProvince `
            -Country $env.Country `
            -City $env.City `
            -PostalCode $env.PostalCode `
            -ShippingAddressType $env.AddressType

        $resource = New-AzDataBoxJob -Name $env.JobNameManagedDisk -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" -SkuModel "AzureDataBox120"

        $resource.Status | Should -Be 'DeviceOrdered'
    }
    It 'Export Job Test' {
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId $env.StorageAccountId

        $transferConfigurationType = New-AzDataBoxTransferConfigurationObject -Type "TransferAll" -TransferAllDetail @{"IncludeDataAccountType"="StorageAccount";"IncludeTransferAllBlob"= "True"; "IncludeTransferAllFile" = "True"}

        $details = New-AzDataBoxJobDetailsObject -DataExportDetail @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"; "TransferConfiguration"= $transferConfigurationType}) `
            -ContactDetailsContactName $env.ContactName `
            -ContactDetailEmailList $env.EmailList `
            -ContactDetailsPhone $env.Phone `
            -StreetAddress1 $env.StreetAddress1 `
            -StateOrProvince $env.StateOrProvince `
            -Country $env.Country `
            -City $env.City `
            -PostalCode $env.PostalCode `
            -ShippingAddressType $env.AddressType

        $resource = New-AzDataBoxJob -Name $env.JobNameExport -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ExportFromAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" -SkuModel "AzureDataBox120"

        $resource.Status | Should -Be 'DeviceOrdered'
        Write-Host -ForegroundColor Green "Create Export completed"
    }
    It 'Import Job UAI Test' {
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId $env.StorageAccountId

        $details = New-AzDataBoxJobDetailsObject -DataImportDetail @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"}) `
            -ContactDetailsContactName $env.ContactName `
            -ContactDetailEmailList $env.EmailList `
            -ContactDetailsPhone $env.Phone `
            -StreetAddress1 $env.StreetAddress1 `
            -StateOrProvince $env.StateOrProvince `
            -Country $env.Country `
            -City $env.City `
            -PostalCode $env.PostalCode `
            -ShippingAddressType $env.AddressType `
            -KeyEncryptionKeyKekType "CustomerManaged" `
            -IdentityPropertyType "UserAssigned" `
            -KeyEncryptionKeyKekUrl $env.KekUrl `
            -KeyEncryptionKeyKekVaultResourceId $env.KekVaultResourceId `
            -UserAssignedResourceId $env.UserAssignedResourceId

        $resource = New-AzDataBoxJob -Name $env.JobNameUAI -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" -SkuModel "AzureDataBox120" -IdentityType "UserAssigned" -UserAssignedIdentity @($env.UserAssignedResourceId)

        $resource.Status | Should -Be 'DeviceOrdered'
    }
    It 'Schedule Job Test' {
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId $env.StorageAccountId

        $details = New-AzDataBoxDiskJobDetailsObject -DataImportDetail @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"}) `
            -ContactDetailsContactName $env.ContactName `
            -ContactDetailEmailList $env.EmailList `
            -ContactDetailsPhone $env.Phone `
            -StreetAddress1 $env.StreetAddress1 `
            -StateOrProvince $env.StateOrProvince `
            -Country $env.Country `
            -City $env.City `
            -PostalCode $env.PostalCode `
            -ShippingAddressType $env.AddressType `
            -ExpectedDataSizeInTeraByte 10

        $date = Get-Date
        $scheduleDate = $date.AddDays(15)

        $resource = New-AzDataBoxJob -Name $env.JobNameScheduleOrder -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBoxDisk" -SkuModel "DataBoxDisk" -DeliveryType "Scheduled" -DeliveryInfoScheduledDateTime $scheduleDate

        Write-Host -ForegroundColor Green "Create Schedule completed" $resource.DeliveryInfoScheduledDateTime
        $resource.DeliveryType | Should -Be "Scheduled"
        $resource.Status | Should -Be 'DeviceOrdered'
    }
    It 'Create databox heavy order' {
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId $env.StorageAccountId

        $details = New-AzDataBoxHeavyJobDetailsObject -DataImportDetail @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"}) `
            -ContactDetailsContactName $env.ContactName `
            -ContactDetailEmailList $env.EmailList `
            -ContactDetailsPhone $env.Phone `
            -StreetAddress1 $env.StreetAddress1 `
            -StateOrProvince $env.StateOrProvince `
            -Country $env.Country `
            -City $env.City `
            -PostalCode $env.PostalCode `
            -ShippingAddressType $env.AddressType `
            -DevicePassword "1234abcd" `
            -ExpectedDataSizeInTeraByte 10

        $resource = New-AzDataBoxJob -Name $env.JobNameHeavy -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBoxHeavy" -SkuModel "DataBoxHeavy"

        $resource.Status | Should -Be 'DeviceOrdered'
    }
    It 'Create disk order' {
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId $env.StorageAccountId

        $details = New-AzDataBoxDiskJobDetailsObject -DataImportDetail @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"}) `
            -ContactDetailsContactName $env.ContactName `
            -ContactDetailEmailList $env.EmailList `
            -ContactDetailsPhone $env.Phone `
            -StreetAddress1 $env.StreetAddress1 `
            -StateOrProvince $env.StateOrProvince `
            -Country $env.Country `
            -City $env.City `
            -PostalCode $env.PostalCode `
            -ShippingAddressType $env.AddressType `
            -Passkey "1234abcd" `
            -PreferredDisk @{"8" = 8; "4" = 2} `
            -ExpectedDataSizeInTeraByte 18

        $resource = New-AzDataBoxJob -Name $env.JobNameDisk -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBoxDisk" -SkuModel "DataBoxDisk"
        $resource.Status | Should -Be 'DeviceOrdered'
    }
}
