---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 7436F31F-9DCB-4365-BA6D-41BDB5D7FCB6
online version: 
schema: 2.0.0
---

# Set-AzureRmActivityLogAlert

## SYNOPSIS
Creates a new or sets an existing activity log alert.

## SYNTAX

```
Set-AzureRmActivityLogAlert [-InputObject <PSActivityLogAlertResource>] [-ResourceId <String> [-Location <String>] [-Scope <System.Collections.Generic.List`1[System.String]>] [-Condition <System.Collections.Generic.List`1[ActivityLogAlertLeafCondition]>]
 [-Action <System.Collections.Generic.List`1[ActivityLogAlertActionGroup]>] [-DisableAlert] [-Description <String>] [-Tag <System.Collections.Generic.Dictionary`1[<string>, <string>]>]] -Location <String> -Name <String> -ResourceGroupName <String>
 -Scope <System.Collections.Generic.List`1[System.String]> -Condition <System.Collections.Generic.List`1[ActivityLogAlertLeafCondition]>
 -Action <System.Collections.Generic.List`1[ActivityLogAlertActionGroup]> [-DisableAlert] [-Description <String>] [-Tag <System.Collections.Generic.Dictionary`1[<string>, <string>]>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmActivityLogAlert** cmdlet creates a new or sets an existing activity log alert.
For tags, conditions, and actions the objects must be created in advance and passed as parameters in this call as a comma separated (see the example below).
This cmdlet implements the ShouldProcess pattern, i.e. it might request confirmation from the user before actually creating/modifying the resource and it accepts the -Force argument.

## EXAMPLES

### Example 1: Create an Activity Log Alert
```
PS C:\>$location = 'Global'
PS C:\>$alertName = 'myAlert'
PS C:\>$resourceGroupName = 'theResourceGroupName'
PS C:\>$condition1 = New-AzureRmActivityLogAlertCondition -Field 'field1' -Equals 'equals1'
PS C:\>$condition2 = New-AzureRmActivityLogAlertCondition -Field 'field2' -Equals 'equals2'
PS C:\>$dict = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
PS C:\>$dict.Add('key1', 'value1')
PS C:\>$actionGrp1 = New-AzureRmActionGroup -ActionGroupId 'actiongr1' -WebhookProperties $dict
PS C:\>Set-AzureRmActivityLogAlert -Location $location -Name $alertName -ResourceGroupName $resourceGroupName -Scope 'scope1','scope2' -Action $actionGrp1 -Condition $condition1, $condition2

```

The first four commands create leaf condition and and action group.
The final command creates an Activity Log Alert using the condition and the action group.

### Example 2: Create an Activity Log Alert disabled
```
PS C:\>$location = 'Global'
PS C:\>$alertName = 'myAlert'
PS C:\>$resourceGroupName = 'theResourceGroupName'
PS C:\>$condition1 = New-AzureRmActivityLogAlertCondition -Field 'field1' -Equals 'equals1'
PS C:\>$condition2 = New-AzureRmActivityLogAlertCondition -Field 'field2' -Equals 'equals2'
PS C:\>$dict = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
PS C:\>$dict.Add('key1', 'value1')
PS C:\>$actionGrp1 = New-AzureRmActionGroup -ActionGroupId 'actiongr1' -WebhookProperties $dict
PS C:\>Set-AzureRmActivityLogAlert -Location $location -Name $alertName -ResourceGroupName $resourceGroupName -Scope 'scope1','scope2' -Action $actionGrp1 -Condition $condition1, $condition2 -DisableAlert

```

The first four commands create leaf condition and and action group.
The final command creates an Activity Log Alert using the condition and the action group, but it creates the alert disabled.

### Example 3: Set an activity log alert based using a value from the pipe or the InputObject parameter
```
PS C:\>Get-AzureRmActivityLogAlert -Name $alertName -ResourceGroupName $resourceGroupName | Set-AzureRmActivityLogAlert
PS C:\>$alert = Get-AzureRmActivityLogAlert -Name $alertName -ResourceGroupName $resourceGroupName
PS C:\>$alert.Description = 'Changing the description'
PS C:\>$alert.Enabled = $false
PS C:\>Set-AzureRmActivityLogAlert -InputObject $alert

```

The first command is similar to a nop, it sets the alert with the same values it already contained
The rest of the commands retrieve the alert rule, change the description and disable it, then use the InputObject parameter to persist those changes

### Example 4: Set an activity log alert based using the ResourceId value from the pipe
```
PS C:\>Find-AzureRmResource -ResourceGroupEquals "myResourceGroup" -ResourceNameEquals "myLogAlert" | Set-AzureRmActivityLogAlert -DisableAlert

```

If the given log alert rule exists this command disables it.

## PARAMETERS

### -Location
The location where the activity log alert will exist.

```yaml
Type: System.String
Parameter Sets: SetActivityLogAlertDefaultParamGroup, SetActivityLogAlertFromResourceIdParamGroup
Aliases: 

Required: True for SetActivityLogAlertDefaultParamGroup, False for SetActivityLogAlertFromResourceIdParamGroup
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the activity log alert.

```yaml
Type: System.String
Parameter Sets: SetActivityLogAlertDefaultParamGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the alert resource is going to exist.

```yaml
Type: System.String
Parameter Sets: SetActivityLogAlertDefaultParamGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
The list of scopes for the activity log alert.

```yaml
Type: <System.Collections.Generic.List`1[System.String]>
Parameter Sets: SetActivityLogAlertDefaultParamGroup, SetActivityLogAlertFromResourceIdParamGroup
Aliases: 

Required: True for SetActivityLogAlertDefaultParamGroup, False for SetActivityLogAlertFromResourceIdParamGroup
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Condition
The list of conditions for the activity log alert.

```yaml
Type: <System.Collections.Generic.List`1[ActivityLogAlertLeafCondition]>
Parameter Sets: (All)
Aliases: 

Required: True for SetActivityLogAlertDefaultParamGroup, False for SetActivityLogAlertFromResourceIdParamGroup
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Action
The list of action groups for the activity log alert.

```yaml
Type: <System.Collections.Generic.List`1[ActivityLogAlertActionGroup]>
Parameter Sets: SetActivityLogAlertDefaultParamGroup, SetActivityLogAlertFromResourceIdParamGroup
Aliases: 

Required: True for SetActivityLogAlertDefaultParamGroup, False for SetActivityLogAlertFromResourceIdParamGroup
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisableAlert
Allows the user to create a disabled the activity log alert. If not given, the alerts are created enabled.

```yaml
Type: SwitchParameter
Parameter Sets: SetActivityLogAlertDefaultParamGroup, SetActivityLogAlertFromResourceIdParamGroup
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Description
The description of the alert resource.

```yaml
Type: System.String
Parameter Sets: SetActivityLogAlertDefaultParamGroup, SetActivityLogAlertFromResourceIdParamGroup
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Sets the tags property of the activity log alert resource.

```yaml
Type: System.Collections.Generic.Dictionary`1[<string>, <string>]
Parameter Sets: SetActivityLogAlertDefaultParamGroup, SetActivityLogAlertFromResourceIdParamGroup
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
Sets the InputObject tags property of the call to extract the required name, and resource group name properties.

```yaml
Type: Microsoft.Azure.Commands.Insights.OutputClasses.PSActivityLogAlertResource
Parameter Sets: SetActivityLogAlertFromPipeParamGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (FromPipeline)
Accept wildcard characters: False
```

### -ResourceId
Sets the ResourceId tags property of the call to extract the required name, resource group name properties.

```yaml
Type: System.String
Parameter Sets: SetActivityLogAlertFromResourceIdParamGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSActivityLogAlertResource

## NOTES

## RELATED LINKS

[Enable-AzureRmActivityLogAlert](./Enable-AzureRmActivityLogAlert.md)

[Disable-AzureRmActivityLogAlert](./Disable-AzureRmActivityLogAlert.md)

[Get-AzureRmActivityLogAlert](./Get-AzureRmActivityLogAlert.md)

[Remove-AzureRmActivityLogAlert](./Remove-AzureRmActivityLogAlert.md)

[New-AzureRmActionGroup](./New-AzureRmActionGroup.md)

[New-AzureRmActivityLogAlertCondition](./Get-AzureRmActivityLogAlertCondition.md)
