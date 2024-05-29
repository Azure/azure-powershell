---
external help file:
Module Name: Az.MixedReality
online version: https://learn.microsoft.com/powershell/module/az.mixedreality/test-azmixedrealitynameavailability
schema: 2.0.0
---

# Test-AzMixedRealityNameAvailability

## SYNOPSIS
Check Name Availability for local uniqueness

## SYNTAX

### CheckExpanded (Default)
```
Test-AzMixedRealityNameAvailability -Location <String> -Name <String> -Type <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzMixedRealityNameAvailability -InputObject <IMixedRealityIdentity> -Name <String> -Type <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check Name Availability for local uniqueness

## EXAMPLES

### Example 1: Check Object Anchors Accounts Name Availability for local uniqueness.
```powershell
Test-AzMixedRealityNameAvailability -Location eastus -Name azpstest -Type "Microsoft.MixedReality/objectAnchorsAccounts"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Check Object Anchors Accounts Name Availability for local uniqueness.

### Example 2: Check Remote Rendering Accounts Name Availability for local uniqueness.
```powershell
Test-AzMixedRealityNameAvailability -Location eastus -Name azpstest -Type "Microsoft.MixedReality/remoteRenderingAccounts"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Check Remote Rendering Accounts Name Availability for local uniqueness.

### Example 3: Check Spatial Anchors Accounts Name Availability for local uniqueness.
```powershell
Test-AzMixedRealityNameAvailability -Location eastus -Name azpstest -Type "Microsoft.MixedReality/spatialAnchorsAccounts"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Check Spatial Anchors Accounts Name Availability for local uniqueness.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.IMixedRealityIdentity
Parameter Sets: CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location in which uniqueness will be verified.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource Name To Verify

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Fully qualified resource type which includes provider namespace

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.IMixedRealityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.ICheckNameAvailabilityResponse

## NOTES

## RELATED LINKS

