---
external help file:
Module Name: Az.Discovery
online version: https://learn.microsoft.com/powershell/module/az.discovery/get-azdiscoveryworkspace
schema: 2.0.0
---

# Get-AzDiscoveryWorkspace

## SYNOPSIS
Get a Workspace

## SYNTAX

### List1 (Default)
```
Get-AzDiscoveryWorkspace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDiscoveryWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDiscoveryWorkspace -InputObject <IDiscoveryIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDiscoveryWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Workspace

## EXAMPLES

### Example 1: List all workspaces in a resource group
```powershell
Get-AzDiscoveryWorkspace -ResourceGroupName "my-rg"
```

```output
Location    Name            ResourceGroupName
--------    ----            -----------------
eastus      my-workspace    my-rg
```

Lists all Discovery workspaces in the specified resource group.

### Example 2: Get a specific workspace
```powershell
Get-AzDiscoveryWorkspace -ResourceGroupName "my-rg" -Name "my-workspace"
```

```output
Location    Name            ResourceGroupName    ProvisioningState
--------    ----            -----------------    -----------------
eastus      my-workspace    my-rg                Succeeded
```

Gets a specific Discovery workspace by name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Workspace

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WorkspaceName

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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspace

## NOTES

## RELATED LINKS

