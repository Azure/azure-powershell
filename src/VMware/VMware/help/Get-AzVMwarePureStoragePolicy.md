---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/get-azvmwarepurestoragepolicy
schema: 2.0.0
---

# Get-AzVMwarePureStoragePolicy

## SYNOPSIS
Get a PureStoragePolicy

## SYNTAX

### List (Default)
```
Get-AzVMwarePureStoragePolicy -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzVMwarePureStoragePolicy -PrivateCloudName <String> -ResourceGroupName <String>
 -StoragePolicyName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityPrivateCloud
```
Get-AzVMwarePureStoragePolicy -StoragePolicyName <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwarePureStoragePolicy -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a PureStoragePolicy

## EXAMPLES

### Example 1: List all Pure Storage policies in a private cloud
```powershell
Get-AzVMwarePureStoragePolicy -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name             Type                                           ResourceGroupName ProvisioningState StoragePolicyDefinition
----             ----                                           ----------------- ----------------- ----------------------
azps_test_policy Microsoft.AVS/privateClouds/pureStoragePolicies azps_test_group   Succeeded         azps_test_policy_definition
```

Lists all Pure Storage policies in the specified private cloud and resource group.

### Example 2: Get a Pure Storage policy by name
```powershell
Get-AzVMwarePureStoragePolicy -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -StoragePolicyName azps_test_policy
```

```output
Name             Type                                           ResourceGroupName ProvisioningState StoragePolicyDefinition
----             ----                                           ----------------- ----------------- ----------------------
azps_test_policy Microsoft.AVS/privateClouds/pureStoragePolicies azps_test_group   Succeeded         azps_test_policy_definition
```

Gets a specific Pure Storage policy by name in the specified private cloud and resource group.

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

### -StoragePolicyName
Name of the storage policy.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityPrivateCloud
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IPureStoragePolicy

## NOTES

## RELATED LINKS
