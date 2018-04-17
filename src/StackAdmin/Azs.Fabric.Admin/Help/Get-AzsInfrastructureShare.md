---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsInfrastructureShare

## SYNOPSIS
Returns a list of all fabric file shares at a certain location.

## SYNTAX

### List (Default)
```
Get-AzsInfrastructureShare [-Location <String>] [-ResourceGroupName <String>] [-Filter <String>]
 [<CommonParameters>]
```

### Get
```
Get-AzsInfrastructureShare [-Name] <String> [-Location <String>] [-ResourceGroupName <String>]
 [<CommonParameters>]
```

### ResourceId
```
Get-AzsInfrastructureShare -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns a list of all fabric file shares at a certain location.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsInfrastructureShare -ResourceGroup "System.local" -Location local
```

Type                                              UncPath                                               Name                 Location AssociatedVolume
----                                              -------                                               ----                 -------- ----------------
Microsoft.Fabric.Admin/fabricLocations/fileShares \\\\SU1FileServer.azurestack.local\SU1_Infrastructure_1 SU1_Infrastructure_1 local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\\\SU1FileServer.azurestack.local\SU1_Infrastructure_2 SU1_Infrastructure_2 local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\\\SU1FileServer.azurestack.local\SU1_Infrastructure_3 SU1_Infrastructure_3 local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\\\SU1FileServer.azurestack.local\SU1_ObjStore         SU1_ObjStore         local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\\\SU1FileServer.azurestack.local\SU1_Public           SU1_Public           local    a42d219b
Microsoft.Fabric.Admin/fabricLocations/fileShares \\\\SU1FileServer.azurestack.local\SU1_VmTemp           SU1_VmTemp           local    a42d219b

Returns a list of all file shares.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsInfrastructureShare -ResourceGroup "System.local" -Location local -Share Microsoft.AzureStack.Management.Fabric.Admin.Models.FileShare.Name
```

Type                                              UncPath                                               Name                 Location AssociatedVolume
----                                              -------                                               ----                 -------- ----------------
Microsoft.Fabric.Admin/fabricLocations/fileShares \\\\SU1FileServer.azurestack.local\SU1_Infrastructure_1 SU1_Infrastructure_1 local    a42d219b

Returns a file share based on name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: List
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
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Fabric file share name.

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

### -ResourceGroupName
Resource group in which the resource provider has been registered.

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

### Microsoft.AzureStack.Management.Fabric.Admin.Models.FileShare

## NOTES

## RELATED LINKS

