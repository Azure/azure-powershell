---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudvolume
schema: 2.0.0
---

# Get-AzNetworkCloudVolume

## SYNOPSIS
Get properties of the provided volume.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudVolume [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudVolume -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudVolume -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudVolume -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided volume.

## EXAMPLES

### Example 1: List volumes by subscription
```powershell
Get-AzNetworkCloudVolume -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
eastus      <name2>       08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
eastus      <name3>       08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
```

This command lists all volumes under a subscription.

### Example 2: Get volume
```powershell
Get-AzNetworkCloudVolume -Name volumeName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
```

This command gets a volume by name.

### Example 3: List volumes by resource group
```powershell
Get-AzNetworkCloudVolume -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                  -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      <name>         08/02/2023 21:39:23    <identity>                          User                                          08/02/2023 21:39:33          <identity> Application
```

This command lists all volumes in a resource group.

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
The name of the volume.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VolumeName

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IVolume

## NOTES

## RELATED LINKS

