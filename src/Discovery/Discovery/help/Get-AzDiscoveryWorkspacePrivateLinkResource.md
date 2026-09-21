---
external help file: Az.Discovery-help.xml
Module Name: Az.Discovery
online version: https://learn.microsoft.com/powershell/module/az.discovery/get-azdiscoveryworkspaceprivatelinkresource
schema: 2.0.0
---

# Get-AzDiscoveryWorkspacePrivateLinkResource

## SYNOPSIS
Gets the specified private link resource for the workspace.

## SYNTAX

### List (Default)
```
Get-AzDiscoveryWorkspacePrivateLinkResource -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzDiscoveryWorkspacePrivateLinkResource -PrivateLinkResourceName <String>
 -WorkspaceInputObject <IDiscoveryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDiscoveryWorkspacePrivateLinkResource -PrivateLinkResourceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -WorkspaceName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDiscoveryWorkspacePrivateLinkResource -InputObject <IDiscoveryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the specified private link resource for the workspace.

## EXAMPLES

### Example 1: List private link resources for a workspace
```powershell
Get-AzDiscoveryWorkspacePrivateLinkResource -ResourceGroupName "my-rg" -WorkspaceName "my-workspace"
```

```output
Name            GroupId
----            -------
workspace       workspace
```

Lists available private link resources for the specified workspace.

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

### -PrivateLinkResourceName
The name of the private link associated with the Azure resource.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityWorkspace, Get
Aliases:

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the Workspace

```yaml
Type: System.String
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePrivateLinkResource

## NOTES

## RELATED LINKS
