---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonaksclustermavenlibraryobject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterMavenLibraryObject

## SYNOPSIS
Create an in-memory object for MavenLibraryProperties.

## SYNTAX

```
New-AzHdInsightOnAksClusterMavenLibraryObject -GroupId <String> -Name <String> [-Remark <String>]
 [-Version <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MavenLibraryProperties.

## EXAMPLES

### Example 1: Create a library object for maven.
```powershell
New-AzHdInsightOnAksClusterMavenLibraryObject -GroupId "com.azure.resourcemanager" -Name "azure-resourcemanager-hdinsight-containers" -Version "1.0.0-beta.2" -Remark "Maven lib"
```

```output
Name                         : 
PropertiesType               : maven
Property                     : {
                                 "type": "maven",
                                 "remarks": "Maven lib",
                                 "groupId": "com.azure.resourcemanager",
                                 "name": "azure-resourcemanager-hdinsight-containers",
                                 "version": "1.0.0-beta.2"
                               }
Remark                       : Maven lib
```

Create a library object for maven.

## PARAMETERS

### -GroupId
GroupId of the Maven package.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
ArtifactId of the Maven package.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Remark
Remark of the latest library management operation.

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

### -Version
Version of the Maven package.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterLibrary

## NOTES

## RELATED LINKS

