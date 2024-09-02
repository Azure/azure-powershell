---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/Az.Peering/new-AzPeeringContactDetailObject
schema: 2.0.0
---

# New-AzPeeringContactDetailObject

## SYNOPSIS
Create an in-memory object for ContactDetail.

## SYNTAX

```
New-AzPeeringContactDetailObject [-Email <String>] [-Phone <String>] [-Role <Role>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ContactDetail.

## EXAMPLES

### Example 1: Create a Contact Detail object
```powershell
New-AzPeeringContactDetailObject -Email "abc@xyz.com" -Phone 1234567890 -Role "Noc"
```

```output
Email       Phone      Role
-----       -----      ----
abc@xyz.com 1234567890 Noc
```

Creates a ContactDetail object with the specified email phone and role stores it in memory

## PARAMETERS

### -Email
The e-mail address of the contact.

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

### -Phone
The phone number of the contact.

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

### -Role
The role of the contact.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.Role
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.ContactDetail

## NOTES

## RELATED LINKS

