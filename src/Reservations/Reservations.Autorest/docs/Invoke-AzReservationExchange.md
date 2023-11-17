---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/invoke-azreservationexchange
schema: 2.0.0
---

# Invoke-AzReservationExchange

## SYNOPSIS
Returns one or more `Reservations` in exchange for one or more `Reservation` purchases.\n

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzReservationExchange [-SessionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Post
```
Invoke-AzReservationExchange -Body <IExchangeRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Returns one or more `Reservations` in exchange for one or more `Reservation` purchases.\n

## EXAMPLES

### Example 1: Proceed reservations exchange with session ID obtained from Invoke-AzReservationCalculateExchange
```powershell
Invoke-AzReservationExchange -SessionId 8982593c-679e-4d4e-b971-c48b6d824cba
```

```output
SessionId                            Status   
---------                            ------   
8982593c-679e-4d4e-b971-c48b6d824cba Succeeded
```

Proceed reservations exchange with session ID obtained from Invoke-AzReservationCalculateExchange.
This is a long running POST operation which can take around 10ish mins.

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

### -Body
Exchange request
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IExchangeRequest
Parameter Sets: Post
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -SessionId
SessionId that was returned by CalculateExchange API.

```yaml
Type: System.String
Parameter Sets: PostExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IExchangeRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.IExchangeOperationResultResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <IExchangeRequest>`: Exchange request
  - `[SessionId <String>]`: SessionId that was returned by CalculateExchange API.

## RELATED LINKS

