---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/new-azmlworkspaceconnection
schema: 2.0.0
---

# New-AzMLWorkspaceConnection

## SYNOPSIS
Creating or updating a new workspace connection

## SYNTAX

### CreateExpanded (Default)
```
New-AzMLWorkspaceConnection -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -AuthType <String> [-SubscriptionId <String>] [-Category <String>] [-ExpiryTime <DateTime>] [-IsSharedToAll]
 [-Metadata <Hashtable>] [-SharedUserList <String[]>] [-Target <String>] [-Value <String>]
 [-ValueFormat <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithProperty
```
New-AzMLWorkspaceConnection -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -Property <IWorkspaceConnectionPropertiesV2> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creating or updating a new workspace connection

## EXAMPLES

### Example 1: Creates a workspace connection
```powershell
New-AzMLWorkspaceConnection -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name test01 -AuthType 'None' -Category 'ContainerRegistry' -Target "www.facebook.com"
```

```output
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/connections/test01
Name                         : test01
Property                     : {
                                 "authType": "None",
                                 "category": "ContainerRegistry",
                                 "createdByWorkspaceArmId":
                               "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2",
                                 "group": "Azure",
                                 "isSharedToAll": false,
                                 "target": "www.facebook.com",
                                 "sharedUserList": [ ]
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 8:00:58 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 8:00:58 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Type                         : Microsoft.MachineLearningServices/workspaces/connections
```

Creates a workspace connection

### Example 2: Create a workspace connection with workspace connection property
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

$connectproperty = New-AzMLWorkspaceNoneAuthTypeWorkspaceConnectionPropertiesObject -Category 'ContainerRegistry' -Target "www.facebook.com" -IsSharedToAll $true
New-AzMLWorkspaceConnection -Name aiservicesconnection -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Property $connectproperty
```

```output
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/connections/test01
Name                         : aiservicesconnection
Property                     : {
                                 "authType": "None",
                                 "category": "ContainerRegistry",
                                 "createdByWorkspaceArmId":
                               "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2",
                                 "group": "Azure",
                                 "isSharedToAll": true,
                                 "target": "www.facebook.com",
                                 "sharedUserList": [ ]
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 8:00:58 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 8:00:58 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Type                         : Microsoft.MachineLearningServices/workspaces/connections
```



## PARAMETERS

### -AuthType
Authentication type of the connection target

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Category
Category of the connection

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -ExpiryTime


```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSharedToAll


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
Store user metadata for this connection

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Friendly name of the workspace connection

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

### -Property
Using one of WorkspaceConnectionPropertiesObject cmdlets to construct

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IWorkspaceConnectionPropertiesV2
Parameter Sets: CreateWithProperty
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedUserList


```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target


```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Value details of the workspace connection.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValueFormat
format for the workspace connection value

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Azure Machine Learning workspace.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IWorkspaceConnectionPropertiesV2BasicResource

## NOTES

## RELATED LINKS

