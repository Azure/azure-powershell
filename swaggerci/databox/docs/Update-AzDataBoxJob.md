---
external help file:
Module Name: Az.DataBox
online version: https://docs.microsoft.com/en-us/powershell/module/az.databox/update-azdataboxjob
schema: 2.0.0
---

# Update-AzDataBoxJob

## SYNOPSIS
Updates the properties of an existing job.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataBoxJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>]
 [-Detail <IUpdateJobDetails>] [-IdentityType <String>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataBoxJob -InputObject <IDataBoxIdentity> [-IfMatch <String>] [-Detail <IUpdateJobDetails>]
 [-IdentityType <String>] [-IdentityUserAssignedIdentity <Hashtable>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of an existing job.

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

### -Detail
Details of a job to be updated.
To construct, see NOTES section for DETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IUpdateJobDetails
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the job Resource within the specified resource group.
job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IJobResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DETAIL <IUpdateJobDetails>: Details of a job to be updated.
  - `[ContactDetailContactName <String>]`: Contact name of the person.
  - `[ContactDetailEmailList <String[]>]`: List of Email-ids to be notified about job progress.
  - `[ContactDetailMobile <String>]`: Mobile number of the contact person.
  - `[ContactDetailNotificationPreference <INotificationPreference[]>]`: Notification preference for a job stage.
    - `SendNotification <Boolean>`: Notification is required or not.
    - `StageName <NotificationStageName>`: Name of the stage.
  - `[ContactDetailPhone <String>]`: Phone number of the contact person.
  - `[ContactDetailPhoneExtension <String>]`: Phone extension number of the contact person.
  - `[IdentityPropertyType <String>]`: Managed service identity type.
  - `[KeyEncryptionKeyKekType <KekType?>]`: Type of encryption key used for key encryption.
  - `[KeyEncryptionKeyKekUrl <String>]`: Key encryption key. It is required in case of Customer managed KekType.
  - `[KeyEncryptionKeyKekVaultResourceId <String>]`: Kek vault resource id. It is required in case of Customer managed KekType.
  - `[ReturnToCustomerPackageDetailCarrierAccountNumber <String>]`: Carrier Account Number of customer for customer disk.
  - `[ReturnToCustomerPackageDetailCarrierName <String>]`: Name of the carrier.
  - `[ReturnToCustomerPackageDetailTrackingId <String>]`: Tracking Id of shipment.
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
  - `[UserAssignedResourceId <String>]`: Arm resource id for user assigned identity to be used to fetch MSI token.

INPUTOBJECT <IDataBoxIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: The name of the job Resource within the specified resource group. job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only
  - `[Location <String>]`: The location of the resource
  - `[ResourceGroupName <String>]`: The Resource Group Name
  - `[SubscriptionId <String>]`: The Subscription Id

## RELATED LINKS

