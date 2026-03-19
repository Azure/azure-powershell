---
external help file: Az.ServiceGroups-help.xml
Module Name: Az.ServiceGroups
online version: https://learn.microsoft.com/powershell/module/az.servicegroups/new-azservicegroup
schema: 2.0.0
---

# New-AzServiceGroup

## SYNOPSIS
Create a serviceGroup

## SYNTAX

### CreateExpanded (Default)
```
New-AzServiceGroup -Name <String> [-DisplayName <String>] [-Kind <String>] [-ParentResourceId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzServiceGroup -Name <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzServiceGroup -Name <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a serviceGroup

## EXAMPLES

### Example 1: Create a service group under the root
```powershell
New-AzServiceGroup -Name "Contoso" -DisplayName "Contoso Group" -ParentResourceId "/providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000"
```

```output
DisplayName   : Contoso Group
Id            : /providers/Microsoft.Management/serviceGroups/Contoso
Kind          :
Name          : Contoso
ParentResourceId : /providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Creates a new service group named 'Contoso' under the root service group (tenant ID).
The groupId is a unique identifier that cannot be changed after creation.
The ParentResourceId must be the full Azure Resource Manager ID of the parent service group.

### Example 2: Create a child service group under an existing parent
```powershell
New-AzServiceGroup -Name "ContosoChild" -DisplayName "Contoso Child Group" -ParentResourceId "/providers/Microsoft.Management/serviceGroups/Contoso"
```

```output
DisplayName   : Contoso Child Group
Id            : /providers/Microsoft.Management/serviceGroups/ContosoChild
Kind          :
Name          : ContosoChild
ParentResourceId : /providers/Microsoft.Management/serviceGroups/Contoso
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Creates a child service group nested under the 'Contoso' parent service group.
Service groups support hierarchical organization where access controls applied to the parent are inherited by child service groups.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
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

### -DisplayName
The display name of the serviceGroup.
For example, ServiceGroupTest1

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of the serviceGroup.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
ServiceGroup Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ServiceGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceId
The fully qualified ID of the parent serviceGroup.
For example, '/providers/Microsoft.Management/serviceGroups/TestServiceGroup'

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The serviceGroup tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Models.IServiceGroup

## NOTES

## RELATED LINKS
