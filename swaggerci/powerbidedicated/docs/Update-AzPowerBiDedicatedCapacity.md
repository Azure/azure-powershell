---
external help file:
Module Name: Az.PowerBiDedicated
online version: https://docs.microsoft.com/en-us/powershell/module/az.powerbidedicated/update-azpowerbidedicatedcapacity
schema: 2.0.0
---

# Update-AzPowerBiDedicatedCapacity

## SYNOPSIS
Updates the current state of the specified Dedicated capacity.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPowerBiDedicatedCapacity -DedicatedCapacityName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AdministrationMember <String[]>] [-Mode <Mode>] [-SkuCapacity <Int32>]
 [-SkuName <String>] [-SkuTier <CapacitySkuTier>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPowerBiDedicatedCapacity -InputObject <IPowerBiDedicatedIdentity> [-AdministrationMember <String[]>]
 [-Mode <Mode>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <CapacitySkuTier>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the current state of the specified Dedicated capacity.

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

### -AdministrationMember
An array of administrator user identities.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DedicatedCapacityName
The name of the Dedicated capacity.
It must be at least 3 characters in length, and no more than 63.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.IPowerBiDedicatedIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Mode
Specifies the generation of the Power BI Embedded capacity.
If no value is specified, the default value 'Gen2' is used.
[Learn More](https://docs.microsoft.com/power-bi/developer/embedded/power-bi-embedded-generation-2)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Support.Mode
Parameter Sets: (All)
Aliases:

Required: False
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
The name of the Azure Resource group of which a given PowerBIDedicated capacity is part.
This name must be at least 1 character in length, and no more than 90.

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

### -SkuCapacity
The capacity of the SKU.

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

### -SkuName
Name of the SKU level.

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

### -SkuTier
The name of the Azure pricing tier to which the SKU applies.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Support.CapacitySkuTier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
A unique identifier for a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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
Key-value pairs of additional provisioning properties.

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

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.IPowerBiDedicatedIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.Api202101.IDedicatedCapacity

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IPowerBiDedicatedIdentity>: Identity Parameter
  - `[DedicatedCapacityName <String>]`: The name of the dedicated capacity. It must be a minimum of 3 characters, and a maximum of 63.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The region name which the operation will lookup into.
  - `[ResourceGroupName <String>]`: The name of the Azure Resource group of which a given PowerBIDedicated capacity is part. This name must be at least 1 character in length, and no more than 90.
  - `[SubscriptionId <String>]`: A unique identifier for a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[VcoreName <String>]`: The name of the auto scale v-core. It must be a minimum of 3 characters, and a maximum of 63.

## RELATED LINKS

