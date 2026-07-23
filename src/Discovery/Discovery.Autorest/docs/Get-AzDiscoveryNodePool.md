---
external help file:
Module Name: Az.Discovery
online version: https://learn.microsoft.com/powershell/module/az.discovery/get-azdiscoverynodepool
schema: 2.0.0
---

# Get-AzDiscoveryNodePool

## SYNOPSIS
Get a NodePool

## SYNTAX

### List (Default)
```
Get-AzDiscoveryNodePool -ResourceGroupName <String> -SupercomputerName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDiscoveryNodePool -Name <String> -ResourceGroupName <String> -SupercomputerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDiscoveryNodePool -InputObject <IDiscoveryIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySupercomputer
```
Get-AzDiscoveryNodePool -Name <String> -SupercomputerInputObject <IDiscoveryIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a NodePool

## EXAMPLES

### Example 1: List all node pools for a supercomputer
```powershell
Get-AzDiscoveryNodePool -ResourceGroupName "my-rg" -SupercomputerName "my-supercomputer"
```

```output
Location    Name        ResourceGroupName
--------    ----        -----------------
eastus      my-pool     my-rg
```

Lists all node pools under the specified supercomputer.

### Example 2: Get a specific node pool
```powershell
Get-AzDiscoveryNodePool -ResourceGroupName "my-rg" -SupercomputerName "my-supercomputer" -Name "my-pool"
```

```output
Location    Name        ResourceGroupName    ProvisioningState
--------    ----        -----------------    -----------------
eastus      my-pool     my-rg                Succeeded
```

Gets a specific node pool by name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the NodePool

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySupercomputer
Aliases: NodePoolName

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
Parameter Sets: Get, List
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

### -SupercomputerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity
Parameter Sets: GetViaIdentitySupercomputer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SupercomputerName
The name of the Supercomputer

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePool

## NOTES

## RELATED LINKS

