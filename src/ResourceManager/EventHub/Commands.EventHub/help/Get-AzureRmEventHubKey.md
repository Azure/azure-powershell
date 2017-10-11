---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmEventHubKey

## SYNOPSIS
Gets the primary key details of the specified Event Hubs authorization rule.

## SYNTAX

### NamespaceAuthorizationRuleSet (Default)
```
Get-AzureRmEventHubKey [-ResourceGroupName] <String> -Namespace <String> -Name <String>
```

### EventhubAuthorizationRuleSet
```
Get-AzureRmEventHubKey [-ResourceGroupName] <String> [-Namespace <String>] -EventHub <String> -Name <String>
```

## DESCRIPTION
The Get-AzureRmEventHubKey cmdlet returns Primary and Secondary connectionstrings and keys details of the specified Event Hubs authorization rule.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventHubKey -ResourceGroupName MyResourceGroupName -NamespaceName MyNamespaceName -EventHubName MyEventHubName -AuthorizationRuleName MyAuthRuleName
```

Gets details of Primary and Secondary connectionstrings and keys for the authorization rule \`MyAuthRuleName\`.

## PARAMETERS

### -ResourceGroupName
Resource group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EventHub
EventHub Name.

```yaml
Type: String
Parameter Sets: EventhubAuthorizationRuleSet
Aliases: EventHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
AuthorizationRule Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: AuthorizationRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name.

```yaml
Type: String
Parameter Sets: NamespaceAuthorizationRuleSet
Aliases: NamespaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: EventhubAuthorizationRuleSet
Aliases: NamespaceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.ListKeysAttributes

## NOTES

## RELATED LINKS

