---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsStorageSystem

## SYNOPSIS
Get storage subsystems given a location.

## SYNTAX

### StorageSystems_List (Default)
```
Get-AzsStorageSystem [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>] [<CommonParameters>]
```

### StorageSystems_Get
```
Get-AzsStorageSystem -StorageSubSystem <String> -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Get storage subsystems given a location.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsStorageSystem -Location local -StorageSubSystem S-Cluster.azurestack.local

Type                                                     TotalCapacityGB Name                       Location
----                                                     --------------- ----                       --------
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems 2525            S-Cluster.azurestack.local local
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems 2525            T-Cluster.azurestack.local local
```

Get all storage subsystems from a location.

### Example 2
```
PS C:\> Get-AzsStorageSystem -Location local -StorageSubSystem S-Cluster.azurestack.local -StorageSubSystem "S-Cluster.azurestack.local"

Type                                                     TotalCapacityGB Name                       Location
----                                                     --------------- ----                       --------
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems 2525            S-Cluster.azurestack.local local
```

Get a storage subsystem given a location and name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: StorageSystems_List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

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

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: StorageSystems_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSubSystem
Name of the storage system.

```yaml
Type: String
Parameter Sets: StorageSystems_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: StorageSystems_List
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

### Microsoft.AzureStack.Management.Fabric.Admin.Models.StorageSystem

## NOTES

## RELATED LINKS

