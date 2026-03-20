---
external help file: Az.ComputeLimit-help.xml
Module Name: Az.ComputeLimit
online version: https://learn.microsoft.com/powershell/module/az.computelimit/add-azguestsubscription
schema: 2.0.0
---

# Add-AzGuestSubscription

## SYNOPSIS
Adds a subscription as a guest to consume the compute limits shared by the host subscription.

## SYNTAX

### CreateExpanded (Default)
```
Add-AzGuestSubscription -Id <String> -Location <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityLocationExpanded
```
Add-AzGuestSubscription -Id <String> -LocationInputObject <IComputeLimitIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityLocation
```
Add-AzGuestSubscription -Id <String> -LocationInputObject <IComputeLimitIdentity>
 -Resource <IGuestSubscription> [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Create
```
Add-AzGuestSubscription -Id <String> -Location <String> [-SubscriptionId <String>]
 -Resource <IGuestSubscription> [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
Add-AzGuestSubscription -InputObject <IComputeLimitIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
Add-AzGuestSubscription -InputObject <IComputeLimitIdentity> -Resource <IGuestSubscription>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Adds a subscription as a guest to consume the compute limits shared by the host subscription.

## EXAMPLES

### Example 1: Add a guest subscription to consume a shared limit
```powershell
Add-AzGuestSubscription -Location "eastus" -Id "00000000-0000-0000-0000-000000000001"
```

```output
Name                                 Location ProvisioningState
----                                 -------- -----------------
00000000-0000-0000-0000-000000000001 eastus   Succeeded
```

Adds a subscription as a guest to consume the compute limits shared by the host subscription.

### Example 2: Add a guest subscription in a different region with an explicit subscription
```powershell
Add-AzGuestSubscription -Location "westus2" -Id "00000000-0000-0000-0000-000000000002" -SubscriptionId "00000000-0000-0000-0000-000000000099"
```

```output
Name                                 Location ProvisioningState
----                                 -------- -----------------
00000000-0000-0000-0000-000000000002 westus2  Succeeded
```

Adds a guest subscription in the West US 2 region, explicitly specifying the host subscription ID.

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
Parameter Sets: CreateExpanded, CreateViaIdentityLocationExpanded, CreateViaIdentityLocation, Create
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
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
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
Parameter Sets: CreateExpanded, Create
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
Parameter Sets: CreateViaIdentityLocationExpanded, CreateViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Resource
Guest subscription that consumes shared compute limits.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.IGuestSubscription
Parameter Sets: CreateViaIdentityLocation, Create, CreateViaIdentity
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
Parameter Sets: CreateExpanded, Create
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.IGuestSubscription

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.IGuestSubscription

## NOTES

## RELATED LINKS
