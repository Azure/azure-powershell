---
external help file:
Module Name: Az.DataBox
online version: https://docs.microsoft.com/powershell/module/az.databox/new-azdataboxjob
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
 [-DeliveryType <JobDeliveryType>] [-Detail <IJobDetails>] [-IdentityType <String>] [-SkuDisplayName <String>]
 [-SkuFamily <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new job with the specified parameters.
Existing job cannot be updated with this API and should instead be updated with the Update job API.

## EXAMPLES

### Example 1: Create a databox import job 
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
$details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
$DebugPreference = "Continue"
# You can use `$DebugPreference = "Continue"`, with any example/usecase to get exact details of error in below format when creation command fails.
# {
#   "Error": {
#     "Code": "StaticValidationGenericCountryCodeHasInvalidLength",
#     "Message": "The attribute country code does not meet length constraints.\r\nEnter a value with 2 characters for country code.",
#     "Details": [
#       null
#     ],
#     "Target": null
#   }
# } 
$resource = New-AzDataBoxJob -Name "ImportTest" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"
$resource

Name         Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------        ------------  ------- ------------ ------------ ------
ImportTest WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails

$resource.Detail

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

$resource.Detail.ShippingAddress

AddressType City          CompanyName Country PostalCode StateOrProvince StreetAddress1  StreetAddress2 StreetAddress3 ZipExtendedCode
----------- ----          ----------- ------- ---------- --------------- --------------  -------------- -------------- ---------------
Commercial  San Francisco             US      94107      CA              101 TOWNSEND ST
```

You can expand and visualize other object in similar way how details and shipping address expanded.

### Example 2: Creates a databox export job
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
$transferConfigurationType = New-AzDataBoxTransferConfigurationObject -Type "TransferAll" -TransferAllDetail @{"IncludeDataAccountType"="StorageAccount";"IncludeTransferAllBlob"= "True"; "IncludeTransferAllFile"="True"}
$details = New-AzDataBoxJobDetailsObject -Type "DataBox" -DataExportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"; "TransferConfiguration"= $transferConfigurationType} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
$resource = New-AzDataBoxJob -Name "ExportTest" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ExportFromAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"
```

```output
Name      Location Status        TransferType    SkuName IdentityType DeliveryType Detail
----      -------- ------        ------------    ------- ------------ ------------ ------
ExportTest WestUS   DeviceOrdered ExportFromAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Creates a databox export job.
For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1

### Example 3: Creates a databox import job with managed disk account
```powershell
$managedDiskAccount=New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName" -StagingStorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName" -DataAccountType "ManagedDisk"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
$details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$managedDiskAccount; AccountDetailDataAccountType = "ManagedDisk"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
New-AzDataBoxJob -Name "PwshManagedDisk" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"
```

```output
Name            Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----            -------- ------        ------------  ------- ------------ ------------ ------
PwshManagedDisk WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Creates a databox import job with managed disk account.
For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1

### Example 4: Creates a databox import job with user assigned identity
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
$keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "UserAssigned"; UserAssignedResourceId = "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName"} -KekUrl "keyIdentifier" -KekVaultResourceId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName"
$details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -KeyEncryptionKey $keyEncryptionDetails
New-AzDataBoxJob -Name "PowershellMSI" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"  -IdentityType "UserAssigned" -UserAssignedIdentity @{"/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName" = @{}}
```

```output
Name          Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----          -------- ------        ------------  ------- ------------ ------------ ------
PowershellMSI WestUS   DeviceOrdered ImportToAzure DataBox UserAssigned NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Creates a databox import job with user assigned identity.
For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1

### Example 5: Creates a databox job with your own key
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
$details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -DevicePassword "randmPass@12345"
$resource = New-AzDataBoxJob -Name "PowershellBYOK" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"
```

```output
Name           Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----           -------- ------        ------------  ------- ------------ ------------ ------
PowershellBYOK WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Creates a databox job with your own key.
For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1

### Example 6: Creates a databoxHeavy job with your own key
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
$details = New-AzDataBoxHeavyJobDetailsObject -Type "DataBoxHeavy"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -DevicePassword "randm@423jarABC" -ExpectedDataSizeInTeraByte 10
$resource = New-AzDataBoxJob -Name "DbxHeavy" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBoxHeavy"
```

```output
Name    Location Status        TransferType  SkuName      IdentityType DeliveryType Detail
----    -------- ------        ------------  -------      ------------ ------------ ------
DbxHeavy WestUS  DeviceOrdered ImportToAzure DataBoxHeavy  None        NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxHeavyJobDetails
```

Creates a databoxHeavy job with your own key.
For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1

### Example 7: Creates a databoxDisk job with your own Passkey
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
$details = New-AzDataBoxDiskJobDetailsObject -Type "DataBoxDisk"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -Passkey "randm@423jarABC" -PreferredDisk @{"8" = 8; "4" = 2} -ExpectedDataSizeInTeraByte 18
New-AzDataBoxJob -Name "pwshDisk" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBoxDisk"
```

