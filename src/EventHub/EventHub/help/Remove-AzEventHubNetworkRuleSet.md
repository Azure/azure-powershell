---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventHub.dll-Help.xml
Module Name: Az.EventHub
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.eventhub/remove-azeventhubnetworkruleset
=======
online version: https://docs.microsoft.com/powershell/module/az.eventhub/remove-azeventhubnetworkruleset
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Remove-AzEventHubNetworkRuleSet

## SYNOPSIS
<<<<<<< HEAD
Removes the NetwrokRuleSet for the Given Namespace
=======
Removes the NetworkRuleSet for the Given Namespace
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## SYNTAX

### NetworkRuleSetPropertiesSet (Default)
```
Remove-AzEventHubNetworkRuleSet [-ResourceGroupName] <String> [-Name] <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### NamespaceInputObjectSet
```
Remove-AzEventHubNetworkRuleSet [-InputObject] <PSNamespaceAttributes> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### NetworkRuleSetResourceIdParameterSet
```
Remove-AzEventHubNetworkRuleSet [-ResourceId] <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
<<<<<<< HEAD
Removes the NetwrokRuleSet for the Given Namespace
=======
Removes the NetworkRuleSet for the Given Namespace
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-AzEventHubNetworkRuleSet -ResourceGroupName  v-ajnavtest -Namespace Eventhub-Namespace1-1375 -PassThru
```
Name                : default
DefaultAction       : Allow
Id                  : /subscriptions/subscriptionId/resourceGroups/ResourceGroup/providers/Microsoft.EventHub/namespaces/EventHub-Namespace-1375/networkRuleSets/default
Type                : Microsoft.EventHub/Namespaces/NetworkRuleSet
IpRules             : 
VirtualNetworkRules : 


<<<<<<< HEAD
Deletes the NetwrokRuleSet for the Given "Eventhub-Namespace1-1375" namesapce 
=======
Deletes the NetworkRuleSet for the Given "Eventhub-Namespace1-1375" namespace 
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

### Example 2
```powershell
PS C:\> Remove-AzEventHubNetworkRuleSet -InputObject $result1375
```

<<<<<<< HEAD
Deletes the NetwrokRuleSet using InputObject 
=======
Deletes the NetworkRuleSet using InputObject 
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

### Example 3
```powershell
PS C:\> Remove-AzEventHubNetworkRuleSet -ResourceId /SubscriptionId/resourcegroups/ResourceGroup/providers/Microsoft.EventHub/namespaces/Eventhub-Namespace1-1375 -PassThru
```
Name                : default
DefaultAction       : Allow
Id                  : /subscriptions/subscriptionId/resourceGroups/ResourceGroup/providers/Microsoft.EventHub/namespaces/EventHub-Namespace-1375/networkRuleSets/default
Type                : Microsoft.EventHub/Namespaces/NetworkRuleSet
IpRules             : 
VirtualNetworkRules : 

<<<<<<< HEAD
Deletes the NetwrokRuleSet using ResourceId of the Namepsace
=======
Deletes the NetworkRuleSet using ResourceId of the Namespace
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a


## PARAMETERS

### -AsJob
Run cmdlet in the background

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Namespace Object

```yaml
Type: Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes
Parameter Sets: NamespaceInputObjectSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Namespace Name

```yaml
Type: System.String
Parameter Sets: NetworkRuleSetPropertiesSet
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
{{Fill PassThru Description}}

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

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: NetworkRuleSetPropertiesSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Namespace Resource Id

```yaml
Type: System.String
Parameter Sets: NetworkRuleSetResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS