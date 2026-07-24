---
external help file:
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/get-azmissioncommunity
schema: 2.0.0
---

# Get-AzMissionCommunity

## SYNOPSIS
Get a CommunityResource

## SYNTAX

### List (Default)
```
Get-AzMissionCommunity [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMissionCommunity -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMissionCommunity -InputObject <IMissionIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzMissionCommunity -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a CommunityResource

## EXAMPLES

### Example 1: Get a Mission community by name
```powershell
Get-AzMissionCommunity -Name 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-community  eastus   mission-rg        Succeeded
```

Gets the community named `contoso-community` in the `mission-rg` resource group.

### Example 2: List all Mission communities in a resource group
```powershell
Get-AzMissionCommunity -ResourceGroupName 'mission-rg'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-community  eastus   mission-rg        Succeeded
```

Lists every community in the `mission-rg` resource group.

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
The name of the communityResource Resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CommunityName

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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.ICommunityResource

## NOTES

## RELATED LINKS

