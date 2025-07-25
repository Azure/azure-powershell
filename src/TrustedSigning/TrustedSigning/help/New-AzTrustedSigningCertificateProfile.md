---
external help file: Az.TrustedSigning-help.xml
Module Name: Az.TrustedSigning
online version: https://learn.microsoft.com/powershell/module/az.trustedsigning/new-aztrustedsigningcertificateprofile
schema: 2.0.0
---

# New-AzTrustedSigningCertificateProfile

## SYNOPSIS
create a certificate profile.

## SYNTAX

### CreateExpanded (Default)
```
New-AzTrustedSigningCertificateProfile -AccountName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IdentityValidationId <String>] [-IncludeCity] [-IncludeCountry]
 [-IncludePostalCode] [-IncludeState] [-IncludeStreetAddress] [-ProfileType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzTrustedSigningCertificateProfile -AccountName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzTrustedSigningCertificateProfile -AccountName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
create a certificate profile.

## EXAMPLES

### Example 1: Create New Trusted Signing Certificate Profile
```powershell
New-AzTrustedSigningCertificateProfile -AccountName test -ResourceGroupName rg-test -ProfileName test -IdentityValidationId 5ab4583e-d027-4998-9d65-a2e88981829f -ProfileType PublicTrustTest
```

```output
City    CommonName              Country EnhancedKeyUsage                                               Id                                                                                                                                                                 IdentityValidationId                 IncludeCity IncludeCountry IncludePostalCode IncludeState IncludeStreetAddress Name    Organization OrganizationUnit PostalCode ProfileType     ProvisioningState ResourceGroupName RetryAfter State      Status StreetAddress SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                                                          Certificate
----    ----------              ------- ----------------                                               --                                                                                                                                                                 --------------------                 ----------- -------------- ----------------- ------------ -------------------- ----    ------------ ---------------- ---------- -----------     ----------------- ----------------- ---------- -----      ------ ------------- -------------------   ------------------- ----------------------- ------------------------ ------------------------             ---------------------------- ----                                                          -----------
Barstow Contoso News(TEST ONLY) US      1.3.6.1.4.1.311.97.1.2.100309390.866961637.294916062.541502583 /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test/certificateProfiles/test       5ab4583e-d027-4998-9d65-a2e88981829f                                                                                test    Contoso News                  92312      PublicTrustTest Succeeded         rg-test                      California Active 5th street    1/24/2025 10:01:04 PM test@example.com    User                    2/3/2025 9:18:57 PM      81af9eaf-3a7b-43eb-bc59-c504bfe12240 Application                  microsoft.codesigning/codesigningaccounts/certificateprofiles {{ "serialNumber": "55000A50AE054B71AB92557ACF0000000A50AE","subjectName": "CN=Contoso News(TEST ONLY), O=Contoso News, L=Barstow, S=California, C=US","thumbprint": "9D808D63D1C8B79A152C92C455303D2DC861A910","createdDate": "1/24/2025 9:51:14 PM","expiryDate": "1/31/2025 9:51:14 PM","status": "Active"}}
```

This command creates new trusted signing certificate profile.

## PARAMETERS

### -AccountName
Trusted Signing account name.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -IdentityValidationId
Identity validation id used for the certificate subject name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeCity
Whether to include L in the certificate subject name.
Applicable only for private trust, private trust ci profile types

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeCountry
Whether to include C in the certificate subject name.
Applicable only for private trust, private trust ci profile types

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludePostalCode
Whether to include PC in the certificate subject name.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeState
Whether to include S in the certificate subject name.
Applicable only for private trust, private trust ci profile types

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeStreetAddress
Whether to include STREET in the certificate subject name.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

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

### -ProfileName
Certificate profile name.

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

### -ProfileType
Profile type of the certificate.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ICertificateProfile

## NOTES

## RELATED LINKS
