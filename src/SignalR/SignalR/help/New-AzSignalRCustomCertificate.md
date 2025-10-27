---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/new-azsignalrcustomcertificate
schema: 2.0.0
---

# New-AzSignalRCustomCertificate

## SYNOPSIS
Create a custom certificate reference for a SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
New-AzSignalRCustomCertificate [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String>
 -KeyVaultBaseUri <String> -KeyVaultSecretName <String> [-KeyVaultSecretVersion <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
New-AzSignalRCustomCertificate [-Name] <String> -KeyVaultBaseUri <String> -KeyVaultSecretName <String>
 [-KeyVaultSecretVersion <String>] -SignalRObject <PSSignalRResource> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a custom certificate reference for a SignalR service. The certificate is stored in Azure Key Vault and referenced by the SignalR service for custom domain configuration.

## EXAMPLES

### Example 1: Create a custom certificate by resource group and SignalR service name
```powershell
New-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myCertificate" -KeyVaultBaseUri "https://myvault.vault.azure.net/" -KeyVaultSecretName "mycert"
```

This command creates a custom certificate named "myCertificate" for the SignalR service "mySignalR" using a certificate stored in Key Vault.

### Example 2: Create a custom certificate with specific version
```powershell
New-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myCertificate" -KeyVaultBaseUri "https://myvault.vault.azure.net/" -KeyVaultSecretName "mycert" -KeyVaultSecretVersion "abc123def456"
```

This command creates a custom certificate with a specific certificate version from Key Vault.

### Example 3: Create a custom certificate using SignalR resource object
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myResourceGroup" -Name "mySignalR"
$signalr | New-AzSignalRCustomCertificate -Name "myCertificate" -KeyVaultBaseUri "https://myvault.vault.azure.net/" -KeyVaultSecretName "mycert"
```

This command creates a custom certificate using a SignalR resource object as input.

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

### -KeyVaultBaseUri
Base URI of the KeyVault that stores certificate.

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

### -KeyVaultSecretName
Certificate secret name.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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

Required: False
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

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSCustomCertificateResource

## NOTES

## RELATED LINKS
