---
external help file:
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/Az.VMware/new-azvmwarevcf5licenseobject
schema: 2.0.0
---

# New-AzVMwareVcf5LicenseObject

## SYNOPSIS
Create an in-memory object for Vcf5License.

## SYNTAX

```
New-AzVMwareVcf5LicenseObject -Core <Int32> -EndDate <DateTime> [-BroadcomContractNumber <String>]
 [-BroadcomSiteId <String>] [-Label <ILabel[]>] [-LicenseKey <SecureString>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Vcf5License.

## EXAMPLES

### Example 1: Create an in-memory object for Vcf5License.
```powershell
New-AzVMwareVcf5LicenseObject -Core 16 -EndDate (Get-Date "2027-01-01") -LicenseKey (ConvertTo-SecureString "YOUR-LICENSE-KEY" -AsPlainText -Force) -BroadcomSiteId "site123" -BroadcomContractNumber "contract123"
```

```output
Core EndDate               Kind
---- -------               ----
  16 1/1/2027 12:00:00 AM  vcf5
```

Creates an in-memory VMware Cloud Foundation (VCF) 5.0 license object to pass to `New-AzVMwarePrivateCloud` via the `-VcfLicense` parameter.

## PARAMETERS

### -BroadcomContractNumber
The Broadcom contract number associated with the license.

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

### -BroadcomSiteId
The Broadcom site ID associated with the license.

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

### -Core
Number of cores included in the license.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndDate
UTC datetime when the license expires.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
Additional labels passed through for license reporting.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.ILabel[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LicenseKey
License key.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Vcf5License

## NOTES

## RELATED LINKS

