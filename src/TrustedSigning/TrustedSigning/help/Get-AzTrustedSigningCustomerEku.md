---
external help file: Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.dll-Help.xml
Module Name: Az.TrustedSigning
online version: https://learn.microsoft.com/powershell/module/az.trustedsigning/get-aztrustedsigningcustomereku
schema: 2.0.0
---

# Get-AzTrustedSigningCustomerEku

## SYNOPSIS
Retrieve Azure.CodeSigning customer Eku

## SYNTAX

### ByAccountProfileNameParameterSet (Default)
```
Get-AzTrustedSigningCustomerEku [-AccountName] <String> [-ProfileName] <String> [-EndpointUrl] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByMetadataFileParameterSet
```
Get-AzTrustedSigningCustomerEku [-MetadataFilePath] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzCodeSigningCustomerEku ** cmdlet retrieves customer Eku.
Use this cmdlet to retrieve customer Eku.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.

## EXAMPLES

### Example 1: Retrieve customer Eku by account and profile name
```powershell
Get-AzCodeSigningCustomerEku -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.codesigning.azure.net'
```

```output
1.3.6.1.5.5.7.3.0
```

This command retrieves the customer eku by account and profile name.

### Example 2: Retrieve customer Eku by metadata file path

```powershell
Get-AzCodeSigningCustomerEku -MetadataFilePath 'c:\cisigning\metadata_input.json'
```

```output
1.3.6.1.5.5.7.3.0
```

This command retrieves the customer eku by the metadata file configuration.

## PARAMETERS

### -AccountName
The account name of Azure CodeSigning.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -EndpointUrl
The endpoint url used to submit request to Azure CodeSigning.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MetadataFilePath
Metadata File path.
Cmdlet constructs the FQDN of an account profile based on the Metadata File and currently selected environment.

```yaml
Type: System.String
Parameter Sets: ByMetadataFileParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProfileName
The certificate profile name of Azure CodeSigning account.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.String[]

## NOTES

## RELATED LINKS
