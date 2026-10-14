---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/update-azmlworkspaceconnection
schema: 2.0.0
---

# Update-AzMLWorkspaceConnection

## SYNOPSIS
Creating or updating a new workspace connection

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMLWorkspaceConnection -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-Property <IWorkspaceConnectionPropertiesV2>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMLWorkspaceConnection -InputObject <IMachineLearningServicesIdentity>
 [-Property <IWorkspaceConnectionPropertiesV2>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityWorkspaceExpanded
```
Update-AzMLWorkspaceConnection -Name <String> -WorkspaceInputObject <IMachineLearningServicesIdentity>
 [-Property <IWorkspaceConnectionPropertiesV2>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creating or updating a new workspace connection

## EXAMPLES

### Example 1: Update a workspace connection with workspace connection property
```powershell
# The Auth type includes "PAT", "ManagedIdentity", "UsernamePassword", "None", "SAS", "AccountKey", "ServicePrincipal", "AccessKey", "ApiKey", "CustomKeys", "OAuth2", "AAD".
# You can use following command to create it then pass it as value to Property parameter of the New-AzMLWorkspaceConnection cmdlet.
# New-AzMLWorkspaceAadAuthTypeWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceAccessKeyAuthTypeWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceAccountKeyAuthTypeWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceApiKeyAuthWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceCustomKeysWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceManagedIdentityAuthTypeWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceNoneAuthTypeWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceOAuth2AuthTypeWorkspaceConnectionPropertiesObject
# New-AzMLWorkspacePatAuthTypeWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceSasAuthTypeWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceServicePrincipalAuthTypeWorkspaceConnectionPropertiesObject
# New-AzMLWorkspaceUsernamePasswordAuthTypeWorkspaceConnectionPropertiesObject

$connectproperty = New-AzMLWorkspaceNoneAuthTypeWorkspaceConnectionPropertiesObject -Category 'ContainerRegistry' -Target "www.google.com" -IsSharedToAll $true
Update-AzMLWorkspaceConnection -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name test01 -Property $connectproperty
```

```output
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/connections/test0
                               1
Name                         : test01
Property                     : {
                                 "authType": "None",
                                 "category": "ContainerRegistry",
                                 "createdByWorkspaceArmId": 
                               "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2",
                                 "group": "Azure",
                                 "isSharedToAll": true,
                                 "target": "www.google.com",
                                 "sharedUserList": [ ]
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 8:26:11 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 8:26:11 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Type                         : Microsoft.MachineLearningServices/workspaces/connections
```



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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Friendly name of the workspace connection

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IWorkspaceConnectionPropertiesV2
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
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: UpdateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
Name of Azure Machine Learning workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IWorkspaceConnectionPropertiesV2BasicResource

## NOTES

## RELATED LINKS

