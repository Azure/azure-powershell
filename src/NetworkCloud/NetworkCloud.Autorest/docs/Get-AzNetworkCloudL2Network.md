---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudl2network
schema: 2.0.0
---

# Get-AzNetworkCloudL2Network

## SYNOPSIS
Get properties of the provided layer 2 (L2) network.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudL2Network [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudL2Network -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudL2Network -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudL2Network -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided layer 2 (L2) network.

## EXAMPLES

### Example 1: List Layer 2 (L2) networks by resource group
```powershell
Get-AzNetworkCloudL2Network -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt   SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                              AzureAsyncOperation
-------- ----       ------------------- -------------------   ----------------------- ------------------------   ------------------------             ---------------------------- ----                              -------------------
eastus   l2Network  05/25/2023 05:14:09 user1                 User                   05/25/2023 06:14:09         user2                                User                         microsoft.networkcloud/l2networks
```

This command lists all L2Networks by resource group.

### Example 2: Get Layer 2 (L2) network
```powershell
Get-AzNetworkCloudL2Network -ResourceGroupName resourceGroupName -Name l2network -SubscriptionId subscriptionId
```

```output
Location Name      SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type                              AzureAsyncOperation
-------- ----      ------------------- -------------------      ----------------------- ------------------------ ------------------------ ---------------------------- ----                              -------------------
eastus   l2Network 05/25/2023 05:14:09 user1                    User                    05/25/2023 06:14:09      user2                    User                         microsoft.networkcloud/l2networks
```

This command gets details of an L2Network.

### Example 3: List Layer 2 (L2) networks by subscription
```powershell
Get-AzNetworkCloudL2Network -SubscriptionId subscriptionId
```

```output
Location    Name            SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType Type                              AzureAsyncOperation
--------    ----            ------------------- -------------------     ----------------------- ------------------------ ------------------------    ---------------------------- ----                              -------------------
eastus      l2NetworkName1  05/09/2023 06:05:38 app1                    Application             05/24/2023 23:54:00      app2                        Application                  microsoft.networkcloud/l2networks
eastus      l2NetworkName2  05/24/2023 16:50:36 user1                   User                    05/24/2023 20:50:36      user2                       User                         microsoft.networkcloud/l2networks
```

This command lists L2Networks by subscription.

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
The name of the L2 network.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: L2NetworkName

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IL2Network

## NOTES

## RELATED LINKS

