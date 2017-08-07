---
external help file: Microsoft.Azure.Commands.SiteRecovery.dll-Help.xml
ms.assetid: 9FF78BE6-FF24-47E9-9F36-48E426097F45
online version: 
schema: 2.0.0
---

# Start-AzureRmSiteRecoveryCommitFailoverJob

## SYNOPSIS
Starts the commit failover action for a Site Recovery object.

## SYNTAX

### ByRPIObject (Default)
```
Start-AzureRmSiteRecoveryCommitFailoverJob -ReplicationProtectedItem <ASRReplicationProtectedItem>
 [<CommonParameters>]
```

### ByRPObject
```
Start-AzureRmSiteRecoveryCommitFailoverJob -RecoveryPlan <ASRRecoveryPlan> [<CommonParameters>]
```

### ByPEObject
```
Start-AzureRmSiteRecoveryCommitFailoverJob -ProtectionEntity <ASRProtectionEntity> [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzureRmSiteRecoveryCommitFailoverJob** cmdlet starts the commit failover process for an Azure Site Recovery object after a failover operation.

## EXAMPLES

## PARAMETERS

### -ProtectionEntity
Specifies the Site Recovery protection entity object.

```yaml
Type: ASRProtectionEntity
Parameter Sets: ByPEObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RecoveryPlan
Specifies a recovery plan object.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### ASRProtectionEntity

Parameter 'ProtectionEntity' accepts value of type 'ASRProtectionEntity' from the pipeline

### ASRRecoveryPlan

Parameter 'RecoveryPlan' accepts value of type 'ASRRecoveryPlan' from the pipeline

### ASRReplicationProtectedItem

Parameter 'ReplicationProtectedItem' accepts value of type 'ASRReplicationProtectedItem' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

