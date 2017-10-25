---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Close-AzsAlert

## SYNOPSIS
Close an alert.

## SYNTAX

```
Close-AzsAlert -Alert <Alert> -Location <String> -AlertName <String> -User <String> [<CommonParameters>]
```

## DESCRIPTION
Close an alert.

## EXAMPLES

### Example 1
```
PS C:\> Close-AzsAlert -Location local -User  AlertCloseTests -AlertName db1a20c7-08f4-4453-96b5-0d73461a8cac -Alert $myAlert
```

Close an alert.

## PARAMETERS

### -Alert
Updated Alert Parameter.

```yaml
Type: Alert
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertName
Name of the alert.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -User
The username used to perform the operation.

```yaml
Type: String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert

## NOTES

## RELATED LINKS

