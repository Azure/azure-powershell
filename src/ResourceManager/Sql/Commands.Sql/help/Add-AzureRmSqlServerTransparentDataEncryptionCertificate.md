---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.sql/Add-AzureRmSqlServerTransparentDataEncryptionCertificate
schema: 2.0.0
---

# Add-AzureRmSqlServerTransparentDataEncryptionCertificate

## SYNOPSIS
Adds a Transparent Data Encryption Certificate for the given SQL Server instance

## SYNTAX

### AddAzureRmSqlServerTransparentDataEncryptionCertificate Input Object Parameter Set
```
Add-AzureRmSqlServerTransparentDataEncryptionCertificate [-SqlServer] <AzureSqlServerModel>
 [-PrivateBlob] <String> [-Password <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AddAzureRmSqlServerTransparentDataEncryptionCertificate Resource Id Parameter Set
```
Add-AzureRmSqlServerTransparentDataEncryptionCertificate [-SqlServerResourceId] <String> [-PrivateBlob] <String>
 [-Password <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AddAzureRmSqlServerTransparentDataEncryptionCertificate Default Parameter Set
```
Add-AzureRmSqlServerTransparentDataEncryptionCertificate [-ResourceGroupName] <String> [-ServerName] <String>
 [-PrivateBlob] <String> [-Password <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Add-AzureRmSqlManagedInstanceTransparentDataEncryptionCertificate adds a Transparent Data Encryption Certificate for the given SQL Server instance

## EXAMPLES

### Example 1
```powershell
PS C:\>     Add-AzureRmSqlServerTransparentDataEncryptionCertificate -ResourceGroupName "YourResourceGroupName" -ServerName "YourServerName" -PrivateBlob "MIIJ+QIBAzCCCbUGCSqGSIb3DQEHAaCCCaYEggmiMIIJnjCCBhcGCSqGSIb3Dasdsadasd" -Password "CertificatePassword"
```

Add TDE certificate to a sql server using resource group name and SQL Server name

### Example 2
```powershell
PS C:\>     $server = Get-AzureRmSqlServer -ServerName "YourServerName" -ResourceGroupName "YourResourceGroupName" 
PS C:\>     Add-AzureRmSqlServerTransparentDataEncryptionCertificate -SqlServerResourceId $server.ResourceId -PrivateBlob "MIIJ+QIBAzCCCbUGCSqGSIb3DQEHAaCCCaYEggmiMIIJnjCCBhcGCSqGSIb3Dasdsadasd" -Password "CertificatePassword"
```

Add TDE certificate to the servers using server resourceId

### Example 3
```powershell
Get-AzureRmSqlServer | Add-AzureRmSqlServerTransparentDataEncryptionCertificate -ResourceGroupName "YourResourceGroupName" -PrivateBlob "MIIJ+QIBAzCCCbUGCSqGSIb3DQEHAaCCCaYEggmiMIIJnjCCBhcGCSqGSIb3Dasdsadasd"-Password "CertificatePassword"

```
Add TDE certificate to all sql servers in a resource group


## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The sql server input object

```yaml
Type: AzureSqlServerModel
Parameter Sets: AddAzureRmSqlServerTransparentDataEncryptionCertificate Input Object Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Password
The Password for Transparent Data Encryption Certificate

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrivateBlob
The Private blob for Transparent Data Encryption Certificate

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

### -ResourceGroupName
The Resource Group Name

```yaml
Type: String
Parameter Sets: AddAzureRmSqlServerTransparentDataEncryptionCertificate Default Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The sql server resource id

```yaml
Type: String
Parameter Sets: AddAzureRmSqlServerTransparentDataEncryptionCertificate Resource Id Parameter Set
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
The Server Name

```yaml
Type: String
Parameter Sets: AddAzureRmSqlServerTransparentDataEncryptionCertificate Default Parameter Set
Aliases: AgentServerName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlServerModel
System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
