---
external help file:
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/Az.DataBox/new-azdataboxdiskjobdetailsobject
schema: 2.0.0
---

# New-AzDataBoxDiskJobDetailsObject

## SYNOPSIS
Create an in-memory object for DataBoxDiskJobDetails.

## SYNTAX

```
New-AzDataBoxDiskJobDetailsObject -ContactDetail <IContactDetails> [-DataExportDetail <IDataExportDetails[]>]
 [-DataImportDetail <IDataImportDetails[]>] [-ExpectedDataSizeInTeraByte <Int32>]
 [-KeyEncryptionKey <IKeyEncryptionKey>] [-Passkey <String>] [-Preference <IPreferences>]
 [-PreferredDisk <IDataBoxDiskJobDetailsPreferredDisks>] [-ShippingAddress <IShippingAddress>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DataBoxDiskJobDetails.

## EXAMPLES

### Example 1: DataBoxDisk details in-memory object 
```powershell
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

New-AzDataBoxDiskJobDetailsObject -Type "DataBoxDisk"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -Passkey "randm@423jarABC" -PreferredDisk @{"8" = 8; "4" = 2} -ExpectedDataSizeInTeraByte 18
```

```output
Action ChainOfCustodySasKey ExpectedDataSizeInTeraByte ReverseShipmentLabelSasKey Type        Passkey        
------ -------------------- -------------------------- -------------------------- ----        -------        
                            18                                                    DataBoxDisk randm@423jarABC
```

DataBoxDisk details in-memory object

## PARAMETERS

### -ContactDetail
Contact details for notification and shipping.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IContactDetails
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IKeyEncryptionKey
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Passkey
User entered passkey for DataBox Disk job.

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

### -Preference
Preferences for the order.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IPreferences
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreferredDisk
User preference on what size disks are needed for the job.
The map is from the disk size in TB to the count.
Eg.
{2,5} means 5 disks of 2 TB size.
Key is string but will be checked against an int.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxDiskJobDetailsPreferredDisks
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IShippingAddress
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.DataBoxDiskJobDetails

## NOTES

## RELATED LINKS

