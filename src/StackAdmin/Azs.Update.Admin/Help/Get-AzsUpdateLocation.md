---
external help file: Azs.Update.Admin-help.xml
Module Name: Azs.Update.Admin
online version: 
schema: 2.0.0
---

# Get-AzsUpdateLocation

## SYNOPSIS
Get the list of update locations.

## SYNTAX

### List (Default)
```
Get-AzsUpdateLocation [-ResourceGroupName <String>] [<CommonParameters>]
```

### Get
```
Get-AzsUpdateLocation [-Location <String>] [-ResourceGroupName <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsUpdateLocation -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Get the list of update locations. 
The locations returned can be used to get available updates at a particular location using Get-AzsUpdate.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsUpdateLocation
```

CurrentVersion    : 1.0.180302.1
CurrentOemVersion : 1.0.1709.3
LastUpdated       : 3/3/2018 8:09:12 AM
State             : UpdateAvailable
Id                : /subscriptions/23d66fd1-4743-42ff-b391-e29dc51d799e/resourceGroups/System.redmond/providers/Microsoft.Update.Admin/updateLocations/redmond
Name              : redmond
Type              : Microsoft.Update.Admin/updateLocations
Location          : redmond
Tags              : {}
...

Get the list of update locations.

## PARAMETERS

### -Location
{{Fill Location Description}}

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group the resource is located under.

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
Aliases: 

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

### Microsoft.AzureStack.Management.Update.Admin.Models.UpdateLocation

## NOTES

## RELATED LINKS

