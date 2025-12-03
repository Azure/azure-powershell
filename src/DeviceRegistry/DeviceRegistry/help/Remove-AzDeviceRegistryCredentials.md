---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/remove-azdeviceregistrycredentials
schema: 2.0.0
---

# Remove-AzDeviceRegistryCredentials

## SYNOPSIS
Delete a Credential

## SYNTAX

### Delete (Default)
```
Remove-AzDeviceRegistryCredentials -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzDeviceRegistryCredentials -InputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete a Credential

## EXAMPLES

### Example 1: Remove credentials from a namespace
```powershell
Remove-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group
```

Removes the credentials resource from the namespace.
This operation is destructive and will affect all devices and policies that depend on these credentials.
**Warning:** All associated policies must be deleted before credentials can be removed.

### Example 2: Remove credentials with confirmation prompt
```powershell
Remove-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm
```

```output
Confirm
Are you sure you want to remove credentials from namespace 'my-namespace'? This will affect all associated policies and devices.
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): Y
```

Removes the credentials after prompting for user confirmation due to the destructive nature of the operation.

### Example 3: Remove credentials without confirmation
```powershell
Remove-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm:$false
```

Removes the credentials without prompting for confirmation.
Useful for automation scenarios where the consequences are understood.

### Example 4: Remove credentials via identity object
```powershell
$credentials = Get-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group
Remove-AzDeviceRegistryCredentials -InputObject $credentials -Confirm:$false
```

Retrieves the credentials object and removes it using the identity object parameter.

### Example 5: Remove credentials after cleaning up policies
```powershell
# First remove all policies
Get-AzDeviceRegistryPolicy -NamespaceName my-namespace -ResourceGroupName my-resource-group | Remove-AzDeviceRegistryPolicy -Confirm:$false

# Then remove credentials
Remove-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm:$false
```

Demonstrates the proper cleanup sequence: remove all dependent policies first, then remove the credentials resource.

## PARAMETERS

### -AsJob
Run the command as a job

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The name of the namespace.

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

### -NoWait
Run the command asynchronously

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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
