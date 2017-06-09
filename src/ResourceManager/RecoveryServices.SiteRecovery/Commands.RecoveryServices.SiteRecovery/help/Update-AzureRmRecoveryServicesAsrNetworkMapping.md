---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# Update-AzureRmRecoveryServicesAsrNetworkMapping

## SYNOPSIS
Updates a network mapping in Site Recovery.

## SYNTAX

### ByNetworkObject (Default)
```
Update-AzureRmRecoveryServicesAsrNetworkMapping -Mapping <ASRNetworkMapping> -RecoveryNetwork <ASRNetwork>
```

### ById
```
Update-AzureRmRecoveryServicesAsrNetworkMapping -Mapping <ASRNetworkMapping> -RecoveryAzureNetworkId <String>
```

## DESCRIPTION
The **Update-AzureRmRecoveryServicesAsrNetworkMapping** cmdlet updates a network mapping in Azure Site Recovery.

## EXAMPLES

### Example 1
```
PS C:\> $currentJob = Update-AzureRmRecoveryServicesAsrNetworkMapping -Mapping $NetworkMapping -RecoveryNetwork $RecoveryNetwork
```

Starts updating network mapping with passed recovery network and returns the job for tracking.

## PARAMETERS

### -Mapping
{{Fill Mapping Description}}

```yaml
Type: ASRNetworkMapping
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryAzureNetworkId
{{Fill RecoveryAzureNetworkId Description}}

```yaml
Type: String
Parameter Sets: ById
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryNetwork
{{Fill RecoveryNetwork Description}}

```yaml
Type: ASRNetwork
Parameter Sets: ByNetworkObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob


## NOTES

## RELATED LINKS

