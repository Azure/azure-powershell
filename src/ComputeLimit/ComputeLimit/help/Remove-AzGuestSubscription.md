---
external help file: Az.ComputeLimit-help.xml
Module Name: Az.ComputeLimit
online version: https://learn.microsoft.com/powershell/module/az.computelimit/remove-azguestsubscription
schema: 2.0.0
---

# Remove-AzGuestSubscription

## SYNOPSIS
Deletes a subscription as a guest to stop consuming the compute limits shared by the host subscription.

## SYNTAX

### Delete (Default)
```
Remove-AzGuestSubscription -Id <String> -Location <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeleteViaIdentityLocation
```
Remove-AzGuestSubscription -Id <String> -LocationInputObject <IComputeLimitIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzGuestSubscription -InputObject <IComputeLimitIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes a subscription as a guest to stop consuming the compute limits shared by the host subscription.

## EXAMPLES

### Example 1: Remove a guest subscription
```powershell
Remove-AzGuestSubscription -Location "eastus" -Id "00000000-0000-0000-0000-000000000001"
```

Removes a subscription as a guest to stop consuming the compute limits shared by the host subscription.

### Example 2: Remove a guest subscription with PassThru
```powershell
Remove-AzGuestSubscription -Location "eastus" -Id "00000000-0000-0000-0000-000000000001" -PassThru -Confirm:$false
```

```output
True
```

Removes the guest subscription and returns True when PassThru is specified.

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

### -Id
The name of the GuestSubscription

```yaml
Type: System.String
Parameter Sets: Delete, DeleteViaIdentityLocation
Aliases: GuestSubscriptionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.IComputeLimitIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

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

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.IComputeLimitIdentity
Parameter Sets: DeleteViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.IComputeLimitIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
