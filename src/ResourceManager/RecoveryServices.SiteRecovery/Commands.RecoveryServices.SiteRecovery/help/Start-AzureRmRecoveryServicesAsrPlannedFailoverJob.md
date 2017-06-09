---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# Start-AzureRmRecoveryServicesAsrPlannedFailoverJob

## SYNOPSIS
Starts a Site Recovery planned failover operation.

## SYNTAX

### ByRPIObject (Default)
```
Start-AzureRmRecoveryServicesAsrPlannedFailoverJob -ReplicationProtectedItem <ASRReplicationProtectedItem>
 -Direction <String> [-Optimize <String>] [-CreateVmIfNotFound <String>]
 [-ServicesProvider <ASRRecoveryServicesProvider>] [-DataEncryptionPrimaryCertFile <String>]
 [-DataEncryptionSecondaryCertFile <String>] [<CommonParameters>]
```

### ByRPObject
```
Start-AzureRmRecoveryServicesAsrPlannedFailoverJob -RecoveryPlan <ASRRecoveryPlan> -Direction <String>
 [-Optimize <String>] [-CreateVmIfNotFound <String>] [-DataEncryptionPrimaryCertFile <String>]
 [-DataEncryptionSecondaryCertFile <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzureRmRecoveryServicesAsrPlannedFailoverJob** cmdlet starts a planned failover for an Azure Site Recovery protection entity or recovery plan.
You can check whether the job succeeds by using the Get-AzureRmRecoveryServicesAsrJob cmdlet.

## EXAMPLES

### Example 1
```
PS C:\> $currentJob = Start-AzureRmRecoveryServicesAsrPlannedFailoverJob -RecoveryPlan $RP -Direction PrimaryToRecovery
```

Starts the planned failover for the passed recovery plan and returns the job for tracking.

## PARAMETERS

### -CreateVmIfNotFound
The acceptable values for this parameter are:

- Yes
- No

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: Yes, No

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionPrimaryCertFile
Specifies the primary certificate file.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionSecondaryCertFile
Specifies the secondary certificate file.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direction
Specifies the direction of the failover.
The acceptable values for this parameter are:

- PrimaryToRecovery
- RecoveryToPrimary

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: PrimaryToRecovery, RecoveryToPrimary

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Optimize
Specifies what to optimize for.
This parameter applies when failover is done from an Azure site to an on-premise site which requires a substantial data synchronization.
Valid values are:

- ForDowntime
- ForSynchronization

When **ForDowntime** is specified, this indicates that data is synchronized before failover to minimize downtime.
Synchronization is performed without shutting down the virtual machine.
After synchronization is complete, the job is suspended.
Resume the job to do an additional synchronization operation that shuts down the virtual machine.

When **ForSynchronization** is specified, this indicates that data is synchronized during failover only so data synchronization is minimized.
With this setting enabled, the virtual machine is shut down immediately.
Synchronization starts after shutdown to complete the failover operation.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: ForDownTime, ForSynchronization

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPlan
{{Fill RecoveryPlan Description}}

```yaml
Type: ASRRecoveryPlan
Parameter Sets: ByRPObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ReplicationProtectedItem
{{Fill ReplicationProtectedItem Description}}

```yaml
Type: ASRReplicationProtectedItem
Parameter Sets: ByRPIObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServicesProvider
{{Fill ServicesProvider Description}}

```yaml
Type: ASRRecoveryServicesProvider
Parameter Sets: ByRPIObject
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRRecoveryPlan
Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRReplicationProtectedItem

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

