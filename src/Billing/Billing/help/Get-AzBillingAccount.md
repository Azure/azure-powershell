---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Billing.dll-Help.xml
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/get-azbillingaccount
schema: 2.0.0
---

# Get-AzBillingAccount

## SYNOPSIS
Get billing accounts.

## SYNTAX

### List (Default)
```
Get-AzBillingAccount [-IncludeAddress] [-ExpandBillingProfiles] [-ExpandInvoiceSections] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### Single
```
Get-AzBillingAccount -Name <System.Collections.Generic.List`1[System.String]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzBillingAccount** cmdlet gets billing accounts, user has access to. 

## EXAMPLES

### Example 1
```
PS C:\> Get-AzBillingAccount
```

Get all billing accounts user has access to.

### Example 2
```
PS C:\> Get-AzBillingAccount -Name 7cff50a2-724a-4357-ab56-b44fc3770f2b_cbcb8ff5-aff4-4b8e-b8aa-ef2d947f6680
```

Get the billing account with the specified name.

### Example 3
```
PS C:\> Get-AzBillingAccount -IncludeAddress
```

Get all billing accounts user has access to, and include the address in the result.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeAddress
Include the address of the billing account.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of a specific billing account.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: Single
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Billing.Models.PSInvoice

## NOTES

## RELATED LINKS
