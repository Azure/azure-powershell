---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudservicesnetwork
schema: 2.0.0
---

# Get-AzNetworkCloudServicesNetwork

## SYNOPSIS
Get properties of the provided cloud services network.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudServicesNetwork [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudServicesNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudServicesNetwork -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudServicesNetwork -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided cloud services network.

## EXAMPLES

### Example 1: List cloud services networks by resource group
```powershell
Get-AzNetworkCloudServicesNetwork -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location Name                     SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
-------- ----                     ------------------- -------------------    ----------------------- ------------------------ ------------------------
eastus   cloudNetworkServicesName 06/30/2023 13:32:28 User1                  User                    06/30/2023 13:32:39      resourceGroupName
```

This command lists all cloud services network in a resource group.

### Example 2: Get cloud services network
```powershell
Get-AzNetworkCloudServicesNetwork -ResourceGroupName resourceGroupName -CloudServicesNetworkName cloudNetworkServicesName
```

```output
Location Name                     SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
-------- ----                     ------------------- -------------------    ----------------------- ------------------------ ------------------------
eastus   cloudNetworkServicesName 06/30/2023 13:32:28 User1                  User                    06/30/2023 13:32:39      resourceGroupName
```

This command gets cloud services network by name.

### Example 3: List cloud services networks by subscription
```powershell
Get-AzNetworkCloudServicesNetwork -SubscriptionId subscriptionId
```

```output
Location Name                     SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
-------- ----                     ------------------- -------------------    ----------------------- ------------------------ ------------------------
eastus   cloudNetworkServicesName 06/30/2023 13:32:28 User1                  User                    06/30/2023 13:32:39      resourceGroupName
```

This command lists all cloud services networks by subscription.

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
The name of the cloud services network.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CloudServicesNetworkName

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ICloudServicesNetwork

## NOTES

## RELATED LINKS

