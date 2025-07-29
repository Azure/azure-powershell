---
external help file: Az.DataBox-help.xml
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/Az.DataBox/new-azdataboxcustomerdiskjobdetailsobject
schema: 2.0.0
---

# New-AzDataBoxCustomerDiskJobDetailsObject

## SYNOPSIS
Create an in-memory object for DataBoxCustomerDiskJobDetails.

## SYNTAX

```
New-AzDataBoxCustomerDiskJobDetailsObject -ContactDetail <IContactDetails> [-EnableManifestBackup <Boolean>]
 [-ImportDiskDetailsCollection <IDataBoxCustomerDiskJobDetailsImportDiskDetailsCollection>]
 [-ReturnToCustomerPackageDetailCarrierAccountNumber <String>]
 [-ReturnToCustomerPackageDetailCarrierName <String>] [-ReturnToCustomerPackageDetailTrackingId <String>]
 [-DataExportDetail <IDataExportDetails[]>] [-DataImportDetail <IDataImportDetails[]>]
 [-ExpectedDataSizeInTeraByte <Int32>] [-KeyEncryptionKey <IKeyEncryptionKey>] [-Preference <IPreferences>]
 [-ReverseShippingDetail <IReverseShippingDetails>] [-ShippingAddress <IShippingAddress>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DataBoxCustomerDiskJobDetails.

## EXAMPLES

### Example 1: DataBoxCustomerDisk details in-memory object
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId "/subscriptions/YourSubscriptionId/resourceGroups/YourResourceGroup/providers/Microsoft.Storage/storageAccounts/YourStorageAccount"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "XXXX XXXX" -EmailList @("emailId") -Phone "0000000000"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "XXXX XXXX" -StateOrProvince "XX" -Country "XX" -City "XXXX XXXX" -PostalCode "00000" -AddressType "Commercial"
$importDiskDetailsCollection = @{"XXXXXX"= @{ManifestFile = "xyz.txt"; ManifestHash = "xxxx"; BitLockerKey = "xxx"}}  

New-AzDataBoxCustomerDiskJobDetailsObject -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -ImportDiskDetailsCollection $importDiskDetailsCollection -ReturnToCustomerPackageDetailCarrierAccountNumber "00000"
```

```output
Action                                            :
ChainOfCustodySasKey                              :
ContactDetail                                     : {
                                                      "contactName": "XXXX XXXX",
                                                      "phone": "0000000000",
                                                      "emailList": [ "emailId" ]
                                                    }
CopyLogDetail                                     :
CopyProgress                                      :
DataCenterCode                                    :
DataExportDetail                                  :
DataImportDetail                                  : {{
                                                      "accountDetails": {
                                                        "dataAccountType": "StorageAccount",
                                                        "storageAccountId":
                                                    "/subscriptions/YourSubscriptionId/resourceGroups/YourResourceGroup/providers/Microsoft.Storage/storageAccounts/YourStorageAccount"
                                                      }
                                                    }}
DatacenterAddress                                 : {
                                                    }
DeliverToDcPackageDetailCarrierName               :
DeliverToDcPackageDetailTrackingId                :
DeliveryPackage                                   : {
                                                    }
DeviceErasureDetail                               : {
                                                    }
EnableManifestBackup                              :
ExpectedDataSizeInTeraByte                        :
ExportDiskDetailsCollection                       : {
                                                    }
ImportDiskDetailsCollection                       : {
                                                      "XXXXXX": {
                                                        "manifestFile": "xyz.txt",
                                                        "manifestHash": "xxxx",
                                                        "bitLockerKey": "xxx"
                                                      }
                                                    }
JobStage                                          :
KeyEncryptionKey                                  : {
                                                    }
LastMitigationActionOnJob                         : {
                                                    }
Preference                                        : {
                                                    }
ReturnPackage                                     : {
                                                    }
ReturnToCustomerPackageDetailCarrierAccountNumber : 00000
ReturnToCustomerPackageDetailCarrierName          :
ReturnToCustomerPackageDetailTrackingId           :
ReverseShipmentLabelSasKey                        :
ReverseShippingDetail                             : {
                                                    }
ShippingAddress                                   : {
                                                      "streetAddress1": "XXXX XXXX",
                                                      "city": "XXXX XXXX",
                                                      "stateOrProvince": "XX",
                                                      "country": "XX",
                                                      "postalCode": "00000",
                                                      "addressType": "Commercial"
                                                    }
Type                                              : DataBoxCustomerDisk
```

DataBoxCustomerDisk details in-memory object

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

### -EnableManifestBackup
Flag to indicate if disk manifest should be backed-up in the Storage Account.

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

### -ImportDiskDetailsCollection
Contains the map of disk serial number to the disk details for import jobs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxCustomerDiskJobDetailsImportDiskDetailsCollection
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

### -ReturnToCustomerPackageDetailCarrierName
Name of the carrier.

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

### -ReturnToCustomerPackageDetailTrackingId
Tracking Id of shipment.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IReverseShippingDetails
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.DataBoxCustomerDiskJobDetails

## NOTES

## RELATED LINKS
