---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version:https://docs.microsoft.com/en-us/powershell/module/azurerm.ServiceBus/New-AzureRmServiceBusVNetRule
schema: 2.0.0
---

# New-AzureRmServiceBusVNetRule

## SYNOPSIS
Creates as new VNet(Virtual Network) Rule for given namespace

## SYNTAX

```
New-AzureRmServiceBusVNetRule [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
 -VirtualNetworkSubnetId <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmServiceBusVNetRule** cmdlet Creates a new VNet Rule for given namespace.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmServiceBusIPFilterRule -ResourceGroup MyResourceGroup -Namespace MyNamespace -Name TestingVNetRule -VirtualNetworkSubnetId VnetsubNetId

Id                     : /subscriptions/XXXXX-XXXX-XXXX-XXXX-XXXXXXXX/resourceGroups/v-ajnavtest/providers/Microsoft.ServiceBus/namespaces/TestingpreviewNS1/virtualnetworkrules/TestingVNetRule
Name                   : TestingVNetRule
VirtualNetworkSubnetId : /subscriptions/XXXXX-XXXX-XXXX-XXXX-XXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft.Network/virtualNetworks/MyVirtualNetworks/subnets/Mydefault
```

Creates a new VNet Rule for the given namespace

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Virtual Network Rule Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkSubnetId
ARM ID of Virtual Network Subnet

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
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

### System.String


## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.PSVirtualNetWorkRuleAttributes


## NOTES

## RELATED LINKS
