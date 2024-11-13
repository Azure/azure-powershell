---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappconnectedenvdapr
schema: 2.0.0
---

# New-AzContainerAppConnectedEnvDapr

## SYNOPSIS
Create a Dapr Component in a connected environment.

## SYNTAX

### CreateExpanded (Default)
```
New-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ComponentType <String>] [-IgnoreError]
 [-InitTimeout <String>] [-Metadata <IDaprMetadata[]>] [-Scope <String[]>] [-Secret <ISecret[]>]
 [-SecretStoreComponent <String>] [-Version <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityConnectedEnvironmentExpanded
```
New-AzContainerAppConnectedEnvDapr -Name <String> -ConnectedEnvironmentInputObject <IAppIdentity>
 [-ComponentType <String>] [-IgnoreError] [-InitTimeout <String>] [-Metadata <IDaprMetadata[]>]
 [-Scope <String[]>] [-Secret <ISecret[]>] [-SecretStoreComponent <String>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzContainerAppConnectedEnvDapr -InputObject <IAppIdentity> [-ComponentType <String>] [-IgnoreError]
 [-InitTimeout <String>] [-Metadata <IDaprMetadata[]>] [-Scope <String[]>] [-Secret <ISecret[]>]
 [-SecretStoreComponent <String>] [-Version <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Dapr Component in a connected environment.

## EXAMPLES

### Example 1: Create a Dapr Component in a connected environment.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

New-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvdapr -ComponentType "state.azure.cosmosdb" -Version v1 -IgnoreError:$false -InitTimeout 50s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName    Version
----                  -------------        ----------- ----------- -----------------    -------
azps-connectedenvdapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

Create a Dapr Component in a connected environment.

## PARAMETERS

### -ComponentType
Component type

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityConnectedEnvironmentExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectedEnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: CreateViaIdentityConnectedEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectedEnvironmentName
Name of the connected environment.

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

### -IgnoreError
Boolean describing if the component errors are ignores

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityConnectedEnvironmentExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitTimeout
Initialization timeout

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityConnectedEnvironmentExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Metadata
Component metadata

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IDaprMetadata[]
Parameter Sets: CreateExpanded, CreateViaIdentityConnectedEnvironmentExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Dapr Component.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityConnectedEnvironmentExpanded
Aliases: DaprName

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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Names of container apps that can use this Dapr component

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityConnectedEnvironmentExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Secret
Collection of secrets used by a Dapr component

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.ISecret[]
Parameter Sets: CreateExpanded, CreateViaIdentityConnectedEnvironmentExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretStoreComponent
Name of a Dapr component to retrieve component secrets from

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityConnectedEnvironmentExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Component version

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityConnectedEnvironmentExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IDaprComponent

## NOTES

## RELATED LINKS
