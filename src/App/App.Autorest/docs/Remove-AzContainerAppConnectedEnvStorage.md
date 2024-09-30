---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/remove-azcontainerappconnectedenvstorage
schema: 2.0.0
---

# Remove-AzContainerAppConnectedEnvStorage

## SYNOPSIS
Delete storage for a connectedEnvironment.

## SYNTAX

### Delete (Default)
```
Remove-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzContainerAppConnectedEnvStorage -InputObject <IAppIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentityConnectedEnvironment
```
Remove-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentInputObject <IAppIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Delete storage for a connectedEnvironment.

## EXAMPLES

### Example 1: Delete storage for a connectedEnvironment.
```powershell
Remove-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azpstestsa
```

Delete storage for a connectedEnvironment.

### Example 2: Delete storage for a connectedEnvironment.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv

Remove-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentInputObject $connectedenv -Name azpstestsa
```

Delete storage for a connectedEnvironment.

### Example 3: Delete storage for a connectedEnvironment.
```powershell
$connectedenvstorage = Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azpstestsa

Remove-AzContainerAppConnectedEnvStorage -InputObject $connectedenvstorage
```

Delete storage for a connectedEnvironment.

## PARAMETERS

### -ConnectedEnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: DeleteViaIdentityConnectedEnvironment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectedEnvironmentName
Name of the Environment.

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

### -Name
Name of the storage.

```yaml
Type: System.String
Parameter Sets: Delete, DeleteViaIdentityConnectedEnvironment
Aliases: StorageName

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

