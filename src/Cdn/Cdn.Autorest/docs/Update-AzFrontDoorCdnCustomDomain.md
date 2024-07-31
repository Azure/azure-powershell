---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azfrontdoorcdncustomdomain
schema: 2.0.0
---

# Update-AzFrontDoorCdnCustomDomain

## SYNOPSIS
Updates an existing domain within a profile.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFrontDoorCdnCustomDomain -CustomDomainName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AzureDnsZoneId <String>] [-MtlSettingCertificatePassthrough <EnabledState>]
 [-MtlSettingCertificateValidation <EnabledState>] [-MtlSettingOcsp <EnabledState>]
 [-MtlSettingOtherAllowedFqdn <String[]>] [-MtlSettingSecret <IResourceReference[]>]
 [-PropertiesPreValidatedCustomDomainResourceId <String>] [-TlsSetting <IAfdDomainHttpsParameters>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFrontDoorCdnCustomDomain -InputObject <ICdnIdentity> [-AzureDnsZoneId <String>]
 [-MtlSettingCertificatePassthrough <EnabledState>] [-MtlSettingCertificateValidation <EnabledState>]
 [-MtlSettingOcsp <EnabledState>] [-MtlSettingOtherAllowedFqdn <String[]>]
 [-MtlSettingSecret <IResourceReference[]>] [-PropertiesPreValidatedCustomDomainResourceId <String>]
 [-TlsSetting <IAfdDomainHttpsParameters>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing domain within a profile.

## EXAMPLES

### Example 1: Update an AzureFrontDoor customdomain under the profile
```powershell
$secret =  Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
$secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
$updateTlsSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS10" -Secret $secretResoure
Update-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001 -TlsSetting $updateSetting
```

```output
Name      ResourceGroupName
----      -----------------
domain001 testps-rg-da16jm
```

Update an AzureFrontDoor customdomain under the profile

### Example 2: Update an AzureFrontDoor customdomain under the profile via identity
```powershell
$secret =  Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
$secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
$updateTlsSetting = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS10" -Secret $secretResoure
Get-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001 | Update-AzFrontDoorCdnCustomDomain -TlsSetting $updateSetting
```

```output
Name      ResourceGroupName
----      -----------------
domain001 testps-rg-da16jm
```

Update an AzureFrontDoor customdomain under the profile via identity

## PARAMETERS

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

### -AzureDnsZoneId
Resource ID.

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

### -CustomDomainName
Name of the domain under the profile which is unique globally

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MtlSettingCertificatePassthrough
Set to Disabled by default.
If set to Enabled, then selected client certificate chain(s) are sent directly to origin using reserved header.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MtlSettingCertificateValidation
Set to Enabled by default.
If set to Disabled, validation of client certificate chain for mutual TLS handshake will be skipped.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MtlSettingOcsp
Set to Enabled by default.
If set to Disabled, revocation status of client certificate chain will be checked before establishing mutual TLS connection.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MtlSettingOtherAllowedFqdn
List of FQDN that will be accepted for mutual TLS validation in addition to custom domain's hostname.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MtlSettingSecret
List of one or two of Resource References (ie.
subs/rg/profile/secret) to Secrets of type MtlsCertificateChain to use in mutual TLS handshake.
To construct, see NOTES section for MTLSETTINGSECRET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240501Preview.IResourceReference[]
Parameter Sets: (All)
Aliases:

Required: False
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
Name of the Azure Front Door Standard or Azure Front Door Premium profile which is unique within the resource group.

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

### -PropertiesPreValidatedCustomDomainResourceId
Resource ID.

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

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

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
Azure Subscription ID.

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

### -TlsSetting
The configuration specifying how to enable HTTPS for the domain - using AzureFrontDoor managed certificate or user's own certificate.
If not specified, enabling ssl uses AzureFrontDoor managed certificate by default.
To construct, see NOTES section for TLSSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240501Preview.IAfdDomainHttpsParameters
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240501Preview.IAfdDomain

## NOTES

## RELATED LINKS

