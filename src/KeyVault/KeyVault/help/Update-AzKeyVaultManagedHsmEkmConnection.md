---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/update-azkeyvaultmanagedhsmekmconnection
schema: 2.0.0
---

# Update-AzKeyVaultManagedHsmEkmConnection

## SYNOPSIS
Updates the External Key Manager (EKM) connection on a Managed HSM. (Preview)

## SYNTAX

### ByHsmName (Default)
```
Update-AzKeyVaultEkmConnection [-HsmName] <String> [-HostName <String>] [-ServerCaCertificate <String[]>]
 [-PathPrefix <String>] [-ServerSubjectCommonName <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHsmId
```
Update-AzKeyVaultEkmConnection [-HsmId] <String> [-HostName <String>] [-ServerCaCertificate <String[]>]
 [-PathPrefix <String>] [-ServerSubjectCommonName <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
Update-AzKeyVaultEkmConnection [-HsmObject] <PSManagedHsm> [-HostName <String>] [-ServerCaCertificate <String[]>]
 [-PathPrefix <String>] [-ServerSubjectCommonName <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzKeyVaultEkmConnection** cmdlet updates the External Key Manager (EKM) connection on a Managed HSM. Only the parameters you specify are changed; the others are preserved. This feature is in preview.

## EXAMPLES

### Example 1: Update the EKM proxy host
```powershell
Update-AzKeyVaultEkmConnection -HsmName testmhsm -HostName ekm2.contoso.com:8443
```

This cmdlet updates the EKM connection on the Managed HSM named `testmhsm` to point at `ekm2.contoso.com:8443`, leaving the other settings unchanged.

### Example 2: Rotate the server CA certificates
```powershell
Update-AzKeyVaultEkmConnection -HsmName testmhsm -ServerCaCertificate ./new-ca.pem
```

This cmdlet replaces the server CA certificates configured on the EKM connection.

## PARAMETERS

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostName
EKM proxy host (FQDN or FQDN:port). If the port is omitted, 443 is assumed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Host

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmId
Resource Id of the HSM.

```yaml
Type: System.String
Parameter Sets: ByHsmId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmName
Name of the HSM.

```yaml
Type: System.String
Parameter Sets: ByHsmName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmObject
HSM object.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PathPrefix
Optional path prefix appended to EKM proxy requests. Must start with "/".

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

### -ServerCaCertificate
Path(s) to one or more server CA certificate(s) in PEM or DER format.

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

### -ServerSubjectCommonName
Optional expected Common Name (CN) for the EKM proxy server certificate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ServerCn

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultEkmConnection

## NOTES

## RELATED LINKS

[New-AzKeyVaultEkmConnection](./New-AzKeyVaultEkmConnection.md)

[Get-AzKeyVaultEkmConnection](./Get-AzKeyVaultEkmConnection.md)

[Remove-AzKeyVaultEkmConnection](./Remove-AzKeyVaultEkmConnection.md)
