---
external help file:
Module Name: Az.ImportExport
online version: https://learn.microsoft.com/powershell/module/az.importexport/get-azimportexportlocation
schema: 2.0.0
---

# Get-AzImportExportLocation

## SYNOPSIS
Returns the details about a location to which you can ship the disks associated with an import or export job.
A location is an Azure region.

## SYNTAX

### List (Default)
```
Get-AzImportExportLocation [-AcceptLanguage <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzImportExportLocation -Name <String> [-AcceptLanguage <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzImportExportLocation -InputObject <IImportExportIdentity> [-AcceptLanguage <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns the details about a location to which you can ship the disks associated with an import or export job.
A location is an Azure region.

## EXAMPLES

### Example 1: Get all Azure region location details with default context
```powershell
Get-AzImportExportLocation
```

```output
Name                 Type
----                 ----
Australia East       Microsoft.ImportExport/locations
Australia Southeast  Microsoft.ImportExport/locations
Brazil South         Microsoft.ImportExport/locations
Canada Central       Microsoft.ImportExport/locations
Canada East          Microsoft.ImportExport/locations
...
West Central US      Microsoft.ImportExport/locations
West Europe          Microsoft.ImportExport/locations
West India           Microsoft.ImportExport/locations
West US              Microsoft.ImportExport/locations
West US 2            Microsoft.ImportExport/locations
```

This cmdlet gets all Azure region location details with default context.

### Example 2: Get Azure region location details by location name
```powershell
Get-AzImportExportLocation -Name eastus
```

```output
Name    Type
----    ----
East US Microsoft.ImportExport/locations
```

This cmdlet gets Azure region location details by location name.

### Example 3: Get Azure region location details by identity
```powershell
$Id = "/providers/Microsoft.ImportExport/locations/eastus"
Get-AzImportExportLocation -InputObject $Id
```

```output
Name    Type
----    ----
East US Microsoft.ImportExport/locations
```

This cmdlet lists gets Azure region location details by identity.

## PARAMETERS

### -AcceptLanguage
Specifies the preferred language for the response.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the location.
For example, West US or westus.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: LocationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api202101.ILocation

## NOTES

## RELATED LINKS

