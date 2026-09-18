---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradminprojectpolicy
schema: 2.0.0
---

# Get-AzDevCenterAdminProjectPolicy

## SYNOPSIS
Gets a specific project policy.

## SYNTAX

### List (Default)
```
Get-AzDevCenterAdminProjectPolicy -DevCenterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterAdminProjectPolicy -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminProjectPolicy -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a specific project policy.

## EXAMPLES

### Example 1: Get all project policies in a dev center
```powershell
Get-AzDevCenterAdminProjectPolicy -DevCenterName Contoso -ResourceGroupName testRg -SubscriptionId 0ac520ee-14c0-480f-b6c9-0a90c58ffff
```

This command gets all project policies in the dev center "Contoso" in resource group "testRg".

### Example 2: Get a specific project policy by name
```powershell
Get-AzDevCenterAdminProjectPolicy -DevCenterName Contoso -Name myPolicy -ResourceGroupName testRg -SubscriptionId 0ac520ee-14c0-480f-b6c9-0a90c58ffff
```

This command gets the project policy named "myPolicy" in the dev center "Contoso".

### Example 3: Get a project policy using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "testRg"
    DevCenterName = "Contoso"
    ProjectPolicyName = "myPolicy"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
Get-AzDevCenterAdminProjectPolicy -InputObject $inputObject
```

This command gets the project policy named "myPolicy" in the dev center "Contoso" using an input object.

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

### -DevCenterName
The name of the devcenter.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get
Aliases: ProjectPolicyName

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20250401Preview.IProjectPolicy

## NOTES

## RELATED LINKS

