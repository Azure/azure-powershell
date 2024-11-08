---
external help file:
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/Az.ConnectedMachine/new-azconnectedlicenseprofileupdate
schema: 2.0.0
---

# New-AzConnectedLicenseProfileUpdate

## SYNOPSIS
Create an in-memory object for ProductFeatureUpdate.

## SYNTAX

```
New-AzConnectedLicenseProfileUpdate [-Name <String>] [-SubscriptionStatus <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ProductFeatureUpdate.

## EXAMPLES

### Example 1: Create the profile update object
```powershell
New-AzConnectedLicenseProfileUpdate -Name "Hotpatch" -SubscriptionStatus "Enable"
```

```output
Name     SubscriptionStatus
----     ------------------
Hotpatch Enable
```

Create the profile update object

## PARAMETERS

### -Name
Product feature name.

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

### -SubscriptionStatus
Indicates the new status of the product feature.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.ProductFeatureUpdate

## NOTES

## RELATED LINKS

