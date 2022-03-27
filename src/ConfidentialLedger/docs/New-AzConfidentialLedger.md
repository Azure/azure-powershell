---
external help file:
Module Name: Az.ConfidentialLedger
online version: https://docs.microsoft.com/powershell/module/az.confidentialledger/new-azconfidentialledger
schema: 2.0.0
---

# New-AzConfidentialLedger

## SYNOPSIS
Creates a  Confidential Ledger with the specified ledger parameters.

## SYNTAX

```
New-AzConfidentialLedger -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AadBasedSecurityPrincipal <IAadBasedSecurityPrincipal[]>]
 [-CertBasedSecurityPrincipal <ICertBasedSecurityPrincipal[]>] [-LedgerType <LedgerType>] [-Location <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a  Confidential Ledger with the specified ledger parameters.

## EXAMPLES

### Example 1: Create a new Confidential Ledger
```powershell
PS C:\> New-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName rg-000 `
  -SubscriptionId 00000000-0000-0000-0000-000000000000 `
  -AadBasedSecurityPrincipal `
      @{
          LedgerRoleName="Administrator"; 
          PrincipalId="34621747-6fc8-4771-a2eb-72f31c461f2e"; 
          TenantId="bce123b9-2b7b-4975-8360-5ca0b9b1cd08"
      } `
  -CertBasedSecurityPrincipal `
      @{
          Cert="-----BEGIN CERTIFICATE-----********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************-----END CERTIFICATE-----"; 
          LedgerRoleName="Reader"
      } `
  -LedgerType Public `
  -Location eastus `
  -Tag @{Location="additional properties 0"}

Location Name
eastus   test-ledger
```

Creates a new Confidential Ledger.

### Example 2: Create Using Security Principal Objects
```powershell
PS C:\> $aadSecurityPrincipal = New-AzConfidentialLedgerAadBasedSecurityPrincipalObject `
  -LedgerRoleName "Administrator" `
  -PrincipalId "34621747-6fc8-4771-a2eb-72f31c461f2e" `
  -TenantId "bce123b9-2b7b-4975-8360-5ca0b9b1cd08"

PS C:\> $certSecurityPrincipal = New-AzConfidentialLedgerCertBasedSecurityPrincipalObject `
  -Cert "-----BEGIN CERTIFICATE-----********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************-----END CERTIFICATE-----" `
  -LedgerRoleName "Reader"

PS C:\> New-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName rg-000 `
  -SubscriptionId 00000000-0000-0000-0000-000000000000 `
  -AadBasedSecurityPrincipal $aadSecurityPrincipal `
  -CertBasedSecurityPrincipal $certSecurityPrincipal `
  -LedgerType Public `
  -Location eastus `
  -Tag @{Location="additional properties 0"}

Location Name
eastus   test-ledger
```

Creates a new Confidential Ledger using objects for `AadBasedSecurityPrincipal` and `CertBasedSecurityPrincipal`.

## PARAMETERS

### -AadBasedSecurityPrincipal
Array of all AAD based Security Principals.
To construct, see NOTES section for AADBASEDSECURITYPRINCIPAL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20210513Preview.IAadBasedSecurityPrincipal[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertBasedSecurityPrincipal
Array of all cert based Security Principals.
To construct, see NOTES section for CERTBASEDSECURITYPRINCIPAL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20210513Preview.ICertBasedSecurityPrincipal[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -LedgerType
Type of Confidential Ledger

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Support.LedgerType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The Azure location where the Confidential Ledger is running.

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

### -Name
Name of the Confidential Ledger

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: LedgerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Additional tags for Confidential Ledger

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20210513Preview.IConfidentialLedger

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


AADBASEDSECURITYPRINCIPAL <IAadBasedSecurityPrincipal[]>: Array of all AAD based Security Principals.
  - `[LedgerRoleName <LedgerRoleName?>]`: LedgerRole associated with the Security Principal of Ledger
  - `[PrincipalId <String>]`: UUID/GUID based Principal Id of the Security Principal
  - `[TenantId <String>]`: UUID/GUID based Tenant Id of the Security Principal

CERTBASEDSECURITYPRINCIPAL <ICertBasedSecurityPrincipal[]>: Array of all cert based Security Principals.
  - `[Cert <String>]`: Public key of the user cert (.pem or .cer)
  - `[LedgerRoleName <LedgerRoleName?>]`: LedgerRole associated with the Security Principal of Ledger

## RELATED LINKS

