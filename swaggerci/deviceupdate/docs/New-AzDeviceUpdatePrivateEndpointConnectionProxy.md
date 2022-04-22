---
external help file:
Module Name: Az.DeviceUpdate
online version: https://docs.microsoft.com/en-us/powershell/module/az.deviceupdate/new-azdeviceupdateprivateendpointconnectionproxy
schema: 2.0.0
---

# New-AzDeviceUpdatePrivateEndpointConnectionProxy

## SYNOPSIS
(INTERNAL - DO NOT USE) Creates or updates the specified private endpoint connection proxy resource associated with the device update account.

## SYNTAX

```
New-AzDeviceUpdatePrivateEndpointConnectionProxy -AccountName <String> -Id <String>
 -ResourceGroupName <String> [-SubscriptionId <String>]
 [-RemotePrivateEndpointConnectionDetail <IConnectionDetails[]>] [-RemotePrivateEndpointId <String>]
 [-RemotePrivateEndpointImmutableResourceId <String>] [-RemotePrivateEndpointImmutableSubscriptionId <String>]
 [-RemotePrivateEndpointLocation <String>]
 [-RemotePrivateEndpointManualPrivateLinkServiceConnection <IPrivateLinkServiceConnection[]>]
 [-RemotePrivateEndpointPrivateLinkServiceConnection <IPrivateLinkServiceConnection[]>]
 [-RemotePrivateEndpointPrivateLinkServiceProxy <IPrivateLinkServiceProxy[]>]
 [-RemotePrivateEndpointVnetTrafficTag <String>] [-Status <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
(INTERNAL - DO NOT USE) Creates or updates the specified private endpoint connection proxy resource associated with the device update account.

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

### -AccountName
Account name.

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

### -Id
The ID of the private endpoint connection proxy object.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PrivateEndpointConnectionProxyId

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

### -RemotePrivateEndpointConnectionDetail
List of connection details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api20200301Preview.IConnectionDetails[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemotePrivateEndpointId
Remote endpoint resource ID.

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

### -RemotePrivateEndpointImmutableResourceId
Original resource ID needed by Microsoft.Network.

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

### -RemotePrivateEndpointImmutableSubscriptionId
Original subscription ID needed by Microsoft.Network.

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

### -RemotePrivateEndpointLocation
ARM location of the remote private endpoint.

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

### -RemotePrivateEndpointManualPrivateLinkServiceConnection
List of private link service connections that need manual approval.
To construct, see NOTES section for REMOTEPRIVATEENDPOINTMANUALPRIVATELINKSERVICECONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api20200301Preview.IPrivateLinkServiceConnection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemotePrivateEndpointPrivateLinkServiceConnection
List of automatically approved private link service connections.
To construct, see NOTES section for REMOTEPRIVATEENDPOINTPRIVATELINKSERVICECONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api20200301Preview.IPrivateLinkServiceConnection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemotePrivateEndpointPrivateLinkServiceProxy
List of private link service proxies.
To construct, see NOTES section for REMOTEPRIVATEENDPOINTPRIVATELINKSERVICEPROXY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api20200301Preview.IPrivateLinkServiceProxy[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemotePrivateEndpointVnetTrafficTag
Virtual network traffic tag.

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

### -ResourceGroupName
The resource group name.

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

### -Status
Operation status.

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

### -SubscriptionId
The Azure subscription ID.

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

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


REMOTEPRIVATEENDPOINTMANUALPRIVATELINKSERVICECONNECTION <IPrivateLinkServiceConnection[]>: List of private link service connections that need manual approval.
  - `[GroupId <String[]>]`: List of group IDs.
  - `[Name <String>]`: Private link service connection name.
  - `[RequestMessage <String>]`: Request message.

REMOTEPRIVATEENDPOINTPRIVATELINKSERVICECONNECTION <IPrivateLinkServiceConnection[]>: List of automatically approved private link service connections.
  - `[GroupId <String[]>]`: List of group IDs.
  - `[Name <String>]`: Private link service connection name.
  - `[RequestMessage <String>]`: Request message.

REMOTEPRIVATEENDPOINTPRIVATELINKSERVICEPROXY <IPrivateLinkServiceProxy[]>: List of private link service proxies.
  - `[GroupConnectivityInformation <IGroupConnectivityInformation[]>]`: Group connectivity information.
    - `[CustomerVisibleFqdn <String[]>]`: List of customer visible FQDNs.
    - `[PrivateLinkServiceArmRegion <String>]`: PrivateLinkService ARM region.
    - `[RedirectMapId <String>]`: Redirect map ID.
  - `[Id <String>]`: NRP resource ID.
  - `[RemotePrivateLinkServiceConnectionStateActionsRequired <String>]`: A message indicating if changes on the service provider require any updates on the consumer.
  - `[RemotePrivateLinkServiceConnectionStateDescription <String>]`: The reason for approval/rejection of the connection.
  - `[RemotePrivateLinkServiceConnectionStateStatus <PrivateEndpointServiceConnectionStatus?>]`: Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.

## RELATED LINKS

