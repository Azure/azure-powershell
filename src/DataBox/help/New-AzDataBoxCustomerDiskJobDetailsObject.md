---
external help file:
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/Az.DataBox/new-AzDataBoxCustomerDiskJobDetailsObject
schema: 2.0.0
---

# New-AzDataBoxCustomerDiskJobDetailsObject

## SYNOPSIS
Create an in-memory object for DataBoxCustomerDiskJobDetails.

## SYNTAX

```
New-AzDataBoxCustomerDiskJobDetailsObject -ContactDetail <IContactDetails> -Type <ClassDiscriminator>
 [-DataExportDetail <IDataExportDetails[]>] [-DataImportDetail <IDataImportDetails[]>]
 [-ExpectedDataSizeInTeraByte <Int32>]
 [-ExportDiskDetailsCollection <IDataBoxCustomerDiskJobDetailsExportDiskDetailsCollection>]
 [-ImportDiskDetailsCollection <IDataBoxCustomerDiskJobDetailsImportDiskDetailsCollection>]
 [-KeyEncryptionKey <IKeyEncryptionKey>] [-Preference <IPreferences>]
 [-ReturnToCustomerPackageDetailCarrierAccountNumber <String>]
 [-ReverseShippingDetail <IReverseShippingDetails>] [-ShippingAddress <IShippingAddress>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DataBoxCustomerDiskJobDetails.

## EXAMPLES

### Example 1: DataBoxCustomerDisk details in-memory object
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/YourSubscriptionId/resourceGroups/YourResourceGroup/providers/Microsoft.Storage/storageAccounts/YourStorageAccount"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "XXXX XXXX" -EmailList @("emailId") -Phone "0000000000"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "XXXX XXXX" -StateOrProvince "XX" -Country "XX" -City "XXXX XXXX" -PostalCode "00000" -AddressType "Commercial"

New-AzDataBoxCustomerDiskJobDetailsObject -Type "DataBoxCustomerDisk" -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -ImportDiskDetailsCollection $importDiskDetailsCollection -ReturnToCustomerPackageDetailCarrierAccountNumber "00000"
```

DataBoxCustomerDisk details in-memory object

## PARAMETERS

