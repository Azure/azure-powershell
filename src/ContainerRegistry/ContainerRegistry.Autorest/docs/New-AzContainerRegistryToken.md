---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/new-azcontainerregistrytoken
schema: 2.0.0
---

# New-AzContainerRegistryToken

## SYNOPSIS
Creates a token for a container registry with the specified parameters.

## SYNTAX

```
New-AzContainerRegistryToken -Name <String> -RegistryName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CredentialsCertificate <ITokenCertificate[]>]
 [-CredentialsPassword <ITokenPassword[]>] [-ScopeMapId <String>] [-Status <TokenStatus>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a token for a container registry with the specified parameters.

## EXAMPLES

### Example 1: Create new token for certain container registry
```powershell
New-AzContainerRegistryToken -Name token2 -RegistryName lnxcr -ResourceGroupName lnxtest -ScopeMapId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lnxtest/providers/Microsoft.ContainerRegistry/registries/lnxcr/scopeMaps/newmap
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLa
                                                                                                      stModifiedBy
----   ------------------- -------------------       ----------------------- ------------------------ ------------
token 01/20/2023 05:14:16  user@microsoft.com User                01/20/2023 05:14:16                       user

```

Create new token for certain container registry

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

### -CredentialsCertificate
.
To construct, see NOTES section for CREDENTIALSCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.ITokenCertificate[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CredentialsPassword
.
To construct, see NOTES section for CREDENTIALSPASSWORD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.ITokenPassword[]
Parameter Sets: (All)
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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the token.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: TokenName

Required: True
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

### -RegistryName
The name of the container registry.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ScopeMapId
The resource ID of the scope map to which the token will be associated with.

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

### -Status
The status of the token example enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.TokenStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IToken

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CREDENTIALSCERTIFICATE <ITokenCertificate[]>`: .
  - `[EncodedPemCertificate <String>]`: Base 64 encoded string of the public certificate1 in PEM format that will be used for authenticating the token.
  - `[Expiry <DateTime?>]`: The expiry datetime of the certificate.
  - `[Name <TokenCertificateName?>]`: 
  - `[Thumbprint <String>]`: The thumbprint of the certificate.

`CREDENTIALSPASSWORD <ITokenPassword[]>`: .
  - `[CreationTime <DateTime?>]`: The creation datetime of the password.
  - `[Expiry <DateTime?>]`: The expiry datetime of the password.
  - `[Name <TokenPasswordName?>]`: The password name "password1" or "password2"

## RELATED LINKS

