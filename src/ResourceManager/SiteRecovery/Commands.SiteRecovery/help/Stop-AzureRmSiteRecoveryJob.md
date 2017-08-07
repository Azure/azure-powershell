---
external help file: Microsoft.Azure.Commands.SiteRecovery.dll-Help.xml
ms.assetid: CFEA76B4-684C-4C2A-9806-36DC133AEE80
online version: 
schema: 2.0.0
---

# Stop-AzureRmSiteRecoveryJob

## SYNOPSIS
Stops a Site Recovery job.

## SYNTAX

### ByObject (Default)
```
Stop-AzureRmSiteRecoveryJob -Job <ASRJob> [<CommonParameters>]
```

### ByName
```
Stop-AzureRmSiteRecoveryJob -Name <String> [<CommonParameters>]
```

## DESCRIPTION
The **Stop-AzureRmSiteRecoveryJob** cmdlet stops an Azure Site Recovery job.

## EXAMPLES

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

### ASRJob

Parameter 'Job' accepts value of type 'ASRJob' from the pipeline

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmSiteRecoveryJob](./Get-AzureRmSiteRecoveryJob.md)

[Restart-AzureRmSiteRecoveryJob](./Restart-AzureRmSiteRecoveryJob.md)

[Resume-AzureRmSiteRecoveryJob](./Resume-AzureRmSiteRecoveryJob.md)
