---
external help file: Az.ConfidentialLedger-help.xml
Module Name: Az.ConfidentialLedger
online version: https://learn.microsoft.com/powershell/module/az.confidentialledger/update-azconfidentialledger
schema: 2.0.0
---

# Update-AzConfidentialLedger

## SYNOPSIS
Updates properties of Confidential Ledger

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzConfidentialLedger -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-AadBasedSecurityPrincipal <IAadBasedSecurityPrincipal[]>]
 [-CertBasedSecurityPrincipal <ICertBasedSecurityPrincipal[]>] [-LedgerType <LedgerType>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConfidentialLedger -InputObject <IConfidentialLedgerIdentity> -Location <String>
 [-AadBasedSecurityPrincipal <IAadBasedSecurityPrincipal[]>]
 [-CertBasedSecurityPrincipal <ICertBasedSecurityPrincipal[]>] [-LedgerType <LedgerType>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates properties of Confidential Ledger

## EXAMPLES

### Example 1: Update tags for a Confidential Ledger
```powershell
Update-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName rg-000 `
  -SubscriptionId 00000000-0000-0000-0000-000000000000 `
  -AadBasedSecurityPrincipal `
      @{
          LedgerRoleName="Administrator"; 
          PrincipalId="00001111-aaaa-2222-bbbb-3333cccc4444"; 
          TenantId="00001111-aaaa-2222-bbbb-3333cccc4444"
      } `
  -CertBasedSecurityPrincipal `
      @{
          Cert="-----BEGIN CERTIFICATE-----********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************-----END CERTIFICATE-----"; 
          LedgerRoleName="Reader"
      } `
  -LedgerType Public `
  -Location eastus `
  -Tag `
      @{
          Location="additional properties 0"
          NewTag="New tag"
      }
```

```output
Location Name
eastus   test-ledger
```

Updates metadata for an existing Confidential Ledger.

## PARAMETERS

### -AadBasedSecurityPrincipal
Array of all AAD based Security Principals.
To construct, see NOTES section for AADBASEDSECURITYPRINCIPAL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.IAadBasedSecurityPrincipal[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.ICertBasedSecurityPrincipal[]
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.IConfidentialLedgerIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Confidential Ledger

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.IConfidentialLedgerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.IConfidentialLedger

## NOTES

## RELATED LINKS
