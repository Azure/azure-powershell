---
external help file: Az.Functions-help.xml
Module Name: Az.Functions
online version: https://learn.microsoft.com/powershell/module/az.functions/start-azfunctionapp
schema: 2.0.0
---

# Start-AzFunctionApp

## SYNOPSIS
Starts a function app.

## SYNTAX

### StartByName (Default)
```
Start-AzFunctionApp -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByObjectInput
```
Start-AzFunctionApp -InputObject <ISite> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Starts a function app.

## EXAMPLES

### Example 1: Get a function app by name and start it.
```powershell
Get-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName | Start-AzFunctionApp
```

This command gets a function app by name and starts it.

### Example 2: Start a function app by name.
```powershell
Start-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName
```

This command starts a function app by name.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
The name of function app.

```yaml
Type: System.String
Parameter Sets: StartByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds.

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

```yaml
Type: System.String
Parameter Sets: StartByName
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
Parameter Sets: StartByName
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

### System.Boolean

## NOTES

## RELATED LINKS
