---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/new-azmobilenetworksim
schema: 2.0.0
---

# New-AzMobileNetworkSim

## SYNOPSIS
Creates or updates a SIM.

## SYNTAX

```
New-AzMobileNetworkSim -GroupName <String> -Name <String> -ResourceGroupName <String>
 -InternationalMobileSubscriberIdentity <String> [-SubscriptionId <String>] [-AuthenticationKey <String>]
 [-DeviceType <String>] [-IntegratedCircuitCardIdentifier <String>] [-OperatorKeyCode <String>]
 [-SimPolicyId <String>] [-StaticIPConfiguration <ISimStaticIPProperties[]>] [-SystemDataCreatedAt <DateTime>]
 [-SystemDataCreatedBy <String>] [-SystemDataCreatedByType <CreatedByType>]
 [-SystemDataLastModifiedAt <DateTime>] [-SystemDataLastModifiedBy <String>]
 [-SystemDataLastModifiedByType <CreatedByType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a SIM.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -AuthenticationKey
The Ki value for the SIM.

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

### -DeviceType
An optional free-form text field that can be used to record the device type this SIM is associated with, for example 'Video camera'.
The Azure portal allows SIMs to be grouped and filtered based on this value.

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

### -GroupName
The name of the SIM Group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SimGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntegratedCircuitCardIdentifier
The integrated circuit card ID (ICCID) for the SIM.

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

### -InternationalMobileSubscriberIdentity
The international mobile subscriber identity (IMSI) for the SIM.

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

### -Name
The name of the SIM.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SimName

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

### -OperatorKeyCode
The Opc value for the SIM.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SimPolicyId
SIM policy resource ID.

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

### -StaticIPConfiguration
A list of static IP addresses assigned to this SIM.
Each address is assigned at a defined network scope, made up of {attached data network, slice}.
To construct, see NOTES section for STATICIPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISimStaticIPProperties[]
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataCreatedAt
The timestamp of resource creation (UTC).

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataCreatedBy
The identity that created the resource.

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

### -SystemDataCreatedByType
The type of identity that created the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.CreatedByType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataLastModifiedAt
The timestamp of resource last modification (UTC)

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataLastModifiedBy
The identity that last modified the resource.

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

### -SystemDataLastModifiedByType
The type of identity that last modified the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.CreatedByType
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISim

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


STATICIPCONFIGURATION <ISimStaticIPProperties[]>: A list of static IP addresses assigned to this SIM. Each address is assigned at a defined network scope, made up of {attached data network, slice}.
  - `[AttachedDataNetworkId <String>]`: Attached data network resource ID.
  - `[SlouseId <String>]`: Slice resource ID.
  - `[StaticIPIpv4Address <String>]`: The IPv4 address assigned to the SIM at this network scope. This address must be in the userEquipmentStaticAddressPoolPrefix defined in the attached data network.

## RELATED LINKS

