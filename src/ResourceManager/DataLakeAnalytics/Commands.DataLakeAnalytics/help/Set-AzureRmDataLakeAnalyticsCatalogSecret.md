---
external help file: Microsoft.Azure.Commands.DataLakeAnalytics.dll-Help.xml
ms.assetid: CAB32C72-5C16-467E-BC57-749EC49916BB
online version: 
schema: 2.0.0
---

# Set-AzureRmDataLakeAnalyticsCatalogSecret

## SYNOPSIS
Modifies a Data Lake Analytics catalog secret.

## SYNTAX

### Specify full URI
```
Set-AzureRmDataLakeAnalyticsCatalogSecret [-Account] <String> [-DatabaseName] <String> [-Secret] <PSCredential>
 [-DatabaseHost] <String> [-Port] <Int32> [<CommonParameters>]
```

### Specify host name and port
```
Set-AzureRmDataLakeAnalyticsCatalogSecret [-Account] <String> [-DatabaseName] <String> [-Secret] <PSCredential>
 [-Uri] <Uri> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmDataLakeAnalyticsCatalogSecret** cmdlet modifies a secret associated with an Azure Data Lake Analytics catalog.

## EXAMPLES

### Example 1: Modify the secret associated with an account
```
PS C:\>Set-AzureRmDataLakeAnalyticsCatalogSecret -Account "ContosoAdlAccount" -DatabaseName "databaseName" -Secret (Get-Credential) -Host "https://example.contoso.com" -Port 8080
```

This command sets the secret associated with a Data Lake Analytics catalog.

## PARAMETERS

### -Account
Specifies the Data Lake Analytics account name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseHost
Specifies the host name for the database the secret is associated with in the format 'mydatabase.contoso.com'.

```yaml
Type: String
Parameter Sets: Specify full URI
Aliases: Host

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseName
Specifies the name of the database holding the secret.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Port
Specifies the port number of the secret.

```yaml
Type: Int32
Parameter Sets: Specify full URI
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Secret
Specifies the name and password of the secret.

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Uri
Specifies the Uniform Resource Identifier (URI) for the secret.

```yaml
Type: Uri
Parameter Sets: Specify host name and port
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[New-AzureRmDataLakeAnalyticsCatalogSecret](./New-AzureRmDataLakeAnalyticsCatalogSecret.md)

[Remove-AzureRmDataLakeAnalyticsCatalogSecret](./Remove-AzureRmDataLakeAnalyticsCatalogSecret.md)


