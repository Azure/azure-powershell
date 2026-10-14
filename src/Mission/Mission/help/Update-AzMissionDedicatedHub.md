---
external help file: Az.Mission-help.xml
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/update-azmissiondedicatedhub
schema: 2.0.0
---

# Update-AzMissionDedicatedHub

## SYNOPSIS
Update a DedicatedHubResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMissionDedicatedHub -CommunityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Designation <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzMissionDedicatedHub -CommunityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzMissionDedicatedHub -CommunityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityCommunityExpanded
```
Update-AzMissionDedicatedHub -Name <String> -CommunityInputObject <IMissionIdentity> [-Designation <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMissionDedicatedHub -InputObject <IMissionIdentity> [-Designation <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a DedicatedHubResource

## EXAMPLES

### Example 1: Patch a dedicated hub's tags
```powershell
Update-AzMissionDedicatedHub -Name 'contoso-dedicatedhub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Tag @{ costCenter = 'platform' }
```

```output
Name                 Location ResourceGroupName ProvisioningState Designation
----                 -------- ----------------- ----------------- -----------
contoso-dedicatedhub eastus   mission-rg        Succeeded         Reserved
```

Updates only the tags on the existing `contoso-dedicatedhub` dedicated hub, leaving all other properties unchanged (PATCH semantics).

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommunityInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: UpdateViaIdentityCommunityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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

### -Designation
Designation of hub resource allocation (Pooled or Reserved)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCommunityExpanded, UpdateViaIdentityExpanded
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Dedicated Hub Resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityCommunityExpanded
Aliases: DedicatedHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityCommunityExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
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
