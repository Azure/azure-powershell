---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermapplicationgatewaytrustedrootcertificate
schema: 2.0.0
---

# New-AzureRmApplicationGatewayTrustedRootCertificate

## SYNOPSIS
Creates a Trusted Root Certificate for an application gateway.

## SYNTAX

```
New-AzureRmApplicationGatewayTrustedRootCertificate -Name <String> -CertificateFile <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmApplicationGatewayTrustedRootCertificate** cmdlet creates a Trusted Root Certificate for an Azure application gateway.

## EXAMPLES

### Example 1
```powershell
PS C:\> $certFilePath = ".\rootCA.cer"
PS C:\> $trc = New-AzureRmApplicationGatewayTrustedRootCertificate -Name "trc1" --CertificateFile $certFilePath
```

This command creates a Trusted Root Certificate named List "trc1" and stores the result in the variable named $trc.

## PARAMETERS

### -CertificateFile
Path of certificate CER file

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the TrustedRoot certificate

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayTrustedRootCertificate

## NOTES

## RELATED LINKS
