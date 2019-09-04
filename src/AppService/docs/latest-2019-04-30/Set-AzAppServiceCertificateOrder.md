---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/set-azappservicecertificateorder
schema: 2.0.0
---

# Set-AzAppServiceCertificateOrder

## SYNOPSIS
Create or update a certificate purchase order.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzAppServiceCertificateOrder -CertificateOrderName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -Location <String> [-AutoRenew] [-Certificate <Hashtable>] [-Csr <String>]
 [-DistinguishedName <String>] [-KeySize <Int32>] [-Kind <String>] [-ProductType <CertificateProductType>]
 [-Tag <Hashtable>] [-ValidityInYear <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzAppServiceCertificateOrder -CertificateOrderName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -CertificateDistinguishedName <IAppServiceCertificateOrder>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a certificate purchase order.

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
Dynamic: False
```

### -AutoRenew
\<code\>true\</code\> if the certificate should be automatically renewed when it expires; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Certificate
State of the Key Vault secret.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CertificateDistinguishedName
SSL certificate purchase order.
To construct, see NOTES section for CERTIFICATEDISTINGUISHEDNAME properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IAppServiceCertificateOrder
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -CertificateOrderName
Name of the certificate order.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Csr
Last CSR that was created for this order.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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

### -DistinguishedName
Certificate distinguished name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeySize
Certificate key size.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource Location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -ProductType
Certificate product type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.CertificateProductType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ValidityInYear
Duration in years (must be between 1 and 3).

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IAppServiceCertificateOrder

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IAppServiceCertificateOrder

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CERTIFICATEDISTINGUISHEDNAME <IAppServiceCertificateOrder>: SSL certificate purchase order.
  - `Location <String>`: Resource Location.
  - `ProductType <CertificateProductType>`: Certificate product type.
  - `[Kind <String>]`: Kind of resource.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AutoRenew <Boolean?>]`: <code>true</code> if the certificate should be automatically renewed when it expires; otherwise, <code>false</code>.
  - `[Certificate <IAppServiceCertificateOrderPropertiesCertificates>]`: State of the Key Vault secret.
    - `[(Any) <IAppServiceCertificate>]`: This indicates any property can be added to this object.
  - `[Csr <String>]`: Last CSR that was created for this order.
  - `[DistinguishedName <String>]`: Certificate distinguished name.
  - `[KeySize <Int32?>]`: Certificate key size.
  - `[ValidityInYear <Int32?>]`: Duration in years (must be between 1 and 3).

## RELATED LINKS

