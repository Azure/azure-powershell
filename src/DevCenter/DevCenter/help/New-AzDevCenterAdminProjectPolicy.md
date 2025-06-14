---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/new-azdevcenteradminprojectpolicy
schema: 2.0.0
---

# New-AzDevCenterAdminProjectPolicy

## SYNOPSIS
Creates or updates an project policy.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDevCenterAdminProjectPolicy -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ResourcePolicy <IResourcePolicy[]>] [-Scope <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDevCenterAdminProjectPolicy -InputObject <IDevCenterIdentity> [-ResourcePolicy <IResourcePolicy[]>]
 [-Scope <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an project policy.

## EXAMPLES

### Example 1: Create a project policy with resource policies and scopes
```powershell
$resourcePolicies = @(
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/default/images/microsoftvisualstudio_visualstudio2019plustools_vs-2019-ent-general-win10-m365-gen2" };
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/default/images/microsoftvisualstudio_visualstudio2019plustools_vs-2019-ent-general-win11-m365-gen2" };
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/attachednetworks/network-westus3" };
    @{ Action = "Allow"; ResourceType = "Skus" }
)
$scopes = @(
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject";
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject2"
)
New-AzDevCenterAdminProjectPolicy `
  -DevCenterName "Contoso" `
  -Name "myPolicy" `
  -ResourceGroupName "testRg" `
  -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff" `
  -ResourcePolicy $resourcePolicies `
  -Scope $scopes
```

This command creates a project policy named "myPolicy" in the dev center "Contoso" with multiple resource policies and scopes.

### Example 2: Create a project policy using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "testRg"
    DevCenterName = "Contoso"
    ProjectPolicyName = "myPolicy"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
$resourcePolicies = @(
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/default/images/microsoftvisualstudio_visualstudio2019plustools_vs-2019-ent-general-win10-m365-gen2" }
)
$scopes = @(
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject"
)
New-AzDevCenterAdminProjectPolicy -InputObject $inputObject -ResourcePolicy $resourcePolicies -Scope $scopes
```

This command creates a project policy using an input object and assigns a single resource policy and scope.

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

### -DevCenterName
The name of the devcenter.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the project policy.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: ProjectPolicyName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourcePolicy
Resource policies that are a part of this project policy.
To construct, see NOTES section for RESOURCEPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20250401Preview.IResourcePolicy[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Resources that have access to the shared resources that are a part of this project policy.

```yaml
Type: System.String[]
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20250401Preview.IProjectPolicy

## NOTES

## RELATED LINKS
