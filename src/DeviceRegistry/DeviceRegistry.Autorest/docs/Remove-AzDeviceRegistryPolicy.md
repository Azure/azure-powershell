---
external help file:
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/remove-azdeviceregistrypolicy
schema: 2.0.0
---

# Remove-AzDeviceRegistryPolicy

## SYNOPSIS
Delete a Policy

## SYNTAX

### Delete (Default)
```
Remove-AzDeviceRegistryPolicy -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzDeviceRegistryPolicy -InputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentityNamespace
```
Remove-AzDeviceRegistryPolicy -Name <String> -NamespaceInputObject <IDeviceRegistryIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Delete a Policy

## EXAMPLES

### Example 1: Remove a policy by name
```powershell
Remove-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group
```

Removes the specified policy from the namespace.
This operation is destructive and cannot be undone.
Devices using this policy will need to be reassigned to a different policy.

### Example 2: Remove a policy with confirmation prompt
```powershell
Remove-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm
```

```output
Confirm
Are you sure you want to remove the policy 'my-policy'?
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): Y
```

Removes the policy after prompting for user confirmation.

### Example 3: Remove a policy without confirmation
```powershell
Remove-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm:$false
```

Removes the policy without prompting for confirmation.
Useful for automation scenarios.

### Example 4: Remove a policy via identity object
```powershell
$policyIdentity = @{
    SubscriptionId = "xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
    CredentialName = "default"
    PolicyName = "my-policy-name"
}
Remove-AzDeviceRegistryPolicy -InputObject $policyIdentity -Confirm:$false
```

Removes a policy object using an identity object parameter.

### Example 5: Remove multiple policies using pipeline
```powershell
Get-AzDeviceRegistryPolicy -NamespaceName my-namespace -ResourceGroupName my-resource-group | Where-Object { $_.Tag.environment -eq "test" } | Remove-AzDeviceRegistryPolicy -Confirm:$false
```

Retrieves all policies with the "test" environment tag and removes them in bulk.

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

### -Name
The name of the Policy tracked resource.

```yaml
Type: System.String
Parameter Sets: Delete, DeleteViaIdentityNamespace
Aliases: PolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: DeleteViaIdentityNamespace
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

