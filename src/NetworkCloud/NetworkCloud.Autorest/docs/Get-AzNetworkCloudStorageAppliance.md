---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudstorageappliance
schema: 2.0.0
---

# Get-AzNetworkCloudStorageAppliance

## SYNOPSIS
Get properties of the provided storage appliance.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudStorageAppliance [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudStorageAppliance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudStorageAppliance -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudStorageAppliance -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided storage appliance.

## EXAMPLES

### Example 1: List storage appliances by subscription
```powershell
Get-AzNetworkCloudStorageAppliance -SubscriptionId subscriptionId
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType ResourceGroupName
-------- ----                ------------------- -------------------  ----------------------- ------------------------ ------------------------  ---------------------------- -----------------
westus3  storage-appliance     07/12/2023 10:42:00 user1                   Application            07/12/2023 12:58:10      user2                      Application                resourceGroup
eastus   storage-appliance     11/03/2022 16:59:20 user1                   Application            12/09/2022 19:46:26      user2                      Application                resourceGroup
```

This command lists all storage appliances in the subscription.

### Example 2: List storage appliances by resource group
```powershell
Get-AzNetworkCloudStorageAppliance -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType ResourceGroupName
-------- ----                ------------------- -------------------  ----------------------- ------------------------ ------------------------  ---------------------------- -----------------
westus3  storage-appliance     07/12/2023 10:42:00 user1                   Application            07/12/2023 12:58:10      user2                      Application                resourceGroup
eastus   storage-appliance     11/03/2022 16:59:20 user1                   Application            12/09/2022 19:46:26      user2                      Application                resourceGroup
```

This command lists all storage appliances in the ResourceGroup.

### Example 3: Get storage appliance
```powershell
Get-AzNetworkCloudStorageAppliance -Name storageApplianceName -SubscriptionId subscriptionId -ResourceGroupName resourceGroup
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType ResourceGroupName
-------- ----                ------------------- -------------------  ----------------------- ------------------------ ------------------------  ---------------------------- -----------------
westus3  storage-appliance     07/12/2023 10:42:00 user1                   Application            07/12/2023 12:58:10      user2                      Application                resourceGroup
```

This command gets a storage appliance by its name.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the storage appliance.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: StorageApplianceName

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IStorageAppliance

## NOTES

## RELATED LINKS

