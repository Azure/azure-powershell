---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 40E56EC1-3327-4DFF-8262-E2EEBB5E4447
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/set-azurermfirewall
schema: 2.0.0
---

# Set-AzureRmFirewall

## SYNOPSIS
Updates a Firewall

## SYNTAX

```
Set-AzureRmFirewall -Firewall <Microsoft.Azure.Commands.Network.Models.PSFirewall>
```

## DESCRIPTION
The **Set-AzureRmFirewall** cmdlet updates an Azure Firewall.

## EXAMPLES

### 1:  Update priority of a Firewall rule
```
$secGw = Get-AzureRmFirewall -Name "SecGw" -ResourceGroupName "rg"
$ruleCollection = $secGw.GetApplicationRuleCollectionByName("ruleCollectionName")
$rule = $ruleCollection.GetRuleByName("ruleName")
$rule.Priority = 101
Set-AzureRmFirewall -Firewall $secGw
```

This example updates the priority of an existing rule of a secure gateway.
Assuming secure gateway "SecGw" in resource group "rg" contains an application rule named "ruleName" inside
an application rule collection named "ruleCollectionName", commands above will change the priority of that rule
and update the Secure Gateway afterwards.
Without the Set-AzureRmSecureGateway command, all operations performed on the local $secGw object are not reflected
on the server.

### 2:  Create a secure gateway and attach it to a virtual network later
```
$secGw = New-AzureRmFirewall -Name "SecGw" -ResourceGroupName "rg"

$vnet = Get-AzureRmVirtualNetwork -Name vnet -ResourceGroupName "rg"
$secGw.AttachToVirtualNetwork($vnet)
$secGw | Set-AzureRmFirewall
```

In this example, a Firewall is created first without being attached to a virtual network.
When AttachToVirtualNetwork is called, Firewall object is modified in memory, without affecting the real configuration in cloud.
For changes to be reflected in cloud, Set-AzureRmFirewall must be called.

## PARAMETERS

### -Firewall
Specifies a **Firewall** object that represents the goal state.

```yaml
Type: PSFirewall
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSVirtualNetwork
Parameter 'Firewall' accepts value of type 'PSFirewall' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSFirewall

## NOTES

## RELATED LINKS

[Get-AzureRmFirewall](./Get-AzureRmFirewall.md)

[New-AzureRmFirewall](./New-AzureRmFirewall.md)

[Remove-AzureRmFirewall](./Remove-AzureRmFirewall.md)
