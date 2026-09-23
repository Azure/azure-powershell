---
external help file:
Module Name: Az.ComputeLimit
online version: https://learn.microsoft.com/powershell/module/az.computelimit/get-azsharedlimit
schema: 2.0.0
---

# Get-AzSharedLimit

## SYNOPSIS
Gets the properties of a compute limit shared by the host subscription with its guest subscriptions.

## SYNTAX

### List (Default)
```
Get-AzSharedLimit -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSharedLimit -Location <String> -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSharedLimit -InputObject <IComputeLimitIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzSharedLimit -LocationInputObject <IComputeLimitIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of a compute limit shared by the host subscription with its guest subscriptions.

## EXAMPLES

### Example 1: List all shared limits in a location
```powershell
Get-AzSharedLimit -Location "eastus"
```

```output
Name          Location ProvisioningState
----          -------- -----------------
mySharedLimit eastus   Succeeded
```

Lists all compute limits shared by the host subscription in the East US region.

### Example 2: Get a specific shared limit by name
```powershell
Get-AzSharedLimit -Location "eastus" -Name "mySharedLimit"
```

```output
Name          Location ProvisioningState
----          -------- -----------------
mySharedLimit eastus   Succeeded
```

Gets the properties of a specific shared limit by name and location.

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
Parameter Sets: Get, List
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

### -Name
The name of the SharedLimit

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeLimit.Models.ISharedLimit

## NOTES

## RELATED LINKS

