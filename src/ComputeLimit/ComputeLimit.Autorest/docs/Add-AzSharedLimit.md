---
external help file:
Module Name: Az.ComputeLimit
online version: https://learn.microsoft.com/powershell/module/az.computelimit/add-azsharedlimit
schema: 2.0.0
---

# Add-AzSharedLimit

## SYNOPSIS
Enables sharing of a compute limit by the host subscription with its guest subscriptions.

## SYNTAX

### CreateExpanded (Default)
```
Add-AzSharedLimit -Location <String> -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
Add-AzSharedLimit -Location <String> -Name <String> -Resource <ISharedLimit> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
Add-AzSharedLimit -InputObject <IComputeLimitIdentity> -Resource <ISharedLimit> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
Add-AzSharedLimit -InputObject <IComputeLimitIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityLocation
```
Add-AzSharedLimit -LocationInputObject <IComputeLimitIdentity> -Name <String> -Resource <ISharedLimit>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityLocationExpanded
```
Add-AzSharedLimit -LocationInputObject <IComputeLimitIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Enables sharing of a compute limit by the host subscription with its guest subscriptions.

## EXAMPLES

### Example 1: Enable sharing of a compute limit
```powershell
Add-AzSharedLimit -Location "eastus" -Name "mySharedLimit"
```

```output
Name          Location ProvisioningState
----          -------- -----------------
mySharedLimit eastus   Succeeded
```

Enables sharing of a compute limit by the host subscription with its guest subscriptions in the specified location.

### Example 2: Enable sharing of a compute limit in a different region
```powershell
Add-AzSharedLimit -Location "westeurope" -Name "standardDSv3Family"
```

```output
Name               Location   ProvisioningState
----               --------   -----------------
standardDSv3Family westeurope Succeeded
```

Enables sharing of the Standard DSv3 Family compute limit in the West Europe region.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.IComputeLimitIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateViaIdentityLocation, CreateViaIdentityLocationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the SharedLimit

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaIdentityLocation, CreateViaIdentityLocationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Compute limits shared by the subscription.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.ISharedLimit
Parameter Sets: Create, CreateViaIdentity, CreateViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.ISharedLimit

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.ISharedLimit

## NOTES

## RELATED LINKS

