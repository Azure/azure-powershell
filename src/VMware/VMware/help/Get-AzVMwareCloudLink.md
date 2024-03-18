---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/get-azvmwarecloudlink
schema: 2.0.0
---

# Get-AzVMwareCloudLink

## SYNOPSIS
Get an cloud link by name in a private cloud

## SYNTAX

### List (Default)
```
Get-AzVMwareCloudLink -PrivateCloudName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityPrivateCloud
```
Get-AzVMwareCloudLink -Name <String> -PrivateCloudInputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzVMwareCloudLink -Name <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareCloudLink -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get an cloud link by name in a private cloud

## EXAMPLES

### Example 1: List cloud link under resource group
```powershell
Get-AzVMwareCloudLink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name                Type                                   ResourceGroupName
----                ----                                   -----------------
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks azps_test_group
```

List cloud link under resource group

### Example 2: Get cloud link by name in a private cloud
```powershell
Get-AzVMwareCloudLink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_cloudlink
```

```output
Name                Type                                   ResourceGroupName
----                ----                                   -----------------
azps_test_cloudlink Microsoft.AVS/privateClouds/cloudLinks azps_test_group
```

Get cloud link by name in a private cloud

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
Name of the cloud link resource

```yaml
Type: System.String
Parameter Sets: GetViaIdentityPrivateCloud, Get
Aliases: CloudLinkName

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.ICloudLink

## NOTES

## RELATED LINKS
