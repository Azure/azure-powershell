---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Anf.dll-Help.xml
Module Name: Az.anf
online version:
schema: 2.0.0
---

# Get-AzAnfPool

## SYNOPSIS
Gets details of an Azure NetApp Files (ANF) pool.

## SYNTAX

### ByFieldsParameterSet
```
Get-AzAnfPool -ResourceGroupName <String> -AccountName <String> [-PoolName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResouceIdParameterSet
```
Get-AzAnfPool -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzAnfPool** cmdlet gets details of an ANF pool.

## EXAMPLES

### Example 1: Get an ANF pool
```
PS C:\>Get-AzAnfPool -AccountName "MyAnfAccount" -PoolName "MyAnfPool"
```

This command gets the account named MyAnfPool from the account "MyAnfAccount".

## PARAMETERS

### -AccountName
The name of the ANF account

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

### -PoolName
The name of the ANF pool

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

### -ResourceGroupName
The resource group of the ANF pool

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
The resource id of the ANF pool

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

### Microsoft.Azure.Commands.Anf.Models.PSAnfPool

## NOTES

## RELATED LINKS
