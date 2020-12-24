---
external help file:
Module Name: Az.ADDomainServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServicesDomainSecuritySettingsObject
schema: 2.0.0
---

# New-AzADDomainServiceDomainSecuritySettingObject

## SYNOPSIS
Create a in-memory object for DomainSecuritySettings

## SYNTAX

```
New-AzADDomainServiceDomainSecuritySettingObject [-NtlmV1 <String>] [-SyncKerberosPassword <String>]
 [-SyncNtlmPassword <String>] [-SyncOnPremPassword <String>] [-TlsV1 <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for DomainSecuritySettings

## EXAMPLES

### Example 1: Create SecuritySetting for ADDOmain
```powershell
PS C:\> New-AzADDomainServiceDomainSecuritySettingObject -NtlmV1 Disabled -SyncKerberosPassword Disabled -SyncNtlmPassword Disabled -SyncOnPremPassword Disabled -TlsV1 Disabled

NtlmV1   SyncKerberosPassword SyncNtlmPassword SyncOnPremPassword TlsV1
------   -------------------- ---------------- ------------------ -----
Disabled Disabled             Disabled         Disabled           Disabled
```

Create SecuritySetting for ADDOmain

## PARAMETERS

### -NtlmV1
A flag to determine whether or not NtlmV1 is enabled or disabled.

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

### -SyncKerberosPassword


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

### -SyncNtlmPassword
A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.

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

### -SyncOnPremPassword
A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.

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

### -TlsV1
A flag to determine whether or not TlsV1 is enabled or disabled.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings

## NOTES

ALIASES

## RELATED LINKS

