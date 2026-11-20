---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteradminprojectpolicy
schema: 2.0.0
---

# Update-AzDevCenterAdminProjectPolicy

## SYNOPSIS
Partially update an project policy.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDevCenterAdminProjectPolicy -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ResourcePolicy <IResourcePolicy[]>] [-Scope <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityDevcenterExpanded
```
Update-AzDevCenterAdminProjectPolicy -DevcenterInputObject <IDevCenterIdentity> -Name <String>
 [-ResourcePolicy <IResourcePolicy[]>] [-Scope <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDevCenterAdminProjectPolicy -InputObject <IDevCenterIdentity> [-ResourcePolicy <IResourcePolicy[]>]
 [-Scope <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDevCenterAdminProjectPolicy -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDevCenterAdminProjectPolicy -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Partially update an project policy.

## EXAMPLES

### Example 1: Update the resource policies of a project policy
```powershell
$resourcePolicies = @(
    @{ Resource = "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/default/images/microsoftvisualstudio_visualstudio2019plustools_vs-2019-ent-general-win10-m365-gen2" };
    @{ Action = "Deny"; ResourceType = "Skus" }
)
Update-AzDevCenterAdminProjectPolicy `
  -DevCenterName "Contoso" `
  -Name "myPolicy" `
  -ResourceGroupName "testRg" `
  -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff" `
  -ResourcePolicy $resourcePolicies
```

This command updates the project policy named "myPolicy" in the dev center "Contoso" to set new resource policies.

### Example 2: Update the scopes of a project policy using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "testRg"
    DevCenterName = "Contoso"
    ProjectPolicyName = "myPolicy"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
$scopes = @(
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject";
    "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/projects/devProject2"
)
Update-AzDevCenterAdminProjectPolicy -InputObject $inputObject -Scope $scopes
```

This command updates the scopes of the project policy "myPolicy" in the dev center "Contoso" using an input object.

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

### -DevcenterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: UpdateViaIdentityDevcenterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DevCenterName
The name of the devcenter.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
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
The name of the project policy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityDevcenterExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourcePolicy
Resource policies that are a part of this project policy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IResourcePolicy[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityDevcenterExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityDevcenterExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IProjectPolicy

## NOTES

## RELATED LINKS

