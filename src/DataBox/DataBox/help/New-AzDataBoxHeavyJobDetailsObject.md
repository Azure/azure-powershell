---
external help file: Az.DataBox-help.xml
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/Az.DataBox/new-azdataboxheavyjobdetailsobject
schema: 2.0.0
---

# New-AzDataBoxHeavyJobDetailsObject

## SYNOPSIS
Create an in-memory object for DataBoxHeavyJobDetails.

## SYNTAX

```
New-AzDataBoxHeavyJobDetailsObject -ContactDetailEmailList <String[]> -ContactDetailsContactName <String>
 -ContactDetailsPhone <String> [-DevicePassword <String>] [-City <String>] [-CompanyName <String>]
 [-ContactDetailNotificationPreference <INotificationPreference[]>] [-ContactDetailsMobile <String>]
 [-ContactDetailsPhoneExtension <String>] [-Country <String>] [-DataExportDetail <IDataExportDetails[]>]
 [-DataImportDetail <IDataImportDetails[]>] [-EncryptionPreferenceDoubleEncryption <String>]
 [-EncryptionPreferenceHardwareEncryption <String>] [-ExpectedDataSizeInTeraByte <Int32>]
 [-IdentityPropertyType <String>] [-KeyEncryptionKeyKekType <String>] [-KeyEncryptionKeyKekUrl <String>]
 [-KeyEncryptionKeyKekVaultResourceId <String>] [-PostalCode <String>]
 [-PreferencePreferredDataCenterRegion <String[]>] [-PreferenceStorageAccountAccessTierPreference <String[]>]
 [-ReverseShippingDetailsContactDetailsMobile <String>] [-ReverseShippingDetailsContactDetailsPhone <String>]
 [-ReverseShippingDetailsContactDetailsPhoneExtension <String>] [-ReverseShippingDetailsContactName <String>]
 [-ReverseShippingDetailsShippingAddressCity <String>]
 [-ReverseShippingDetailsShippingAddressCompanyName <String>]
 [-ReverseShippingDetailsShippingAddressCountry <String>]
 [-ReverseShippingDetailsShippingAddressPostalCode <String>]
 [-ReverseShippingDetailsShippingAddressSkipAddressValidation <Boolean>]
 [-ReverseShippingDetailsShippingAddressStateOrProvince <String>]
 [-ReverseShippingDetailsShippingAddressStreetAddress1 <String>]
 [-ReverseShippingDetailsShippingAddressStreetAddress2 <String>]
 [-ReverseShippingDetailsShippingAddressStreetAddress3 <String>]
 [-ReverseShippingDetailsShippingAddressTaxIdentificationNumber <String>]
 [-ReverseShippingDetailsShippingAddressType <String>]
 [-ReverseShippingDetailsShippingAddressZipExtendedCode <String>]
 [-ReverseTransportPreferencePreferredShipmentType <String>] [-ShippingAddressType <String>]
 [-SkipAddressValidation <Boolean>] [-StateOrProvince <String>] [-StreetAddress1 <String>]
 [-StreetAddress2 <String>] [-StreetAddress3 <String>] [-TaxIdentificationNumber <String>]
 [-TransportPreferencePreferredShipmentType <String>] [-UserAssignedResourceId <String>]
 [-ZipExtendedCode <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DataBoxHeavyJobDetails.

## EXAMPLES

### Example 1: Create a in-memory object for DataBoxHeavyJobDetails
```powershell
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

New-AzDataBoxHeavyJobDetailsObject -Type "DataBoxHeavy"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -DevicePassword $password -ExpectedDataSizeInTeraByte 10
```

```output
Action ChainOfCustodySasKey ExpectedDataSizeInTeraByte ReverseShipmentLabelSasKey Type        Passkey        
------ -------------------- -------------------------- -------------------------- ----        -------        
                            18                                                    DataBoxDisk $password
