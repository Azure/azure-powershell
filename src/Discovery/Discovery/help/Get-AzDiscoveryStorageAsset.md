---
external help file: Az.Discovery-help.xml
Module Name: Az.Discovery
online version: https://learn.microsoft.com/powershell/module/az.discovery/get-azdiscoverystorageasset
schema: 2.0.0
---

# Get-AzDiscoveryStorageAsset

## SYNOPSIS
Get a StorageAsset

## SYNTAX

### List (Default)
```
Get-AzDiscoveryStorageAsset -ResourceGroupName <String> -StorageContainerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityStorageContainer
```
Get-AzDiscoveryStorageAsset -Name <String> -StorageContainerInputObject <IDiscoveryIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDiscoveryStorageAsset -Name <String> -ResourceGroupName <String> -StorageContainerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDiscoveryStorageAsset -InputObject <IDiscoveryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a StorageAsset

## EXAMPLES

### Example 1: List all storage assets in a container
```powershell
Get-AzDiscoveryStorageAsset -ResourceGroupName "my-rg" -StorageContainerName "my-container"
```

```output
Location    Name            ResourceGroupName
--------    ----            -----------------
eastus      my-asset        my-rg
```

Lists all storage assets under the specified storage container.

### Example 2: Get a specific storage asset
```powershell
Get-AzDiscoveryStorageAsset -ResourceGroupName "my-rg" -StorageContainerName "my-container" -Name "my-asset"
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-asset        my-rg                Succeeded
```

Gets a specific storage asset by name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the StorageAsset

```yaml
Type: System.String
Parameter Sets: GetViaIdentityStorageContainer, Get
Aliases: StorageAssetName

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

### -StorageContainerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity
Parameter Sets: GetViaIdentityStorageContainer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageContainerName
The name of the StorageContainer

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

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IStorageAsset

## NOTES

## RELATED LINKS
