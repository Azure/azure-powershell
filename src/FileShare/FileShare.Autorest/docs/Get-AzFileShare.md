---
external help file:
Module Name: Az.FileShare
online version: https://learn.microsoft.com/powershell/module/az.fileshare/get-azfileshare
schema: 2.0.0
---

# Get-AzFileShare

## SYNOPSIS
Get a FileShare

## SYNTAX

### List (Default)
```
Get-AzFileShare [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFileShare -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFileShare -InputObject <IFileShareIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzFileShare -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a FileShare

## EXAMPLES

### Example 1: Get a file share
```powershell
Get-AzFileShare -ResourceName "testshare" -ResourceGroupName "myresourcegroup"

```

```output
HostName                                  : fs-xxxxxxxxxxxxxxxxx.z41.file.storage.azure.net
Id                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.FileShares/fileShares/testshare
IncludedBurstIoPerSec                     : 15000
Location                                  : eastus2euap
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

This command gets a file share properties.

### Example 2: List file shares in a resource group and format the output
```powershell
Get-AzFileShare -ResourceGroupName $resourceGroup | ft Name,Location,Protocol,ProvisionedStorageGiB,MediaTier
```

```output
Name       Location    Protocol ProvisionedStorageGiB MediaTier
----       --------    -------- --------------------- ---------
testshare1 eastus2euap NFS                        100 SSD
testshare2 uaecentral  NFS                         50 SSD
```

This command lists all file shares in a resource group and format the output to a table with selected properties.

### Example 3: List file shares in the current subscription
```powershell
Get-AzFileShare
```

```output
Location    Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------    ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus2euap testshare1 8/7/2025 3:36:39 AM  user11@microsoft.com   User                  8/7/2025 3:36:39 AM      user11@microsoft.com     User                         myresourcegroup
uaecentral  testshare2 2/26/2026 8:13:58 AM user11@microsoft.com   User                  2/26/2026 8:13:58 AM     user11@microsoft.com     User                         myresourcegroup
eastus2euap testshare3 5/14/2025 9:24:49 AM user11@microsoft.com   User                  5/14/2025 9:24:49 AM     user11@microsoft.com     User                         resourcegroup2
```

This command lists all file shares in the current subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ResourceName
The resource name of the file share, as seen by the administrator through Azure Resource Manager.

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShare

## NOTES

## RELATED LINKS

