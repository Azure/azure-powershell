---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/test-azappservicecertificateorderpurchaseinformation
schema: 2.0.0
---

# Test-AzAppServiceCertificateOrderPurchaseInformation

## SYNOPSIS
Validate information for a certificate order.

## SYNTAX

### Validate (Default)
```
Test-AzAppServiceCertificateOrderPurchaseInformation -SubscriptionId <String>
 [-AppServiceCertificateOrder <IAppServiceCertificateOrder>] [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ValidateExpanded
```
Test-AzAppServiceCertificateOrderPurchaseInformation -SubscriptionId <String> [-PassThru]
 [-AutoRenew <Boolean>] [-Certificate <IAppServiceCertificateOrderPropertiesCertificates>] [-Csr <String>]
 [-DistinguishedName <String>] [-KeySize <Int32>] [-Kind <String>] -Location <String>
 -ProductType <CertificateProductType> [-ProvisioningState <ProvisioningState>]
 [-Status <CertificateOrderStatus>] [-Tag <IResourceTags>] [-ValidityInYear <Int32>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzAppServiceCertificateOrderPurchaseInformation -InputObject <IWebSiteIdentity> [-PassThru]
 [-AutoRenew <Boolean>] [-Certificate <IAppServiceCertificateOrderPropertiesCertificates>] [-Csr <String>]
 [-DistinguishedName <String>] [-KeySize <Int32>] [-Kind <String>] -Location <String>
 -ProductType <CertificateProductType> [-ProvisioningState <ProvisioningState>]
 [-Status <CertificateOrderStatus>] [-Tag <IResourceTags>] [-ValidityInYear <Int32>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzAppServiceCertificateOrderPurchaseInformation -InputObject <IWebSiteIdentity>
 [-AppServiceCertificateOrder <IAppServiceCertificateOrder>] [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Validate information for a certificate order.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AppServiceCertificateOrder
SSL certificate purchase order.

```yaml
Type: IAppServiceCertificateOrder
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AutoRenew
\<code\>true\</code\> if the certificate should be automatically renewed when it expires; otherwise, \<code\>false\</code\>.

```yaml
Type: Boolean
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Certificate
State of the Key Vault secret.

```yaml
Type: IAppServiceCertificateOrderPropertiesCertificates
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Csr
Last CSR that was created for this order.

```yaml
Type: String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DistinguishedName
Certificate distinguished name.

```yaml
Type: String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: IWebSiteIdentity
Parameter Sets: ValidateViaIdentityExpanded, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeySize
Certificate key size.

```yaml
Type: Int32
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Kind of resource.

```yaml
Type: String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource Location.

```yaml
Type: String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProductType
Certificate product type.

```yaml
Type: CertificateProductType
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningState
Status of certificate order.

```yaml
Type: ProvisioningState
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Current order status.

```yaml
Type: CertificateOrderStatus
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: String
Parameter Sets: Validate, ValidateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: IResourceTags
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidityInYear
Duration in years (must be between 1 and 3).

```yaml
Type: Int32
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/test-azappservicecertificateorderpurchaseinformation](https://docs.microsoft.com/en-us/powershell/module/az.website/test-azappservicecertificateorderpurchaseinformation)

