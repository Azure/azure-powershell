---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM.EventHub
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.eventhub/Remove-AzureRmEventHubVNetRule
schema: 2.0.0
---

# Remove-AzureRmEventHubVNetRule

## SYNOPSIS
Removes the specified VNet rule for the given namespace

## SYNTAX

### VNetRulePropertiesSet (Default)
```
Remove-AzureRmEventHubVNetRule [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-PassThru]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### VNetRuleInputObjectSet
```
Remove-AzureRmEventHubVNetRule [-InputObject] <PSIpFilterRuleAttributes> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### VNetRuleResourceIdParameterSet
```
Remove-AzureRmEventHubVNetRule [-ResourceId] <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Cmdlet **Remove-AzureRmEventHubVNetRule** deletes the specified VNet Rule for the given namespace

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-AzureRmEventHubVNetRule -ResourceGroup MyResourceGroup -Namespace MyNamespace -Name TestingVNetRule
```
removes the specified VNet Rule

### Example 2
```powershell
PS C:\> Get-AzureRmEventHubVNetRule -ResourceGroup MyResourceGroup -Namespace MyNamespace -Name TestingVNetRule | Remove-AzureRmEventHubVNetRule
```
removes the specified VNet Rule through piping InputObject

### Example 3
```powershell
PS C:\> Remove-AzureRmEventHubVNetRule -ResourceId resourceIdOfVNetRule
```
removes the specified VNet Rule using resource Id

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
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
Type: Microsoft.Azure.Commands.EventHub.Models.PSIpFilterRuleAttributes
Parameter Sets: VNetRuleInputObjectSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Virtual Network Rule Name

```yaml
Type: System.String
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
Type: System.String
Parameter Sets: VNetRulePropertiesSet
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Type: System.String
Parameter Sets: VNetRuleResourceIdParameterSet
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

### System.String
Microsoft.Azure.Commands.EventHub.Models.PSIpFilterRuleAttributes


## OUTPUTS

### System.Boolean


## NOTES

## RELATED LINKS
