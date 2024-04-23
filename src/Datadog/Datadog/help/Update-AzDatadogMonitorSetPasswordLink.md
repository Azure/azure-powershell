---
external help file: Az.Datadog-help.xml
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/update-azdatadogmonitorsetpasswordlink
schema: 2.0.0
---

# Update-AzDatadogMonitorSetPasswordLink

## SYNOPSIS
Refresh the set password link and return a latest one.

## SYNTAX

### Refresh (Default)
```
Update-AzDatadogMonitorSetPasswordLink -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RefreshViaIdentity
```
Update-AzDatadogMonitorSetPasswordLink -InputObject <IDatadogIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Refresh the set password link and return a latest one.

## EXAMPLES

### Example 1: Refresh the set password link and return a latest one
```powershell
Update-AzDatadogMonitorSetPasswordLink -ResourceGroupName azure-rg-Datadog -Name Datadog
```

```output
https://us3.Datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one.

### Example 2: Refresh the set password link and return a latest one by pipeline
```powershell
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Update-AzDatadogMonitorSetPasswordLink
```

```output
https://us3.Datadoghq.com/account/reset_password/xxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This command refresh the set password link and return a latest one by pipeline.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
Parameter Sets: RefreshViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Refresh
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Refresh
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Refresh
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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
