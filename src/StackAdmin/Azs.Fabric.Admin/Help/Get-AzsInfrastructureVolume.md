---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsInfrastructureVolume

## SYNOPSIS
Get volumes at a location.

## SYNTAX

### InfrastructureVolumes_List (Default)
```
Get-AzsInfrastructureVolume [-Filter <String>] -StorageSubSystem <String> [-Skip <Int32>] -Location <String>
 [-Top <Int32>] -StoragePool <String> [<CommonParameters>]
```

### InfrastructureVolumes_Get
```
Get-AzsInfrastructureVolume -StorageSubSystem <String> -Volume <String> -Location <String>
 -StoragePool <String> [<CommonParameters>]
```

## DESCRIPTION
Get volumes at a location.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsInfrastructureVolume -Location local -StoragePool SU1_Pool -StorageSubSystem S-Cluster.azurestack.local

Type                                                                          FileSystem RemainingSizeGB Name     SizeGB
----                                                                          ---------- --------------- ----     ------
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems/storagePools/volumes CSVFS_ReFS 2201            a42d219b 2525
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems/storagePools/volumes CSVFS_ReFS 1220            a42d219c 2525
```

Get a list of all volumes from a location.

### Example 2
```
PS C:\> Get-AzsInfrastructureVolume -Location local -StoragePool SU1_Pool -StorageSubSystem S-Cluster.azurestack.local -Volume a42d219b

Type                                                                          FileSystem RemainingSizeGB Name     SizeGB
----                                                                          ---------- --------------- ----     ------
Microsoft.Fabric.Admin/fabricLocations/storageSubSystems/storagePools/volumes CSVFS_ReFS 2201            a42d219b 2525
```

Get a volume by name from a given location.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: InfrastructureVolumes_List
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
Parameter Sets: InfrastructureVolumes_List
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
Parameter Sets: (All)
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
Parameter Sets: InfrastructureVolumes_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Volume
Name of the volume.

```yaml
Type: String
Parameter Sets: InfrastructureVolumes_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.Volume

## NOTES

## RELATED LINKS

