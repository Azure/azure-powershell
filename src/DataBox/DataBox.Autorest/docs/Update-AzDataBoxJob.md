---
external help file:
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/az.databox/update-azdataboxjob
schema: 2.0.0
---

# Update-AzDataBoxJob

## SYNOPSIS
Updates the properties of an existing job.

## SYNTAX

```
Update-AzDataBoxJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>]
 [-ContactDetail <IContactDetails>] [-ContactDetailContactName <String>] [-ContactDetailMobile <String>]
 [-ContactDetailPhone <String>] [-ContactDetailPhoneExtension <String>]
 [-EncryptionPreferenceDoubleEncryption <DoubleEncryption>]
 [-EncryptionPreferenceHardwareEncryption <HardwareEncryption>] [-IdentityType <String>]
 [-KeyEncryptionKey <IKeyEncryptionKey>] [-PreferencePreferredDataCenterRegion <String[]>]
 [-ReturnToCustomerPackageDetailCarrierAccountNumber <String>]
 [-ReturnToCustomerPackageDetailCarrierName <String>] [-ReturnToCustomerPackageDetailTrackingId <String>]
 [-ReverseShippingDetail <IShippingAddress>] [-ReverseTransportPreferredShipmentType <TransportShipmentTypes>]
 [-ShippingAddress <IShippingAddress>] [-StorageAccountAccessTierPreference <StorageAccountAccessTier[]>]
 [-Tag <Hashtable>] [-TransportPreferredShipmentType <TransportShipmentTypes>]
 [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of an existing job.

## EXAMPLES

### Example 1: Update databox job encryption from microsoft managed to customer managed with user assigned identities 
```powershell
$keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "UserAssigned"; UserAssignedResourceId = "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName"} -KekUrl "keyIdentifier" -KekVaultResourceId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName"

$DebugPreference = "Continue"

# You can use `$DebugPreference = "Continue"`, with any example/usecase to get exact details of error in below format when update command fails.
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

Update-AzDataBoxJob -Name "powershell10" -ResourceGroupName "resourceGroupName" -KeyEncryptionKey $keyEncryptionDetails -ContactDetail $contactDetail -ShippingAddress $ShippingDetails  -IdentityType "UserAssigned" -UserAssignedIdentity @{"/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName" = @{}}

$keyEncryptionDetails
```

```output
KekType         KekUrl                                           KekVaultResourceId
-------         ------                                           ------------------
CustomerManaged keyIdentifier /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName

Name         Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------        ------------  ------- ------------ ------------ ------
Powershell10 WestUS   DeviceOrdered ImportToAzure DataBox UserAssigned NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Update databox job encryption from microsoft managed to customer managed with user assigned identities.

### Example 2: Update databox job encryption from microsoft managed to customer managed with system identities in 2 updates
```powershell
$databoxUpdate = Update-AzDataBoxJob -Name "pwshTestSAssigned" -ResourceGroupName "resourceGroupName" -ContactDetail $contactDetail -ShippingAddress $ShippingDetails  -IdentityType "SystemAssigned"

$databoxUpdate.Identity

$keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "SystemAssigned"} -KekUrl "keyIdentifier" -KekVaultResourceId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName"

$databoxUpdateWithCMK = Update-AzDataBoxJob -Name "pwshTestSAssigned" -ResourceGroupName "resourceGroupName" -ContactDetail $contactDetail -ShippingAddress $ShippingDetails  -KeyEncryptionKey $keyEncryptionDetails

$databoxUpdateWithCMK.Identity

$databoxUpdateWithCMK.Detail.KeyEncryptionKey
```

```output
PrincipalId                          TenantId                             Type
-----------                          --------                             ----
920850f5-9b6b-4017-a81a-3dcafe348be7 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned

PrincipalId                          TenantId                             Type
-----------                          --------                             ----
920850f5-9b6b-4017-a81a-3dcafe348be7 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned

KekType         KekUrl                                           KekVaultResourceId
-------         ------                                           ------------------
CustomerManaged keyIdentifier /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName
```

Update databox job encryption from microsoft managed to customer managed to customer managed with sytem assigned identity.
For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1

### Example 3: Update databox job from system assigned to user assigned with customer managed key encryption
```powershell
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

Update-AzDataBoxJob -Name "pwshTestSAssigned" -ResourceGroupName "resourceGroupName" -KeyEncryptionKey $keyEncryptionDetails -ContactDetail $contactDetail -ShippingAddress $ShippingDetails  -IdentityType "SystemAssigned,UserAssigned" -UserAssignedIdentity @{"/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName" = @{}}
```

Update databox job from system assigned to user assigned with customer managed key encryption.
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

### -ContactDetail
Contact details for notification and shipping.
To construct, see NOTES section for CONTACTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IContactDetails
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContactDetailContactName
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

### -ContactDetailMobile
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

### -ContactDetailPhone
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

### -ContactDetailPhoneExtension
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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -EncryptionPreferenceDoubleEncryption
Defines secondary layer of software-based encryption enablement.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.DoubleEncryption
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionPreferenceHardwareEncryption
Defines Hardware level encryption (Only for disk)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.HardwareEncryption
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

### -IfMatch
Defines the If-Match condition.
The patch will be performed only if the ETag of the job on the server matches this value.

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

### -KeyEncryptionKey
Key encryption key for the job.
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
Shipping address where customer wishes to receive the device.
To construct, see NOTES section for REVERSESHIPPINGDETAIL properties and create a hash table.

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

### -ReverseTransportPreferredShipmentType
Indicates Shipment Logistics type that the customer preferred.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.TransportShipmentTypes
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

### -StorageAccountAccessTierPreference
Preferences related to the Access Tier of storage accounts.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.StorageAccountAccessTier[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -TransportPreferredShipmentType
Indicates Shipment Logistics type that the customer preferred.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.TransportShipmentTypes
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IJobResource

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

`KEYENCRYPTIONKEY <IKeyEncryptionKey>`: Key encryption key for the job.
  - `KekType <KekType>`: Type of encryption key used for key encryption.
  - `[IdentityProperty <IIdentityProperties>]`: Managed identity properties used for key encryption.
    - `[Type <String>]`: Managed service identity type.
    - `[UserAssignedResourceId <String>]`: Arm resource id for user assigned identity to be used to fetch MSI token.
  - `[KekUrl <String>]`: Key encryption key. It is required in case of Customer managed KekType.
  - `[KekVaultResourceId <String>]`: Kek vault resource id. It is required in case of Customer managed KekType.

`REVERSESHIPPINGDETAIL <IShippingAddress>`: Shipping address where customer wishes to receive the device.
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

