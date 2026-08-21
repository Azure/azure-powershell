---
external help file:
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/get-azmissiondedicatedhub
schema: 2.0.0
---

# Get-AzMissionDedicatedHub

## SYNOPSIS
Get a DedicatedHubResource

## SYNTAX

### List (Default)
```
Get-AzMissionDedicatedHub -CommunityName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMissionDedicatedHub -CommunityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMissionDedicatedHub -InputObject <IMissionIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCommunity
```
Get-AzMissionDedicatedHub -CommunityInputObject <IMissionIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzMissionDedicatedHub -CommunityName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a DedicatedHubResource

## EXAMPLES

### Example 1: List all dedicated hubs in a community
```powershell
Get-AzMissionDedicatedHub -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name                 Location ResourceGroupName ProvisioningState
----                 -------- ----------------- -----------------
contoso-dedicatedhub eastus   mission-rg        Succeeded
```

Lists every dedicated hub defined under the `contoso-community` community in the `mission-rg` resource group.

### Example 2: Get a single dedicated hub by name
```powershell
Get-AzMissionDedicatedHub -Name 'contoso-dedicatedhub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name                 Location ResourceGroupName ProvisioningState Designation
----                 -------- ----------------- ----------------- -----------
contoso-dedicatedhub eastus   mission-rg        Succeeded         Reserved
```

Retrieves the `contoso-dedicatedhub` dedicated hub, including its designation.

## PARAMETERS

### -CommunityInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: GetViaIdentityCommunity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CommunityName
The name of the communityResource Resource

```yaml
Type: System.String
Parameter Sets: Get, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Dedicated Hub Resource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCommunity
Aliases: DedicatedHubName

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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IDedicatedHubResource

## NOTES

## RELATED LINKS

