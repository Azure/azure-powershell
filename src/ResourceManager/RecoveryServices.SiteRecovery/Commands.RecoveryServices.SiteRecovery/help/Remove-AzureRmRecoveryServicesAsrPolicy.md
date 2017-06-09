---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmRecoveryServicesAsrPolicy

## SYNOPSIS
Removes a Site Recovery replication policy.

## SYNTAX

```
Remove-AzureRmRecoveryServicesAsrPolicy -Policy <ASRPolicy> [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmRecoveryServicesAsrPolicy** cmdlet removes an Azure Site Recovery replication policy.

## EXAMPLES

### Example 1
```
PS C:\> $currentJob = Remove-AzureRmRecoveryServicesAsrPolicy -Policy $Policy
```

Starts the deletion of passed policy and returns the job for tracking.

## PARAMETERS

### -Policy
Specifies the Site Recovery policy object.

```yaml
Type: ASRPolicy
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRPolicy

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[Get-AzureRmRecoveryServicesAsrPolicy](./Get-AzureRmRecoveryServicesAsrPolicy.md)

[New-AzureRmRecoveryServicesAsrPolicy](./New-AzureRmRecoveryServicesAsrPolicy.md)
