---
external help file: Az.Mission-help.xml
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/get-azmissioncommunityendpoint
schema: 2.0.0
---

# Get-AzMissionCommunityEndpoint

## SYNOPSIS
Get a CommunityEndpointResource

## SYNTAX

### List (Default)
```
Get-AzMissionCommunityEndpoint -CommunityName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzMissionCommunityEndpoint -CommunityName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMissionCommunityEndpoint -CommunityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCommunity
```
Get-AzMissionCommunityEndpoint -Name <String> -CommunityInputObject <IMissionIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMissionCommunityEndpoint -InputObject <IMissionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a CommunityEndpointResource

## EXAMPLES

### Example 1: List all community endpoints in a community
```powershell
Get-AzMissionCommunityEndpoint -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name             Location ResourceGroupName ProvisioningState
----             -------- ----------------- -----------------
contoso-endpoint eastus   mission-rg        Succeeded
```

Lists every community endpoint defined under the `contoso-community` community in the `mission-rg` resource group.

### Example 2: Get a single community endpoint by name
```powershell
Get-AzMissionCommunityEndpoint -Name 'contoso-endpoint' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name             Location ResourceGroupName ProvisioningState UpdateMode
----             -------- ----------------- ----------------- ----------
contoso-endpoint eastus   mission-rg        Succeeded         Automatic
```

Retrieves the `contoso-endpoint` community endpoint, including its rule collection and update mode.

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
Parameter Sets: List, List1, Get
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
The name of the Community Endpoint Resource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCommunity
Aliases: CommunityEndpointName

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
Parameter Sets: List1, Get
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
Parameter Sets: List, List1, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.ICommunityEndpointResource

## NOTES

## RELATED LINKS
