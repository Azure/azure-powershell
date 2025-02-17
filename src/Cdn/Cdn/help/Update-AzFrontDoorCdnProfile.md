---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azfrontdoorcdnprofile
schema: 2.0.0
---

# Update-AzFrontDoorCdnProfile

## SYNOPSIS
Updates an existing Azure Front Door Standard or Azure Front Door Premium or CDN profile with the specified profile name under the specified subscription and resource group.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFrontDoorCdnProfile -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-LogScrubbingRule <IProfileScrubbingRules[]>] [-LogScrubbingState <ProfileScrubbingState>]
 [-OriginResponseTimeoutSecond <Int32>] [-Tag <Hashtable>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFrontDoorCdnProfile -InputObject <ICdnIdentity> [-LogScrubbingRule <IProfileScrubbingRules[]>]
 [-LogScrubbingState <ProfileScrubbingState>] [-OriginResponseTimeoutSecond <Int32>] [-Tag <Hashtable>]
 [-IdentityType <ManagedServiceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates an existing Azure Front Door Standard or Azure Front Door Premium or CDN profile with the specified profile name under the specified subscription and resource group.

## EXAMPLES

### Example 1: Update an AzureFrontDoor profile under the resource group
```powershell
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -Tag $tags
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Update an AzureFrontDoor profile under the resource group

### Example 2: Update an AzureFrontDoor profile under the resource group via identity
```powershell
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 | Update-AzFrontDoorCdnProfile -Tag $tags
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Update an AzureFrontDoor profile under the resource group via identity

### Example 3: Enable managed identity using SystemAssigned type to an AzureFrontDoor profile
```powershell
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -IdentityType SystemAssigned
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable managed identity using SystemAssigned type to an AzureFrontDoor profile

### Example 4: Enable managed identity using UserAssigned type to an AzureFrontDoor profile
```powershell
$userId =  @{"/subscriptions/subId/resourceGroups/testps-rg-da16jm/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testcdnrpaadidentity" = @{}}
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -IdentityType UserAssigned -IdentityUserAssignedIdentity $userId
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable managed identity using UserAssigned type to an AzureFrontDoor profile

### Example 5: Enable the Profile Logscrub to an AzureFrontDoor profile, only contains one LogScrubbingRule
```powershell
$rule = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -LogScrubbingRule $rule -LogScrubbingState Enabled
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable the Profile Logscrub to an AzureFrontDoor profile, only contains one LogScrubbingRule

### Example 6: Enable the Profile Logscrub to an AzureFrontDoor profile, contains more than one LogScrubbingRule
```powershell
$rule1 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled 
$rule2 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable QueryStringArgNames -State Enabled
$rules = New-AzFrontDoorCdnProfileLogScrubbingObject -ScrubbingRule @($rule1, $rule2) -State Enabled

Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -LogScrubbingRule $rules.ScrubbingRule -LogScrubbingState Enabled
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Enable the Profile Logscrub to an AzureFrontDoor profile, contains more than one LogScrubbingRule

### Example 7: Disable the Profile Logscrub to an AzureFrontDoor profile
```powershell
$rule = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Disabled
Update-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -LogScrubbingRule $rule -LogScrubbingState Disabled
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Disable the Profile Logscrub to an AzureFrontDoor profile

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LogScrubbingRule
List of log scrubbing rules applied to the Azure Front Door profile logs.
To construct, see NOTES section for LOGSCRUBBINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IProfileScrubbingRules[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogScrubbingState
State of the log scrubbing config.
Default value is Enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ProfileScrubbingState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Azure Front Door Standard or Azure Front Door Premium or CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ProfileName

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

### -OriginResponseTimeoutSecond
Send and receive timeout on forwarding request to the origin.
When timeout is reached, the request fails and returns.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Profile tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IProfile

## NOTES

## RELATED LINKS
