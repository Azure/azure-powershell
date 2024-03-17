---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/get-azvmwaredatastore
schema: 2.0.0
---

# Get-AzVMwareDatastore

## SYNOPSIS
Get a datastore in a private cloud cluster

## SYNTAX

### List (Default)
```
Get-AzVMwareDatastore -ClusterName <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentityPrivateCloud
```
Get-AzVMwareDatastore -ClusterName <String> -Name <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzVMwareDatastore -ClusterName <String> -Name <String> -PrivateCloudName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzVMwareDatastore -Name <String> -ClusterInputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareDatastore -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a datastore in a private cloud cluster

## EXAMPLES

### Example 1: List datastores in a private cloud cluster.
```powershell
Get-AzVMwareDatastore -ClusterName azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name                 Status     ProvisioningState ResourceGroupName
----                 ------     ----------------- -----------------
azps_test_datastore  Accessible Succeeded         azps_test_group
azps_test_datastore1 Accessible Succeeded         azps_test_group
```

List datastores in a private cloud cluster.

### Example 2: Get a datastore in a data store name.
```powershell
Get-AzVMwareDatastore -ClusterName azps_test_cluster -Name azps_test_datastore -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name                Status     ProvisioningState ResourceGroupName
----                ------     ----------------- -----------------
azps_test_datastore Accessible Succeeded         azps_test_group
```

Get a datastore in a data store name.

## PARAMETERS

### -ClusterInputObject
IdentityParameter

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
Nameoftheclusterintheprivatecloud

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
TheDefaultProfileparameterisnotfunctional.UsetheSubscriptionIdparameterwhenavailableifexecutingthecmdletagainstadifferentsubscription.

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
IdentityParameter

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

### -Name
Nameofthedatastoreintheprivatecloudcluster

```yaml
Type: System.String
Parameter Sets: GetViaIdentityPrivateCloud, Get, GetViaIdentityCluster
Aliases: DatastoreName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateCloudInputObject
IdentityParameter

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
Nameoftheprivatecloud

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Thenameoftheresourcegroup.Thenameiscaseinsensitive.

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
TheIDofthetargetsubscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IDatastore

## NOTES

## RELATED LINKS
