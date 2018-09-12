---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM.EventHub
online version:
schema: 2.0.0
---

# Set-AzureRmEventHubVNetRule

## SYNOPSIS
Update the specified VNet Rule for the given namespace

## SYNTAX

### VNetRulePropertiesSet (Default)
```
Set-AzureRmEventHubVNetRule [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
 [-VirtualNetworkSubnetId <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### IpFilterRuleInputObjectSet
```
Set-AzureRmEventHubVNetRule [-InputObject <PSVirtualNetWorkRuleAttributes>] [-VirtualNetworkSubnetId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### VNetRuleResourceIdParameterSet
```
Set-AzureRmEventHubVNetRule [-ResourceId] <String> [-VirtualNetworkSubnetId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
command **Set-AzureRmEventHubVNetRule** will update the specified VNet Rule description. 

## EXAMPLES

### Example 1
```powershell
PS C:\> $updatedVNetRule = Set-AzureRmEventHubVNetRule -ResourceGroup resourcegroup -Namespace namespacename -Name vnetrulename -VirtualNetworkSubnetId vNetsubnetId
```

update the VNet Rule using parameters

### Example 2
```powershell

PS C:\> $createdVNetRule = Get-AzureRmEventHubVNetRule -ResourceGroup resourcegroup -Namespace namespaceame -Name vnetrulename
PS C:\> $createdVNetRule.VirtualNetworkSubnetId = vNetsubnetId
PS C:\> $updatedVNetRule = Set-AzureRmEventHubVNetRule -ResourceGroup resourcegroup -Namespace namespacename -Name vnetrulename -InputObject $createdVNetRule
```

update the VNet Rule using InputObject

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -InputObject
Virtual Network Rule Object

```yaml
Type: PSVirtualNetWorkRuleAttributes
Parameter Sets: IpFilterRuleInputObjectSet
Aliases: EventHubObj

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Virtual Network Rule Name

```yaml
Type: String
Parameter Sets: VNetRulePropertiesSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name

```yaml
Type: String
Parameter Sets: VNetRulePropertiesSet
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
Type: String
Parameter Sets: VNetRulePropertiesSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Virtual Network Rule Resource Id

```yaml
Type: String
Parameter Sets: VNetRuleResourceIdParameterSet
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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
Microsoft.Azure.Commands.EventHub.Models.PSVirtualNetWorkRuleAttributes


## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.PSVirtualNetWorkRuleAttributes


## NOTES

## RELATED LINKS
