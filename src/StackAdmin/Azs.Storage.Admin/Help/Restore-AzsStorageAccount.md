---
external help file: Azs.Storage.Admin-help.xml
Module Name: Azs.Storage.Admin
online version: 
schema: 2.0.0
---

# Restore-AzsStorageAccount

## SYNOPSIS
Undelete a deleted storage account.

## SYNTAX

### Undelete (Default)
```
Restore-AzsStorageAccount -FarmName <String> -AccountId <String> [-ResourceGroupName <String>]
 [<CommonParameters>]
```

### ResourceId
```
Restore-AzsStorageAccount -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Undelete a deleted storage account.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Restore-AzsStorageAccount -FarmName "90987d65-eb60-42ae-b735-18bcd7ff69da" -AccountId "83fe9ac0-f1e7-433e-b04c-c61ae0712093"
```

Undelete a deleted storage account.

## PARAMETERS

### -AccountId
Internal storage account ID, which is not visible to tenant.

```yaml
Type: String
Parameter Sets: Undelete
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FarmName
Farm Id.

```yaml
Type: String
Parameter Sets: Undelete
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: String
Parameter Sets: Undelete
Aliases: 

Required: False
Position: Named
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

