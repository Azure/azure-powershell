---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# Stop-AzureRmRecoveryServicesAsrJob

## SYNOPSIS
Stops a Site Recovery job.

## SYNTAX

### ByObject (Default)
```
Stop-AzureRmRecoveryServicesAsrJob -Job <ASRJob> [<CommonParameters>]
```

### ByName
```
Stop-AzureRmRecoveryServicesAsrJob -Name <String> [<CommonParameters>]
```

## DESCRIPTION
The **Stop-AzureRmRecoveryServicesAsrJob** cmdlet stops an Azure Site Recovery job.

## EXAMPLES

### Example 1
```
PS C:\> $currentJob = Stop-AzureRmRecoveryServicesAsrJob -Job $Job
```

Starts stopping the passed job and returns the job for tracking.

## PARAMETERS

### -Job
Specifies the Site Recovery job object to stop.

```yaml
Type: ASRJob
Parameter Sets: ByObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the unique name for the Site Recovery job to stop.

```yaml
Type: String
Parameter Sets: ByName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

[Get-AzureRmRecoveryServicesAsrJob](./Get-AzureRmRecoveryServicesAsrJob.md)

[Restart-AzureRmRecoveryServicesAsrJob](./Restart-AzureRmRecoveryServicesAsrJob.md)

[Resume-AzureRmRecoveryServicesAsrJob](./Resume-AzureRmRecoveryServicesAsrJob.md)
