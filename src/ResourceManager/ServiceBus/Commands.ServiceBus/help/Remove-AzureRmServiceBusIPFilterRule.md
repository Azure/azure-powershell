---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version:https://docs.microsoft.com/en-us/powershell/module/azurerm.servicebus/remove-azurermServiceBusipfilterrule
schema: 2.0.0
---

# Remove-AzureRmServiceBusIPFilterRule

## SYNOPSIS
removes the specified Ip Filter rule for the given namespace

## SYNTAX

### IpFilterRulePropertiesSet (Default)
```
Remove-AzureRmServiceBusIPFilterRule [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
 [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IpFilterRuleInputObjectSet
```
Remove-AzureRmServiceBusIPFilterRule [-InputObject] <PSIpFilterRuleAttributes> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IpFilterRuleResourceIdParameterSet
```
Remove-AzureRmServiceBusIPFilterRule [-ResourceId] <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Cmdlet **Remove-AzureRmServiceBusIPFilterRule** deletes the specified Ip Filter Rule for the given namespace

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-AzureRmServiceBusIPFilterRule -ResourceGroup resourcegroup -Namespace namespaceame -Name ipfilterrulename
```

removes the specified Ip Filter Rule

### Example 2
```powershell
PS C:\> Get-AzureRmServiceBusIPFilterRule -ResourceGroup resourcegroup -Namespace namespaceame -Name ipfilterrulename | Remove-AzureRmServiceBusIPFilterRule
```

removes the specified Ip Filter Rule through piping InputObject

### Example 3
```powershell
PS C:\> Remove-AzureRmServiceBusIPFilterRule -ResourceId resourceIdOfIpFilterRule
```

removes the specified Ip Filter Rule using resource Id

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
Ip Filter Rule Object

```yaml
Type: Microsoft.Azure.Commands.ServiceBus.Models.PSIpFilterRuleAttributes
Parameter Sets: IpFilterRuleInputObjectSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Ip Filter Rule Name

```yaml
Type: System.String
Parameter Sets: IpFilterRulePropertiesSet
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
Parameter Sets: IpFilterRulePropertiesSet
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
Parameter Sets: IpFilterRulePropertiesSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Ip Filter Rule Resource Id

```yaml
Type: System.String
Parameter Sets: IpFilterRuleResourceIdParameterSet
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
Microsoft.Azure.Commands.ServiceBus.Models.PSIpFilterRuleAttributes


## OUTPUTS

### System.Boolean


## NOTES

## RELATED LINKS
