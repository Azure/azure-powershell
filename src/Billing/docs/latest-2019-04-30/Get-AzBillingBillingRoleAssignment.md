---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/get-azbillingbillingroleassignment
schema: 2.0.0
---

# Get-AzBillingBillingRoleAssignment

## SYNOPSIS
Get the role assignment for the caller

## SYNTAX

### List (Default)
```
Get-AzBillingBillingRoleAssignment -BillingAccountName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List2
```
Get-AzBillingBillingRoleAssignment -BillingAccountName <String> -BillingProfileName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzBillingBillingRoleAssignment -BillingAccountName <String> -InvoiceSectionName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get2
```
Get-AzBillingBillingRoleAssignment -BillingAccountName <String> -Name <String> -BillingProfileName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzBillingBillingRoleAssignment -BillingAccountName <String> -Name <String> -InvoiceSectionName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzBillingBillingRoleAssignment -BillingAccountName <String> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity2
```
Get-AzBillingBillingRoleAssignment -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzBillingBillingRoleAssignment -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBillingBillingRoleAssignment -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the role assignment for the caller

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

### -BillingAccountName
billing Account Id.

```yaml
Type: System.String
Parameter Sets: List, List2, List1, Get2, Get1, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BillingProfileName
Billing Profile Id.

```yaml
Type: System.String
Parameter Sets: List2, Get2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity
Parameter Sets: GetViaIdentity2, GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InvoiceSectionName
InvoiceSection Id.

```yaml
Type: System.String
Parameter Sets: List1, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
role assignment id.

```yaml
Type: System.String
Parameter Sets: Get2, Get1, Get
Aliases: BillingRoleAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IBillingRoleAssignment

## ALIASES

## RELATED LINKS

