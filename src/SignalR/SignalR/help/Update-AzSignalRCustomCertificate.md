---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version:
schema: 2.0.0
---

# Update-AzSignalRCustomCertificate

## SYNOPSIS
Update a custom certificate for a SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Update-AzSignalRCustomCertificate -ResourceGroupName <String> -SignalRName <String> [-Name] <String>
 [-KeyVaultBaseUri <String>] [-KeyVaultSecretName <String>] [-KeyVaultSecretVersion <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Update-AzSignalRCustomCertificate [-Name] <String> -SignalRObject <PSSignalRResource>
 [-KeyVaultBaseUri <String>] [-KeyVaultSecretName <String>] [-KeyVaultSecretVersion <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Update-AzSignalRCustomCertificate -InputObject <PSCustomCertificateResource> [-KeyVaultBaseUri <String>]
 [-KeyVaultSecretName <String>] [-KeyVaultSecretVersion <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzSignalRCustomCertificate [-KeyVaultBaseUri <String>] [-KeyVaultSecretName <String>]
 [-KeyVaultSecretVersion <String>] [-AsJob] -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing custom certificate for a SignalR service. This can be used to update the Key Vault reference or change to a different certificate version.

## EXAMPLES

### Example 1: Update a custom certificate with new Key Vault version
```powershell
Update-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myCertificate" -KeyVaultSecretVersion "def456ghi789"
```

This command updates the custom certificate to use a new version of the certificate from Key Vault.

### Example 2: Update a custom certificate using certificate object
```powershell
$cert = Get-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myCertificate"
Update-AzSignalRCustomCertificate -InputObject $cert -KeyVaultSecretVersion "def456ghi789"
```

This command updates the custom certificate using an existing certificate object.

### Example 3: Update a custom certificate with new Key Vault reference
```powershell
Update-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myCertificate" -KeyVaultBaseUri "https://mynewvault.vault.azure.net/" -KeyVaultSecretName "mynewcert"
```

This command updates the custom certificate to reference a different certificate in Key Vault.

## PARAMETERS

### -AsJob
Run the cmdlet in background job.

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

### -InputObject
The SignalR custom certificate resource object.

```yaml
Type: Microsoft.Azure.Commands.SignalR.Models.PSCustomCertificateResource
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultBaseUri
Base URI of the KeyVault that stores certificate.

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

### -KeyVaultSecretName
Certificate secret name.

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

### -KeyVaultSecretVersion
Certificate secret version.

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
The custom certificate name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet, InputSignalRObjectParameterSet
Aliases:

Required: True
Position: 0
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

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The SignalR custom certificate resource Id.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignalRName
The SignalR service name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignalRObject
The SignalR resource object.

```yaml
Type: Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource
Parameter Sets: InputSignalRObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.SignalR.Models.PSCustomCertificateResource

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSCustomCertificateResource

## NOTES

## RELATED LINKS
