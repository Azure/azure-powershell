---
external help file: Az.SqlVirtualMachine-help.xml
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/invoke-azsqlvmtroubleshoot
schema: 2.0.0
---

# Invoke-AzSqlVMTroubleshoot

## SYNOPSIS
Starts SQL virtual machine troubleshooting.

## SYNTAX

### TroubleshootExpanded (Default)
```
Invoke-AzSqlVMTroubleshoot -ResourceGroupName <String> -SqlVirtualMachineName <String>
 [-SubscriptionId <String>] [-EndTimeUtc <DateTime>] [-StartTimeUtc <DateTime>]
 [-TroubleshootingScenario <TroubleshootingScenario>] [-UnhealthyReplicaInfoAvailabilityGroupName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### TroubleshootViaIdentityExpanded
```
Invoke-AzSqlVMTroubleshoot -InputObject <ISqlVirtualMachineIdentity> [-EndTimeUtc <DateTime>]
 [-StartTimeUtc <DateTime>] [-TroubleshootingScenario <TroubleshootingScenario>]
 [-UnhealthyReplicaInfoAvailabilityGroupName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Starts SQL virtual machine troubleshooting.

## EXAMPLES

### Example 1
```powershell
Invoke-AzSqlVMTroubleshoot -ResourceGroupName 'ResourceGroup01' -SqlVirtualMachineName 'sqlvm1' -StartTimeUtc '2023-03-15T17:10:00Z' -EndTimeUtc '2023-03-16T08:30:10Z' -TroubleshootingScenario 'UnhealthyReplica'
```

```output
EndTimeUtc StartTimeUtc TroubleshootingScenario VirtualMachineResourceId
---------- ------------ ----------------------- ------------------------
```

### Example 2
```powershell
$sqlvm = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlvm | Invoke-AzSqlVMTroubleshoot -StartTimeUtc '2023-03-15T17:10:00Z' -EndTimeUtc '2023-03-16T08:30:10Z' -TroubleshootingScenario 'UnhealthyReplica'
```

```output
EndTimeUtc StartTimeUtc TroubleshootingScenario VirtualMachineResourceId
---------- ------------ ----------------------- ------------------------
```

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

### -EndTimeUtc
End time in UTC timezone.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity
Parameter Sets: TroubleshootViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: TroubleshootExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlVirtualMachineName
Name of the SQL virtual machine.

```yaml
Type: System.String
Parameter Sets: TroubleshootExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTimeUtc
Start time in UTC timezone.

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

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: TroubleshootExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TroubleshootingScenario
SQL VM troubleshooting scenario.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.TroubleshootingScenario
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnhealthyReplicaInfoAvailabilityGroupName
The name of the availability group

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

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.ISqlVMTroubleshooting

## NOTES

## RELATED LINKS
