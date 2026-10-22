---
external help file: Az.RedHatOpenShiftHcp-help.xml
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/get-azredhatopenshifthcpcluster
schema: 2.0.0
---

# Get-AzRedHatOpenShiftHcpCluster

## SYNOPSIS
Get a HcpOpenShiftCluster

## SYNTAX

### List (Default)
```
Get-AzRedHatOpenShiftHcpCluster [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzRedHatOpenShiftHcpCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzRedHatOpenShiftHcpCluster -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRedHatOpenShiftHcpCluster -InputObject <IRedHatOpenShiftHcpIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a HcpOpenShiftCluster

## EXAMPLES

### Example 1: List clusters in a resource group
```powershell
Get-AzRedHatOpenShiftHcpCluster -ResourceGroupName myResourceGroup
```

```output
Name       Location   ResourceGroupName  VersionId ProvisioningState ApiUrl
----       --------   -----------------  --------- ----------------- ------
myCluster  westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster.32z5.westeurope.aroapp-hcp.io:443
myCluster2 westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster2.4k8p.westeurope.aroapp-hcp.io:443
```

Lists all ARO-HCP clusters in the specified resource group.
Omit `-ResourceGroupName` to list every cluster in the subscription.

### Example 2: Get a single cluster by name
```powershell
Get-AzRedHatOpenShiftHcpCluster -ResourceGroupName myResourceGroup -Name myCluster
```

```output
Name      Location   ResourceGroupName  VersionId ProvisioningState ApiUrl
----      --------   -----------------  --------- ----------------- ------
myCluster westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster.32z5.westeurope.aroapp-hcp.io:443
```

Gets a single ARO-HCP cluster by resource group and name.
The returned object exposes flattened properties such as `ProvisioningState`, `VersionId`, `NetworkType`, and the operator-identity maps under `UserAssignedIdentityControlPlaneOperator` / `UserAssignedIdentityDataPlaneOperator`.

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
The name of the HcpOpenShiftCluster

```yaml
Type: System.String
Parameter Sets: Get
Aliases: HcpOpenShiftClusterName

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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster

## NOTES

## RELATED LINKS
