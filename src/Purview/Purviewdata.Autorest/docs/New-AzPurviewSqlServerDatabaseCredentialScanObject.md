---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewsqlserverdatabasecredentialscanobject
schema: 2.0.0
---

# New-AzPurviewSqlServerDatabaseCredentialScanObject

## SYNOPSIS
Create an in-memory object for SqlServerDatabaseCredentialScan.

## SYNTAX

```
New-AzPurviewSqlServerDatabaseCredentialScanObject [-CollectionReferenceName <String>]
 [-CollectionType <String>] [-ConnectedViaReferenceName <String>] [-CredentialReferenceName <String>]
 [-CredentialType <String>] [-DatabaseName <String>] [-ScanRulesetName <String>] [-ScanRulesetType <String>]
 [-ServerEndpoint <String>] [-Worker <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SqlServerDatabaseCredentialScan.

## EXAMPLES

### Example 1: Create Sql Server DB Credential scan object
```powershell
New-AzPurviewSqlServerDatabaseCredentialScanObject -Kind 'SqlServerDatabaseCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'sqlauth' -CredentialType 'SqlAuth' -DatabaseName 'db' -ScanRulesetName 'SqlServer' -ScanRulesetType 'Custom' -ServerEndpoint '10.1.2.1' -ConnectedViaReferenceName 'IntegrationRuntime-NJh'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName : IntegrationRuntime-NJh
CreatedAt                 :
CredentialReferenceName   : sqlauth
CredentialType            : SqlAuth
DatabaseName              : db
Id                        :
Kind                      : SqlServerDatabaseCredential
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : SqlServer
ScanRulesetType           : Custom
ServerEndpoint            : 10.1.2.1
Worker                    :
```

Create Swl Server DB Credential scan object

## PARAMETERS

### -CollectionReferenceName


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

### -CollectionType


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

### -ConnectedViaReferenceName


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

### -CredentialReferenceName


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

### -CredentialType


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

### -DatabaseName


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

### -ScanRulesetName


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

### -ScanRulesetType


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

### -ServerEndpoint


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

### -Worker


```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.SqlServerDatabaseCredentialScan

## NOTES

ALIASES

## RELATED LINKS

