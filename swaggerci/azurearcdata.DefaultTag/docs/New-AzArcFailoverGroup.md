---
external help file:
Module Name: Az.Arc
online version: https://learn.microsoft.com/powershell/module/az.arc/new-azarcfailovergroup
schema: 2.0.0
---

# New-AzArcFailoverGroup

## SYNOPSIS
Creates or replaces a failover group resource.

## SYNTAX

```
New-AzArcFailoverGroup -Name <String> -ResourceGroupName <String> -SqlManagedInstanceName <String>
 -Property <IFailoverGroupProperties> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or replaces a failover group resource.

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

### -Name
The name of the Failover Group

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FailoverGroupName

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

### -Property
null
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20230315Preview.IFailoverGroupProperties
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Azure resource group

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

### -SqlManagedInstanceName
Name of SQL Managed Instance

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
The ID of the Azure subscription

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

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20230315Preview.IFailoverGroupResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PROPERTY <IFailoverGroupProperties>`: null
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `PartnerManagedInstanceId <String>`: The resource ID of the partner SQL managed instance.
  - `Spec <IFailoverGroupSpec>`: The specifications of the failover group resource.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `Role <InstanceFailoverGroupRole>`: The role of the SQL managed instance in this failover group.
    - `[PartnerMi <String>]`: The name of the partner SQL managed instance.
    - `[PartnerMirroringCert <String>]`: The mirroring endpoint public certificate for the partner SQL managed instance. Only PEM format is supported.
    - `[PartnerMirroringUrl <String>]`: The mirroring endpoint URL of the partner SQL managed instance.
    - `[PartnerSyncMode <FailoverGroupPartnerSyncMode?>]`: The partner sync mode of the SQL managed instance.
    - `[SharedName <String>]`: The shared name of the failover group for this SQL managed instance. Both SQL managed instance and its partner have to use the same shared name.
    - `[SourceMi <String>]`: The name of the SQL managed instance with this failover group role.
  - `[Status <IAny>]`: The status of the failover group custom resource.

## RELATED LINKS

