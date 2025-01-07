---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudclustermanager
schema: 2.0.0
---

# Get-AzNetworkCloudClusterManager

## SYNOPSIS
Get the properties of the provided cluster manager.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudClusterManager [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudClusterManager -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudClusterManager -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudClusterManager -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the properties of the provided cluster manager.

## EXAMPLES

### Example 1: List cluster managers by subscription
```powershell
Get-AzNetworkCloudClusterManager -SubscriptionId subscriptionId
```

```output
Location    Name                          SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------    ----                          ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus      cmName                        08/26/2022 15:26:43 <identity>                           User                    10/17/2022 21:24:16      <identity>                           User                         resourceGroupName
```

This command lists all cluster managers by subscription.

### Example 2: Get cluster manager
```powershell
Get-AzNetworkCloudClusterManager -Name clusterManagerName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName
```

```output
Location Name   SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----   ------------------- -------------------    ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   cmName 07/31/2023 17:38:44 <identity>             User                    07/31/2023 17:38:44      <identity>               User                         resourceGroupName
```

This command gets a cluster manager by name.

### Example 3: List cluster managers by resource group
```powershell
Get-AzNetworkCloudClusterManager -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name   SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----   ------------------- -------------------    ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   cmName 07/31/2023 17:38:44 <identity>             User                    07/31/2023 17:38:44      <identity>               User                         resourceGroupName
```

This command lists all cluster managers in a resource group.

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
The name of the cluster manager.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ClusterManagerName

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IClusterManager

## NOTES

## RELATED LINKS
