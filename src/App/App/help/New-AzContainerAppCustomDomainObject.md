---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappcustomdomainobject
schema: 2.0.0
---

# New-AzContainerAppCustomDomainObject

## SYNOPSIS
Create an in-memory object for CustomDomain.

## SYNTAX

```
New-AzContainerAppCustomDomainObject -Name <String> [-BindingType <String>] [-CertificateId <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CustomDomain.

## EXAMPLES

### Example 1: Create an in-memory object for CustomDomain.
```powershell
$certificateId = (Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-env-cert).Id

New-AzContainerAppCustomDomainObject -Name "www.my-name.com" -BindingType "SniEnabled" -CertificateId $certificateId
```

```output
BindingType CertificateId                                                                                                                                 Name
----------- -------------                                                                                                                                 ----
SniEnabled  /subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/managedEnvironments/{manageEnvName}/certificates/{testcert} www.my-name.com
```

Create an in-memory object for CustomDomain.

## PARAMETERS

### -BindingType
Custom Domain binding type.

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

### -CertificateId
Resource Id of the Certificate to be bound to this hostname.
Must exist in the Managed Environment.

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
Hostname.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.CustomDomain

## NOTES

## RELATED LINKS
