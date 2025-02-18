---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradminproject
schema: 2.0.0
---

# Get-AzDevCenterAdminProject

## SYNOPSIS
Gets a specific project.

## SYNTAX

### List (Default)
```
Get-AzDevCenterAdminProject [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterAdminProject -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminProject -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzDevCenterAdminProject -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a specific project.

## EXAMPLES

### Example 1: List projects in a subscription
```powershell

```

```powershell
Get-AzDevCenterAdminProject
 ```
This command lists the projects in the current subscription.

### Example 2: List projects in a resource group
```powershell
Get-AzDevCenterAdminProject -ResourceGroupName testRg
```

This command lists the projects under the resource group "testRg".

### Example 3: Get a project
```powershell
Get-AzDevCenterAdminProject -ResourceGroupName testRg -Name DevProject
```

This command gets the project named "DevProject" under the resource group "testRg".

### Example 4: Get a project using InputObject
```powershell
$project = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminProject -InputObject $project
```

This command gets the project named "DevProject" under the resource group "testRg".

## PARAMETERS

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the project.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ProjectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IProject

## NOTES

## RELATED LINKS

