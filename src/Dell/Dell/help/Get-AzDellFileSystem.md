---
external help file: Az.Dell-help.xml
Module Name: Az.Dell
online version: https://learn.microsoft.com/powershell/module/az.dell/get-azdellfilesystem
schema: 2.0.0
---

# Get-AzDellFileSystem

## SYNOPSIS
Get a FileSystemResource

## SYNTAX

### List (Default)
```
Get-AzDellFileSystem [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDellFileSystem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDellFileSystem -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDellFileSystem -InputObject <IDellIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a FileSystemResource

## EXAMPLES

### Example 1: List all Dell filesystems in a subscription
```powershell
Get-AzDellFileSystem -SubscriptionId 834be33e-67e6-45ed-a454-c25a34cdec1f
```

```output
Location    Name          SystemDataCreatedAt   SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifi
                                                                                                   edAt
--------    ----          -------------------   -------------------        ----------------------- --------------------
eastus      wwwww         3/19/2026 10:32:42 AM dummy@example.com   User                    3/19/2026 10:32:42 …
eastus      test07072026  7/7/2026 2:00:48 PM   dummy@example.com   User                    7/7/2026 2:00:48 PM
eastus      Test210726    7/21/2026 4:57:37 AM  dummy@example.com   User                    7/21/2026 4:57:37 AM
eastus2euap test          4/27/2026 5:46:34 AM  dummy@example.com   User                    6/25/2026 8:58:30 AM
eastus2euap DhritiJindal  5/29/2026 8:56:43 AM  dummy@example.com User                    5/29/2026 9:01:43 AM
eastus2euap eee           6/9/2026 4:27:42 PM   dummy@example.com   User                    6/24/2026 3:32:35 PM
eastus2euap test1407      7/14/2026 11:00:32 AM dummy@example.com   User                    7/14/2026 11:00:32 …
eastus2euap test210726-01 7/21/2026 5:39:44 AM  dummy@example.com   User                    7/21/2026 5:39:44 AM
```

Lists all Dell filesystem resources in the specified subscription.

### Example 2: List Dell filesystems in a resource group
```powershell
Get-AzDellFileSystem -ResourceGroupName bhargavi-rg -SubscriptionId 834be33e-67e6-45ed-a454-c25a34cdec1f
```

```output
Location    Name          SystemDataCreatedAt   SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifi
                                                                                                   edAt
--------    ----          -------------------   -------------------        ----------------------- --------------------
eastus      test07072026  7/7/2026 2:00:48 PM   dummy@example.com   User                    7/7/2026 2:00:48 PM
eastus      Test210726    7/21/2026 4:57:37 AM  dummy@example.com   User                    7/21/2026 4:57:37 AM
eastus2euap test          4/27/2026 5:46:34 AM  dummy@example.com   User                    6/25/2026 8:58:30 AM
eastus2euap DhritiJindal  5/29/2026 8:56:43 AM  dummy@example.com User                    5/29/2026 9:01:43 AM
eastus2euap eee           6/9/2026 4:27:42 PM   dummy@example.com   User                    6/24/2026 3:32:35 PM
eastus2euap test1407      7/14/2026 11:00:32 AM dummy@example.com   User                    7/14/2026 11:00:32 …
eastus2euap test210726-01 7/21/2026 5:39:44 AM  dummy@example.com   User                    7/21/2026 5:39:44 AM
```

Lists all Dell filesystem resources in the specified resource group.

### Example 3: Get a specific Dell filesystem by name
```powershell
Get-AzDellFileSystem -ResourceGroupName praveensingh-test -Name dell-e2e-missingrequired-tests-70302421 -SubscriptionId b9aad304-baa9-4d2a-9404-dbdd3ab55ac5
```

```output
CapacityCurrent                              : 351
CapacityIncremental                          : 1
CapacityMax                                  : 2100
CapacityMin                                  : 65
DelegatedSubnetCidr                          : 10.0.1.0/24
DelegatedSubnetId                            : /subscriptions/b9aad304-baa9-4d2a-9404-dbdd3ab55ac5/resourceGroups/prave
                                               ensingh-test/providers/Microsoft.Network/virtualNetworks/scusVnet/subnet
                                               s/default2
DellReferenceNumber                          : 100438419
EncryptionIdentityPropertyIdentityResourceId :
EncryptionIdentityPropertyIdentityType       :
EncryptionKeyUrl                             :
EncryptionType                               : Microsoft-managed keys (MMK)
FileSystemId                                 : ONEFS-0ad6b06d44738aafcd6527093d9afe3f2268
Id                                           : /subscriptions/b9aad304-baa9-4d2a-9404-dbdd3ab55ac5/resourceGroups/prave
                                               ensingh-test/providers/Dell.Storage/filesystems/dell-e2e-missingrequired
                                               -tests-70302421
IdentityPrincipalId                          :
IdentityTenantId                             :
IdentityType                                 :
IdentityUserAssignedIdentity                 : {
                                               }
Location                                     : southcentralus
MarketplaceEndDate                           : 01/21/2027 00:00:00
MarketplaceOfferId                           : thunderscaletest
MarketplacePlanId                            : testplan
MarketplacePlanName                          : Premium
MarketplacePrivateOfferId                    :
MarketplacePublisherId                       : dellemc
MarketplaceSubscriptionId                    : 4f6940dc-5a96-49c1-de4e-3c43d15bb7b1
MarketplaceSubscriptionStatus                : Subscribed
MarketplaceTermUnit                          : P1Y
Name                                         : dell-e2e-missingrequired-tests-70302421
OneFsUrl                                     :
ProvisioningState                            : Succeeded
ResourceGroupName                            : praveensingh-test
SmartConnectFqdn                             :
SystemDataCreatedAt                          : 1/22/2026 7:42:19 AM
SystemDataCreatedBy                          : 01364267-c687-4289-a1a7-8c423fd3ff9c
SystemDataCreatedByType                      : Application
SystemDataLastModifiedAt                     : 1/22/2026 7:42:19 AM
SystemDataLastModifiedBy                     : 01364267-c687-4289-a1a7-8c423fd3ff9c
SystemDataLastModifiedByType                 : Application
Tag                                          : {
                                                 "DEPLOYMENT_MODE": "SkipProvision"
                                               }
Type                                         : dell.storage/filesystems
UserEmail                                    :
```

Gets the details of a specific Dell filesystem resource.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Dell.Models.IDellIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the filesystem resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases: FilesystemName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Dell.Models.IDellIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dell.Models.ILiftrBaseStorageFileSystemResource

## NOTES

## RELATED LINKS
