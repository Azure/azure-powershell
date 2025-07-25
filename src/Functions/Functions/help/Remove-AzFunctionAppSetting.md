---
external help file: Az.Functions-help.xml
Module Name: Az.Functions
online version: https://learn.microsoft.com/powershell/module/az.functions/remove-azfunctionappsetting
schema: 2.0.0
---

# Remove-AzFunctionAppSetting

## SYNOPSIS
Removes app settings from a function app.

## SYNTAX

### ByName (Default)
```
Remove-AzFunctionAppSetting -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -AppSettingName <String[]> [-Force] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectInput
```
Remove-AzFunctionAppSetting -AppSettingName <String[]> [-Force] -InputObject <ISite>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Removes app settings from a function app.

## EXAMPLES

### Example 1: Remove app settings in a function app.
```powershell
Remove-AzFunctionAppSetting -Name MyAppName -ResourceGroupName MyResourceGroupName -AppSettingName "MyAppSetting1", "MyAppSetting2"
```

This command removes app settings in a function app.

## PARAMETERS

### -AppSettingName
List of function app settings to be removed from the function app.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile

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

### -Force
Forces the cmdlet to remove function app setting without prompting for confirmation.

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

### -InputObject
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ISite
Parameter Sets: ByObjectInput
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the function app.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ISite

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.IStringDictionary

## NOTES

## RELATED LINKS
