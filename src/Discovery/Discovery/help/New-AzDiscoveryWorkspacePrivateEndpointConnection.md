---
external help file: Az.Discovery-help.xml
Module Name: Az.Discovery
online version: https://learn.microsoft.com/powershell/module/az.discovery/new-azdiscoveryworkspaceprivateendpointconnection
schema: 2.0.0
---

# New-AzDiscoveryWorkspacePrivateEndpointConnection

## SYNOPSIS
Approves or create the specified private endpoint connection.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDiscoveryWorkspacePrivateEndpointConnection -PrivateEndpointConnectionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -WorkspaceName <String>
 [-PrivateLinkServiceConnectionStateActionsRequired <String>]
 [-PrivateLinkServiceConnectionStateDescription <String>] [-PrivateLinkServiceConnectionStateStatus <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDiscoveryWorkspacePrivateEndpointConnection -PrivateEndpointConnectionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -WorkspaceName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDiscoveryWorkspacePrivateEndpointConnection -PrivateEndpointConnectionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -WorkspaceName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityWorkspaceExpanded
```
New-AzDiscoveryWorkspacePrivateEndpointConnection -PrivateEndpointConnectionName <String>
 -WorkspaceInputObject <IDiscoveryIdentity> [-PrivateLinkServiceConnectionStateActionsRequired <String>]
 [-PrivateLinkServiceConnectionStateDescription <String>] [-PrivateLinkServiceConnectionStateStatus <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Approves or create the specified private endpoint connection.

## EXAMPLES

### Example 1: Approve a private endpoint connection
```powershell
New-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName "my-rg" -WorkspaceName "my-workspace" -PrivateEndpointConnectionName "my-pe-connection" -PrivateLinkServiceConnectionStateStatus "Approved" -PrivateLinkServiceConnectionStateDescription "Approved by admin"
```

```output
Name                    ResourceGroupName    ProvisioningState
----                    -----------------    -----------------
my-pe-connection        my-rg                Succeeded
```

Creates or approves a private endpoint connection for the specified workspace.

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

### -PrivateEndpointConnectionName
The name of the private endpoint connection associated with the Azure resource.

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

### -PrivateLinkServiceConnectionStateActionsRequired
A message indicating if changes on the service provider require any updates on the consumer.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateDescription
The reason for approval/rejection of the connection.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateStatus
Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateViaIdentityWorkspaceExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePrivateEndpointConnection

## NOTES

## RELATED LINKS
