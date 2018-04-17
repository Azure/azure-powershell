---
external help file: Azs.Storage.Admin-help.xml
Module Name: Azs.Storage.Admin
online version: 
schema: 2.0.0
---

# Get-AzsStorageContainerMigrationStatus

## SYNOPSIS
Returns the status of a container migration job.

## SYNTAX

### MigrationStatus (Default)
```
Get-AzsStorageContainerMigrationStatus -FarmName <String> -JobId <String> [-ResourceGroupName <String>]
 [<CommonParameters>]
```

### ResourceId
```
Get-AzsStorageContainerMigrationStatus -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns the status of a container migration job.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsStorageContainerMigrationStatus -FarmName "6ed442a3-ec47-4145-b2f0-9b90377b01d0" -JobId "6478ef3b-b7d5-4827-8d47-551c6afb9dd4"
```

jobId                : 6478ef3b-b7d5-4827-8d47-551c6afb9dd4
sourceShareName      : testSourceShare
StorageAccountName   : testStorageAccount
ContainerName        : testContainer
DestinationShareName : \\\\127.0.0.1\C$\Share
MigrationStatus      : Active
SubEntitiesCompleted : 0
SubEntitiesFailed    : 0
FailureReason        :

Get the status of a container migration job.

## PARAMETERS

### -FarmName
Farm Id.

```yaml
Type: String
Parameter Sets: MigrationStatus
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobId
{{Fill JobId Description}}

```yaml
Type: String
Parameter Sets: MigrationStatus
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
Parameter Sets: MigrationStatus
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

### Microsoft.AzureStack.Management.Storage.Admin.Models.MigrationResult

## NOTES

## RELATED LINKS

