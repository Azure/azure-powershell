---
external help file: Az.FileShare-help.xml
Module Name: Az.FileShare
online version: https://learn.microsoft.com/powershell/module/az.fileshare/update-azfileshare
schema: 2.0.0
---

# Update-AzFileShare

## SYNOPSIS
Update a FileShare

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFileShare -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String>]
 [-NfProtocolPropertyRootSquash <String>] [-ProvisionedIoPerSec <Int32>] [-ProvisionedStorageGiB <Int32>]
 [-ProvisionedThroughputMiBPerSec <Int32>] [-PublicAccessPropertyAllowedSubnet <String[]>]
 [-PublicNetworkAccess <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzFileShare -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzFileShare -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFileShare -InputObject <IFileShareIdentity> [-NfProtocolPropertyRootSquash <String>]
 [-ProvisionedIoPerSec <Int32>] [-ProvisionedStorageGiB <Int32>] [-ProvisionedThroughputMiBPerSec <Int32>]
 [-PublicAccessPropertyAllowedSubnet <String[]>] [-PublicNetworkAccess <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a FileShare

## EXAMPLES

### Example 1: Update a file share
```powershell
Update-AzFileShare -ResourceName "testshare" -ResourceGroupName "myresourcegroup" -NfProtocolPropertyRootSquash RootSquash -ProvisionedIoPerSec 5001 -ProvisionedStorageGiB 101 -ProvisionedThroughputMiBPerSec 126 -PublicNetworkAccess Disabled -Tag @{tag1="value1"} -PublicAccessPropertyAllowedSubnet $vnet1
```

```output
HostName                                  : fs-xxxxxxxxxxxxxxxxx.z41.file.storage.azure.net
Id                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.FileShares/fileShares/testshare
IncludedBurstIoPerSec                     : 15000
Location                                  : uaecentral
MaxBurstIoPerSecCredit                    : 36007200
MediaTier                                 : SSD
MountName                                 : testshare
Name                                      : testshare
NfProtocolPropertyRootSquash              : RootSquash
PrivateEndpointConnection                 :
Protocol                                  : NFS
ProvisionedIoPerSec                       : 5001
ProvisionedIoPerSecNextAllowedDowngrade   : 2/27/2026 8:38:36 AM
ProvisionedStorageGiB                     : 101
ProvisionedStorageNextAllowedDowngrade    : 2/27/2026 8:38:36 AM
ProvisionedThroughputMiBPerSec            : 126
ProvisionedThroughputNextAllowedDowngrade : 2/27/2026 8:38:36 AM
ProvisioningState                         : Succeeded
PublicAccessPropertyAllowedSubnet         : {/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1}
PublicNetworkAccess                       : Disabled
Redundancy                                : Local
ResourceGroupName                         : myresourcegroup
SystemDataCreatedAt                       :
SystemDataCreatedBy                       :
SystemDataCreatedByType                   :
SystemDataLastModifiedAt                  : 2/25/2026 6:51:08 AM
SystemDataLastModifiedBy                  : username@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                              "tag1": "value1"
                                            }
Type                                      : Microsoft.FileShares/fileShares
```

This command updates a file share.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NfProtocolPropertyRootSquash
Root squash defines how root users on clients are mapped to the NFS share.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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

### -ProvisionedIoPerSec
The provisioned IO / sec of the share.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisionedStorageGiB
The provisioned storage size of the share in GiB (1 GiB is 1024^3 bytes or 1073741824 bytes).
A component of the file share's bill is the provisioned storage, regardless of the amount of used storage.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisionedThroughputMiBPerSec
The provisioned throughput / sec of the share.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicAccessPropertyAllowedSubnet
The allowed set of subnets when access is restricted.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
Gets or sets allow or disallow public network access to azure managed file share

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The resource name of the file share, as seen by the administrator through Azure Resource Manager.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShare

## NOTES

## RELATED LINKS
