---
external help file:
Module Name: Az.DeviceUpdate
online version: https://docs.microsoft.com/powershell/module/az.deviceupdate/test-azdeviceupdatenameavailability
schema: 2.0.0
---

# Test-AzDeviceUpdateNameAvailability

## SYNOPSIS
Checks ADU resource name availability.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzDeviceUpdateNameAvailability [-SubscriptionId <String>] [-Name <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzDeviceUpdateNameAvailability -Request <ICheckNameAvailabilityRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzDeviceUpdateNameAvailability -InputObject <IDeviceUpdateIdentity>
 -Request <ICheckNameAvailabilityRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzDeviceUpdateNameAvailability -InputObject <IDeviceUpdateIdentity> [-Name <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Checks ADU resource name availability.

## EXAMPLES

### Example 1: Checks ADU resource name availability.
```powershell
$data = New-AzDeviceUpdateCheckNameAvailabilityRequestObject -Name azpstest-account -Type "Microsoft.DeviceUpdate/accounts"
Test-AzDeviceUpdateNameAvailability -Request $data
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Checks ADU resource name availability.

### Example 2: Checks ADU resource name availability.
```powershell
Test-AzDeviceUpdateNameAvailability -Name azpstest-account -Type "Microsoft.DeviceUpdate/accounts"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Checks ADU resource name availability.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IDeviceUpdateIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the resource for which availability needs to be checked.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
The check availability request body.
To construct, see NOTES section for REQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api30.ICheckNameAvailabilityRequest
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The resource type.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api30.ICheckNameAvailabilityRequest

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IDeviceUpdateIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api30.ICheckNameAvailabilityResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDeviceUpdateIdentity>`: Identity Parameter
  - `[AccountName <String>]`: Account name.
  - `[GroupId <String>]`: The group ID of the private link resource.
  - `[Id <String>]`: Resource identity path
  - `[InstanceName <String>]`: Instance name.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource
  - `[PrivateEndpointConnectionProxyId <String>]`: The ID of the private endpoint connection proxy object.
  - `[ResourceGroupName <String>]`: The resource group name.
  - `[SubscriptionId <String>]`: The Azure subscription ID.

`REQUEST <ICheckNameAvailabilityRequest>`: The check availability request body.
  - `[Name <String>]`: The name of the resource for which availability needs to be checked.
  - `[Type <String>]`: The resource type.

## RELATED LINKS