```

Create a in-memory object for DataBoxHeavyJobDetails

## PARAMETERS

### -City
Name of the City.

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

### -CompanyName
Name of the company.

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

### -ContactDetailEmailList
List of Email-ids to be notified about job progress.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContactDetailNotificationPreference
Notification preference for a job stage.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.INotificationPreference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContactDetailsContactName
Contact name of the person.

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

### -ContactDetailsMobile
Mobile number of the contact person.

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

### -ContactDetailsPhone
Phone number of the contact person.

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

### -ContactDetailsPhoneExtension
Phone extension number of the contact person.

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

### -Country
Name of the Country.

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

### -DataExportDetail
Details of the data to be exported from azure.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataExportDetails[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataImportDetails[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevicePassword
Set Device password for unlocking Databox Heavy.
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

### -EncryptionPreferenceDoubleEncryption
Defines secondary layer of software-based encryption enablement.

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

### -EncryptionPreferenceHardwareEncryption
Defines Hardware level encryption (Only for disk).

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

### -IdentityPropertyType
Managed service identity type.

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

### -KeyEncryptionKeyKekType
Type of encryption key used for key encryption.

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

### -KeyEncryptionKeyKekUrl
Key encryption key.
It is required in case of Customer managed KekType.

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

### -KeyEncryptionKeyKekVaultResourceId
Kek vault resource id.
It is required in case of Customer managed KekType.

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

### -PostalCode
Postal code.

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

### -PreferencePreferredDataCenterRegion
Preferred data center region.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreferenceStorageAccountAccessTierPreference
Preferences related to the Access Tier of storage accounts.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReverseShippingDetailsContactDetailsMobile
Mobile number of the contact person.

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

### -ReverseShippingDetailsContactDetailsPhone
Phone number of the contact person.

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

### -ReverseShippingDetailsContactDetailsPhoneExtension
Phone extension number of the contact person.

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

### -ReverseShippingDetailsContactName
Contact name of the person.

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

### -ReverseShippingDetailsShippingAddressCity
Name of the City.

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

### -ReverseShippingDetailsShippingAddressCompanyName
Name of the company.

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

### -ReverseShippingDetailsShippingAddressCountry
Name of the Country.

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

### -ReverseShippingDetailsShippingAddressPostalCode
Postal code.

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

### -ReverseShippingDetailsShippingAddressSkipAddressValidation
Flag to indicate if customer has chosen to skip default address validation.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReverseShippingDetailsShippingAddressStateOrProvince
Name of the State or Province.

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

### -ReverseShippingDetailsShippingAddressStreetAddress1
Street Address line 1.

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

### -ReverseShippingDetailsShippingAddressStreetAddress2
Street Address line 2.

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

### -ReverseShippingDetailsShippingAddressStreetAddress3
Street Address line 3.

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

### -ReverseShippingDetailsShippingAddressTaxIdentificationNumber
Tax Identification Number.

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

### -ReverseShippingDetailsShippingAddressType
Type of address.

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

### -ReverseShippingDetailsShippingAddressZipExtendedCode
Extended Zip Code.

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

### -ReverseTransportPreferencePreferredShipmentType
Indicates Shipment Logistics type that the customer preferred.

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

### -ShippingAddressType
Type of address.

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

### -SkipAddressValidation
Flag to indicate if customer has chosen to skip default address validation.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StateOrProvince
Name of the State or Province.

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

### -StreetAddress1
Street Address line 1.

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

### -StreetAddress2
Street Address line 2.

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

### -StreetAddress3
Street Address line 3.

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

### -TaxIdentificationNumber
Tax Identification Number.

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

### -TransportPreferencePreferredShipmentType
Indicates Shipment Logistics type that the customer preferred.

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

### -UserAssignedResourceId
Arm resource id for user assigned identity to be used to fetch MSI token.

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

### -ZipExtendedCode
Extended Zip Code.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.DataBoxHeavyJobDetails

## NOTES

## RELATED LINKS
