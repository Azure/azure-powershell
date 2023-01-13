### Example 1: List all linkers in a spring cloud app's deployment
```powershell
Get-AzServiceLinkerForSpringCloud -ServiceName servicelinker-springcloud -AppName appconfiguration -ResourceGroupName servicelinker-test-group -DeploymentName "default"
```

```output
Name
----
appconfig_08b18
postgresql_novnet
postgresql_203ca
eventhub_3ab5f
```

List all linkers in a spring cloud app's deployment

### Example 2: Get linker by name
```powershell
Get-AzServiceLinkerForSpringCloud -ServiceName servicelinker-springcloud -AppName appconfiguration -DeploymentName "default" -ResourceGroupName servicelinker-test-group  -Name postgresql_connection | fl
```

```output
AuthInfo                     : Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Model
                               s.Api20220501.SecretAuthInfo
ClientType                   : dotnet
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/re 
                               sourceGroups/servicelinker-test-group/providers/ 
                               Microsoft.AppPlatform/Spring/servicelinker-springcloud/apps/appconfiguration/deployments/default/providers 
                               /Microsoft.ServiceLinker/linkers/postgresql_connection     
Name                         : postgresql_connection
ProvisioningState            : Succeeded
Scope                        : 
SecretStoreKeyVaultId        :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TargetService                : Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Model 
                               s.Api20220501.AzureResource
Type                         : microsoft.servicelinker/linkers
VNetSolutionType             : serviceEndpoint

```

Get linker by name

### Example 3: Get linker via identity object
```powershell
$identity = @{
ResourceUri = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-linux-group/providers/Microsoft.AppPlatform/Spring/servicelinker-springcloud/apps/appconfiguration/deployments/default'
LinkerName = 'postgresql_connection'}

$identity | Get-AzServiceLinkerForSpringCloud  |fl
```

```output
AuthInfo                     : Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Model
                               s.Api20220501.SecretAuthInfo
ClientType                   : dotnet
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/re 
                               sourceGroups/servicelinker-test-group/providers/ 
                               Microsoft.AppPlatform/Spring/servicelinker-springcloud/apps/appconfiguration/deployments/default/providers 
                               /Microsoft.ServiceLinker/linkers/postgresql_connection     
Name                         : postgresql_connection
ProvisioningState            : Succeeded
Scope                        : 
SecretStoreKeyVaultId        :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TargetService                : Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Model 
                               s.Api20220501.AzureResource
Type                         : microsoft.servicelinker/linkers
VNetSolutionType             : serviceEndpoint

```

Get linker by name

