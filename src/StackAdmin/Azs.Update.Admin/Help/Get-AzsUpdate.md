---
external help file: Azs.Update.Admin-help.xml
Module Name: Azs.Update.Admin
online version: 
schema: 2.0.0
---

# Get-AzsUpdate

## SYNOPSIS
Get the list of available updates.

## SYNTAX

### List (Default)
```
Get-AzsUpdate [-Location <String>] [-ResourceGroupName <String>] [-Skip <Int32>] [-Top <Int32>]
 [<CommonParameters>]
```

### Get
```
Get-AzsUpdate [-Name] <String> [-Location <String>] [-ResourceGroupName <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsUpdate -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Get the list of available updates. 
Updates returned from this module may be piped to 'Install-AzsUpdate', if applicable.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsUpdate | ft
```

DateAvailable        InstalledDate       Description             State     KbLink                          MinVersionRequired PackagePath
-------------        -------------       -----------             -----     ------                          ------------------ -----------
1/1/0001 12:00:00 AM 3/3/2018 8:09:12 AM MAS Update 1.0.180302.1 Installed https://aka.ms/azurestackupdate 1.0.180103.2       \\\\SU1FileServer\SU1_Infr...
1/1/0001 12:00:00 AM                     AzS Update 1.0.180305.1 Ready     https://aka.ms/azurestackupdate 1.0.180103.2       https://updateadminaccou...
...

Get the list of available updates.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsUpdate -Name Microsoft1.0.180305.1
```

DateAvailable      : 1/1/0001 12:00:00 AM
InstalledDate      :
Description        : AzS Update 1.0.180305.1
State              : Ready
KbLink             : https://aka.ms/azurestackupdate
MinVersionRequired : 1.0.180103.2
PackagePath        : https://updateadminaccount.blob.location.company.com/180305
PackageSizeInMb    : 2954
UpdateName         : AzS Update - 1.0.180305.1
Version            : 1.0.180305.1

Get the specific update.

## PARAMETERS

### -Location
The name of the update location.

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
Name of the update.

```yaml
Type: String
Parameter Sets: Get
Aliases: Update

Required: True
Position: 1
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
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: List
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

### Microsoft.AzureStack.Management.Update.Admin.Models.Update

## NOTES

## RELATED LINKS

