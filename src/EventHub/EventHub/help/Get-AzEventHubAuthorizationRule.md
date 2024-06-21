---
external help file: Az.EventHub-help.xml
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/get-azeventhubauthorizationrule
schema: 2.0.0
---

# Get-AzEventHubAuthorizationRule

## SYNOPSIS
Gets an EventHub Authorization Rule

## SYNTAX

### GetExpandedNamespace (Default)
```
Get-AzEventHubAuthorizationRule -NamespaceName <String> -ResourceGroupName <String> [-Name <String>]
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetExpandedEntity
```
Get-AzEventHubAuthorizationRule -NamespaceName <String> -ResourceGroupName <String> [-Name <String>]
 [-SubscriptionId <String[]>] -EventHubName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetExpandedAlias
```
Get-AzEventHubAuthorizationRule -NamespaceName <String> -ResourceGroupName <String> [-Name <String>]
 [-SubscriptionId <String[]>] -AliasName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzEventHubAuthorizationRule -InputObject <IEventHubIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an EventHub Authorization Rule

## EXAMPLES

### Example 1: Get an EventHub Namespace Authorization Rule
```powershell
Get-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAuthRule
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/authorizationRules
                               /myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Gets details of authorization rule `myAuthRule` of EventHub namespace `myNamespace`.

### Example 2: Get an EventHub entity authorization rule
```powershell
Get-AzEventHubAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name myAuthRule
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub/authorizationRules
                               /myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Gets details of authorization rule `myAuthRule` of EventHub entity `myEventHub` from namespace `myNamespace`.

## PARAMETERS

### -AliasName
The name of the Disaster Recovery alias

```yaml
Type: System.String
Parameter Sets: GetExpandedAlias
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

### -EventHubName
The name of the EventHub entity.

```yaml
Type: System.String
Parameter Sets: GetExpandedEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Authorization Rule

```yaml
Type: System.String
Parameter Sets: GetExpandedNamespace, GetExpandedEntity, GetExpandedAlias
Aliases: AuthorizationRuleName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of EventHub namespace

```yaml
Type: System.String
Parameter Sets: GetExpandedNamespace, GetExpandedEntity, GetExpandedAlias
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: GetExpandedNamespace, GetExpandedEntity, GetExpandedAlias
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
Parameter Sets: GetExpandedNamespace, GetExpandedEntity, GetExpandedAlias
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IAuthorizationRule

## NOTES

## RELATED LINKS
