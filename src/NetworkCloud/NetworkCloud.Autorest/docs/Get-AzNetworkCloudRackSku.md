---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudracksku
schema: 2.0.0
---

# Get-AzNetworkCloudRackSku

## SYNOPSIS
Get the properties of the provided rack SKU.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudRackSku [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudRackSku -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudRackSku -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the properties of the provided rack SKU.

## EXAMPLES

### Example 1: List rack SKUs by subscription
```powershell
Get-AzNetworkCloudRackSku -SubscriptionId subscriptionId
```

```output
Name                          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                          ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
rackSkuName                     07/10/2023 16:09:59 user1               User                    07/10/2023 16:20:31     user2                       User                     resourceGroupName
```

This command lists all rack SKUs by subscription.

### Example 2: Get rack SKU
```powershell
Get-AzNetworkCloudRackSku -Name rackSkuName -SubscriptionId subscriptionId
```

```output
Name                         SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                         ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
rackSkuName                     07/10/2023 16:09:59 user1               User                    07/10/2023 16:20:31     user2                       User                    resourceGroupName
```

This command gets a rack SKU.

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
The name of the rack SKU.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RackSkuName

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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IRackSku

## NOTES

## RELATED LINKS

