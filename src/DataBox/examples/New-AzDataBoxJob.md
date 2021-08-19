### Example 1: {{ Create a databox import job }}
```powershell
PS C:\> $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
PS C:\>  $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\> $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\>  $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
PS C:\> $resource = New-AzDataBoxJob -Name "ImportTest" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"
PS C:\> $resource

Name         Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------        ------------  ------- ------------ ------------ ------
ImportTest WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails

PS C:\> $resource.Detail

Action                     :
ChainOfCustodySasKey       :
ContactDetail              : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ContactDetails
CopyLogDetail              :
CopyProgress               :
DataExportDetail           :
DataImportDetail           : {Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataImportDetails}
DeliveryPackage            : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.PackageShippingDetails
DevicePassword             :
ExpectedDataSizeInTeraByte : 0
JobStage                   :
KeyEncryptionKey           : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.KeyEncryptionKey
LastMitigationActionOnJob  : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.LastMitigationActionOnJob
Preference                 : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.Preferences
ReturnPackage              : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.PackageShippingDetails
ReverseShipmentLabelSasKey :
ShippingAddress            : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ShippingAddress
Type                       : DataBox

PS C:\> $resource.Detail.ShippingAddress

AddressType City          CompanyName Country PostalCode StateOrProvince StreetAddress1  StreetAddress2 StreetAddress3 ZipExtendedCode
----------- ----          ----------- ------- ---------- --------------- --------------  -------------- -------------- ---------------
Commercial  San Francisco             US      94107      CA              101 TOWNSEND ST
```

{{You can expand and visualize other object in similar way how details and shipping address expanded}}

### Example 2: {{ Creates a databox export job}}
```powershell
PS C:\> $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
PS C:\>  $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\> $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\> $transferConfigurationType = New-AzDataBoxTransferConfigurationObject -Type "TransferAll" -TransferAllDetail @{"IncludeDataAccountType"="StorageAccount";"IncludeTransferAllBlob"= "True"; "IncludeTransferAllFile"="True"}
PS C:\>  $details = New-AzDataBoxJobDetailsObject -Type "DataBox" -DataExportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"; "TransferConfiguration"= $transferConfigurationType} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
PS C:\> $resource = New-AzDataBoxJob -Name "ExportTest" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ExportFromAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"

Name      Location Status        TransferType    SkuName IdentityType DeliveryType Detail
----      -------- ------        ------------    ------- ------------ ------------ ------
ExportTest WestUS   DeviceOrdered ExportFromAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

{{ Creates a databox export job }}

### Example 3: {{ Creates a databox import job with managed disk account}}
```powershell
PS C:\> $managedDiskAccount=New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName" -StagingStorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName" -DataAccountType "ManagedDisk"
PS C:\>  $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\> $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\>  $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$managedDiskAccount; AccountDetailDataAccountType = "ManagedDisk"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
PS C:\> New-AzDataBoxJob -Name "PwshManagedDisk" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"

Name            Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----            -------- ------        ------------  ------- ------------ ------------ ------
PwshManagedDisk WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

{{Creates a databox import job with managed disk account }}


### Example 4: {{ Creates a databox import job with user assigned identity}}
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
PS C:\>  $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\> $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\> $keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "UserAssigned"; UserAssignedResourceId = "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName"} -KekUrl "keyIdentifier" -KekVaultResourceId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName"
PS C:\>  $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -KeyEncryptionKey $keyEncryptionDetails
PS C:\> New-AzDataBoxJob -Name "PowershellMSI" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"  -IdentityType "UserAssigned" -UserAssignedIdentity @{"/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName" = @{}}

Name          Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----          -------- ------        ------------  ------- ------------ ------------ ------
PowershellMSI WestUS   DeviceOrdered ImportToAzure DataBox UserAssigned NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

{{ Creates a databox import job with user assigned identity }}


### Example 5: {{ Schedule a databox job}}
```powershell
PS C:\> $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
PS C:\>  $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\> $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\>  $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
PS C:\> $date = Get-Date
PS C:\> $scheduleDate = $date.AddDays(15)
PS C:\> $resource = New-AzDataBoxJob -Name "pwshScheduleJob" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox" -DeliveryType "Scheduled" -DeliveryInfoScheduledDateTime $scheduleDate

Name            Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----            -------- ------        ------------  ------- ------------ ------------ ------
pwshScheduleJob WestUS   DeviceOrdered ImportToAzure DataBox None         Scheduled    Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

{{ Schedule a databox job }}

### Example 6: {{ Creates a databox job with your own key}}
```powershell
PS C:\> $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
PS C:\>  $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\> $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\>  $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -DevicePassword "randmPass@12345"
PS C:\> $resource = New-AzDataBoxJob -Name "PowershellBYOK" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"

Name           Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----           -------- ------        ------------  ------- ------------ ------------ ------
PowershellBYOK WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

{{ Creates a databox job with your own key }}

### Example 7: {{ Creates a databoxHeavy job with your own key}}
```powershell
PS C:\> $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
PS C:\>  $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\> $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\>  $details = New-AzDataBoxHeavyJobDetailsObject -Type "DataBoxHeavy"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -DevicePassword "randm@423jarABC" -ExpectedDataSizeInTeraByte 10
PS C:\> $resource = New-AzDataBoxJob -Name "DbxHeavy" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBoxHeavy"

Name    Location Status        TransferType  SkuName      IdentityType DeliveryType Detail
----    -------- ------        ------------  -------      ------------ ------------ ------
DbxHeavy WestUS  DeviceOrdered ImportToAzure DataBoxHeavy  None        NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxHeavyJobDetails
```

{{ Creates a databoxHeavy job with your own key }}

### Example 8: {{ Creates a databoxDisk job with your own Passkey}}
```powershell
PS C:\> $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
PS C:\>  $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\> $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\>  $details = New-AzDataBoxDiskJobDetailsObject -Type "DataBoxDisk"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -Passkey "randm@423jarABC" -PreferredDisk @{"8" = 8; "4" = 2} -ExpectedDataSizeInTeraByte 18
PS C:\> New-AzDataBoxJob -Name "pwshDisk" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBoxDisk"

Name     Location Status        TransferType  SkuName     IdentityType DeliveryType Detail
----     -------- ------        ------------  -------     ------------ ------------ ------
pwshDisk WestUS   DeviceOrdered ImportToAzure DataBoxDisk None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
```

{{ Creates a databoxDisky job with your own Passkey }}

### Example 9: {{ Creates a databox job with double encryption enabled}}
```powershell
PS C:\> $dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
PS C:\>  $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\> $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\>  $details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -Preference @{EncryptionPreferenceDoubleEncryption="Enabled"}
PS C:\> New-AzDataBoxJob -Name "pwshDoubEncy" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"

Name        Location Status        TransferType  SkuName     IdentityType DeliveryType Detail
----        -------- ------        ------------  -------     ------------ ------------ ------
pwshDoubEncy WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
```

{{ Creates a databox job with double encryption enabled }}