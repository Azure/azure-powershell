---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudrack
schema: 2.0.0
---

# Get-AzNetworkCloudRack

## SYNOPSIS
Get properties of the provided rack.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudRack [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudRack -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudRack -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudRack -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided rack.

## EXAMPLES

### Example 1: List racks by resource group
```powershell
Get-AzNetworkCloudRack -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType       ResourceGroupName
--------    ----              ------------------- -------------------  ----------------------- ------------------------ ------------------------    ----------------------------      -----------------
eastus      rackName            07/11/2023 16:09:59 user1               User                    07/11/2023 16:20:31     user2                       User                               sim
```

This command lists all racks by resource group.

### Example 2: Get rack
```powershell
Get-AzNetworkCloudRack -ResourceGroupName resourceGroupName -Name rackName -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType       ResourceGroupName
--------    ----              ------------------- -------------------  ----------------------- ------------------------ ------------------------    ----------------------------      -----------------
eastus      rackName            07/11/2023 16:09:59 user1               User                    07/11/2023 16:20:31     user2                       User                               sim
```

This command gets details of a rack.

### Example 3: List racks by subscription
```powershell
Get-AzNetworkCloudRack -SubscriptionId subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType       ResourceGroupName
--------    ----              ------------------- -------------------  ----------------------- ------------------------ ------------------------    ----------------------------      -----------------
eastus      rackName            07/11/2023 16:09:59 user1               User                    07/11/2023 16:20:31     user2                       User                               sim
```

This command lists racks by subscription.

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
The name of the rack.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RackName

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IRack

## NOTES

## RELATED LINKS

