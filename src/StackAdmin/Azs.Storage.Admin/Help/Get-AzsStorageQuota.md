---
external help file: Azs.Storage.Admin-help.xml
Module Name: Azs.Storage.Admin
online version: 
schema: 2.0.0
---

# Get-AzsStorageQuota

## SYNOPSIS
Returns a list of storage quotas at the given location.

## SYNTAX

### List (Default)
```
Get-AzsStorageQuota [-Location <String>] [-Skip <Int32>] [-Top <Int32>] [<CommonParameters>]
```

### Get
```
Get-AzsStorageQuota [-QuotaName] <String> [-Location <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsStorageQuota -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns a list of storage quotas at the given location.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsStorageQuota -Location local
```

Name       Location   CapacityIn NumberOfSt
					  Gb         orageAccou
								 nts
----       --------   ---------- ----------
local/D...
local      2048       20
   local/T...
local      50         100

   Get the list of storage quotas at the given location.

## PARAMETERS

### -Location
Resource location.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QuotaName
{{Fill QuotaName Description}}

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Storage.Admin.Models.StorageQuota

## NOTES

## RELATED LINKS

