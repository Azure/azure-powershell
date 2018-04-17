---
external help file: Azs.Storage.Admin-help.xml
Module Name: Azs.Storage.Admin
online version: 
schema: 2.0.0
---

# Start-AzsStorageContainerMigration

## SYNOPSIS
Starts a container migration job to migrate containers to the specified destination share.

## SYNTAX

```
Start-AzsStorageContainerMigration -StorageAccountName <String> -ContainerName <String> -ShareName <String>
 [-ResourceGroupName <String>] -FarmName <String> -DestinationShareUncPath <String> [-Wait]
 [<CommonParameters>]
```

## DESCRIPTION
Starts a container migration job to migrate containers to the specified destination share.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Start-AzsStorageContainerMigration -StorageAccountName "accountTest" -ContainerName "containerTest" -ShareName "shareTest" -FarmName "10e8d576-d73c-454c-a40a-aee31a77a5f0" -DestinationShareUncPath "\\127.0.0.1\C$\Test"
```

Starts a container migration.

## PARAMETERS

### -ContainerName
The name of the container to be migrated.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationShareUncPath
The UNC path of the destination share for migration.

```yaml
Type: String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name in which the storage resource provider was registered under.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShareName
Name of the share containing the container specified for migration.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountName
The name of storage account where the container locates.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Wait
{{Fill Wait Description}}

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

