---
external help file:
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/en-us/powershell/module/az.providerhub/new-azproviderhubnotificationregistration
schema: 2.0.0
---

# New-AzProviderHubNotificationRegistration

## SYNOPSIS
Creates or updates a notification registration.

## SYNTAX

### CreateExpanded
```
New-AzProviderHubNotificationRegistration -Name <String> -ProviderNamespace <String>
 [-SubscriptionId <String>] [-IncludedEvent <String[]>] [-MessageScope <MessageScope>]
 [-NotificationEndpoint <INotificationEndpoint[]>] [-NotificationMode <NotificationMode>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a notification registration.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
New-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest" -NotificationMode "EventHub" -MessageScope "RegisteredSubscriptions" -IncludedEvent "*/write", "Microsoft.Contoso/testResourceType/delete" -NotificationEndpoint @{Location = "", "East US"; NotificationDestination = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mgmtexp-eastus/providers/Microsoft.EventHub/namespaces/unitedstates-mgmtexpint/eventhubs/armlinkednotifications"}
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: CreateExpanded
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludedEvent
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MessageScope
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.MessageScope
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The notification registration.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: NotificationRegistrationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationEndpoint
.
To construct, see NOTES section for NOTIFICATIONENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationEndpoint[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationMode
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.NotificationMode
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationRegistration

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationRegistration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IProviderHubIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[NestedResourceTypeFirst <String>]`: The first child resource type.
  - `[NestedResourceTypeSecond <String>]`: The second child resource type.
  - `[NestedResourceTypeThird <String>]`: The third child resource type.
  - `[NotificationRegistrationName <String>]`: The notification registration.
  - `[ProviderNamespace <String>]`: The name of the resource provider hosted within ProviderHub.
  - `[ResourceType <String>]`: The resource type.
  - `[RolloutName <String>]`: The rollout name.
  - `[Sku <String>]`: The SKU.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

NOTIFICATIONENDPOINT <INotificationEndpoint[]>: .
  - `[Location <String[]>]`:
  - `[NotificationDestination <String>]`:

PROPERTY <INotificationRegistration>: The notification registration definition.
  - `[IncludedEvent <String[]>]`:
  - `[MessageScope <MessageScope?>]`:
  - `[NotificationEndpoint <INotificationEndpoint[]>]`:
    - `[Location <String[]>]`:
    - `[NotificationDestination <String>]`:
  - `[NotificationMode <NotificationMode?>]`:

## RELATED LINKS

