---
external help file:
Module Name: Az.PrivateTrafficManager
online version: https://learn.microsoft.com/powershell/module/az.privatetrafficmanager/get-azprivatetrafficmanagersite
schema: 2.0.0
---

# Get-AzPrivateTrafficManagerSite

## SYNOPSIS
Gets a Site.

## SYNTAX

### List (Default)
```
Get-AzPrivateTrafficManagerSite -ResourceGroupName <String> -TopologyMapName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPrivateTrafficManagerSite -Name <String> -ResourceGroupName <String> -TopologyMapName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPrivateTrafficManagerSite -InputObject <IPrivateTrafficManagerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityTopologyMap
```
Get-AzPrivateTrafficManagerSite -Name <String> -TopologyMapInputObject <IPrivateTrafficManagerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a Site.

## EXAMPLES

### Example 1: Get a specific site from a topology map
```powershell
Get-AzPrivateTrafficManagerSite -Name "site-eastus" -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo"
```

```output
Name         ProvisioningState
----         -----------------
site-eastus  Succeeded
```

This command gets the specified site from the topology map.

### Example 2: List all sites in a topology map
```powershell
Get-AzPrivateTrafficManagerSite -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo"
```

```output
Name         ProvisioningState
----         -----------------
site-eastus  Succeeded
site-westus  Succeeded
```

This command lists all sites configured in the specified topology map.

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
The name of the Site.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityTopologyMap
Aliases: SiteName

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

### -TopologyMapInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity
Parameter Sets: GetViaIdentityTopologyMap
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TopologyMapName
The name of the Topology Map.

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

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.ISite

## NOTES

## RELATED LINKS

