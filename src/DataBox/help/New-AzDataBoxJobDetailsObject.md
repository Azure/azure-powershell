---
external help file:
Module Name: Az.DataBox
online version: https://docs.microsoft.com/powershell/module/az.DataBox/new-AzDataBoxJobDetailsObject
schema: 2.0.0
---

# New-AzDataBoxJobDetailsObject

## SYNOPSIS
Create an in-memory object for DataBoxJobDetails.

## SYNTAX

```
New-AzDataBoxJobDetailsObject -ContactDetail <IContactDetails> -Type <ClassDiscriminator>
 [-DataExportDetail <IDataExportDetails[]>] [-DataImportDetail <IDataImportDetails[]>]
 [-DevicePassword <String>] [-ExpectedDataSizeInTeraByte <Int32>] [-KeyEncryptionKey <IKeyEncryptionKey>]
 [-Preference <IPreferences>] [-ShippingAddress <IShippingAddress>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DataBoxJobDetails.

## EXAMPLES

### Example 1: Creates a databox job detail in memory object 
```powershell
$details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
$details
```

```output
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
```

Create a in-memory object for DataBoxJobDetails

## PARAMETERS

### -ContactDetail
Contact details for notification and shipping.
To construct, see NOTES section for CONTACTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IContactDetails
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IDataExportDetails[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IDataImportDetails[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevicePassword
Set Device password for unlocking Databox.
Should not be passed for TransferType:ExportFromAzure jobs.
If this is not passed, the service will generate password itself.
This will not be returned in Get Call.
Password Requirements :  Password must be minimum of 12 and maximum of 64 characters.
Password must have at least one uppercase alphabet, one number and one special character.
Password cannot have the following characters : IilLoO0 Password can have only alphabets, numbers and these characters : @#\-$%^!+=;:_()]+.

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

### -KeyEncryptionKey
Details about which key encryption type is being used.
To construct, see NOTES section for KEYENCRYPTIONKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IKeyEncryptionKey
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IPreferences
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IShippingAddress
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CONTACTDETAIL <IContactDetails>: Contact details for notification and shipping.
  - `ContactName <String>`: Contact name of the person.
  - `EmailList <String[]>`: List of Email-ids to be notified about job progress.
  - `Phone <String>`: Phone number of the contact person.
  - `[Mobile <String>]`: Mobile number of the contact person.
  - `[NotificationPreference <INotificationPreference[]>]`: Notification preference for a job stage.
    - `SendNotification <Boolean>`: Notification is required or not.
    - `StageName <NotificationStageName>`: Name of the stage.
  - `[PhoneExtension <String>]`: Phone extension number of the contact person.

DATAEXPORTDETAIL <IDataExportDetails[]>: Details of the data to be exported from azure.
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

DATAIMPORTDETAIL <IDataImportDetails[]>: Details of the data to be imported into azure.
  - `AccountDetailDataAccountType <DataAccountType>`: Account Type of the data to be transferred.
  - `[AccountDetailSharePassword <String>]`: Password for all the shares to be created on the device. Should not be passed for TransferType:ExportFromAzure jobs. If this is not passed, the service will generate password itself. This will not be returned in Get Call. Password Requirements :  Password must be minimum of 12 and maximum of 64 characters. Password must have at least one uppercase alphabet, one number and one special character. Password cannot have the following characters : IilLoO0 Password can have only alphabets, numbers and these characters : @#\-$%^!+=;:_()]+

KEYENCRYPTIONKEY <IKeyEncryptionKey>: Details about which key encryption type is being used.
  - `KekType <KekType>`: Type of encryption key used for key encryption.
  - `[IdentityProperty <IIdentityProperties>]`: Managed identity properties used for key encryption.
    - `[Type <String>]`: Managed service identity type.
    - `[UserAssignedResourceId <String>]`: Arm resource id for user assigned identity to be used to fetch MSI token.
  - `[KekUrl <String>]`: Key encryption key. It is required in case of Customer managed KekType.
  - `[KekVaultResourceId <String>]`: Kek vault resource id. It is required in case of Customer managed KekType.

PREFERENCE <IPreferences>: Preferences for the order.
  - `[EncryptionPreferenceDoubleEncryption <DoubleEncryption?>]`: Defines secondary layer of software-based encryption enablement.
  - `[PreferredDataCenterRegion <String[]>]`: Preferred data center region.
  - `[TransportPreferencePreferredShipmentType <TransportShipmentTypes?>]`: Indicates Shipment Logistics type that the customer preferred.

SHIPPINGADDRESS <IShippingAddress>: Shipping address of the customer.
  - `Country <String>`: Name of the Country.
  - `StreetAddress1 <String>`: Street Address line 1.
  - `[AddressType <AddressType?>]`: Type of address.
  - `[City <String>]`: Name of the City.
  - `[CompanyName <String>]`: Name of the company.
  - `[PostalCode <String>]`: Postal code.
  - `[StateOrProvince <String>]`: Name of the State or Province.
  - `[StreetAddress2 <String>]`: Street Address line 2.
  - `[StreetAddress3 <String>]`: Street Address line 3.
  - `[ZipExtendedCode <String>]`: Extended Zip Code.

## RELATED LINKS

