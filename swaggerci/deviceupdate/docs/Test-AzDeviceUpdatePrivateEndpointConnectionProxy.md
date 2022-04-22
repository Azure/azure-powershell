---
external help file:
Module Name: Az.DeviceUpdate
online version: https://docs.microsoft.com/en-us/powershell/module/az.deviceupdate/test-azdeviceupdateprivateendpointconnectionproxy
schema: 2.0.0
---

# Test-AzDeviceUpdatePrivateEndpointConnectionProxy

## SYNOPSIS
(INTERNAL - DO NOT USE) Validates a private endpoint connection proxy object.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzDeviceUpdatePrivateEndpointConnectionProxy -AccountName <String> -Id <String>
 -ResourceGroupName <String> [-SubscriptionId <String>]
 [-RemotePrivateEndpointConnectionDetail <IConnectionDetails[]>] [-RemotePrivateEndpointId <String>]
 [-RemotePrivateEndpointImmutableResourceId <String>] [-RemotePrivateEndpointImmutableSubscriptionId <String>]
 [-RemotePrivateEndpointLocation <String>]
 [-RemotePrivateEndpointManualPrivateLinkServiceConnection <IPrivateLinkServiceConnection[]>]
 [-RemotePrivateEndpointPrivateLinkServiceConnection <IPrivateLinkServiceConnection[]>]
 [-RemotePrivateEndpointPrivateLinkServiceProxy <IPrivateLinkServiceProxy[]>]
 [-RemotePrivateEndpointVnetTrafficTag <String>] [-Status <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Validate
```
Test-AzDeviceUpdatePrivateEndpointConnectionProxy -AccountName <String> -Id <String>
 -ResourceGroupName <String> -PrivateEndpointConnectionProxy <IPrivateEndpointConnectionProxy>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzDeviceUpdatePrivateEndpointConnectionProxy -InputObject <IDeviceUpdateIdentity>
 -PrivateEndpointConnectionProxy <IPrivateEndpointConnectionProxy> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzDeviceUpdatePrivateEndpointConnectionProxy -InputObject <IDeviceUpdateIdentity>
 [-RemotePrivateEndpointConnectionDetail <IConnectionDetails[]>] [-RemotePrivateEndpointId <String>]
 [-RemotePrivateEndpointImmutableResourceId <String>] [-RemotePrivateEndpointImmutableSubscriptionId <String>]
 [-RemotePrivateEndpointLocation <String>]
 [-RemotePrivateEndpointManualPrivateLinkServiceConnection <IPrivateLinkServiceConnection[]>]
 [-RemotePrivateEndpointPrivateLinkServiceConnection <IPrivateLinkServiceConnection[]>]
 [-RemotePrivateEndpointPrivateLinkServiceProxy <IPrivateLinkServiceProxy[]>]
 [-RemotePrivateEndpointVnetTrafficTag <String>] [-Status <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
(INTERNAL - DO NOT USE) Validates a private endpoint connection proxy object.

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
Parameter Sets: Validate, ValidateExpanded
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

### -Id
The ID of the private endpoint connection proxy object.

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
Aliases: PrivateEndpointConnectionProxyId

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
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -PrivateEndpointConnectionProxy
Private endpoint connection proxy details.
To construct, see NOTES section for PRIVATEENDPOINTCONNECTIONPROXY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api20200301Preview.IPrivateEndpointConnectionProxy
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RemotePrivateEndpointConnectionDetail
List of connection details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api20200301Preview.IConnectionDetails[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: Validate, ValidateExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: Validate, ValidateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api20200301Preview.IPrivateEndpointConnectionProxy

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.IDeviceUpdateIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDeviceUpdateIdentity>: Identity Parameter
  - `[AccountName <String>]`: Account name.
  - `[GroupId <String>]`: The group ID of the private link resource.
  - `[Id <String>]`: Resource identity path
  - `[InstanceName <String>]`: Instance name.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource
  - `[PrivateEndpointConnectionProxyId <String>]`: The ID of the private endpoint connection proxy object.
  - `[ResourceGroupName <String>]`: The resource group name.
  - `[SubscriptionId <String>]`: The Azure subscription ID.

PRIVATEENDPOINTCONNECTIONPROXY <IPrivateEndpointConnectionProxy>: Private endpoint connection proxy details.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[RemotePrivateEndpointConnectionDetail <IConnectionDetails[]>]`: List of connection details.
  - `[RemotePrivateEndpointId <String>]`: Remote endpoint resource ID.
  - `[RemotePrivateEndpointImmutableResourceId <String>]`: Original resource ID needed by Microsoft.Network.
  - `[RemotePrivateEndpointImmutableSubscriptionId <String>]`: Original subscription ID needed by Microsoft.Network.
  - `[RemotePrivateEndpointLocation <String>]`: ARM location of the remote private endpoint.
  - `[RemotePrivateEndpointManualPrivateLinkServiceConnection <IPrivateLinkServiceConnection[]>]`: List of private link service connections that need manual approval.
    - `[GroupId <String[]>]`: List of group IDs.
    - `[Name <String>]`: Private link service connection name.
    - `[RequestMessage <String>]`: Request message.
  - `[RemotePrivateEndpointPrivateLinkServiceConnection <IPrivateLinkServiceConnection[]>]`: List of automatically approved private link service connections.
  - `[RemotePrivateEndpointPrivateLinkServiceProxy <IPrivateLinkServiceProxy[]>]`: List of private link service proxies.
    - `[GroupConnectivityInformation <IGroupConnectivityInformation[]>]`: Group connectivity information.
      - `[CustomerVisibleFqdn <String[]>]`: List of customer visible FQDNs.
      - `[PrivateLinkServiceArmRegion <String>]`: PrivateLinkService ARM region.
      - `[RedirectMapId <String>]`: Redirect map ID.
    - `[Id <String>]`: NRP resource ID.
    - `[RemotePrivateLinkServiceConnectionStateActionsRequired <String>]`: A message indicating if changes on the service provider require any updates on the consumer.
    - `[RemotePrivateLinkServiceConnectionStateDescription <String>]`: The reason for approval/rejection of the connection.
    - `[RemotePrivateLinkServiceConnectionStateStatus <PrivateEndpointServiceConnectionStatus?>]`: Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.
  - `[RemotePrivateEndpointVnetTrafficTag <String>]`: Virtual network traffic tag.
  - `[Status <String>]`: Operation status.

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

