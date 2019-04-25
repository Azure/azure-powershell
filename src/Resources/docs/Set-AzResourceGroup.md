---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azresourcegroup
schema: 2.0.0
---

# Set-AzResourceGroup

## SYNOPSIS
Creates or updates a resource group.

## SYNTAX

### UpdateSubscriptionIdViaHost (Default)
```
Set-AzResourceGroup -Name <String> [-Parameters <IResourceGroup>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzResourceGroup -Name <String> -SubscriptionId <String> -Location <String> [-ManagedBy <String>]
 [-Tag <IResourceGroupTags>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Set-AzResourceGroup -Name <String> -SubscriptionId <String> [-Parameters <IResourceGroup>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded
```
Set-AzResourceGroup -Name <String> -Location <String> [-ManagedBy <String>] [-Tag <IResourceGroupTags>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Location
The location of the resource group.
It cannot be changed after the resource group has been created.
It must be one of the supported Azure locations.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedBy
The ID of the resource that manages this resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the resource group to create or update.
Can include alphanumeric, underscore, parentheses, hyphen, period (except at end), and Unicode characters that match the allowed characters.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Resource group information.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourceGroup
Parameter Sets: UpdateSubscriptionIdViaHost, Update
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags attached to the resource group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourceGroupTags
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IResourceGroup
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azresourcegroup](https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azresourcegroup)

