---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/update-azvmwareprivatecloud
schema: 2.0.0
---

# Update-AzVMwarePrivateCloud

## SYNOPSIS
Update a private cloud

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzVMwarePrivateCloud -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EncryptionStatus <String>] [-ExtendedNetworkBlock <String[]>] [-IdentitySource <IIdentitySource[]>]
 [-IdentityType <String>] [-Internet <String>] [-KeyVaultPropertyKeyName <String>]
 [-KeyVaultPropertyKeyVaultUrl <String>] [-KeyVaultPropertyKeyVersion <String>]
 [-ManagementClusterHost <String[]>] [-ManagementClusterSize <Int32>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzVMwarePrivateCloud -InputObject <IVMwareIdentity> [-EncryptionStatus <String>]
 [-ExtendedNetworkBlock <String[]>] [-IdentitySource <IIdentitySource[]>] [-IdentityType <String>]
 [-Internet <String>] [-KeyVaultPropertyKeyName <String>] [-KeyVaultPropertyKeyVaultUrl <String>]
 [-KeyVaultPropertyKeyVersion <String>] [-ManagementClusterHost <String[]>] [-ManagementClusterSize <Int32>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a private cloud

## EXAMPLES

### Example 1: Update size of private cloud by name
```powershell
Update-AzVMwarePrivateCloud -Name azps_test_cloud -ResourceGroupName azps_test_group -ManagementClusterSize 4
```

```output
Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

Update size of private cloud by name

### Example 2: Update size of private cloud
```powershell
Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud | Update-AzVMwarePrivateCloud -ManagementClusterSize 4
```

```output
Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

Update size of private cloud

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### -EncryptionStatus
Status of customer managed encryption key

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedNetworkBlock
Array of additional networks noncontiguous with networkBlock.
Networks must be unique and non-overlapping across VNet in your subscription, on-premise, and this privateCloud networkBlock attribute.
Make sure the CIDR format conforms to (A.B.C.D/X).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentitySource
vCenter Single Sign On Identity Sources

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IIdentitySource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of identity used for the private cloud.
The type 'SystemAssigned' refers to an implicitly created identity.
The type 'None' will remove any identities from the Private Cloud.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Internet
Connectivity to internet is enabled or disabled

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyName
The name of the key.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyVaultUrl
The URL of the vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyVersion
The version of the key.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementClusterHost
The hosts

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementClusterSize
The cluster size

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the private cloud

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: PrivateCloudName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IPrivateCloud

## NOTES

## RELATED LINKS
