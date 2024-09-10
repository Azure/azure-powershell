---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/update-azcontainerappmanagedenvdapr
schema: 2.0.0
---

# Update-AzContainerAppManagedEnvDapr

## SYNOPSIS
Create a Dapr Component in a Managed Environment.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzContainerAppManagedEnvDapr -EnvName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ComponentType <String>] [-IgnoreError] [-InitTimeout <String>]
 [-Metadata <IDaprMetadata[]>] [-Scope <String[]>] [-Secret <ISecret[]>] [-SecretStoreComponent <String>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzContainerAppManagedEnvDapr -InputObject <IAppIdentity> [-ComponentType <String>] [-IgnoreError]
 [-InitTimeout <String>] [-Metadata <IDaprMetadata[]>] [-Scope <String[]>] [-Secret <ISecret[]>]
 [-SecretStoreComponent <String>] [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityManagedEnvironmentExpanded
```
Update-AzContainerAppManagedEnvDapr -ManagedEnvironmentInputObject <IAppIdentity> -Name <String>
 [-ComponentType <String>] [-IgnoreError] [-InitTimeout <String>] [-Metadata <IDaprMetadata[]>]
 [-Scope <String[]>] [-Secret <ISecret[]>] [-SecretStoreComponent <String>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a Dapr Component in a Managed Environment.

## EXAMPLES

### Example 1: Update a managed environment dapr component.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

Update-AzContainerAppManagedEnvDapr -Name azps-dapr -EnvName azps-env -ResourceGroupName azps_test_group_app -componentType state.azure.cosmosdb -Version v2 -IgnoreError:$false -InitTimeout 60s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----      -------------        ----------- ----------- -----------------   -------
azps-dapr state.azure.cosmosdb False       60s         azps_test_group_app v2
```

Update a managed environment dapr component.

### Example 2: Update a managed environment dapr component.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
$managedenvdapr = Get-AzContainerAppManagedEnvDapr -Name azps-dapr -EnvName 4azps-env -ResourceGroupName azps_test_group_app

Update-AzContainerAppManagedEnvDapr -InputObject $managedenvdapr -componentType state.azure.cosmosdb -Version v2 -IgnoreError:$false -InitTimeout 60s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----      -------------        ----------- ----------- -----------------   -------
azps-dapr state.azure.cosmosdb False       60s         azps_test_group_app v2
```

Update a managed environment dapr component.

### Example 3: Update a managed environment dapr component.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app

Update-AzContainerAppManagedEnvDapr -Name azps-dapr -ManagedEnvironmentInputObject $managedenv -componentType state.azure.cosmosdb -Version v2 -IgnoreError:$false -InitTimeout 60s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----      -------------        ----------- ----------- -----------------   -------
azps-dapr state.azure.cosmosdb False       60s         azps_test_group_app v2
```

Update a managed environment dapr component.

## PARAMETERS

### -ComponentType
Component type

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

### -EnvName
Name of the Managed Environment.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IgnoreError
Boolean describing if the component errors are ignores

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

### -InitTimeout
Initialization timeout

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedEnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentityManagedEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Metadata
Component metadata

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IDaprMetadata[]
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityManagedEnvironmentExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IDaprComponent

## NOTES

## RELATED LINKS

