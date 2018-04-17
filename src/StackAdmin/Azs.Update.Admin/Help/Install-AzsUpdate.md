---
external help file: Azs.Update.Admin-help.xml
Module Name: Azs.Update.Admin
online version: 
schema: 2.0.0
---

# Install-AzsUpdate

## SYNOPSIS
Apply a specific update at an update location.

## SYNTAX

### Apply (Default)
```
Install-AzsUpdate [-ResourceGroupName <String>] [-Location <String>] -Name <String> [-Wait]
 [<CommonParameters>]
```

### ResourceId
```
Install-AzsUpdate [-Wait] -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Apply a specific update at an update location. 
After invoked, Get-AzsUpdateRun may be used to modify the progress of the update.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsUpdate -Name Microsoft1.0.180305.1 | Install-AzsUpdate
```

DateAvailable      :
InstalledDate      :
Description        :
State              : InProgress
KbLink             :
MinVersionRequired :
PackagePath        :
PackageSizeInMb    :
UpdateName         :
Version            :
UpdateOemFile      :
Publisher          :
PackageType        :
Id                 : /subscriptions/23d66fd1-4743-42ff-b391-e29dc51d799e/resourcegroups/System.redmond/providers/Microsoft.Update.Admin/updateLocations/r
		 edmond/updates/Microsoft1.0.180305.1/updateRuns/a6ad672e-097d-4d40-bc00-8d6ebe327246
Name               : a6ad672e-097d-4d40-bc00-8d6ebe327246
Type               : Microsoft.Update.Admin/updateLocations/updates/updateRuns
Location           : redmond
Tags               : {}

Apply a specific update at an update location.

## PARAMETERS

### -Location
The name of the update location.

```yaml
Type: String
Parameter Sets: Apply
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the update.

```yaml
Type: String
Parameter Sets: Apply
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group the resource is located under.

```yaml
Type: String
Parameter Sets: Apply
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

### Microsoft.AzureStack.Management.Update.Admin.Models.Update

## NOTES

## RELATED LINKS

