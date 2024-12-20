---
external help file:
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/Az.ConnectedMachine/new-azconnectedlicenseprofilefeature
schema: 2.0.0
---

# New-AzConnectedLicenseProfileFeature

## SYNOPSIS
Create an in-memory object for ProductFeature.

## SYNTAX

```
New-AzConnectedLicenseProfileFeature [-Name <String>] [-SubscriptionStatus <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ProductFeature.

## EXAMPLES

### Example 1: Create an object to pass into license profile
```powershell
$productfeature = New-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"
$productfeature | Should -Not -BeNullOrEmpty
```

Create an object to pass into license profile

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
Indicates the current status of the product features.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.ProductFeature

## NOTES

## RELATED LINKS

