---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/get-azproviderhubnotificationregistration
schema: 2.0.0
---

# Get-AzProviderHubNotificationRegistration

## SYNOPSIS
Gets the notification registration details.

## SYNTAX

### List (Default)
```
Get-AzProviderHubNotificationRegistration -ProviderNamespace <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzProviderHubNotificationRegistration -Name <String> -ProviderNamespace <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzProviderHubNotificationRegistration -InputObject <IProviderHubIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the notification registration details.

## EXAMPLES

### Example 1: List all the notification registration by ProviderNamespace.
```powershell
Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso"
```

```output
Name
----
notificationRegistrationTest1
notificationRegistrationTest2
```

List all the notification registration in the provider namespace.

### Example 2: Get the notification registration by name.
```powershell
Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest"
```

```output
Name
----
notificationRegistrationTest
```

Get the notification registration by name.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The notification registration.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NotificationRegistrationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationRegistration

## NOTES

## RELATED LINKS
