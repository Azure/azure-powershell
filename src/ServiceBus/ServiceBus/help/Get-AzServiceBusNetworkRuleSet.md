---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/get-azservicebusnetworkruleset
schema: 2.0.0
---

# Get-AzServiceBusNetworkRuleSet

## SYNOPSIS
Gets NetworkRuleSet for a Namespace.

## SYNTAX

### Get (Default)
```
Get-AzServiceBusNetworkRuleSet -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List
```
Get-AzServiceBusNetworkRuleSet -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceBusNetworkRuleSet -InputObject <IServiceBusIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets NetworkRuleSet for a Namespace.

## EXAMPLES

### Example 1: Gets the network rule set of a ServiceBus namespace
```powershell
Get-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

```output
DefaultAction                : Allow
IPRule                       : {}
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/networkRuleSets/default
Location                     : Central US
Name                         : default
PublicNetworkAccess          : Enabled
ResourceGroupName            : myResourceGroup
VirtualNetworkRule           :
```

Gets the network rule set of ServiceBus namespace `myNamespace`.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The namespace name

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.INetworkRuleSet

## NOTES

## RELATED LINKS
