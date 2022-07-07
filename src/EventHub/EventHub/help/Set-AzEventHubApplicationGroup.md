---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventHub.dll-Help.xml
Module Name: Az.EventHub
online version:
schema: 2.0.0
---

# Set-AzEventHubApplicationGroup

## SYNOPSIS
Updates an application group in a namespace.

## SYNTAX

### ApplicationGroupPropertiesParameterSet (Default)
```
Set-AzEventHubApplicationGroup [-ResourceGroupName] <String> [-NamespaceName] <String> [-Name] <String>
 [-IsEnabled] [-ThrottlingPolicyConfig <PSEventHubThrottlingPolicyConfigAttributes[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationGroupResourceIdParameterSet
```
Set-AzEventHubApplicationGroup [-IsEnabled]
 [-ThrottlingPolicyConfig <PSEventHubThrottlingPolicyConfigAttributes[]>] -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ApplicationGroupInputObjectParameterSet
```
Set-AzEventHubApplicationGroup [-InputObject] <PSEventHubApplicationGroupAttributes>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates an application group in a namespace.
Cmdlet can be used to enable or disable application group connections and set throttling policies.

## EXAMPLES

### Example 1: Add throttling policies to an already existing application group.
```powershell
$policyToBeAppended = New-AzEventHubThrottlingPolicyConfig -Name policy1 -MetricId IncomingBytes -RateLimitThreshold 12345

$appGroup = Get-AzEventHubApplicationGroup -ResourceGroupName myresourcegroup -NamespaceName mynamespace -Name myappgroup

$appGroup.ThrottlingPolicyConfig += $policyToBeAppended

Set-AzEventHubApplicationGroup -ResourceGroupName myresourcegroup -NamespaceName mynamespace -Name myappgroup -ThrottlingPolicyConfig $appGroup.ThrottlingPolicyConfig
```

`-ThrottlingPolicyConfig` takes an array of PSEventHubThrottlingPolicyConfigAttributes objects. It represents the entire set of throttling policies
defined on the appplication group and not just the one. If you want to add or remove throttling policies, the right way to do it is to get
the application group and query the ThrottlingPolicyConfig field of the object returned as shown above.

## PARAMETERS

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
Input Object of type PSEventHubApplicationGroupAttributes

```yaml
Type: Microsoft.Azure.Commands.EventHub.Models.PSEventHubApplicationGroupAttributes
Parameter Sets: ApplicationGroupInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsEnabled
Determines if Application Group is allowed to create connection with namespace or not.
Once the isEnabled is set to false, all the existing connections of application group gets dropped and no new connections will be allowed

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ApplicationGroupPropertiesParameterSet, ApplicationGroupResourceIdParameterSet
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Application Group Name

```yaml
Type: System.String
Parameter Sets: ApplicationGroupPropertiesParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NamespaceName
Namespace Name

```yaml
Type: System.String
Parameter Sets: ApplicationGroupPropertiesParameterSet
Aliases:

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
Parameter Sets: ApplicationGroupPropertiesParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
ResourceId of application group

```yaml
Type: System.String
Parameter Sets: ApplicationGroupResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ThrottlingPolicyConfig
List of Throttling Policy Objects.
Please use New-AzEventHubThrottlingPolicyConfig to create in memory object which can be one item in this list.

```yaml
Type: Microsoft.Azure.Commands.EventHub.Models.PSEventHubThrottlingPolicyConfigAttributes[]
Parameter Sets: ApplicationGroupPropertiesParameterSet, ApplicationGroupResourceIdParameterSet
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Management.Automation.SwitchParameter

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubThrottlingPolicyConfigAttributes[]

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubApplicationGroupAttributes

## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubApplicationGroupAttributes

## NOTES

## RELATED LINKS
