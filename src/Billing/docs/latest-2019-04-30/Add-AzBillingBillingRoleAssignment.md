---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/add-azbillingbillingroleassignment
schema: 2.0.0
---

# Add-AzBillingBillingRoleAssignment

## SYNOPSIS
The operation to add a role assignment to a billing account.

## SYNTAX

### Add (Default)
```
Add-AzBillingBillingRoleAssignment -BillingAccountName <String> [-Parameter <IBillingRoleAssignmentPayload>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddExpanded2
```
Add-AzBillingBillingRoleAssignment -BillingAccountName <String> -BillingProfileName <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddExpanded1
```
Add-AzBillingBillingRoleAssignment -BillingAccountName <String> -InvoiceSectionName <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddExpanded
```
Add-AzBillingBillingRoleAssignment -BillingAccountName <String> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Add2
```
Add-AzBillingBillingRoleAssignment -BillingAccountName <String> -BillingProfileName <String>
 [-Parameter <IBillingRoleAssignmentPayload>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Add1
```
Add-AzBillingBillingRoleAssignment -BillingAccountName <String> -InvoiceSectionName <String>
 [-Parameter <IBillingRoleAssignmentPayload>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AddViaIdentityExpanded2
```
Add-AzBillingBillingRoleAssignment -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### AddViaIdentityExpanded1
```
Add-AzBillingBillingRoleAssignment -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### AddViaIdentityExpanded
```
Add-AzBillingBillingRoleAssignment -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### AddViaIdentity2
```
Add-AzBillingBillingRoleAssignment -InputObject <IBillingIdentity>
 [-Parameter <IBillingRoleAssignmentPayload>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AddViaIdentity1
```
Add-AzBillingBillingRoleAssignment -InputObject <IBillingIdentity>
 [-Parameter <IBillingRoleAssignmentPayload>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AddViaIdentity
```
Add-AzBillingBillingRoleAssignment -InputObject <IBillingIdentity>
 [-Parameter <IBillingRoleAssignmentPayload>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to add a role assignment to a billing account.

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
Parameter Sets: Add, AddExpanded2, AddExpanded1, AddExpanded, Add2, Add1
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
Parameter Sets: AddExpanded2, Add2
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
Parameter Sets: AddViaIdentityExpanded2, AddViaIdentityExpanded1, AddViaIdentityExpanded, AddViaIdentity2, AddViaIdentity1, AddViaIdentity
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
Parameter Sets: AddExpanded1, Add1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The payload use to update role assignment on a scope

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IBillingRoleAssignmentPayload
Parameter Sets: Add, Add2, Add1, AddViaIdentity2, AddViaIdentity1, AddViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IBillingRoleAssignmentPayload

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IBillingRoleAssignment

## ALIASES

## RELATED LINKS

