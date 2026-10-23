---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/new-azkeyvaultmanagedhsmekmconnection
schema: 2.0.0
---

# New-AzKeyVaultManagedHsmEkmConnection

## SYNOPSIS
Creates the External Key Manager (EKM) connection on a Managed HSM.

## SYNTAX

### ByHsmName (Default)
```
New-AzKeyVaultManagedHsmEkmConnection -HostName <String> [-ConnectivityMode <String>]
 -ServerCaCertificate <String[]> [-PathPrefix <String>] [-ServerSubjectCommonName <String>] [-HsmName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByHsmId
```
New-AzKeyVaultManagedHsmEkmConnection -HostName <String> [-ConnectivityMode <String>]
 -ServerCaCertificate <String[]> [-PathPrefix <String>] [-ServerSubjectCommonName <String>] [-HsmId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByInputObject
```
New-AzKeyVaultManagedHsmEkmConnection -HostName <String> [-ConnectivityMode <String>]
 -ServerCaCertificate <String[]> [-PathPrefix <String>] [-ServerSubjectCommonName <String>]
 [-HsmObject] <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzKeyVaultManagedHsmEkmConnection** cmdlet creates the External Key Manager (EKM) connection on a Managed HSM, wiring the HSM to an EKM proxy. At least one server CA certificate is required. Multiple PEM or DER files and PEM certificate chains are accepted. Creating a connection is not an upsert; use Update to change an existing connection.

The optional ConnectivityMode parameter is in preview. Public hosts default to port 443. In PrivateEndpoint mode, HostName is the endpoint name without a port. Omitting ConnectivityMode leaves the service default unchanged.

## EXAMPLES

### Example 1: Create an EKM connection on a Managed HSM
```powershell
New-AzKeyVaultManagedHsmEkmConnection -HsmName testmhsm -HostName ekm.contoso.com -ServerCaCertificate ./ekm-proxy-ca.cer
```

This cmdlet creates an EKM connection on the Managed HSM named `testmhsm`, pointing at the EKM proxy host `ekm.contoso.com` (port 443).

### Example 2: Create an EKM connection with a path prefix and multiple CA certificates
```powershell
New-AzKeyVaultManagedHsmEkmConnection -HsmName testmhsm -HostName ekm.contoso.com:8443 -PathPrefix /api/v1 -ServerCaCertificate ./ca1.pem, ./ca2.pem -ServerSubjectCommonName ekm.contoso.com
```

This cmdlet creates an EKM connection that targets `ekm.contoso.com:8443`, appends the path prefix `/api/v1`, trusts two CA certificates, and validates the proxy server certificate Common Name.

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
Preview: Public uses a proxy host and port; PrivateEndpoint uses the name of an EKM private endpoint.

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

Required: True
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

Required: True
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

[Get-AzKeyVaultManagedHsmEkmConnection](./Get-AzKeyVaultManagedHsmEkmConnection.md)

[Update-AzKeyVaultManagedHsmEkmConnection](./Update-AzKeyVaultManagedHsmEkmConnection.md)

[Remove-AzKeyVaultManagedHsmEkmConnection](./Remove-AzKeyVaultManagedHsmEkmConnection.md)

[Test-AzKeyVaultManagedHsmEkmConnection](./Test-AzKeyVaultManagedHsmEkmConnection.md)
