---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/Az.SqlVirtualMachine/new-AzSqlVirtualMachineAgReplicaObject
schema: 2.0.0
---

# New-AzSqlVirtualMachineAgReplicaObject

## SYNOPSIS
Create an in-memory object for AgReplica.

## SYNTAX

```
New-AzSqlVirtualMachineAgReplicaObject [-Commit <Commit>] [-Failover <Failover>]
 [-ReadableSecondary <ReadableSecondary>] [-Role <Role>] [-SqlVirtualMachineInstanceId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AgReplica.

## EXAMPLES

### Example 1: Create an in-memory object for availability group replica configuration
```powershell
$AgReplica = New-AzSqlVirtualMachineAgReplicaObject -Commit 'SYNCHRONOUS_COMMIT' -Failover 'MANUAL' -ReadableSecondary 'NO' -Role 'PRIMARY' -SqlVirtualMachineInstanceId $sqlvmResourceId1
$AgReplica
```

```output
Commit             Failover ReadableSecondary Role    SqlVirtualMachineInstanceId
------             -------- ----------------- ----    ---------------------------
SYNCHRONOUS_COMMIT MANUAL   NO                PRIMARY 
```

*New-AzSqlVirtualMachineAgReplicaObject* creates an in-memory object of type *AgReplica*.
This object represents an availability group replica configuration and will be used for parameter *AvailabilityGroupConfigurationReplica* in cmdlet *New-AzAvailabilityGroupListener*.

## PARAMETERS

### -Commit
Replica commit mode in availability group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.Commit
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Failover
Replica failover mode in availability group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.Failover
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadableSecondary
Replica readable secondary mode in availability group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.ReadableSecondary
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
Replica Role in availability group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Support.Role
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlVirtualMachineInstanceId
Sql VirtualMachine Instance Id.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.AgReplica

## NOTES

ALIASES

## RELATED LINKS

