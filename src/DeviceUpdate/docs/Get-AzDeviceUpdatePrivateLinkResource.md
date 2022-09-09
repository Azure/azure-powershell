---
external help file:
Module Name: Az.DeviceUpdate
online version: https://docs.microsoft.com/powershell/module/az.deviceupdate/get-azdeviceupdateprivatelinkresource
schema: 2.0.0
---

# Get-AzDeviceUpdatePrivateLinkResource

## SYNOPSIS
Get the specified private link resource associated with the device update account.

## SYNTAX

### List (Default)
```
Get-AzDeviceUpdatePrivateLinkResource -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDeviceUpdatePrivateLinkResource -AccountName <String> -GroupId <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeviceUpdatePrivateLinkResource -InputObject <IDeviceUpdateIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the specified private link resource associated with the device update account.

## EXAMPLES

### Example 1: Get the specified private link resource associated with the device update account.
```powershell
Get-AzDeviceUpdatePrivateLinkResource -AccountName azpstest-account -ResourceGroupName azpstest_gp
```

```output
Name         GroupId
----         -------
DeviceUpdate DeviceUpdate
```

Get the specified private link resource associated with the device update account.

### Example 2: Get the specified private link resource associated with the device update account and group id.
```powershell
Get-AzDeviceUpdatePrivateLinkResource -AccountName azpstest-account -ResourceGroupName azpstest_gp -GroupId DeviceUpdate
```

```output
Name         GroupId
----         -------
DeviceUpdate DeviceUpdate
```

Get the specified private link resource associated with the device update account and group id.

## PARAMETERS

### -AccountName
Account name.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
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

### -GroupId
The group ID of the private link resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IDeviceUpdateIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api20221001.IGroupInformation

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

## RELATED LINKS

