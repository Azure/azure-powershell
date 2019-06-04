---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/invoke-azinitiatetransfer
schema: 2.0.0
---

# Invoke-AzInitiateTransfer

## SYNOPSIS
Initiates the request to transfer the legacy subscriptions or RIs.

## SYNTAX

### Initiate (Default)
```
Invoke-AzInitiateTransfer -BillingAccountName <String> -InvoiceSectionName <String>
 [-Body <IInitiateTransferRequest>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InitiateExpanded
```
Invoke-AzInitiateTransfer -BillingAccountName <String> -InvoiceSectionName <String>
 [-BillingProfileId <String>] [-RecipientEmailId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### InitiateViaIdentityExpanded
```
Invoke-AzInitiateTransfer -InputObject <IBillingIdentity> [-BillingProfileId <String>]
 [-RecipientEmailId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InitiateViaIdentity
```
Invoke-AzInitiateTransfer -InputObject <IBillingIdentity> [-Body <IInitiateTransferRequest>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Initiates the request to transfer the legacy subscriptions or RIs.

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
Parameter Sets: Initiate, InitiateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BillingProfileId
Target Usage context for devTest subscriptions.

```yaml
Type: System.String
Parameter Sets: InitiateExpanded, InitiateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Body
Request parameters to initiate transfer.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IInitiateTransferRequest
Parameter Sets: Initiate, InitiateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: InitiateViaIdentityExpanded, InitiateViaIdentity
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
Parameter Sets: Initiate, InitiateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RecipientEmailId
Email Id of recipient for transfer.

```yaml
Type: System.String
Parameter Sets: InitiateExpanded, InitiateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IInitiateTransferRequest

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.ITransferProperties

## ALIASES

### Invoke-AzBillingInitiateTransfer

## RELATED LINKS

