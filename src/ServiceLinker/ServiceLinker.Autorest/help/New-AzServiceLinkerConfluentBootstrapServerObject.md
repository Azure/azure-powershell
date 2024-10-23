---
external help file:
Module Name: Az.ServiceLinker
online version: https://learn.microsoft.com/powershell/module/az.ServiceLinker/new-azservicelinkerconfluentbootstrapserverobject
schema: 2.0.0
---

# New-AzServiceLinkerConfluentBootstrapServerObject

## SYNOPSIS
Create an in-memory object for ConfluentBootstrapServer.

## SYNTAX

```
New-AzServiceLinkerConfluentBootstrapServerObject -Endpoint <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ConfluentBootstrapServer.

## EXAMPLES

### Example 1: Create an target resource object for Kafka server on Confluent cloud
```powershell
New-AzServiceLinkerConfluentBootstrapServerObject -Endpoint "pkc-xxxx.eastus.azure.confluent.cloud:9092"
```

```output
Endpoint
--------
pkc-xxxx.eastus.azure.confluent.cloud:9092
```

Create an target resource object for Kafka server on Confluent cloud

## PARAMETERS

### -Endpoint
The endpoint of service.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.ConfluentBootstrapServer

## NOTES

## RELATED LINKS

