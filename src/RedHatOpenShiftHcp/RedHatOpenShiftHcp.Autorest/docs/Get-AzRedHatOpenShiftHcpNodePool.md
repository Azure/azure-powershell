---
external help file:
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/get-azredhatopenshifthcpnodepool
schema: 2.0.0
---

# Get-AzRedHatOpenShiftHcpNodePool

## SYNOPSIS
Get a NodePool

## SYNTAX

### List (Default)
```
Get-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRedHatOpenShiftHcpNodePool -InputObject <IRedHatOpenShiftHcpIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityHcpOpenShiftCluster
```
Get-AzRedHatOpenShiftHcpNodePool -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a NodePool

## EXAMPLES

### Example 1: List all node pools in a cluster
```powershell
Get-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster
```

```output
Name        Location ProvisioningState Replica PlatformVMSize   OSDiskSizeGiB VersionId
----        -------- ----------------- ------- --------------   ------------- ---------
mynodepool  eastus   Succeeded         2       Standard_D8s_v3  128           4.22.18
worker-pool eastus   Succeeded         3       Standard_D8s_v3  64            4.22.18
```

Lists all node pools belonging to cluster `myCluster`.

### Example 2: Get a single node pool by name
```powershell
Get-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool
```

```output
Name        Location ProvisioningState Replica PlatformVMSize   OSDiskSizeGiB OSDiskStorageAccountType VersionId
----        -------- ----------------- ------- --------------   ------------- ------------------------ ---------
mynodepool  eastus   Succeeded         2       Standard_D8s_v3  128           StandardSSD_LRS          4.22.18
```

Retrieves the single node pool `mynodepool`.
The osDisk/platform properties are flattened on the returned `INodePool` object (`OSDiskSizeGiB`, `PlatformVMSize`, `Replica`), not the nested API shape `.Platform.OSDisk.*`.

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

### -HcpOpenShiftClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: GetViaIdentityHcpOpenShiftCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HcpOpenShiftClusterName
The name of the HcpOpenShiftCluster

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
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
Parameter Sets: Get, GetViaIdentityHcpOpenShiftCluster
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.INodePool

## NOTES

## RELATED LINKS

