---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/get-azvmwareprovisionednetwork
schema: 2.0.0
---

# Get-AzVMwareProvisionedNetwork

## SYNOPSIS
Get a ProvisionedNetwork

## SYNTAX

### List (Default)
```
Get-AzVMwareProvisionedNetwork -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityPrivateCloud
```
Get-AzVMwareProvisionedNetwork -Name <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzVMwareProvisionedNetwork -Name <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareProvisionedNetwork -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a ProvisionedNetwork

## EXAMPLES

### Example 1: List all provisioned networks in a private cloud
```powershell
Get-AzVMwareProvisionedNetwork -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name     Type                                            AddressPrefix   NetworkType ResourceGroupName
----     ----                                            -------------   ----------  -----------------
vsan     Microsoft.AVS/privateClouds/provisionedNetworks 10.0.2.128/25   vsan        azps_test_group
esxvmot  Microsoft.AVS/privateClouds/provisionedNetworks 10.0.1.128/25   esxvmot     azps_test_group
mgmtvnet Microsoft.AVS/privateClouds/provisionedNetworks 10.0.3.128/26   mgmtvnet    azps_test_group
```

Lists all provisioned networks in the specified private cloud and resource group.

### Example 2:  Get a provisioned network by name
```powershell
Get-AzVMwareProvisionedNetwork -Name vsan -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name     Type                                            AddressPrefix   NetworkType ResourceGroupName
----     ----                                            -------------   ----------  -----------------
vsan     Microsoft.AVS/privateClouds/provisionedNetworks 10.0.2.128/25   vsan        azps_test_group
```

Gets a specific provisioned network by name in the specified private cloud and resource group

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

### -Name
Name of the cloud link.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityPrivateCloud, Get
Aliases: ProvisionedNetworkName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IProvisionedNetwork

## NOTES

## RELATED LINKS
