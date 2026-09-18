---
external help file: Az.ComputeLimit-help.xml
Module Name: Az.ComputeLimit
online version: https://learn.microsoft.com/powershell/module/az.computelimit/get-azguestsubscription
schema: 2.0.0
---

# Get-AzGuestSubscription

## SYNOPSIS
Gets the properties of a guest subscription.

## SYNTAX

### List (Default)
```
Get-AzGuestSubscription -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzGuestSubscription -Id <String> -LocationInputObject <IComputeLimitIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzGuestSubscription -Id <String> -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzGuestSubscription -InputObject <IComputeLimitIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of a guest subscription.

## EXAMPLES

### Example 1: List all guest subscriptions for a shared limit
```powershell
Get-AzGuestSubscription -Location "eastus"
```

```output
Name                                 Location ProvisioningState
----                                 -------- -----------------
00000000-0000-0000-0000-000000000001 eastus   Succeeded
```

Lists all guest subscriptions consuming shared compute limits in the specified location.

### Example 2: Get a specific guest subscription
```powershell
Get-AzGuestSubscription -Location "eastus" -Id "00000000-0000-0000-0000-000000000001"
```

```output
Name                                 Location ProvisioningState
----                                 -------- -----------------
00000000-0000-0000-0000-000000000001 eastus   Succeeded
```

Gets the properties of a specific guest subscription by ID.

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
Parameter Sets: GetViaIdentityLocation, Get
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
Parameter Sets: GetViaIdentity
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
Parameter Sets: List, Get
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
Parameter Sets: GetViaIdentityLocation
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
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.IComputeLimitIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.IGuestSubscription

## NOTES

## RELATED LINKS
