---
external help file:
Module Name: Az.FileShare
online version: https://learn.microsoft.com/powershell/module/az.fileshare/new-azfileshare
schema: 2.0.0
---

# New-AzFileShare

## SYNOPSIS
Create a file share.

## SYNTAX

### CreateExpanded (Default)
```
New-AzFileShare -ResourceGroupName <String> -ResourceName <String> -Location <String>
 [-SubscriptionId <String>] [-MediaTier <String>] [-MountName <String>]
 [-NfProtocolPropertyRootSquash <String>] [-Protocol <String>] [-ProvisionedIoPerSec <Int32>]
 [-ProvisionedStorageGiB <Int32>] [-ProvisionedThroughputMiBPerSec <Int32>]
 [-PublicAccessPropertyAllowedSubnet <String[]>] [-PublicNetworkAccess <String>] [-Redundancy <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFileShare -ResourceGroupName <String> -ResourceName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFileShare -ResourceGroupName <String> -ResourceName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a file share.

## EXAMPLES

### Example 1: Create a file share
```powershell
New-AzFileShare -ResourceName "testshare" -ResourceGroupName "myresourcegroup" -Location uaecentral -MediaTier SSD -NfProtocolPropertyRootSquash AllSquash -Protocol NFS -ProvisionedIoPerSec 5000 -ProvisionedStorageGiB 100 -ProvisionedThroughputMiBPerSec 125 -PublicAccessPropertyAllowedSubnet $vnet1,$vnet2 -Tag @{"tag1" = "value1"; "tag2" = "value2" }
```

```output
HostName                                  : fs-xxxxxxxxxxxxxxxxx.z41.file.storage.azure.net
Id                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.FileShares/fileShares/testshare
IncludedBurstIoPerSec                     : 15000
Location                                  : uaecentral
MaxBurstIoPerSecCredit                    : 36000000
MediaTier                                 : SSD
MountName                                 : testshare
Name                                      : testshare
NfProtocolPropertyRootSquash              : AllSquash
PrivateEndpointConnection                 : {}
Protocol                                  : NFS
ProvisionedIoPerSec                       : 5000
ProvisionedIoPerSecNextAllowedDowngrade   : 2/26/2026 6:56:35 AM
ProvisionedStorageGiB                     : 100
ProvisionedStorageNextAllowedDowngrade    : 2/26/2026 6:56:35 AM
ProvisionedThroughputMiBPerSec            : 125
ProvisionedThroughputNextAllowedDowngrade : 2/26/2026 6:56:35 AM
ProvisioningState                         : Succeeded
PublicAccessPropertyAllowedSubnet         : {/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1,
                                            /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet2}
PublicNetworkAccess                       : Enabled
Redundancy                                : Local
ResourceGroupName                         : myresourcegroup
SystemDataCreatedAt                       :
SystemDataCreatedBy                       :
SystemDataCreatedByType                   :
SystemDataLastModifiedAt                  : 2/25/2026 6:51:08 AM
SystemDataLastModifiedBy                  : username@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                              "tag2": "value2",
                                              "tag1": "value1"
                                            }
Type                                      : Microsoft.FileShares/fileShares
```

This command creates a file share.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MediaTier
The storage media tier of the file share.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MountName
The name of the file share as seen by the end user when mounting the share, such as in a URI or UNC format in their operating system.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NfProtocolPropertyRootSquash
Root squash defines how root users on clients are mapped to the NFS share.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -Protocol
The file sharing protocol for this file share.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Redundancy
The chosen redundancy level of the file share.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShare

## NOTES

## RELATED LINKS

