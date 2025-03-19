---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/start-azrecoveryservicesasrclustertestfailovercleanupjob
schema: 2.0.0
---

# Start-AzRecoveryServicesAsrClusterTestFailoverCleanupJob

## SYNOPSIS
Starts the test failover cleanup operation for a cluster.

## SYNTAX

```
Start-AzRecoveryServicesAsrClusterTestFailoverCleanupJob
 -ReplicationProtectionCluster <ASRReplicationProtectionCluster> [-Comment <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzRecoveryServicesAsrClusterTestFailoverCleanupJob** cmdlet starts the test failover cleanup operation on a replication protection cluster on which a test failover has been performed.
You can check whether the job succeeded by using the Get-AzRecoveryServicesAsrJob cmdlet.

## EXAMPLES

### Example 1
```powershell
$currentJob = Start-AzRecoveryServicesAsrClusterTestFailoverCleanupJob -ReplicationProtectionCluster $protectionCluster -Comment "testing done"

```

Starts the test failover cleanup operation for a replication protection cluster.

## PARAMETERS

### -Comment
User Comment for Test Failover Cleanup.

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicationProtectionCluster
Specifies the replication protection cluster.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRReplicationProtectionCluster
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRReplicationProtectionCluster

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS
