---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/get-azvmwarehost
schema: 2.0.0
---

# Get-AzVMwareHost

## SYNOPSIS
Get a Host

## SYNTAX

### List (Default)
```
Get-AzVMwareHost -ClusterName <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityPrivateCloud
```
Get-AzVMwareHost -ClusterName <String> -Id <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzVMwareHost -ClusterName <String> -Id <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzVMwareHost -Id <String> -ClusterInputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareHost -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Host

## EXAMPLES

### Example 1: List all hosts in a cluster
```powershell
Get-AzVMwareHost -ClusterName azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name                                                       Type                                       SkuName ResourceGroupName Kind          Maintenance
----                                                       ----                                       ------- ----------------- ------------- -----------
esx03-r52.1111111111111111111.westcentralus.prod.azure.com Microsoft.AVS/privateClouds/clusters/hosts av64    azps_test_group    General
esx03-r60.1111111111111111111.westcentralus.prod.azure.com Microsoft.AVS/privateClouds/clusters/hosts av64    azps_test_group    General      Replacement
esx03-r65.1111111111111111111.westcentralus.prod.azure.com Microsoft.AVS/privateClouds/clusters/hosts         azps_test_group    Specialized
```

Lists all hosts in the specified cluster within the private cloud and resource group.

### Example 2: Get a host by ID in a cluster
```powershell
Get-AzVMwareHost -ClusterName azps_test_cluster -Id esx03-r52.1111111111111111111.westcentralus.prod.azure.com -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name                                                       Type                                       ResourceGroupName SkuName Kind
----                                                       ----                                       ----------------- ------- ----
esx03-r52.1111111111111111111.westcentralus.prod.azure.com Microsoft.AVS/privateClouds/clusters/hosts azps_test_group   av64    General
```

Gets a specific host by its ID in the specified cluster, private cloud, and resource group.

## PARAMETERS

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
Name of the cluster

```yaml
Type: System.String
Parameter Sets: List, GetViaIdentityPrivateCloud, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
The host identifier.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityPrivateCloud, Get, GetViaIdentityCluster
Aliases: HostId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateCloudInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentityPrivateCloud
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateCloudName
Name of the private cloud

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IHost

## NOTES

## RELATED LINKS
