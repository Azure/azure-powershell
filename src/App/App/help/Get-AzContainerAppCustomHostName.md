---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappcustomhostname
schema: 2.0.0
---

# Get-AzContainerAppCustomHostName

## SYNOPSIS
Analyzes a custom hostname for a Container App

## SYNTAX

```
Get-AzContainerAppCustomHostName -ContainerAppName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-CustomHostname <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Analyzes a custom hostname for a Container App

## EXAMPLES

### Example 1: Analyzes a custom hostname for a Container App.
```powershell
Get-AzContainerAppCustomHostName -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app
```

```output
ConflictWithEnvironmentCustomDomain ConflictingContainerAppResourceId CustomDomainVerificationTest HasConflictOnManagedEnvironment HostName IsHostnameAlreadyVerified
----------------------------------- --------------------------------- ---------------------------- ------------------------------- -------- -------------------------
False                                                                 Failed                       False                                    False
```

Analyzes a custom hostname for a Container App.

## PARAMETERS

### -ContainerAppName
Name of the Container App.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomHostname
Custom hostname.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Parameter Sets: (All)
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
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.ICustomHostnameAnalysisResult

## NOTES

## RELATED LINKS
