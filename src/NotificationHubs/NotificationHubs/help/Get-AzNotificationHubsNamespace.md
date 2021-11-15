---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.dll-Help.xml
Module Name: Az.NotificationHubs
ms.assetid: 9805B3F1-C6BB-4A0F-A7C3-1DD1ACB75CDA
online version: https://docs.microsoft.com/powershell/module/az.notificationhubs/get-aznotificationhubsnamespace
schema: 2.0.0
---

# Get-AzNotificationHubsNamespace

## SYNOPSIS
Gets information about a notification hub namespace.

## SYNTAX

```
Get-AzNotificationHubsNamespace [[-ResourceGroup] <String>] [[-Namespace] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
**The Get-AzNotificationHubsNamespace** cmdlet gets information about notification hub namespaces.
This cmdlet provides you the option of getting information for all your namespaces, information about the namespaces assigned to a specified resource group; or for returning information about a specific namespace.
Namespaces are logical containers that help you organize and manage your notification hubs.
You must have at least one notification hub namespace: all notification hubs must be assigned to a namespace.
A single namespace can house multiple hubs which means that you might only need one namespace in your organization.
However, you can also have multiple namespaces to better organize your hubs, or to give specific individuals permission to manage a selected subset of hubs.
The **Get-AzNotificationHubsNamespace** cmdlet returns basic information about the namespace itself.
To get information about the authorization rules associated with a namespace use Get-AzNotificationHubsNamespaceAuthorizationRules.

## EXAMPLES

### Example 1: Get information for all notification hub namespaces
```
PS C:\>Get-AzNotificationHubsNamespace
```

This command returns information for all your notification hub namespaces.

### Example 2: Get information for a single notification hub namespace
```
PS C:\>Get-AzNotificationHubsNamespace -Namespace "ContosoNamespace"
```

This command gets information for a single notification hub namespace: ContosoNamespace.

### Example 3: Get information for all notification hubs assigned to a specific namespace
```
PS C:\>Get-AzNotificationHubsNamespace -ResourceGroup "ContosoNotificationsGroup"
```

This command gets information for all notification hub namespaces assigned to the resource group ContosoNotificationsGroup.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
Specifies a unique name for the namespace.
Namespaces provide a way to group and categorize notification hubs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
Specifies the resource group to which the namespace is assigned.
Resource groups organize items such as namespaces, notification hubs, and authorization rules in ways that help simply inventory management and Azure administration.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.NotificationHubs.Models.NamespaceAttributes

## NOTES

## RELATED LINKS

[Get-AzNotificationHubsNamespaceAuthorizationRule](./Get-AzNotificationHubsNamespaceAuthorizationRule.md)

[New-AzNotificationHubsNamespace](./New-AzNotificationHubsNamespace.md)

[Remove-AzNotificationHubsNamespace](./Remove-AzNotificationHubsNamespace.md)

[Set-AzNotificationHubsNamespace](./Set-AzNotificationHubsNamespace.md)


