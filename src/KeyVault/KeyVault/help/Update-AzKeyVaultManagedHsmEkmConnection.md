---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/update-azkeyvaultmanagedhsmekmconnection
schema: 2.0.0
---

# Update-AzKeyVaultManagedHsmEkmConnection

## SYNOPSIS
Updates the External Key Manager (EKM) connection on a Managed HSM.

## SYNTAX

### ByHsmName (Default)
```
Update-AzKeyVaultManagedHsmEkmConnection [-HostName <String>] [-ConnectivityMode <String>]
 [-ServerCaCertificate <String[]>] [-PathPrefix <String>] [-ServerSubjectCommonName <String>]
 [-HsmName] <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByHsmId
```
Update-AzKeyVaultManagedHsmEkmConnection [-HostName <String>] [-ConnectivityMode <String>]
 [-ServerCaCertificate <String[]>] [-PathPrefix <String>] [-ServerSubjectCommonName <String>] [-HsmId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByInputObject
```
Update-AzKeyVaultManagedHsmEkmConnection [-HostName <String>] [-ConnectivityMode <String>]
 [-ServerCaCertificate <String[]>] [-PathPrefix <String>] [-ServerSubjectCommonName <String>]
 [-HsmObject] <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzKeyVaultManagedHsmEkmConnection** cmdlet updates the External Key Manager (EKM) connection on a Managed HSM. Only the parameters you specify are changed; the others are preserved.

ConnectivityMode is in preview. Omitting it preserves the current mode, including PrivateEndpoint mode. Changing modes requires an explicit HostName. Public mode uses a proxy host and port; PrivateEndpoint mode uses an endpoint name without a port.

## EXAMPLES

### Example 1: Update the EKM proxy host
```powershell
Update-AzKeyVaultManagedHsmEkmConnection -HsmName testmhsm -HostName ekm2.contoso.com:8443
```

This cmdlet updates the EKM connection on the Managed HSM named `testmhsm` to point at `ekm2.contoso.com:8443`, leaving the other settings unchanged.

### Example 2: Rotate the server CA certificates
```powershell
Update-AzKeyVaultManagedHsmEkmConnection -HsmName testmhsm -ServerCaCertificate ./new-ca.pem
```

This cmdlet replaces the server CA certificates configured on the EKM connection.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: String
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectivityMode
Preview: connectivity mode. Supply HostName when changing modes; omitting the mode preserves the existing value.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Public, PrivateEndpoint

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
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
Type: String
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
Type: String
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
Type: String
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
Type: PSManagedHsm
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
Type: String
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
Type: String[]
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
Type: String
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
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

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultEkmConnection

## NOTES

## RELATED LINKS

[New-AzKeyVaultManagedHsmEkmConnection](./New-AzKeyVaultManagedHsmEkmConnection.md)

[Get-AzKeyVaultManagedHsmEkmConnection](./Get-AzKeyVaultManagedHsmEkmConnection.md)

[Remove-AzKeyVaultManagedHsmEkmConnection](./Remove-AzKeyVaultManagedHsmEkmConnection.md)
