---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/new-azmanagementgroupsubscription/
schema: 2.0.0
---

# Get-AzManagementGroupNameAvailability

## SYNOPSIS
Checks if the Management Group name is available in the Tenant and a valid name.

## SYNTAX

```
Get-AzManagementGroupNameAvailability
```

## DESCRIPTION
The **Get-AzManagementGroupNameAvailability** checks if a Management Group Name is Available and Valid

## EXAMPLES

### Example 1: Get the Name Availability for a Valid Name
```powershell
Get-AzManagementGroupNameAvailability -GroupName "testMG"
```

```output
Message              : 
NameAvailable        : True
Reason               :
```

### Example 2: Get the Name Availability for a name that is already taken
```powershell
Get-AzManagementGroupNameAvailability -GroupName "testMG3"
```

```output
Message              : The group with the specified name already exists
NameAvailable        : False
Reason               : AlreadyExists
```

### Example 3: Get the Name Availability for a name that contains invalid characters
```powershell
Get-AzManagementGroupNameAvailability -GroupName "testMG!"
```

```output
Message              : The provided management group name has invalid characters
NameAvailable        : False
Reason               : Invalid
```

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSManagementGroupNameAvailabilityResult

## NOTES

## RELATED LINKS
