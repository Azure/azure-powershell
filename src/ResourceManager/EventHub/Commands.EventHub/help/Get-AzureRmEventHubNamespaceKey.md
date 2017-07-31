---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmEventHubNamespaceKey

## SYNOPSIS
Gets details of Primary, Secondary connectionstrings and keys for the authorization rule of the specified Event Hubs namespace authorization rule.

## SYNTAX

```
Get-AzureRmEventHubNamespaceKey [-ResourceGroupName] <String> [-NamespaceName] <String>
 [-AuthorizationRuleName] <String>
```

## DESCRIPTION
The Get-AzureRmEventHubNamespaceKey cmdlet returns the Primary and Secondary connectionstrings and keys details of the specified authorization rule in the given Event Hubs namespace.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventHubNamespaceKey -ResourceGroupName MyResourceGroupName -NamespaceName MyNamespaceName -AuthorizationRuleName MyAuthRuleName
```

Gets details of Primary, Secondary connectionstrings and keys for the authorization rule \`MyAuthRuleName\` on the Event Hubs namespace \`MyNamespaceName\` in the resource group \`MyResourceGroupName\`.

## PARAMETERS

### -AuthorizationRuleName
The name of the authorization rule on the Event Hubs namespace.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NamespaceName
The Event Hubs namespace name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.ListKeysAttributes

## NOTES

## RELATED LINKS