```output
Name     Location Status        TransferType  SkuName     IdentityType DeliveryType Detail
----     -------- ------        ------------  -------     ------------ ------------ ------
pwshDisk WestUS   DeviceOrdered ImportToAzure DataBoxDisk None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
```

Creates a databoxDisky job with your own Passkey.
For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1

### Example 8: Creates a databox job with double encryption enabled
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/storageAccountName"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
$details = New-AzDataBoxJobDetailsObject -Type "DataBox"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -Preference @{EncryptionPreferenceDoubleEncryption="Enabled"}
New-AzDataBoxJob -Name "pwshDoubEncy" -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName" -TransferType "ImportToAzure" -Detail $details -Location "WestUS" -SkuName "DataBox"
```

```output
Name        Location Status        TransferType  SkuName     IdentityType DeliveryType Detail
----        -------- ------        ------------  -------     ------------ ------------ ------
pwshDoubEncy WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
```

Creates a databox job with double encryption enabled.
For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IJobDetails
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

### -UserAssignedIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IJobResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DETAIL `<IJobDetails>`: Details of a job run. This field will only be sent for expand details filter.
  - `ContactDetail <IContactDetails>`: Contact details for notification and shipping.
    - `ContactName <String>`: Contact name of the person.
    - `EmailList <String[]>`: List of Email-ids to be notified about job progress.
    - `Phone <String>`: Phone number of the contact person.
    - `[Mobile <String>]`: Mobile number of the contact person.
    - `[NotificationPreference <INotificationPreference[]>]`: Notification preference for a job stage.
      - `SendNotification <Boolean>`: Notification is required or not.
      - `StageName <NotificationStageName>`: Name of the stage.
    - `[PhoneExtension <String>]`: Phone extension number of the contact person.
  - `Type <ClassDiscriminator>`: Indicates the type of job details.
  - `[DataExportDetail <IDataExportDetails[]>]`: Details of the data to be exported from azure.
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
  - `[DataImportDetail <IDataImportDetails[]>]`: Details of the data to be imported into azure.
    - `AccountDetailDataAccountType <DataAccountType>`: Account Type of the data to be transferred.
    - `[AccountDetailSharePassword <String>]`: Password for all the shares to be created on the device. Should not be passed for TransferType:ExportFromAzure jobs. If this is not passed, the service will generate password itself. This will not be returned in Get Call. Password Requirements :  Password must be minimum of 12 and maximum of 64 characters. Password must have at least one uppercase alphabet, one number and one special character. Password cannot have the following characters : IilLoO0 Password can have only alphabets, numbers and these characters : @#\-$%^!+=;:_()]+
  - `[ExpectedDataSizeInTeraByte <Int32?>]`: The expected size of the data, which needs to be transferred in this job, in terabytes.
  - `[KeyEncryptionKey <IKeyEncryptionKey>]`: Details about which key encryption type is being used.
    - `KekType <KekType>`: Type of encryption key used for key encryption.
    - `[IdentityProperty <IIdentityProperties>]`: Managed identity properties used for key encryption.
      - `[Type <String>]`: Managed service identity type.
      - `[UserAssignedResourceId <String>]`: Arm resource id for user assigned identity to be used to fetch MSI token.
    - `[KekUrl <String>]`: Key encryption key. It is required in case of Customer managed KekType.
    - `[KekVaultResourceId <String>]`: Kek vault resource id. It is required in case of Customer managed KekType.
  - `[Preference <IPreferences>]`: Preferences for the order.
    - `[EncryptionPreferenceDoubleEncryption <DoubleEncryption?>]`: Defines secondary layer of software-based encryption enablement.
    - `[PreferredDataCenterRegion <String[]>]`: Preferred data center region.
    - `[TransportPreferencePreferredShipmentType <TransportShipmentTypes?>]`: Indicates Shipment Logistics type that the customer preferred.
  - `[ShippingAddress <IShippingAddress>]`: Shipping address of the customer.
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

