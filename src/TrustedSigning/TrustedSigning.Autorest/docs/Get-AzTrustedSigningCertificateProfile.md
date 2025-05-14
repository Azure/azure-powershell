---
external help file:
Module Name: Az.TrustedSigning
online version: https://learn.microsoft.com/powershell/module/az.trustedsigning/get-aztrustedsigningcertificateprofile
schema: 2.0.0
---

# Get-AzTrustedSigningCertificateProfile

## SYNOPSIS
Get details of a certificate profile.

## SYNTAX

### List (Default)
```
Get-AzTrustedSigningCertificateProfile -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzTrustedSigningCertificateProfile -AccountName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzTrustedSigningCertificateProfile -InputObject <ITrustedSigningIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCodeSigningAccount
```
Get-AzTrustedSigningCertificateProfile -CodeSigningAccountInputObject <ITrustedSigningIdentity>
 -ProfileName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get details of a certificate profile.

## EXAMPLES

### Example 1: Get Trusted Signing Certificate Profile
```powershell
Get-AzTrustedSigningCertificateProfile -AccountName test -ResourceGroupName rg-test -ProfileName test
```

```output
City    CommonName              Country EnhancedKeyUsage                                               Id                                                                                                                                                                 IdentityValidationId                 IncludeCity IncludeCountry IncludePostalCode IncludeState IncludeStreetAddress Name    Organization OrganizationUnit PostalCode ProfileType     ProvisioningState ResourceGroupName RetryAfter State      Status StreetAddress SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                                                          Certificate
----    ----------              ------- ----------------                                               --                                                                                                                                                                 --------------------                 ----------- -------------- ----------------- ------------ -------------------- ----    ------------ ---------------- ---------- -----------     ----------------- ----------------- ---------- -----      ------ ------------- -------------------   ------------------- ----------------------- ------------------------ ------------------------             ---------------------------- ----                                                          -----------
Barstow Contoso News(TEST ONLY) US      1.3.6.1.4.1.311.97.1.2.100309390.866961637.294916062.541502583 /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test/certificateProfiles/test       18f2c413-51a1-4990-a0b6-83e19b7c5991                                                                                janielm Contoso News                  92312      PublicTrustTest Succeeded         rg-test                      California Active 5th street    1/24/2025 10:01:04 PM test@example.com    User                    2/3/2025 9:18:57 PM      81af9eaf-3a7b-43eb-bc59-c504bfe12240 Application                  microsoft.codesigning/codesigningaccounts/certificateprofiles {{ "serialNumber": "55000A50AE054B71AB92557ACF0000000A50AE","subjectName": "CN=Contoso News(TEST ONLY), O=Contoso News, L=Barstow, S=California, C=US","thumbprint": "9D808D63D1C8B79A152C92C455303D2DC861A910","createdDate": "1/24/2025 9:51:14 PM","expiryDate": "1/31/2025 9:51:14 PM","status": "Active"}}
```

This command gets a trusted signing certificate profile

### Example 2: List Trusted Signing Certificate Profiles
```powershell
Get-AzTrustedSigningCertificateProfile -AccountName test -ResourceGroupName rg-test

```

```output
City    CommonName              Country EnhancedKeyUsage                                               Id                                                                                                                                                                 IdentityValidationId                 IncludeCity IncludeCountry IncludePostalCode IncludeState IncludeStreetAddress Name    Organization OrganizationUnit PostalCode ProfileType     ProvisioningState ResourceGroupName RetryAfter State      Status StreetAddress SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                                                          Certificate
----    ----------              ------- ----------------                                               --                                                                                                                                                                 --------------------                 ----------- -------------- ----------------- ------------ -------------------- ----    ------------ ---------------- ---------- -----------     ----------------- ----------------- ---------- -----      ------ ------------- -------------------   ------------------- ----------------------- ------------------------ ------------------------             ---------------------------- ----                                                          -----------
Barstow Contoso News(TEST ONLY) US      1.3.6.1.4.1.311.97.1.2.100309390.866961637.294916062.541502583 /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test/certificateProfiles/test       18f2c413-51a1-4990-a0b6-83e19b7c5991                                                                                janielm Contoso News                  92312      PublicTrustTest Succeeded         rg-test                      California Active 5th street    1/24/2025 10:01:04 PM test@example.com    User                    2/3/2025 9:18:57 PM      81af9eaf-3a7b-43eb-bc59-c504bfe12240 Application                  microsoft.codesigning/codesigningaccounts/certificateprofiles {{ "serialNumber": "55000A50AE054B71AB92557ACF0000000A50AE","subjectName": "CN=Contoso News(TEST ONLY), O=Contoso News, L=Barstow, S=California, C=US","thumbprint": "9D808D63D1C8B79A152C92C455303D2DC861A910","createdDate": "1/24/2025 9:51:14 PM","expiryDate": "1/31/2025 9:51:14 PM","status": "Active"}}
```

This command lists trusted signing certificate profiles

## PARAMETERS

### -AccountName
Trusted Signing account name.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CodeSigningAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ITrustedSigningIdentity
Parameter Sets: GetViaIdentityCodeSigningAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ITrustedSigningIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Certificate profile name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCodeSigningAccount
Aliases:

Required: True
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ITrustedSigningIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ICertificateProfile

## NOTES

## RELATED LINKS

