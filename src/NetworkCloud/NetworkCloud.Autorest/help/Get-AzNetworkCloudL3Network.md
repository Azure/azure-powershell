---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudl3network
schema: 2.0.0
---

# Get-AzNetworkCloudL3Network

## SYNOPSIS
Get properties of the provided layer 3 (L3) network.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudL3Network [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudL3Network -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudL3Network -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudL3Network -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided layer 3 (L3) network.

## EXAMPLES

### Example 1: List Layer 3 (L3) networks by resource group
```powershell
Get-AzNetworkCloudL3Network -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType AzureAsyncOperation ResourceGroupName
--------    ----              ------------------- -------------------   ----------------------- ------------------------ ------------------------   ---------------------------- ------------------- -----------------
eastus      l3NetworkName     05/08/2023 20:59:18 user1                 User                    05/08/2023 20:59:18      user2                      User                                             resourceGroupName
```

This command lists all L3Networks by resource group.

### Example 2: Get Layer 3 (L3) network
```powershell
Get-AzNetworkCloudL3Network -ResourceGroupName resourceGroupName -Name l3NetworkName -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType AzureAsyncOperation ResourceGroupName
--------    ----              ------------------- -------------------   ----------------------- ------------------------ ------------------------   ---------------------------- ------------------- -----------------
eastus      l3NetworkName     05/08/2023 20:59:18 user1                 User                    05/08/2023 20:59:18      user2                      User                                             resourceGroupName
```

This command gets details of an L3Network.

### Example 3: List Layer 3 (L3) networks by subscription
```powershell
Get-AzNetworkCloudL3Network -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType   Type                              AzureAsyncOperation
--------    ----              ------------------- -------------------  ----------------------- ------------------------ ------------------------    ----------------------------  ----                              -----------------
eastus      l3NetworkName      03/13/2023 16:09:59 user1               User                    03/13/2023 16:20:31     user2                       User                           microsoft.networkcloud/l3networks
```

This command lists L3Networks by subscription.

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
The name of the L3 network.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: L3NetworkName

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IL3Network

## NOTES

## RELATED LINKS

