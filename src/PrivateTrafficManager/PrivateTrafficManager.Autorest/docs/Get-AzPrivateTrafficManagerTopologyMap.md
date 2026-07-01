---
external help file:
Module Name: Az.PrivateTrafficManager
online version: https://learn.microsoft.com/powershell/module/az.privatetrafficmanager/get-azprivatetrafficmanagertopologymap
schema: 2.0.0
---

# Get-AzPrivateTrafficManagerTopologyMap

## SYNOPSIS
Gets a Topology Map.

## SYNTAX

### List (Default)
```
Get-AzPrivateTrafficManagerTopologyMap [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPrivateTrafficManagerTopologyMap -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPrivateTrafficManagerTopologyMap -InputObject <IPrivateTrafficManagerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPrivateTrafficManagerTopologyMap -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a Topology Map.

## EXAMPLES

### Example 1: Get a specific topology map
```powershell
Get-AzPrivateTrafficManagerTopologyMap -Name "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo"
```

```output
Name               Location CatchAllSiteName ProvisioningState
----               -------- ---------------- -----------------
ptm-topology-demo  global   site-default     Succeeded
```

This command gets the specified topology map by name and resource group.

### Example 2: List all topology maps in a resource group
```powershell
Get-AzPrivateTrafficManagerTopologyMap -ResourceGroupName "rg-ptm-demo"
```

```output
Name               Location CatchAllSiteName ProvisioningState
----               -------- ---------------- -----------------
ptm-topology-demo  global   site-default     Succeeded
ptm-topology-prod  global   site-default     Succeeded
```

This command lists all topology maps in the specified resource group.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Topology Map.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: TopologyMapName

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

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.ITopologyMap

## NOTES

## RELATED LINKS

