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

