---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/get-azvmwareaddon
schema: 2.0.0
---

# Get-AzVMwareAddon

## SYNOPSIS
Get an addon by name in a private cloud

## SYNTAX

### List (Default)
```
Get-AzVMwareAddon -PrivateCloudName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzVMwareAddon -PrivateCloudName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -AddonType <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareAddon -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get an addon by name in a private cloud

## EXAMPLES

### Example 1: List addon under resource group
```powershell
Get-AzVMwareAddon -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name Type                               ResourceGroupName
---- ----                               -----------------
srm  Microsoft.AVS/privateClouds/addons azps_test_group
vr   Microsoft.AVS/privateClouds/addons azps_test_group
```

List addon under resource group

### Example 2: Get an addon by name in a private cloud
```powershell
Get-AzVMwareAddon -AddonType vr -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name Type                               ResourceGroupName
---- ----                               -----------------
vr   Microsoft.AVS/privateClouds/addons azps_test_group
```

Get an addon by name in a private cloud

## PARAMETERS

### -AddonType
Nameoftheaddonfortheprivatecloud

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AddonName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
Thecredentials,account,tenant,andsubscriptionusedforcommunicationwithAzure.

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
IdentityParameterToconstruct,seeNOTESsectionforINPUTOBJECTpropertiesandcreateahashtable.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IAddon

## NOTES

## RELATED LINKS
