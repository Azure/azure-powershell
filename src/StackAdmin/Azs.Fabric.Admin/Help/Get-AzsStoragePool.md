---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsStoragePool

## SYNOPSIS
Get storage pools at a location.

## SYNTAX

### StoragePools_List (Default)
```
Get-AzsStoragePool [-Filter <String>] -StorageSubSystem <String> [-Skip <Int32>] -Location <String>
 [-Top <Int32>] [<CommonParameters>]
```

### StoragePools_Get
```
Get-AzsStoragePool -StorageSubSystem <String> -Location <String> -StoragePool <String> [<CommonParameters>]
```

## DESCRIPTION
Get storage pools at a location.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsStoragePool -Location local -StoragePool SU1_Pool -StorageSubSystem S-Cluster.azurestack.local

Type                                                                  Name     SizeGB Location
----                                                                  ----     ------ --------
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems/storagePools SU1_Pool 5614   local
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems/storagePools SU2_Pool 5614   local
```

Get all storage pools at a given location.

### Example 2
```
PS C:\> Get-AzsStoragePool -Location local -StoragePool SU1_Pool -StorageSubSystem S-Cluster.azurestack.local -StoragePool "SU1_Pool"

Type                                                                  Name     SizeGB Location
----                                                                  ----     ------ --------
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems/storagePools SU1_Pool 5614   local
```

Get a storage pools at a given location given a storage pool name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: StoragePools_List
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
Parameter Sets: StoragePools_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -StoragePool
Storage pool name.

```yaml
Type: String
Parameter Sets: StoragePools_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSubSystem
Name of the storage system.

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

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: StoragePools_List
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

### Microsoft.AzureStack.Management.Fabric.Admin.Models.StoragePool

## NOTES

## RELATED LINKS

