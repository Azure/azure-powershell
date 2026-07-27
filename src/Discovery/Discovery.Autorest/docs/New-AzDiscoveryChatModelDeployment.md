---
external help file:
Module Name: Az.Discovery
online version: https://learn.microsoft.com/powershell/module/az.discovery/new-azdiscoverychatmodeldeployment
schema: 2.0.0
---

# New-AzDiscoveryChatModelDeployment

## SYNOPSIS
Create a ChatModelDeployment

## SYNTAX

### CreateExpanded (Default)
```
New-AzDiscoveryChatModelDeployment -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -Location <String> [-SubscriptionId <String>] [-Capacity <Int32>] [-ModelFormat <String>]
 [-ModelName <String>] [-ModelVersion <String>] [-SkuName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityWorkspaceExpanded
```
New-AzDiscoveryChatModelDeployment -Name <String> -WorkspaceInputObject <IDiscoveryIdentity>
 -Location <String> [-Capacity <Int32>] [-ModelFormat <String>] [-ModelName <String>] [-ModelVersion <String>]
 [-SkuName <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDiscoveryChatModelDeployment -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDiscoveryChatModelDeployment -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a ChatModelDeployment

## EXAMPLES

### Example 1: Create a new chat model deployment
```powershell
New-AzDiscoveryChatModelDeployment -ResourceGroupName "my-rg" -WorkspaceName "my-workspace" -Name "my-chat-model" -Location "eastus" -ModelFormat "OpenAI" -ModelName "gpt-4o" -ModelVersion "2024-05-13" -SkuName "Standard" -Capacity 1
```

```output
Location    Name                ResourceGroupName    ProvisioningState
--------    ----                -----------------    -----------------
eastus      my-chat-model       my-rg                Succeeded
```

Creates a new chat model deployment under the specified workspace.

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

### -Capacity
Provisioned SKU capacity units for this chat model deployment.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModelFormat
Model format as published by the provider.
Verify supported formats per region using the Model Catalog API.

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

### -ModelName
Canonical provider model name available in the selected region.
Verify supported values per region using the Model Catalog API.

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

### -ModelVersion
Provider-published version of the selected model.

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

### -Name
The name of the ChatModelDeployment

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ChatModelDeploymentName

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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
SKU tier used by this chat model deployment.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeployment

## NOTES

## RELATED LINKS

