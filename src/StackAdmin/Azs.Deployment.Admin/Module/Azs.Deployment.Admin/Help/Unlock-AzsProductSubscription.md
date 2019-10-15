---
external help file: Azs.Deployment.Admin-help.xml
Module Name: Azs.Deployment.Admin
online version:
schema: 2.0.0
---

# Unlock-AzsProductSubscription

## SYNOPSIS
Unlock the product subscription.

## SYNTAX

```
Unlock-AzsProductSubscription [-ProductId] <String> [[-Duration] <TimeSpan>] [<CommonParameters>]
```

## DESCRIPTION
Unlock the product subscription.

## EXAMPLES

### EXAMPLE 1
```
Unlock-AzsProductSubscription -ProductId $ProductId -Duration ([timespan]::FromDays(5))
```

Unlocks the product subscription for the specified product and the specified duration

## PARAMETERS

### -ProductId
Product package Id to unlock the product subscription for.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Duration
The time duration for the product subscription to be unlocked.

```yaml
Type: TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: [timespan]::Zero
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
