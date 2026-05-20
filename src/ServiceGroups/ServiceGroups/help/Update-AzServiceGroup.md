---
external help file: Az.ServiceGroups-help.xml
Module Name: Az.ServiceGroups
online version: https://learn.microsoft.com/powershell/module/az.servicegroups/update-azservicegroup
schema: 2.0.0
---

# Update-AzServiceGroup

## SYNOPSIS
Update a serviceGroup

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzServiceGroup -Name <String> [-DisplayName <String>] [-ParentResourceId <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzServiceGroup -Name <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzServiceGroup -Name <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzServiceGroup -InputObject <IServiceGroupsIdentity> [-DisplayName <String>]
 [-ParentResourceId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a serviceGroup

## EXAMPLES

### Example 1: Update the display name of a service group
```powershell
Update-AzServiceGroup -Name "Contoso" -DisplayName "Contoso Group Updated"
```

```output
DisplayName   : Contoso Group Updated
Id            : /providers/Microsoft.Management/serviceGroups/Contoso
Kind          :
Name          : Contoso
ParentResourceId : /providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Updates the display name of the 'Contoso' service group.
The update operation is asynchronous.

### Example 2: Move a service group under a different parent
```powershell
Update-AzServiceGroup -Name "ContosoChild" -ParentResourceId "/providers/Microsoft.Management/serviceGroups/NewParent"
```

```output
DisplayName   : Contoso Child Group
Id            : /providers/Microsoft.Management/serviceGroups/ContosoChild
Kind          :
Name          : ContosoChild
ParentResourceId : /providers/Microsoft.Management/serviceGroups/NewParent
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Moves the 'ContosoChild' service group under a different parent service group by updating the ParentResourceId property.

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Models.IServiceGroupsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
ServiceGroup Name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Models.IServiceGroupsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Models.IServiceGroup

## NOTES

## RELATED LINKS
