---
external help file:
Module Name: Az.Accounts
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/get-aztenant
schema: 2.0.0
---

# Get-AzTenant

## SYNOPSIS

Get-AzTenant [[-TenantId] <string>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]


## SYNTAX

### Get (Default)
```
Get-AzTenant -BillingAccountId <String> -BillingProfileId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzTenant -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a Tenant Properties.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String


## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSAzureTenant


## ALIASES

### Get-AzDomain

## RELATED LINKS

