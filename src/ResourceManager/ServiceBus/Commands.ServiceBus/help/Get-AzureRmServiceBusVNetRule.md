---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version:https://docs.microsoft.com/en-us/powershell/module/azurerm.ServiceBus/Get-AzureRmServiceBusVNetRule
schema: 2.0.0
---

# Get-AzureRmServiceBusVNetRule

## SYNOPSIS
Returns description for the specified rule or list of VNet rules for specified namespace.

## SYNTAX

### VNetRulePropertiesSet (Default)
```
Get-AzureRmServiceBusVNetRule [-ResourceGroupName] <String> [-Namespace] <String> [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### VNetRuleResourceIdParameterSet
```
Get-AzureRmServiceBusVNetRule [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmServiceBusVNetRule** cmdlet returns the description of the specified VNet Rule or list of VNet Rules.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmServiceBusVNetRule -ResourceGroup resourcegroup -Namespace namespaceame -Name vnetrulename
```

Get-AzureRmServiceBusVNetRule cmdlet with the name of the VNet Rule will return the rule description

### Example 2
```powershell
PS C:\> Get-AzureRmServiceBusVNetRule -ResourceGroup resourcegroup -Namespace namespaceame
```

Get-AzureRmServiceBusVNetRule cmdlet without specific VNet Rule name will return the list of rule description

### Example 3
```powershell
PS C:\> Get-AzureRmServiceBusVNetRule -ResourceId vnetrule_resourceid
```

Get-AzureRmServiceBusVNetRule cmdlet without specific VNet Rule ResourceId

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
Parameter Sets: VNetRulePropertiesSet
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
Namespace Name

```yaml
Type: System.String
Parameter Sets: VNetRulePropertiesSet
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: VNetRulePropertiesSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Virtual Network Rule Resource Id

```yaml
Type: System.String
Parameter Sets: VNetRuleResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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
