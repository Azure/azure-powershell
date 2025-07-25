---
external help file:
Module Name: Az.Mdp
online version: https://learn.microsoft.com/powershell/module/az.mdp/get-azmdppool
schema: 2.0.0
---

# Get-AzMdpPool

## SYNOPSIS
Get a Pool

## SYNTAX

### List (Default)
```
Get-AzMdpPool [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMdpPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMdpPool -InputObject <IMdpIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzMdpPool -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Pool

## EXAMPLES

### Example 1: List pools in a subscription
```powershell
Get-AzMdpPool
```

This command lists the Managed DevOps Pools in the current subscription.

### Example 2: List pools in a resource group
```powershell
Get-AzMdpPool -ResourceGroupName testRg
```

This command lists the Managed DevOps Pools under the resource group "testRg".

### Example 3: Get a pool
```powershell
Get-AzMdpPool -ResourceGroupName testRg -Name Contoso
```

This command gets the Managed DevOps Pool named "Contoso" under the resource group "testRg".

### Example 4: Get a pool using InputObject
```powershell
$pool = @{"ResourceGroupName" = "testRg"; "PoolName" = "Contoso"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzMdpPool -InputObject $pool
```

This command gets the Managed DevOps Pool named "Contoso" under the resource group "testRg".

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IMdpIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the pool.
It needs to be globally unique.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PoolName

Required: True
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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IMdpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IPool

## NOTES

## RELATED LINKS

