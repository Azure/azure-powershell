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
        
        $contactDetail = New-AzDataBoxContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone

        $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType 
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId $env.StorageAccountId
        
        $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails

        $resource = New-AzDataBoxJob -Name $env.JobNameImport -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" 

        $resource.Status | Should -Be 'DeviceOrdered'
    }
    It 'Import Job with managed disk' {    
        
        $contactDetail = New-AzDataBoxContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone

        $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType 

        $managedDiskAccount=New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId $env.ManagedDiskRg -StagingStorageAccountId $env.StagingStorageAccount -DataAccountType "ManagedDisk"
        
        $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$managedDiskAccount; AccountDetailDataAccountType = "ManagedDisk"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails

        $resource = New-AzDataBoxJob -Name $env.JobNameManagedDisk -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" 

        $resource.Status | Should -Be 'DeviceOrdered'
    }
    It 'Export Job Test' {
            #ExportFromAzure
            $contactDetail = New-AzDataBoxContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone

            $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType
        
            $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId $env.StorageAccountId
            
            $transferConfigurationType = New-AzDataBoxTransferConfigurationObject -Type "TransferAll" -TransferAllDetail @{"IncludeDataAccountType"="StorageAccount";"IncludeTransferAllBlob"= "True"; "IncludeTransferAllFile" = "True"}

            $details = New-AzDataBoxJobDetailsObject -Type "DataBox"   -DataExportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"; "TransferConfiguration"= $transferConfigurationType} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
            
            $resource = New-AzDataBoxJob -Name $env.JobNameExport -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroup -TransferType "ExportFromAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" 

            $resource.Status | Should -Be 'DeviceOrdered'

            Write-Host -ForegroundColor Green "Create Export completed" 
    }
    It 'Import Job UAI Test' {    
        
        $contactDetail = New-AzDataBoxContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone

        $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType
    
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId $env.StorageAccountId
        
        $keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "UserAssigned"; UserAssignedResourceId = $env.UserAssignedResourceId} -KekUrl $env.KekUrl -KekVaultResourceId $env.KekVaultResourceId

        
        $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -KeyEncryptionKey $keyEncryptionDetails

        $resource = New-AzDataBoxJob -Name $env.JobNameUAI -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" -IdentityType "UserAssigned" -UserAssignedIdentity @{$env.UserAssignedResourceId = @{}} 

        $resource.Status | Should -Be 'DeviceOrdered'
    }
    It 'Schedule Job Test' {    
        
        $contactDetail = New-AzDataBoxContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone

        $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType
    
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId $env.StorageAccountId
        
        $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails

        $date = Get-Date
        $scheduleDate = $date.AddDays(15)

        $resource = New-AzDataBoxJob -Name $env.JobNameScheduleOrder -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" -DeliveryType "Scheduled" -DeliveryInfoScheduledDateTime $scheduleDate

        Write-Host -ForegroundColor Green "Create Schedule completed" $resource.DeliveryInfoScheduledDateTime

        $resource.DeliveryType | Should -Be "Scheduled"
        $resource.Status | Should -Be 'DeviceOrdered'
    } 
    It 'Create databox heavy order' {    
        
        $contactDetail = New-AzDataBoxContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone

        $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType
    
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId $env.StorageAccountId
        
        $details = New-AzDataBoxHeavyJobDetailsObject -Type "DataBoxHeavy"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -DevicePassword "randm@423jarABC" -ExpectedDataSizeInTeraByte 10

        $resource = New-AzDataBoxJob -Name $env.JobNameHeavy -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBoxHeavy" 

        # Write-Host -ForegroundColor Green "Create Schedule completed" $resource.DeliveryInfoScheduledDateTime
        $resource.Status | Should -Be 'DeviceOrdered'
    } 
    It 'Create disk order' {    
        
        $contactDetail = New-AzDataBoxContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone

        $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType
    
        $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId $env.StorageAccountId
        
        $details = New-AzDataBoxDiskJobDetailsObject -Type "DataBoxDisk"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -Passkey "randm@423jarABC" -PreferredDisk @{"8" = 8; "4" = 2} -ExpectedDataSizeInTeraByte 18
        $resource = New-AzDataBoxJob -Name $env.JobNameDisk -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroup -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBoxDisk" 
        $resource.Status | Should -Be 'DeviceOrdered'
    } 

}
