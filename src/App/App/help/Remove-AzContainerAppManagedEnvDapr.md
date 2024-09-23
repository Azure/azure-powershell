---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/remove-azcontainerappmanagedenvdapr
schema: 2.0.0
---

# Remove-AzContainerAppManagedEnvDapr

## SYNOPSIS
Delete a Dapr Component from a Managed Environment.

## SYNTAX

### Delete (Default)
```
Remove-AzContainerAppManagedEnvDapr -EnvName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityManagedEnvironment
```
Remove-AzContainerAppManagedEnvDapr -Name <String> -ManagedEnvironmentInputObject <IAppIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzContainerAppManagedEnvDapr -InputObject <IAppIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete a Dapr Component from a Managed Environment.

## EXAMPLES

### Example 1: Delete a Dapr Component from a Managed Environment.
```powershell
Remove-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-dapr
```

Delete a Dapr Component from a Managed Environment.

### Example 2: Delete a Dapr Component from a Managed Environment.
```powershell
$managedenvdapr = Get-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-dapr

Remove-AzContainerAppManagedEnvDapr -InputObject $managedenvdapr
```

Delete a Dapr Component from a Managed Environment.

### Example 3: Delete a Dapr Component from a Managed Environment.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app

Remove-AzContainerAppManagedEnvDapr -ManagedEnvironmentInputObject $managedenv -Name azps-dapr
```

Delete a Dapr Component from a Managed Environment.

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

### -EnvName
Name of the Managed Environment.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedEnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: DeleteViaIdentityManagedEnvironment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Dapr Component.

```yaml
Type: System.String
Parameter Sets: Delete, DeleteViaIdentityManagedEnvironment
Aliases: DaprName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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
Parameter Sets: Delete
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
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
