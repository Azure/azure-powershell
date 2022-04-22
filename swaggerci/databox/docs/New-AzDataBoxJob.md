---
external help file:
Module Name: Az.DataBox
online version: https://docs.microsoft.com/en-us/powershell/module/az.databox/new-azdataboxjob
schema: 2.0.0
---

# New-AzDataBoxJob

## SYNOPSIS
Creates a new job with the specified parameters.
Existing job cannot be updated with this API and should instead be updated with the Update job API.

## SYNTAX

```
New-AzDataBoxJob -Name <String> -ResourceGroupName <String> -Location <String> -SkuName <SkuName>
 -TransferType <TransferType> [-SubscriptionId <String>] [-DeliveryInfoScheduledDateTime <DateTime>]
 [-DeliveryType <JobDeliveryType>] [-Detail <IJobDetails>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-SkuDisplayName <String>] [-SkuFamily <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new job with the specified parameters.
Existing job cannot be updated with this API and should instead be updated with the Update job API.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryInfoScheduledDateTime
Scheduled date time.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryType
Delivery type of Job.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.JobDeliveryType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Detail
Details of a job run.
This field will only be sent for expand details filter.
To construct, see NOTES section for DETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IJobDetails
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Identity type

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

### -IdentityUserAssignedIdentity
User Assigned Identities

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the resource.
This will be one of the supported and registered Azure Regions (e.g.
West US, East US, Southeast Asia, etc.).
The region of a resource cannot be changed once it is created, but if an identical region is specified on update the request will succeed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the job Resource within the specified resource group.
job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: JobName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuDisplayName
The display name of the sku.

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

### -SkuFamily
The sku family.

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

### -SkuName
The sku name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.SkuName
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The list of key value pairs that describe the resource.
These tags can be used in viewing and grouping this resource (across resource groups).

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TransferType
Type of the data transfer.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.TransferType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IJobResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DETAIL <IJobDetails>: Details of a job run. This field will only be sent for expand details filter.
  - `ContactDetailContactName <String>`: Contact name of the person.
  - `ContactDetailEmailList <String[]>`: List of Email-ids to be notified about job progress.
  - `ContactDetailPhone <String>`: Phone number of the contact person.
  - `Type <ClassDiscriminator>`: Indicates the type of job details.
  - `[ContactDetailMobile <String>]`: Mobile number of the contact person.
  - `[ContactDetailNotificationPreference <INotificationPreference[]>]`: Notification preference for a job stage.
    - `SendNotification <Boolean>`: Notification is required or not.
    - `StageName <NotificationStageName>`: Name of the stage.
  - `[ContactDetailPhoneExtension <String>]`: Phone extension number of the contact person.
  - `[DataExportDetail <IDataExportDetails[]>]`: Details of the data to be exported from azure.
    - `AccountDetailDataAccountType <DataAccountType>`: Account Type of the data to be transferred.
    - `TransferConfigurationType <TransferConfigurationType>`: Type of the configuration for transfer.
    - `[AccountDetailSharePassword <String>]`: Password for all the shares to be created on the device. Should not be passed for TransferType:ExportFromAzure jobs. If this is not passed, the service will generate password itself. This will not be returned in Get Call. Password Requirements :  Password must be minimum of 12 and maximum of 64 characters. Password must have at least one uppercase alphabet, one number and one special character. Password cannot have the following characters : IilLoO0 Password can have only alphabets, numbers and these characters : @#\-$%^!+=;:_()]+
    - `[AzureFileFilterDetailFilePathList <String[]>]`: List of full path of the files to be transferred.
    - `[AzureFileFilterDetailFilePrefixList <String[]>]`: Prefix list of the Azure files to be transferred.
    - `[AzureFileFilterDetailFileShareList <String[]>]`: List of file shares to be transferred.
    - `[BlobFilterDetailBlobPathList <String[]>]`: List of full path of the blobs to be transferred.
    - `[BlobFilterDetailBlobPrefixList <String[]>]`: Prefix list of the Azure blobs to be transferred.
    - `[BlobFilterDetailContainerList <String[]>]`: List of blob containers to be transferred.
    - `[IncludeFilterFileDetail <IFilterFileDetails[]>]`: Details of the filter files to be used for data transfer.
      - `FilterFilePath <String>`: Path of the file that contains the details of all items to transfer.
      - `FilterFileType <FilterFileType>`: Type of the filter file.
    - `[IncludeTransferAllBlob <Boolean?>]`: To indicate if all Azure blobs have to be transferred
    - `[IncludeTransferAllFile <Boolean?>]`: To indicate if all Azure Files have to be transferred
    - `[LogCollectionLevel <LogCollectionLevel?>]`: Level of the logs to be collected.
    - `[TransferAllDetailsIncludeDataAccountType <DataAccountType?>]`: Type of the account of data
    - `[TransferFilterDetailsIncludeDataAccountType <DataAccountType?>]`: Type of the account of data.
  - `[DataImportDetail <IDataImportDetails[]>]`: Details of the data to be imported into azure.
    - `AccountDetailDataAccountType <DataAccountType>`: Account Type of the data to be transferred.
    - `[AccountDetailSharePassword <String>]`: Password for all the shares to be created on the device. Should not be passed for TransferType:ExportFromAzure jobs. If this is not passed, the service will generate password itself. This will not be returned in Get Call. Password Requirements :  Password must be minimum of 12 and maximum of 64 characters. Password must have at least one uppercase alphabet, one number and one special character. Password cannot have the following characters : IilLoO0 Password can have only alphabets, numbers and these characters : @#\-$%^!+=;:_()]+
    - `[LogCollectionLevel <LogCollectionLevel?>]`: Level of the logs to be collected.
  - `[DatacenterAddressType <DatacenterAddressType?>]`: Data center address type
  - `[EncryptionPreferenceDoubleEncryption <DoubleEncryption?>]`: Defines secondary layer of software-based encryption enablement.
  - `[ExpectedDataSizeInTeraByte <Int32?>]`: The expected size of the data, which needs to be transferred in this job, in terabytes.
  - `[IdentityPropertyType <String>]`: Managed service identity type.
  - `[KeyEncryptionKeyKekType <KekType?>]`: Type of encryption key used for key encryption.
  - `[KeyEncryptionKeyKekUrl <String>]`: Key encryption key. It is required in case of Customer managed KekType.
  - `[KeyEncryptionKeyKekVaultResourceId <String>]`: Kek vault resource id. It is required in case of Customer managed KekType.
  - `[LastMitigationActionOnJobActionDateTimeInUtc <DateTime?>]`: Action performed date time
  - `[LastMitigationActionOnJobCustomerResolution <CustomerResolutionCode?>]`: Resolution code provided by customer
  - `[LastMitigationActionOnJobIsPerformedByCustomer <Boolean?>]`: Action performed by customer,         possibility is that mitigation might happen by customer or service or by ops
  - `[PreferencePreferredDataCenterRegion <String[]>]`: Preferred data center region.
  - `[PreferenceStorageAccountAccessTierPreference <StorageAccountAccessTier[]>]`: Preferences related to the Access Tier of storage accounts.
  - `[ShippingAddressCity <String>]`: Name of the City.
  - `[ShippingAddressCompanyName <String>]`: Name of the company.
  - `[ShippingAddressCountry <String>]`: Name of the Country.
  - `[ShippingAddressPostalCode <String>]`: Postal code.
  - `[ShippingAddressStateOrProvince <String>]`: Name of the State or Province.
  - `[ShippingAddressStreetAddress1 <String>]`: Street Address line 1.
  - `[ShippingAddressStreetAddress2 <String>]`: Street Address line 2.
  - `[ShippingAddressStreetAddress3 <String>]`: Street Address line 3.
  - `[ShippingAddressType <AddressType?>]`: Type of address.
  - `[ShippingAddressZipExtendedCode <String>]`: Extended Zip Code.
  - `[TransportPreferencePreferredShipmentType <TransportShipmentTypes?>]`: Indicates Shipment Logistics type that the customer preferred.
  - `[UserAssignedResourceId <String>]`: Arm resource id for user assigned identity to be used to fetch MSI token.

## RELATED LINKS

