---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsInfrastructureShare

## SYNOPSIS
Get file shares.

## SYNTAX

### InfrastructureShares_List (Default)
```
Get-AzsInfrastructureShare [-Filter <String>] -Location <String> [<CommonParameters>]
```

### InfrastructureShares_Get
```
Get-AzsInfrastructureShare -Share <String> -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Get file shares.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsInfrastructureShare -Location local

Type                                              UncPath                                               Name                 Location AssociatedVolume
----                                              -------                                               ----                 -------- ----------------
Microsoft.Fabric.Admin/fabricLocations/fileShares \\SU1FileServer.azurestack.local\SU1_Infrastructure_1 SU1_Infrastructure_1 local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\SU1FileServer.azurestack.local\SU1_Infrastructure_2 SU1_Infrastructure_2 local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\SU1FileServer.azurestack.local\SU1_Infrastructure_3 SU1_Infrastructure_3 local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\SU1FileServer.azurestack.local\SU1_ObjStore         SU1_ObjStore         local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\SU1FileServer.azurestack.local\SU1_Public           SU1_Public           local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\SU1FileServer.azurestack.local\SU1_VmTemp           SU1_VmTemp           local    a42d219b
```

Returns a list of all file shares.

### Example 2
```
PS C:\> Get-AzsInfrastructureShare -Location local -Share Microsoft.AzureStack.Management.Fabric.Admin.Models.FileShare.Name

Type                                              UncPath                                               Name                 Location AssociatedVolume
----                                              -------                                               ----                 -------- ----------------
Microsoft.Fabric.Admin/fabricLocations/fileShares \\SU1FileServer.azurestack.local\SU1_Infrastructure_1 SU1_Infrastructure_1 local    a42d219b
```

Returns a file shares based on name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: InfrastructureShares_List
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

### -Share
Infrastructure share name.

```yaml
Type: String
Parameter Sets: InfrastructureShares_Get
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

### Microsoft.AzureStack.Management.Fabric.Admin.Models.FileShare

## NOTES

## RELATED LINKS

