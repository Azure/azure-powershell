---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappcustomdomainobject
schema: 2.0.0
---

# New-AzContainerAppCustomDomainObject

## SYNOPSIS
Create an in-memory object for CustomDomain.

## SYNTAX

```
New-AzContainerAppCustomDomainObject -CertificateId <String> -Name <String> [-BindingType <BindingType>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CustomDomain.

## EXAMPLES

### Example 1: Create a CustomDomain object for ContainerApp.
```powershell
$certificateId = (Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp -Name azps-env-cert).Id

$customDomain = New-AzContainerAppCustomDomainObject -CertificateId $certificateId -Name www.fabrikam.com -BindingType SniEnabled
```

```output
BindingType CertificateId                                                                                                                                                Name
----------- -------------                                                                                                                                                ----
SniEnabled  /subscriptions/{subscriptionid}/resourceGroups/rg/providers/Microsoft.App/managedEnvironments/demokube/certificates/my-certificate-for-my-other-name-dot-com www.my-name.com
```

Create a CustomDomain object for ContainerApp.

## PARAMETERS

### -BindingType
Custom Domain binding type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType
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

Required: True
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.CustomDomain

## NOTES

ALIASES

## RELATED LINKS

