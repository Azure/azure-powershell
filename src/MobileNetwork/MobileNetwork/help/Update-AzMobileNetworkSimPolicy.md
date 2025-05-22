---
external help file: Az.MobileNetwork-help.xml
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/update-azmobilenetworksimpolicy
schema: 2.0.0
---

# Update-AzMobileNetworkSimPolicy

## SYNOPSIS
update a SIM policy.
Must be created in the same location as its parent mobile network.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMobileNetworkSimPolicy -MobileNetworkName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultSliceId <String>] [-RegistrationTimer <Int32>] [-RfspIndex <Int32>]
 [-SliceConfiguration <ISliceConfiguration[]>] [-Tag <Hashtable>] [-UeAmbrDownlink <String>]
 [-UeAmbrUplink <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityMobileNetworkExpanded
```
Update-AzMobileNetworkSimPolicy -Name <String> -MobileNetworkInputObject <IMobileNetworkIdentity>
 [-DefaultSliceId <String>] [-RegistrationTimer <Int32>] [-RfspIndex <Int32>]
 [-SliceConfiguration <ISliceConfiguration[]>] [-Tag <Hashtable>] [-UeAmbrDownlink <String>]
 [-UeAmbrUplink <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMobileNetworkSimPolicy -InputObject <IMobileNetworkIdentity> [-DefaultSliceId <String>]
 [-RegistrationTimer <Int32>] [-RfspIndex <Int32>] [-SliceConfiguration <ISliceConfiguration[]>]
 [-Tag <Hashtable>] [-UeAmbrDownlink <String>] [-UeAmbrUplink <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update a SIM policy.
Must be created in the same location as its parent mobile network.

## EXAMPLES

### Example 1: Updates SIM policy.
```powershell
Update-AzMobileNetworkSimPolicy -MobileNetworkName azps-mn -SimPolicyName azps-mn-simpolicy -ResourceGroupName azps_test_group -Tag @{"abc"="123"}
```

```output
Location Name              ResourceGroupName ProvisioningState RegistrationTimer UeAmbrDownlink UeAmbrUplink
-------- ----              ----------------- ----------------- ----------------- -------------- ------------
eastus   azps-mn-simpolicy azps_test_group   Succeeded         3240              1 Gbps         500 Mbps
```

Updates SIM policy.

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

### -DefaultSliceId
Slice resource ID.

```yaml
Type: System.String
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MobileNetworkInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: UpdateViaIdentityMobileNetworkExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MobileNetworkName
The name of the mobile network.

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

### -Name
The name of the SIM policy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityMobileNetworkExpanded
Aliases: SimPolicyName

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

### -RegistrationTimer
Interval for the UE periodic registration update procedure, in seconds.

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
The name of the resource group.
The name is case insensitive.

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

### -RfspIndex
RAT/Frequency Selection Priority Index, defined in 3GPP TS 36.413.
This is an optional setting and by default is unspecified.

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

### -SliceConfiguration
The allowed slices and the settings to use for them.
The list must not contain duplicate items and must contain at least one item.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.ISliceConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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
Resource tags.

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

### -UeAmbrDownlink
Downlink bit rate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UeAmbrUplink
Uplink bit rate.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.ISimPolicy

## NOTES

## RELATED LINKS
