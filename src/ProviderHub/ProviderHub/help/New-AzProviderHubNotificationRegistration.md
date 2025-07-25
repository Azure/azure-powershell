---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubnotificationregistration
schema: 2.0.0
---

# New-AzProviderHubNotificationRegistration

## SYNOPSIS
Create a notification registration.

## SYNTAX

### CreateExpanded (Default)
```
New-AzProviderHubNotificationRegistration -Name <String> -ProviderNamespace <String> [-SubscriptionId <String>]
 [-IncludedEvent <String[]>] [-MessageScope <String>] [-NotificationEndpoint <INotificationEndpoint[]>]
 [-NotificationMode <String>] [-ProvisioningState <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzProviderHubNotificationRegistration -Name <String> -ProviderNamespace <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzProviderHubNotificationRegistration -Name <String> -ProviderNamespace <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityProviderRegistrationExpanded
```
New-AzProviderHubNotificationRegistration -Name <String>
 -ProviderRegistrationInputObject <IProviderHubIdentity> [-IncludedEvent <String[]>] [-MessageScope <String>]
 [-NotificationEndpoint <INotificationEndpoint[]>] [-NotificationMode <String>] [-ProvisioningState <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a notification registration.

## EXAMPLES

### Example 1: Create/Update a notification registration.
```powershell
New-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest" -NotificationMode "EventHub" -MessageScope "RegisteredSubscriptions" -IncludedEvent "*/write", "Microsoft.Contoso/testResourceType/delete" -NotificationEndpoint @{Location = "", "East US"; NotificationDestination = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mgmtexp-eastus/providers/Microsoft.EventHub/namespaces/unitedstates-mgmtexpint/eventhubs/armlinkednotifications"}
```

```output
Name
----
notificationRegistrationTest
```

Create/Update a notification registration.

### Example 2: Create/Update a notification registration.
```powershell
New-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest" -NotificationMode "EventHub" -MessageScope "RegisteredSubscriptions" -IncludedEvent "*/write", "Microsoft.Contoso/testResourceType/delete" -NotificationEndpoint @{Location = "", "East US"; NotificationDestination = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mgmtexp-eastus/providers/Microsoft.EventHub/namespaces/unitedstates-mgmtexpint/eventhubs/armlinkednotifications"}
```

```output
Name
----
notificationRegistrationTest
```

Create/Update a notification registration.

## PARAMETERS

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

### -IncludedEvent
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MessageScope
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: (All)
Aliases: NotificationRegistrationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationEndpoint
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.INotificationEndpoint[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderRegistrationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
Parameter Sets: CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProvisioningState
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.INotificationRegistration

## NOTES

## RELATED LINKS