### -ContactDetail
Contact details for notification and shipping.
To construct, see NOTES section for CONTACTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IContactDetails
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExportDetail
Details of the data to be exported from azure.
To construct, see NOTES section for DATAEXPORTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IDataExportDetails[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataImportDetail
Details of the data to be imported into azure.
To construct, see NOTES section for DATAIMPORTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IDataImportDetails[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpectedDataSizeInTeraByte
The expected size of the data, which needs to be transferred in this job, in terabytes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportDiskDetailsCollection
Contains the map of disk serial number to the disk details for export jobs.
To construct, see NOTES section for EXPORTDISKDETAILSCOLLECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IDataBoxCustomerDiskJobDetailsExportDiskDetailsCollection
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportDiskDetailsCollection
Contains the map of disk serial number to the disk details for import jobs.
To construct, see NOTES section for IMPORTDISKDETAILSCOLLECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IDataBoxCustomerDiskJobDetailsImportDiskDetailsCollection
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyEncryptionKey
Details about which key encryption type is being used.
To construct, see NOTES section for KEYENCRYPTIONKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IKeyEncryptionKey
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Preference
Preferences for the order.
To construct, see NOTES section for PREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IPreferences
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReturnToCustomerPackageDetailCarrierAccountNumber
Carrier Account Number of customer for customer disk.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReverseShippingDetail
Optional Reverse Shipping details for order.
To construct, see NOTES section for REVERSESHIPPINGDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IReverseShippingDetails
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShippingAddress
Shipping address of the customer.
To construct, see NOTES section for SHIPPINGADDRESS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IShippingAddress
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Indicates the type of job details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.ClassDiscriminator
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.DataBoxCustomerDiskJobDetails

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CONTACTDETAIL <IContactDetails>`: Contact details for notification and shipping.
  - `ContactName <String>`: Contact name of the person.
  - `EmailList <String[]>`: List of Email-ids to be notified about job progress.
  - `Phone <String>`: Phone number of the contact person.
  - `[Mobile <String>]`: Mobile number of the contact person.
  - `[NotificationPreference <INotificationPreference[]>]`: Notification preference for a job stage.
    - `SendNotification <Boolean>`: Notification is required or not.
    - `StageName <NotificationStageName>`: Name of the stage.
  - `[PhoneExtension <String>]`: Phone extension number of the contact person.

`DATAEXPORTDETAIL <IDataExportDetails[]>`: Details of the data to be exported from azure.
  - `AccountDetailDataAccountType <DataAccountType>`: Account Type of the data to be transferred.
  - `TransferConfiguration <ITransferConfiguration>`: Configuration for the data transfer.
    - `Type <TransferConfigurationType>`: Type of the configuration for transfer.
    - `[TransferAllDetail <ITransferConfigurationTransferAllDetails>]`: Map of filter type and the details to transfer all data. This field is required only if the TransferConfigurationType is given as TransferAll
      - `[IncludeDataAccountType <DataAccountType?>]`: Type of the account of data
      - `[IncludeTransferAllBlob <Boolean?>]`: To indicate if all Azure blobs have to be transferred
      - `[IncludeTransferAllFile <Boolean?>]`: To indicate if all Azure Files have to be transferred
    - `[TransferFilterDetail <ITransferConfigurationTransferFilterDetails>]`: Map of filter type and the details to filter. This field is required only if the TransferConfigurationType is given as TransferUsingFilter.
      - `[AzureFileFilterDetailFilePathList <String[]>]`: List of full path of the files to be transferred.
      - `[AzureFileFilterDetailFilePrefixList <String[]>]`: Prefix list of the Azure files to be transferred.
      - `[AzureFileFilterDetailFileShareList <String[]>]`: List of file shares to be transferred.
      - `[BlobFilterDetailBlobPathList <String[]>]`: List of full path of the blobs to be transferred.
      - `[BlobFilterDetailBlobPrefixList <String[]>]`: Prefix list of the Azure blobs to be transferred.
      - `[BlobFilterDetailContainerList <String[]>]`: List of blob containers to be transferred.
      - `[IncludeDataAccountType <DataAccountType?>]`: Type of the account of data.
      - `[IncludeFilterFileDetail <IFilterFileDetails[]>]`: Details of the filter files to be used for data transfer.
        - `FilterFilePath <String>`: Path of the file that contains the details of all items to transfer.
        - `FilterFileType <FilterFileType>`: Type of the filter file.
  - `[AccountDetailSharePassword <String>]`: Password for all the shares to be created on the device. Should not be passed for TransferType:ExportFromAzure jobs. If this is not passed, the service will generate password itself. This will not be returned in Get Call. Password Requirements :  Password must be minimum of 12 and maximum of 64 characters. Password must have at least one uppercase alphabet, one number and one special character. Password cannot have the following characters : IilLoO0 Password can have only alphabets, numbers and these characters : @#\-$%^!+=;:_()]+
  - `[LogCollectionLevel <LogCollectionLevel?>]`: Level of the logs to be collected.

`DATAIMPORTDETAIL <IDataImportDetails[]>`: Details of the data to be imported into azure.
  - `AccountDetailDataAccountType <DataAccountType>`: Account Type of the data to be transferred.
  - `[AccountDetailSharePassword <String>]`: Password for all the shares to be created on the device. Should not be passed for TransferType:ExportFromAzure jobs. If this is not passed, the service will generate password itself. This will not be returned in Get Call. Password Requirements :  Password must be minimum of 12 and maximum of 64 characters. Password must have at least one uppercase alphabet, one number and one special character. Password cannot have the following characters : IilLoO0 Password can have only alphabets, numbers and these characters : @#\-$%^!+=;:_()]+
  - `[LogCollectionLevel <LogCollectionLevel?>]`: Level of the logs to be collected.

`EXPORTDISKDETAILSCOLLECTION <IDataBoxCustomerDiskJobDetailsExportDiskDetailsCollection>`: Contains the map of disk serial number to the disk details for export jobs.
  - `[(Any) <IExportDiskDetails>]`: This indicates any property can be added to this object.

`IMPORTDISKDETAILSCOLLECTION <IDataBoxCustomerDiskJobDetailsImportDiskDetailsCollection>`: Contains the map of disk serial number to the disk details for import jobs.
  - `[(Any) <IImportDiskDetails>]`: This indicates any property can be added to this object.

`KEYENCRYPTIONKEY <IKeyEncryptionKey>`: Details about which key encryption type is being used.
  - `KekType <KekType>`: Type of encryption key used for key encryption.
  - `[IdentityProperty <IIdentityProperties>]`: Managed identity properties used for key encryption.
    - `[Type <String>]`: Managed service identity type.
    - `[UserAssignedResourceId <String>]`: Arm resource id for user assigned identity to be used to fetch MSI token.
  - `[KekUrl <String>]`: Key encryption key. It is required in case of Customer managed KekType.
  - `[KekVaultResourceId <String>]`: Kek vault resource id. It is required in case of Customer managed KekType.

`PREFERENCE <IPreferences>`: Preferences for the order.
  - `[EncryptionPreferenceDoubleEncryption <DoubleEncryption?>]`: Defines secondary layer of software-based encryption enablement.
  - `[EncryptionPreferenceHardwareEncryption <HardwareEncryption?>]`: Defines Hardware level encryption (Only for disk)
  - `[PreferredDataCenterRegion <String[]>]`: Preferred data center region.
  - `[ReverseTransportPreferencePreferredShipmentType <TransportShipmentTypes?>]`: Indicates Shipment Logistics type that the customer preferred.
  - `[StorageAccountAccessTierPreference <StorageAccountAccessTier[]>]`: Preferences related to the Access Tier of storage accounts.
  - `[TransportPreferencePreferredShipmentType <TransportShipmentTypes?>]`: Indicates Shipment Logistics type that the customer preferred.

`REVERSESHIPPINGDETAIL <IReverseShippingDetails>`: Optional Reverse Shipping details for order.
  - `[ContactDetailContactName <String>]`: Contact name of the person.
  - `[ContactDetailMobile <String>]`: Mobile number of the contact person.
  - `[ContactDetailPhone <String>]`: Phone number of the contact person.
  - `[ContactDetailPhoneExtension <String>]`: Phone extension number of the contact person.
  - `[ShippingAddress <IShippingAddress>]`: Shipping address where customer wishes to receive the device.
    - `Country <String>`: Name of the Country.
    - `StreetAddress1 <String>`: Street Address line 1.
    - `[AddressType <AddressType?>]`: Type of address.
    - `[City <String>]`: Name of the City.
    - `[CompanyName <String>]`: Name of the company.
    - `[PostalCode <String>]`: Postal code.
    - `[SkipAddressValidation <Boolean?>]`: Flag to indicate if customer has chosen to skip default address validation
    - `[StateOrProvince <String>]`: Name of the State or Province.
    - `[StreetAddress2 <String>]`: Street Address line 2.
    - `[StreetAddress3 <String>]`: Street Address line 3.
    - `[TaxIdentificationNumber <String>]`: Tax Identification Number
    - `[ZipExtendedCode <String>]`: Extended Zip Code.

`SHIPPINGADDRESS <IShippingAddress>`: Shipping address of the customer.
  - `Country <String>`: Name of the Country.
  - `StreetAddress1 <String>`: Street Address line 1.
  - `[AddressType <AddressType?>]`: Type of address.
  - `[City <String>]`: Name of the City.
  - `[CompanyName <String>]`: Name of the company.
  - `[PostalCode <String>]`: Postal code.
  - `[SkipAddressValidation <Boolean?>]`: Flag to indicate if customer has chosen to skip default address validation
  - `[StateOrProvince <String>]`: Name of the State or Province.
  - `[StreetAddress2 <String>]`: Street Address line 2.
  - `[StreetAddress3 <String>]`: Street Address line 3.
  - `[TaxIdentificationNumber <String>]`: Tax Identification Number
  - `[ZipExtendedCode <String>]`: Extended Zip Code.

## RELATED LINKS

