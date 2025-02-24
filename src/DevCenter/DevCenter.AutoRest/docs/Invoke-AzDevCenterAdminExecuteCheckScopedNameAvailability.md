---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/invoke-azdevcenteradminexecutecheckscopednameavailability
schema: 2.0.0
---

# Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability

## SYNOPSIS
Check the availability of name for resource

## SYNTAX

### ExecuteExpanded (Default)
```
Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability [-SubscriptionId <String>] [-Name <String>]
 [-Scope <String>] [-Type <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaIdentityExpanded
```
Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability -InputObject <IDevCenterIdentity> [-Name <String>]
 [-Scope <String>] [-Type <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check the availability of name for resource

## EXAMPLES

### Example 1: Checked scoped name availability of project catalog
```powershell
Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability -Name "CentralCatalog" -Type "Microsoft.DevCenter/projects/catalogs" -Scope "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/rg1/providers/Microsoft.DevCenter/projects/DevProject"
```

This command checks the scoped name availability of "CentralCatalog" with a resource type of "Microsoft.Devcenter/projects/catalogs"

### Example 2: Checked scoped name availability of dev center catalog
```powershell
Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability -Name "CentralCatalog" -Type "Microsoft.DevCenter/devcenters/catalogs" -Scope "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/rg1/providers/Microsoft.DevCenter/devcenters/Contoso"
```

This command checks the scoped name availability of "CentralCatalog" with a resource type of "Microsoft.Devcenter/devcenters/catalogs"

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
Parameter Sets: ExecuteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the resource for which availability needs to be checked.

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

### -Scope
The resource id to scope the name check.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: ExecuteExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The resource type.

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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api30.ICheckNameAvailabilityResponse

## NOTES

## RELATED LINKS

