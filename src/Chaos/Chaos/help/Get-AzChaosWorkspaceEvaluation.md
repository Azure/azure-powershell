---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaosworkspaceevaluation
schema: 2.0.0
---

# Get-AzChaosWorkspaceEvaluation

## SYNOPSIS
Get the latest workspace evaluation result.

## SYNTAX

### Get (Default)
```
Get-AzChaosWorkspaceEvaluation -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosWorkspaceEvaluation -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### GetViaIdentitySubscription
```
Get-AzChaosWorkspaceEvaluation -SubscriptionInputObject <IChaosIdentity> -WorkspaceName <String>
 [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Get the latest workspace evaluation result.

## EXAMPLES

### Example 1: Read the latest workspace evaluation after refreshing recommendations
```powershell
Update-AzChaosWorkspaceRecommendation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
Get-AzChaosWorkspaceEvaluation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
Status    WorkspaceName
------    -------------
Succeeded contoso-workspace
```

Reads the latest terminal workspace evaluation record produced by `Update-AzChaosWorkspaceRecommendation`.
Use this when a recommendation refresh has finished and you need to inspect the stored result again without starting a new evaluation.

### Example 2: Read the latest workspace evaluation after setup
```powershell
Initialize-AzChaosWorkspace -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Location eastus -Scope '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg'
Get-AzChaosWorkspaceEvaluation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
Status    WorkspaceName
------    -------------
Succeeded contoso-workspace
```

Reads the workspace evaluation record after `Initialize-AzChaosWorkspace` creates the workspace and runs its initial evaluation.
Use this cmdlet to re-read the terminal result later instead of repeating setup or evaluation work.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentitySubscription
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
String that represents a Workspace resource name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySubscription
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IWorkspaceEvaluation

## NOTES

## RELATED LINKS

