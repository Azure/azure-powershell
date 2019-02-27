---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Anf.dll-Help.xml
Module Name: Az.anf
online version:
schema: 2.0.0
---

# Get-AzAnfAccount

## SYNOPSIS
Gets details of an Azure NetApp Files (ANF) account.

## SYNTAX

### ByFieldsParameterSet
```
Get-AzAnfAccount -ResourceGroupName <String> [-AccountName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByResouceIdParameterSet
```
Get-AzAnfAccount -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzAnfAccount** cmdlet gets details of an ANF account.

## EXAMPLES

### Example 1: Get an ANF account
```
PS C:\>Get-AzAnfAccount -AccountName "MyAnfAccount"
```

This command gets the account named MyAnfAccount.


## PARAMETERS

### -AccountName
The name of the ANF account

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF account

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the ANF account

```yaml
Type: String
Parameter Sets: ByResouceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Anf.Models.PSAnfAccount

## NOTES

## RELATED LINKS
