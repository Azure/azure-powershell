### Example 1: Creates a workspace connection
```powershell
New-AzMLWorkspaceConnection -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name test01 -AuthType 'None' -Category 'ContainerRegistry' -Target "www.facebook.com"
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
test01                                                                                                                                                ml-rg-test
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
Name                 SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName 
----                 -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- 
aiservicesconnection 7/19/2024 9:20:27 AM t-user@AAexample.com  User                    7/19/2024 9:20:27 AM     t-user@AAexample.com     User                         ml-test
```

