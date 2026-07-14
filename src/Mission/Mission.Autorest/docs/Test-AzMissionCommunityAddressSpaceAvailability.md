---
external help file:
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/test-azmissioncommunityaddressspaceavailability
schema: 2.0.0
---

# Test-AzMissionCommunityAddressSpaceAvailability

## SYNOPSIS
Checks that the IP Address Space to be allocated for this Community is available.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzMissionCommunityAddressSpaceAvailability -CommunityName <String> -ResourceGroupName <String>
 -CommunityResourceId <String> [-SubscriptionId <String>] [-EnclaveVirtualNetworkAllowSubnetCommunication]
 [-EnclaveVirtualNetworkCustomCidrRange <String>] [-EnclaveVirtualNetworkName <String>]
 [-EnclaveVirtualNetworkSize <String>] [-EnclaveVirtualNetworkSubnetConfiguration <ISubnetConfiguration[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzMissionCommunityAddressSpaceAvailability -CommunityName <String> -ResourceGroupName <String>
 -CheckAddressSpaceAvailabilityRequest <ICheckAddressSpaceAvailabilityRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzMissionCommunityAddressSpaceAvailability -InputObject <IMissionIdentity>
 -CheckAddressSpaceAvailabilityRequest <ICheckAddressSpaceAvailabilityRequest> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzMissionCommunityAddressSpaceAvailability -InputObject <IMissionIdentity> -CommunityResourceId <String>
 [-EnclaveVirtualNetworkAllowSubnetCommunication] [-EnclaveVirtualNetworkCustomCidrRange <String>]
 [-EnclaveVirtualNetworkName <String>] [-EnclaveVirtualNetworkSize <String>]
 [-EnclaveVirtualNetworkSubnetConfiguration <ISubnetConfiguration[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzMissionCommunityAddressSpaceAvailability -CommunityName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzMissionCommunityAddressSpaceAvailability -CommunityName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Checks that the IP Address Space to be allocated for this Community is available.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -CheckAddressSpaceAvailabilityRequest
Request to the action call to check address space availability.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.ICheckAddressSpaceAvailabilityRequest
Parameter Sets: Check, CheckViaIdentity
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
Parameter Sets: Check, CheckExpanded, CheckViaJsonFilePath, CheckViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommunityResourceId
Resource Id of the Community

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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

### -EnclaveVirtualNetworkAllowSubnetCommunication
Allow Subnet Communication.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveVirtualNetworkCustomCidrRange
Custom CIDR Range.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveVirtualNetworkName
Network Name.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveVirtualNetworkSize
Network Size.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveVirtualNetworkSubnetConfiguration
Subnet Configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.ISubnetConfiguration[]
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonString
Aliases:

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
Parameter Sets: Check, CheckExpanded, CheckViaJsonFilePath, CheckViaJsonString
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
Parameter Sets: Check, CheckExpanded, CheckViaJsonFilePath, CheckViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.ICheckAddressSpaceAvailabilityRequest

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.ICheckAddressSpaceAvailabilityResponse

## NOTES

## RELATED LINKS

