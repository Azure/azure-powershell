# Migration Guide for Az 10.0.0

## Az.Cdn

### `Update-AzFrontDoorCdnProfile`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Update-AzCdnProfile`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Update-AzCdnOriginGroup`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Update-AzCdnOrigin`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Update-AzCdnEndpoint`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Stop-AzCdnEndpoint`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Start-AzCdnEndpoint`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `New-AzFrontDoorCdnProfile`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `New-AzCdnProfile`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `New-AzCdnOriginGroup`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `New-AzCdnOrigin`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `New-AzCdnEndpoint`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `New-AzCdnCustomDomain`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Get-AzFrontDoorCdnProfile`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Get-AzCdnSubscriptionResourceUsage`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Get-AzCdnProfileResourceUsage`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Get-AzCdnProfile`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Get-AzCdnOriginGroup`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Get-AzCdnOrigin`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Get-AzCdnEndpointResourceUsage`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Get-AzCdnEndpoint`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Get-AzCdnCustomDomain`
- The output type is changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile' to'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IProfile' without properties changed.

### `Enable-AzCdnCustomDomainCustomHttps`
- The cmdlet 'Enable-AzCdnCustomDomainCustomHttps' no longer supports the parameter 'PassThru' and no alias was found for the original parameter name.

#### Before
```powershell
$customDomainHttpsParameter = New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType Dedicated -CertificateSource Cdn  -ProtocolType ServerNameIndication
Enable-AzCdnCustomDomainCustomHttps -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -CustomDomainName customdomain001 -CustomDomainHttpsParameter $customDomainHttpsParameter -PassThru

Output:
True
```
#### After
```powershell
$customDomainHttpsParameter = New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType Dedicated -CertificateSource Cdn  -ProtocolType ServerNameIndication
Enable-AzCdnCustomDomainCustomHttps -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -CustomDomainName customdomain001 -CustomDomainHttpsParameter $customDomainHttpsParameter

Output:
Null
```


### `Disable-AzCdnCustomDomainCustomHttps`
- The cmdlet 'Disable-AzCdnCustomDomainCustomHttps' no longer supports the parameter 'PassThru' and no alias was found for the original parameter name.

#### Before
```powershell
Disable-AzCdnCustomDomainCustomHttps -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -CustomDomainName customdomain001 -PassThru

Output:
True
```
#### After
```powershell
Disable-AzCdnCustomDomainCustomHttps -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -CustomDomainName customdomain001

OutPut:
Null
```


## Az.Compute

### `Get-AzVM`
- The cmdlet 'Get-AzVM' no longer supports the parameter 'NextLink' and no alias was found for the original parameter name.

#### Before
```powershell
Get-AzVM -NextLink $myUri
```
#### After
```powershell
Get-AzVM -ResourceGroupName $rgname -Name $vmName
```


## Az.ContainerRegistry

### `Update-AzContainerRegistryWebhook`
- The cmdlet 'Update-AzContainerRegistryWebhook' no longer supports the alias 'WebhookUri' for parameter 'Uri'.
- The cmdlet 'Update-AzContainerRegistryWebhook' no longer supports the alias 'WebhookActions' for parameter 'Action'.
- The cmdlet 'Update-AzContainerRegistryWebhook' no longer supports the alias 'WebhookHeaders' for parameter 'Header'.
- The cmdlet 'Update-AzContainerRegistryWebhook' no longer supports the alias 'WebhookStatus' for parameter 'Status'.
- The cmdlet 'Update-AzContainerRegistryWebhook' no longer supports the alias 'WebhookScope' for parameter 'Scope'.
- The cmdlet 'Update-AzContainerRegistryWebhook' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Update-AzContainerRegistryWebhook' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzContainerRegistryWebhook' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzContainerRegistryWebhook' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Update-AzContainerRegistryWebhook -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry/webhooks/webhook001 -Uri http://www.bing.com -Action Delete,Push -Header @{SpecialHeader='headerVal'} -Tag @{Key='val'} -Status Enabled -Scope 'foo:*'
```
#### After
```powershell
Update-AzContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001" -Uri http://www.bing.com -Action Delete,Push -Header @{SpecialHeader='headerVal'} -Tag @{Key='val'} -Status Enabled -Scope 'foo:*'
```


### `Update-AzContainerRegistryCredential`
- The cmdlet 'Update-AzContainerRegistryCredential' no longer supports the alias 'RegistryName' for parameter 'Name'.
- The cmdlet 'Update-AzContainerRegistryCredential' no longer supports the type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistry' for parameter 'Registry'.
- The cmdlet 'Update-AzContainerRegistryCredential' no longer supports the type 'Microsoft.Azure.Management.ContainerRegistry.Models.PasswordName' for parameter 'PasswordName'.
- The cmdlet 'Update-AzContainerRegistryCredential' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Update-AzContainerRegistryCredential' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzContainerRegistryCredential' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzContainerRegistryCredential' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Update-AzContainerRegistryCredential -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry -PasswordName password

```
#### After
```powershell
Update-AzContainerRegistryCredential -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -PasswordName Password
```


### `Update-AzContainerRegistry`
- The cmdlet 'Update-AzContainerRegistry' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistry'.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the alias 'EnableAdmin' for parameter 'EnableAdminUser'.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the parameter 'DisableAdminUser' and no alias was found for the original parameter name.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the parameter 'StorageAccountName' and no alias was found for the original parameter name.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the parameter 'NetworkRuleSet' and no alias was found for the original parameter name.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the alias 'ContainerRegistrySku' for parameter 'Sku'.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the alias 'RegistrySku' for parameter 'Sku'.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzContainerRegistry' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Update-AzContainerRegistry -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry -EnableAdmin
```
#### After
```powershell
Update-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "RegistryExample" -EnableAdminUser
```


### `Test-AzContainerRegistryWebhook`
- The cmdlet 'Test-AzContainerRegistryWebhook' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryEventInfo'.
- The cmdlet 'Test-AzContainerRegistryWebhook' no longer supports the type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryWebhook' for parameter 'Webhook'.
- The cmdlet 'Test-AzContainerRegistryWebhook' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Test-AzContainerRegistryWebhook' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Test-AzContainerRegistryWebhook' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Test-AzContainerRegistryWebhook' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Test-AzContainerRegistryWebhook -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry/webhooks/webhook001
```
#### After
```powershell
Test-AzContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001"
```


### `Test-AzContainerRegistryNameAvailability`
- The cmdlet 'Test-AzContainerRegistryNameAvailability' no longer supports the alias 'ContainerRegistryName' for parameter 'Name'.
- The cmdlet 'Test-AzContainerRegistryNameAvailability' no longer supports the alias 'RegistryName' for parameter 'Name'.
- The cmdlet 'Test-AzContainerRegistryNameAvailability' no longer supports the alias 'ResourceName' for parameter 'Name'.
- The cmdlet 'Test-AzContainerRegistryNameAvailability' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Test-AzContainerRegistryNameAvailability' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Test-AzContainerRegistryNameAvailability' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Test-AzContainerRegistryNameAvailability -ContainerRegistryName 'SomeRegistryName'
```
#### After
```powershell
Test-AzContainerRegistryNameAvailability -Name 'SomeRegistryName'
```


### `Set-AzContainerRegistryNetworkRuleSet`
- The cmdlet 'Set-AzContainerRegistryNetworkRuleSet' has been removed and no alias was found for the original cmdlet name.

### `Remove-AzContainerRegistryWebhook`
- The cmdlet 'Remove-AzContainerRegistryWebhook' no longer supports the parameter 'Webhook' and no alias was found for the original parameter name.
- The cmdlet 'Remove-AzContainerRegistryWebhook' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Remove-AzContainerRegistryWebhook' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzContainerRegistryWebhook' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzContainerRegistryWebhook' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Remove-AzContainerRegistryWebhook -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry/webhooks/webhook001
```
#### After
```powershell
Remove-AzContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001"
```


### `Remove-AzContainerRegistryReplication`
- The cmdlet 'Remove-AzContainerRegistryReplication' no longer supports the parameter 'Replication' and no alias was found for the original parameter name.
- The cmdlet 'Remove-AzContainerRegistryReplication' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Remove-AzContainerRegistryReplication' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzContainerRegistryReplication' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzContainerRegistryReplication' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Remove-AzContainerRegistryReplication -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry/replications/westus
```
#### After
```powershell
Remove-AzContainerRegistryReplication -Name "NewReplication" -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"
```


### `Remove-AzContainerRegistry`
- The cmdlet 'Remove-AzContainerRegistry' no longer supports the parameter 'Registry' and no alias was found for the original parameter name.
- The cmdlet 'Remove-AzContainerRegistry' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Remove-AzContainerRegistry' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzContainerRegistry' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzContainerRegistry' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Remove-AzContainerRegistry -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry
```
#### After
```powershell
Remove-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "MyRegistry"
```


### `New-AzContainerRegistryWebhook`
- The cmdlet 'New-AzContainerRegistryWebhook' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryWebhook'.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the alias 'WebhookUri' for parameter 'Uri'.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the alias 'WebhookActions' for parameter 'Action'.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the alias 'WebhookHeaders' for parameter 'Header'.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the alias 'WebhookStatus' for parameter 'Status'.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the alias 'WebhookScope' for parameter 'Scope'.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the alias 'WebhookLocation' for parameter 'Location'.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzContainerRegistryWebhook' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
New-AzContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001" -Uri http://www.bing.com -Action Delete,Push -Header @{SpecialHeader='headerVal'} -Tag @{Key="val"} -Location "east us" -Status WebhookStatus -WebhookScope "foo:*"
```
#### After
```powershell
New-AzContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001" -Uri http://www.bing.com -Action Delete,Push -Header @{SpecialHeader='headerVal'} -Tag @{Key="val"} -Location "east us" -Status Enabled -Scope "foo:*"
```


### `New-AzContainerRegistryReplication`
- The cmdlet 'New-AzContainerRegistryReplication' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryReplication'.
- The cmdlet 'New-AzContainerRegistryReplication' no longer supports the type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistry' for parameter 'Registry'.
- The cmdlet 'New-AzContainerRegistryReplication' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'New-AzContainerRegistryReplication' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzContainerRegistryReplication' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzContainerRegistryReplication' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
New-AzContainerRegistryReplication -Name replication001 -Location 'west us' -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry
```
#### After
```powershell
New-AzContainerRegistryReplication -ResourceGroupName "MyResourceGroup" -RegistryName "MyRegistry" -Name replication001 -Location 'west us'
```


### `New-AzContainerRegistryNetworkRule`
- The cmdlet 'New-AzContainerRegistryNetworkRule' has been removed and no alias was found for the original cmdlet name.

### `New-AzContainerRegistry`
- The cmdlet 'New-AzContainerRegistry' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistry'.
- The cmdlet 'New-AzContainerRegistry' no longer supports the alias 'ContainerRegistrySku' for parameter 'Sku'.
- The cmdlet 'New-AzContainerRegistry' no longer supports the alias 'RegistrySku' for parameter 'Sku'.
- The cmdlet 'New-AzContainerRegistry' no longer supports the alias 'EnableAdmin' for parameter 'EnableAdminUser'.
- The cmdlet 'New-AzContainerRegistry' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzContainerRegistry' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzContainerRegistry' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
 New-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "RegistryExample" -ContainerRegistrySku "Basic" -Location "west us" -EnableAdmin
```
#### After
```powershell
 New-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "RegistryExample" -Sku "Basic" -Location "west us" -EnableAdminUser
```


### `Import-AzContainerRegistryImage`
- The cmdlet 'Import-AzContainerRegistryImage' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Import-AzContainerRegistryImage' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Import-AzContainerRegistryImage' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Get-AzContainerRegistryWebhookEvent`
- The cmdlet 'Get-AzContainerRegistryWebhookEvent' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryWebhookEvent'.
- The cmdlet 'Get-AzContainerRegistryWebhookEvent' no longer supports the type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryWebhook' for parameter 'Webhook'.
- The cmdlet 'Get-AzContainerRegistryWebhookEvent' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Get-AzContainerRegistryWebhookEvent' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryWebhookEvent' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryWebhookEvent' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Get-AzContainerRegistryWebhookEvent -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry/webhooks/webhook001
```
#### After
```powershell
Get-AzContainerRegistryWebhookEvent  -ResourceGroupName MyResourceGroup -RegistryName RegistryExample -WebhookName webhook001
```


### `Get-AzContainerRegistryWebhook`
- The cmdlet 'Get-AzContainerRegistryWebhook' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryWebhook'.
- The cmdlet 'Get-AzContainerRegistryWebhook' no longer supports the type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistry' for parameter 'Registry'.
- The cmdlet 'Get-AzContainerRegistryWebhook' no longer supports the parameter 'IncludeConfiguration' and no alias was found for the original parameter name.
- The cmdlet 'Get-AzContainerRegistryWebhook' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Get-AzContainerRegistryWebhook' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryWebhook' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryWebhook' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Get-AzContainerRegistryWebhook -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry/webhooks/webhook001
```
#### After
```powershell
Get-AzContainerRegistryWebhook  -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001"
```


### `Get-AzContainerRegistryUsage`
- The cmdlet 'Get-AzContainerRegistryUsage' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.Models.PSRegistryUsage'.
- The cmdlet 'Get-AzContainerRegistryUsage' no longer supports the alias 'RegistryName' for parameter 'Name'.
- The cmdlet 'Get-AzContainerRegistryUsage' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryUsage' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryUsage' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Get-AzContainerRegistryUsage -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry
```
#### After
```powershell
Get-AzContainerRegistryUsage -ResourceGroupName "MyResourceGroup" -Name "MyRegistry"
```


### `Get-AzContainerRegistryReplication`
- The cmdlet 'Get-AzContainerRegistryReplication' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryReplication'.
- The cmdlet 'Get-AzContainerRegistryReplication' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Get-AzContainerRegistryReplication' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryReplication' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryReplication' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Get-AzContainerRegistryReplication  -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry/replications/westus
```
#### After
```powershell
 Get-AzContainerRegistryReplication -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"
```


### `Get-AzContainerRegistryCredential`
- The cmdlet 'Get-AzContainerRegistryCredential' no longer supports the alias 'ContainerRegistryName' for parameter 'Name'.
- The cmdlet 'Get-AzContainerRegistryCredential' no longer supports the alias 'RegistryName' for parameter 'Name'.
- The cmdlet 'Get-AzContainerRegistryCredential' no longer supports the alias 'ResourceName' for parameter 'Name'.
- The cmdlet 'Get-AzContainerRegistryCredential' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Get-AzContainerRegistryCredential' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryCredential' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistryCredential' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
 Get-AzContainerRegistryCredential  -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry
```
#### After
```powershell
 Get-AzContainerRegistryCredential -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"
```


### `Get-AzContainerRegistry`
- The cmdlet 'Get-AzContainerRegistry' no longer has output type 'Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistry'.
- The cmdlet 'Get-AzContainerRegistry' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Get-AzContainerRegistry' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistry' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzContainerRegistry' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Get-AzContainerRegistry -ResourceId /subscriptions/{subscriptionID}/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerRegistry/registries/MyRegistry
```
#### After
```powershell
Get-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "MyRegistry"
```


## Az.DataProtection

### `Initialize-AzDataProtectionBackupInstance`
- The parameter 'BackupConfiguration' is changed from 'Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.KubernetesClusterBackupDatasourceParameters' to its base class type 'Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupDatasourceParameters'. The usage remains unchanged.

## Az.DesktopVirtualization

### `Update-AzWvdScalingPlan`
- The cmdlet 'Update-AzWvdScalingPlan' no longer supports the parameter 'HostPoolType' and no alias was found for the original parameter name.

#### Before
```powershell
Update-AzWvdScalingPlan `
            -ResourceGroupName ResourceGroupName `
            -Name 'scalingPlan1' `
            -Description 'Description' `
            -FriendlyName 'Friendly Name' `
            -HostPoolType 'Pooled' `
            -TimeZone '(UTC-08:00) Pacific Time (US & Canada)' `
            -Schedule @(
                @{
                    'name'                           = 'Work Week';
                    'daysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');
                    'rampUpStartTime'                = '1900-01-01T06:00:00Z';
                    'rampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                    'rampUpMinimumHostsPct'          = 20;
                    'rampUpCapacityThresholdPct'     = 20;
                    'peakStartTime'                  = '1900-01-01T08:00:00Z';
                    'peakLoadBalancingAlgorithm'     = 'DepthFirst';
                    'RampDownStartTime'              = '1900-01-01T18:00:00Z';
                    'rampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                    'rampDownMinimumHostsPct'        = 20;
                    'rampDownCapacityThresholdPct'   = 20;
                    'rampDownForceLogoffUser'        = $true;
                    'rampDownWaitTimeMinute'         = 30;
                    'rampDownNotificationMessage'    = 'Log out now, please.';
                    'rampDownStopHostsWhen'          = 'ZeroSessions';
                    'offPeakStartTime'               = '1900-01-01T20:00:00Z';
                    'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                }
            ) `
            -HostPoolReference @(
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName1';
                    'scalingPlanEnabled' = $false;
                },
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName2';
                    'scalingPlanEnabled' = $false;
                }

            )
```
#### After
```powershell
Update-AzWvdScalingPlan `
            -ResourceGroupName ResourceGroupName `
            -Name 'scalingPlan1' `
            -Description 'Description' `
            -FriendlyName 'Friendly Name' `
            -TimeZone '(UTC-08:00) Pacific Time (US & Canada)' `
            -Schedule @(
                @{
                    'name'                           = 'Work Week';
                    'daysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');
                    'rampUpStartTime'                = '1900-01-01T06:00:00Z';
                    'rampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                    'rampUpMinimumHostsPct'          = 20;
                    'rampUpCapacityThresholdPct'     = 20;
                    'peakStartTime'                  = '1900-01-01T08:00:00Z';
                    'peakLoadBalancingAlgorithm'     = 'DepthFirst';
                    'RampDownStartTime'              = '1900-01-01T18:00:00Z';
                    'rampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                    'rampDownMinimumHostsPct'        = 20;
                    'rampDownCapacityThresholdPct'   = 20;
                    'rampDownForceLogoffUser'        = $true;
                    'rampDownWaitTimeMinute'         = 30;
                    'rampDownNotificationMessage'    = 'Log out now, please.';
                    'rampDownStopHostsWhen'          = 'ZeroSessions';
                    'offPeakStartTime'               = '1900-01-01T20:00:00Z';
                    'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                }
            ) `
            -HostPoolReference @(
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName1';
                    'scalingPlanEnabled' = $false;
                },
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName2';
                    'scalingPlanEnabled' = $false;
                }

            )
```


### `General`
We upgraded the API version of the Az.DesktopVirtualization module from 2021-07-12 to 2022-09-09. It caused breaking changes as we include the version in the namespace of the models, for example, 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210712.IHostPool'. If your script depends on the namespace, please replace "Api20210712" with "Api202209".

### `New-AzWvdScalingPlan`
- The cmdlet 'New-AzWvdScalingPlan' no longer supports the type 'Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType' for parameter 'HostPoolType'.

#### Before
```powershell
New-AzWvdScalingPlan `
            -ResourceGroupName ResourceGroupName `
            -Name 'scalingPlan1' `
            -Location 'westcentralus' `
            -Description 'Description' `
            -FriendlyName 'Friendly Name' `
            -HostPoolType 'Pooled' `
            -TimeZone '(UTC-08:00) Pacific Time (US & Canada)' `
            -Schedule @(
                @{
                    'name'                           = 'Work Week';
                    'daysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');
                    'rampUpStartTime'                = '1900-01-01T06:00:00Z';
                    'rampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                    'rampUpMinimumHostsPct'          = 20;
                    'rampUpCapacityThresholdPct'     = 20;
                    'peakStartTime'                  = '1900-01-01T08:00:00Z';
                    'peakLoadBalancingAlgorithm'     = 'DepthFirst';
                    'RampDownStartTime'              = '1900-01-01T18:00:00Z';
                    'rampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                    'rampDownMinimumHostsPct'        = 20;
                    'rampDownCapacityThresholdPct'   = 20;
                    'rampDownForceLogoffUser'        = $true;
                    'rampDownWaitTimeMinute'         = 30;
                    'rampDownNotificationMessage'    = 'Log out now, please.';
                    'rampDownStopHostsWhen'          = 'ZeroSessions';
                    'offPeakStartTime'               = '1900-01-01T20:00:00Z';
                    'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                }
            ) `
            -HostPoolReference @(
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName';
                    'scalingPlanEnabled' = $false;
                }
            )
```
#### After
```powershell
New-AzWvdScalingPlan `
            -ResourceGroupName ResourceGroupName `
            -Name 'scalingPlan1' `
            -Location 'westcentralus' `
            -Description 'Description' `
            -FriendlyName 'Friendly Name' `
            -TimeZone '(UTC-08:00) Pacific Time (US & Canada)' `
            -Schedule @(
                @{
                    'name'                           = 'Work Week';
                    'daysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');
                    'rampUpStartTime'                = '1900-01-01T06:00:00Z';
                    'rampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                    'rampUpMinimumHostsPct'          = 20;
                    'rampUpCapacityThresholdPct'     = 20;
                    'peakStartTime'                  = '1900-01-01T08:00:00Z';
                    'peakLoadBalancingAlgorithm'     = 'DepthFirst';
                    'RampDownStartTime'              = '1900-01-01T18:00:00Z';
                    'rampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                    'rampDownMinimumHostsPct'        = 20;
                    'rampDownCapacityThresholdPct'   = 20;
                    'rampDownForceLogoffUser'        = $true;
                    'rampDownWaitTimeMinute'         = 30;
                    'rampDownNotificationMessage'    = 'Log out now, please.';
                    'rampDownStopHostsWhen'          = 'ZeroSessions';
                    'offPeakStartTime'               = '1900-01-01T20:00:00Z';
                    'offPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                }
            ) `
            -HostPoolReference @(
                @{
                    'hostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName';
                    'scalingPlanEnabled' = $false;
                }
            )
```


### `New-AzWvdHostPool`
- The cmdlet 'New-AzWvdHostPool' no longer supports the parameter 'MigrationRequestMigrationPath' and no alias was found for the original parameter name.
- The cmdlet 'New-AzWvdHostPool' no longer supports the parameter 'MigrationRequestOperation' and no alias was found for the original parameter name.

#### Before
```powershell
New-AzWvdHostpool -hostpoolName  hpName -location westus -resourceGroupName rgName -friendlyName "friendly" -description "des1" -hostPoolType Pooled -personalDesktopAssignmentType Automatic -customRdpProperty null -maxSessionLimit 999999 -loadBalancerType BreadthFirst -registrationInfo @{
          "expirationTime"= "2020-10-01T14:01:54.9571247Z",
          "registrationTokenOperation":="Update"
        }
        -vmTemplate "{json:json}"
        -ssoadfsAuthority "https://adfs"
        -ssoClientId "client"
        -ssoClientSecretKeyVaultPath "https://keyvault/secret"
        -ssoSecretType "SharedKey”
        -preferredAppGroupType Desktop
        -startVMOnConnect $false
        -migrationRequest @{
          "migrationPath"= "TenantGroups/{defaultV1TenantGroup.Name}/Tenants/{defaultV1Tenant.Name}/HostPools/{sessionHostPool.Name}",
          "operation"= "Start"
        }
```
#### After
```powershell
New-AzWvdHostpool -hostpoolName  hpName -location westus -resourceGroupName rgName -friendlyName "friendly" -description "des1" -hostPoolType Pooled -personalDesktopAssignmentType Automatic -customRdpProperty null -maxSessionLimit 999999 -loadBalancerType BreadthFirst -registrationInfo @{
          "expirationTime"= "2020-10-01T14:01:54.9571247Z",
          "registrationTokenOperation":="Update"
        }
        -vmTemplate "{json:json}"
        -ssoadfsAuthority https://adfs
        -ssoClientId "client"
        -ssoClientSecretKeyVaultPath https://keyvault/secret
        -ssoSecretType "SharedKey”
        -preferredAppGroupType Desktop
        -startVMOnConnect $false
       -agentUpdate @{
          "type"= "Scheduled",
          "useSessionHostLocalTime"= $false,
          "maintenanceWindowTimeZone"= "Alaskan Standard Time",
          "maintenanceWindows"= “{json:json}
        }
```


### `New-AzWvdApplicationGroup`
- The cmdlet 'New-AzWvdApplicationGroup' no longer supports the parameter 'MigrationRequestMigrationPath' and no alias was found for the original parameter name.
- The cmdlet 'New-AzWvdApplicationGroup' no longer supports the parameter 'MigrationRequestOperation' and no alias was found for the original parameter name.

#### Before
```powershell
New-AzWvdApplicationGroup -resourceGroupName “rgName” -applicationGroupName “appName” -applicationGroup @{"description"= "des1",
        "friendlyName"= "friendly",
        "hostPoolArmPath"= "/subscriptions/daefabc0-95b4-48b3-b645-8a753a63c4fa/resourceGroups/resourceGroup1/providers/Microsoft.DesktopVirtualization/hostPools/hostPool1",
        "applicationGroupType"= "RemoteApp",
        "migrationRequest"= @{
          "migrationPath"="TenantGroups/{defaultV1TenantGroup.Name}/Tenants/{defaultV1Tenant.Name}/HostPools/{sessionHostPool.Name}",
          "operation"= "Start"
        }

```
#### After
```powershell
New-AzWvdApplicationGroup -resourceGroupName -applicationGroupName -applicationGroup @{"description"= "des1",
        "friendlyName"= "friendly",
        "hostPoolArmPath"= "/subscriptions/daefabc0-95b4-48b3-b645-8a753a63c4fa/resourceGroups/resourceGroup1/providers/Microsoft.DesktopVirtualization/hostPools/hostPool1",
        "applicationGroupType"= "RemoteApp"
}
```


## Az.EventHub

### `Set-AzEventHubNamespace`
- The cmdlet 'Set-AzEventHubNamespace' has undergone several changes, including changes to the output type and default parameter set. 
- The cmdlet no longer supports certain aliases and parameter types, including 'NamespaceName', 'System.String' for 'SkuName', and 'System.Nullable`1[System.Int32]' for 'SkuCapacity'. Additionally, the parameters 'MaximumThroughputUnits', 'EnableKafka', 'ClusterARMId', 'IdentityId', and 'EncryptionConfig' are no longer supported, and no aliases were found for the original parameter names. 
- The cmdlet also no longer supports the 'IAzureContextContainer' type for the 'DefaultProfile' parameter, and the 'AzContext' and 'AzureRmContext' aliases for 'DefaultProfile' are no longer supported. Finally, several parameter sets, including '__AllParameterSets', 'NamespaceParameterSet', and 'AutoInflateParameterSet', have been removed.

### `Set-AzEventHub`
- MessageRetentionInDays' has been deprecated and replaced by '-RetentionTimeInHours'.

#### Before
```powershell
$eventhub = Get-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace
Set-AzEventHub -InputObject $eventhub -MessageRetentionInDays 3
```
#### After
```powershell
Set-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
    -BlobContainer container -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId
    "/subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount"
```


### `Remove-AzEventHubVirtualNetworkRule`
- The cmdlet 'Remove-AzEventHubVirtualNetworkRule' has been removed. Please use 'Set-AzEventHubNetworkRuleSet'.

#### Before
```powershell
Remove-AzEventHubVirtualNetworkRule -ResourceGroupName v-ajnavtest -Name Eventhub-Namespace1-2389 -SubnetId "/subscriptions/SubscriptionId/resourcegroups/ResourceGroup/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault01"
```
#### After
```powershell
$virtualNetworkRule1 = New-AzEventHubVirtualNetworkRuleConfig -SubnetId '/subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/default'
Set-AzEventHubNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -VirtualNetworkRule $virtualNetworkRule1
```


### `Remove-AzEventHubNetworkRuleSet`
- The cmdlet 'Remove-AzEventHubNetworkRuleSet' has been removed. Please use 'Set-AzEventHubNetworkRuleSet'.

#### Before
```powershell
Remove-AzEventHubNetworkRuleSet -ResourceGroupName  v-ajnavtest -Name Eventhub-Namespace1-1375 -PassThru
```
#### After
```powershell
Set-AzEventHubNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -VirtualNetworkRule @()
```


### `Remove-AzEventHubNamespace`
- The cmdlet 'Remove-AzEventHubNamespace' has undergone several changes, including type change for parameter 'InputObject' and 'DefaultProfile', but the usage remains the same, including piping.

### `Remove-AzEventHubIPRule`
- The cmdlet 'Remove-AzEventHubIPRule' has been removed. Please use 'Set-AzEventHubNetworkRuleSet'.

#### Before
```powershell
Remove-AzEventHubIPRule -ResourceGroupName v-ajnavtest -Name Eventhub-Namespace1-2389 -IpMask "11.22.33.44"
```
#### After
```powershell
$ipRule1 = New-AzEventHubIPRuleConfig -IPMask 2.2.2.2 -Action Allow
$ipRule2 = New-AzEventHubIPRuleConfig -IPMask 3.3.3.3 -Action Allow
Set-AzEventHubNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -IPRule $ipRule1,$ipRule2
```


### `New-AzEventHubNamespace`
- The cmdlet 'New-AzEventHubNamespace' has undergone several changes, including changes to the output type and default parameter set. 
- The cmdlet no longer supports certain aliases and parameter types, including 'NamespaceName', 'System.String' for 'SkuName', and 'System.Nullable`1[System.Int32]' for 'SkuCapacity'. Additionally, the parameters 'MaximumThroughputUnits', 'EnableKafka', 'ClusterARMId', 'IdentityId', and 'EncryptionConfig' are no longer supported, and no aliases were found for the original parameter names. 
- The cmdlet also no longer supports the 'IAzureContextContainer' type for the 'DefaultProfile' parameter, and the 'AzContext' and 'AzureRmContext' aliases for 'DefaultProfile' are no longer supported. Finally, several parameter sets, including '__AllParameterSets', 'NamespaceParameterSet', and 'AutoInflateParameterSet', have been removed.

### `New-AzEventHubEncryptionConfig`
- The cmdlet 'New-AzEventHubEncryptionConfig' has been replaced by 'New-AzEventHubKeyVaultPropertiesObject'.

#### Before
```powershell
New-AzEventHubEncryptionConfig -KeyName key1 -KeyVaultUri https://myvaultname.vault.azure.net -UserAssignedIdentity '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName2'
```
#### After
```powershell
$keyVaultProperty1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaultUri https://testkeyvault.vault.azure.net -UserAssignedIdentity "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$keyVaultProperty2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key2 -KeyVaultUri https://testkeyvault.vault.azure.net -UserAssignedIdentity "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity"

New-AzEventHubNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentityId "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity","/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity" -KeyVaultProperty $keyVaultProperty1,$keyVaultProperty2
```


### `New-AzEventHub`
-MessageRetentionInDays' has been deprecated and replaced by '-RetentionTimeInHours'.

#### Before
```powershell
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -MessageRetentionInDays 6 -PartitionCount 5
```
#### After
```powershell
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -RetentionTimeInHour 168 -PartitionCount 5 -CleanupPolicy Delete
```


### `Get-AzEventHubNamespace`
- The output type and the properties has been changed. See the example for more information.

#### Before
```powershell
Name                   : MyNamespaceName
Id                     : /subscriptions/{subscriptionId}/resourceGroups/Default-EventHub-WestCentralUS/providers/Microsoft.EventHub/namespaces/MyNamespaceName
ResourceGroupName      : Default-EventHub-WestCentralUS
Location               : West US
Sku                    : Name : Standard , Capacity : 1 , Tier : Standard
Tags                   :
ProvisioningState      : Succeeded
Status                 : Active
CreatedAt              : 5/24/2019 12:47:27 AM
UpdatedAt              : 5/24/2019 12:48:14 AM
ServiceBusEndpoint     : #########
Enabled                : True
KafkaEnabled           : True
IsAutoInflateEnabled   : True
MaximumThroughputUnits : 10
```
#### After
```powershell
AlternateName                   :
ClusterArmId                    :
CreatedAt                       : 11/17/2022 3:14:09 PM
DisableLocalAuth                : True
EnableAutoInflate               : True
Id                              : /subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
IdentityType                    :
KafkaEnabled                    : True
KeySource                       :
KeyVaultProperty                :
Location                        : South Central US
MaximumThroughputUnit           : 0
MetricId                        : 000000000000000:myNamespace
MinimumTlsVersion               : 1.2
Name                            : myNamespace
PrincipalId                     : 000000000000000000
PrivateEndpointConnection       :
ProvisioningState               : Succeeded
PublicNetworkAccess             : Enabled
RequireInfrastructureEncryption :
ResourceGroupName               : myResourceGroup
ServiceBusEndpoint              : https://myNamespace.servicebus.windows.net:443/
SkuCapacity                     : 1
SkuName                         : Standard
SkuTier                         : Standard
Status                          : Active
Tag                             : {
                                  }
TenantId                        : 00000000000
Type                            : Microsoft.EventHub/Namespaces
UpdatedAt                       : 11/17/2022 3:21:19 PM
UserAssignedIdentity            : {
                                  }
ZoneRedundant                   : True
```


### `Get-AzEventHub`
- The cmdlet 'Get-AzEventHub' no longer has output type 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IEventhub'.
(Yeming: namespace changed, not considered a breaking change. should be removed)

### `Add-AzEventHubVirtualNetworkRule`
- The cmdlet 'Add-AzEventHubVirtualNetworkRule' has been removed. Please use 'Set-AzEventHubNetworkRuleSet'.

#### Before
```powershell
Add-AzEventHubVirtualNetworkRule -ResourceGroupName v-ajnavtest -Name Eventhub-Namespace1-2389 -SubnetId "/subscriptions/SubscriptionId/resourcegroups/ResourceGroup/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault01" -IgnoreMissingVnetServiceEndpoint
```
#### After
```powershell
$virtualNetworkRule1 = New-AzEventHubVirtualNetworkRuleConfig -SubnetId '/subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/default'
Set-AzEventHubNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -VirtualNetworkRule $virtualNetworkRule1
```


### `Add-AzEventHubIPRule`
- The cmdlet 'Add-AzEventHubIPRule' has been removed. Please use 'Set-AzEventHubNetworkRuleSet'.

#### Before
```powershell
Add-AzEventHubIPRule -ResourceGroupName v-ajnavtest -Name Eventhub-Namespace1-2389 -IpMask "11.22.33.44" -Action Allow
```
#### After
```powershell
$ipRule1 = New-AzEventHubIPRuleConfig -IPMask 2.2.2.2 -Action Allow
$ipRule2 = New-AzEventHubIPRuleConfig -IPMask 3.3.3.3 -Action Allow
Set-AzEventHubNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -IPRule $ipRule1,$ipRule2
```


## Az.HDInsight

### `New-AzHDInsightCluster`
- The cmdlet 'New-AzHDInsightCluster' no longer supports the parameter 'RdpCredential' and no alias was found for the original parameter name.
- The cmdlet 'New-AzHDInsightCluster' no longer supports the parameter 'RdpAccessExpiry' and no alias was found for the original parameter name.

#### Before
```powershell
Customer didn’t use the two parameters for a very long time. There is not old usage.
```
#### After
```powershell
Don’t use the two parameters any more.
```


## Az.Relay

### `Test-AzRelayName`
- The cmdlet 'Test-AzRelayName' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Test-AzRelayName' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Test-AzRelayName' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Set-AzWcfRelay`
- The cmdlet 'Set-AzWcfRelay' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSWcfRelayAttributes'.
- The cmdlet 'Set-AzWcfRelay' no longer supports the type 'Microsoft.Azure.Commands.Relay.Models.PSWcfRelayAttributes' for parameter 'InputObject'.
- The cmdlet 'Set-AzWcfRelay' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Set-AzWcfRelay' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Set-AzWcfRelay' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Set-AzRelayNamespace`
- The cmdlet 'Set-AzRelayNamespace' has been removed and no alias was found for the original cmdlet name.

#### Before
```powershell
Set-AzRelayNamespace -ResourceGroupName Default-ServiceBus-WestUS -Name TestNameSpace-Relay1 -Tag @{Tag2="Tag2Value"}
```
#### After
```powershell
Update-AzRelayNamespace -ResourceGroupName Default-ServiceBus-WestUS -Name TestNameSpace-Relay1 -Tag @{Tag2="Tag2Value"}
```


### `Set-AzRelayNamespace`
- The cmdlet 'Set-AzRelayNamespace' has been removed and no alias was found for the original cmdlet name.

#### Before
```powershell
$relayNamespace = new RelayNamespaceAttirbutesUpdateParameter()
Update-AzRelayNamespace -InputObject $relayNamespace -Tag @{'k'='v'}
```
#### After
```powershell
$relayNamespace = Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01
Update-AzRelayNamespace -InputObject $relayNamespace -Tag @{'k'='v'}
```


### `Set-AzRelayHybridConnection`
- The cmdlet 'Set-AzRelayHybridConnection' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSHybridConnectionAttributes'.
- The cmdlet 'Set-AzRelayHybridConnection' no longer supports the type 'Microsoft.Azure.Commands.Relay.Models.PSHybridConnectionAttributes' for parameter 'InputObject'.
- The cmdlet 'Set-AzRelayHybridConnection' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Set-AzRelayHybridConnection' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Set-AzRelayHybridConnection' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Set-AzRelayAuthorizationRule`
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSAuthorizationRuleAttributes'.
The parameter set 'NamespaceAuthorizationRuleSet' for cmdlet 'Set-AzRelayAuthorizationRule' is no longer the default parameter set.
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer supports the type 'Microsoft.Azure.Commands.Relay.Models.PSAuthorizationRuleAttributes' for parameter 'InputObject'.
The element type for parameter 'Rights' has been changed from 'System.String' to 'Microsoft.Azure.PowerShell.Cmdlets.Relay.Support.AccessRights'.
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Set-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -WcfRelay TestWCFRelay1 -Name AuthoRule1 -Rights "Send"
```
#### After
```powershell
Set-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -Namespace TestNameSpace-Relay1 -WcfRelay TestWCFRelay1 -Name AuthoRule1 -Rights "Send"
```


### `Set-AzRelayAuthorizationRule`
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSAuthorizationRuleAttributes'.
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer supports the type 'Microsoft.Azure.Commands.Relay.Models.PSAuthorizationRuleAttributes' for parameter 'InputObject'.
The element type for parameter 'Rights' has been changed from 'System.String' to 'Microsoft.Azure.PowerShell.Cmdlets.Relay.Support.AccessRights'.
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Set-AzRelayAuthorizationRule' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
$GetHybirdAutho = Get-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -Namespace TestNameSpace-Relay1 -HybridConnection TestHybridConnection -Name AuthoRule1
Set-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -Namespace TestNameSpace-Relay1 -HybridConnection TestHybridConnection -Name AuthoRule1 -InputObject $GetHybirdAutho -Rights {"Listen", "Send"}
```
#### After
```powershell
$GetHybirdAutho = Get-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -Namespace TestNameSpace-Relay1 -HybridConnection TestHybridConnection -Name AuthoRule1
$GetHybirdAutho.Rights.Add("Send")
Set-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -Namespace TestNameSpace-Relay1 -HybridConnection TestHybridConnection -Name AuthoRule1 -InputObject $GetHybirdAutho
```


### `Remove-AzWcfRelay`
- The cmdlet 'Remove-AzWcfRelay' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzWcfRelay' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzWcfRelay' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Remove-AzRelayNamespace`
- The cmdlet 'Remove-AzRelayNamespace' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzRelayNamespace' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzRelayNamespace' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Remove-AzRelayHybridConnection`
- The cmdlet 'Remove-AzRelayHybridConnection' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzRelayHybridConnection' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzRelayHybridConnection' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Remove-AzRelayAuthorizationRule`
- The cmdlet 'Remove-AzRelayAuthorizationRule' no longer supports the parameter 'Force' and no alias was found for the original parameter name.
- The cmdlet 'Remove-AzRelayAuthorizationRule' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzRelayAuthorizationRule' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzRelayAuthorizationRule' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Remove-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -WcfRelay TestWcfRelay -Name AuthoRule1
```
#### After
```powershell
Remove-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -Namespace TestNameSpace-Relay1 -WcfRelay TestWcfRelay -Name AuthoRule1
```


### `New-AzWcfRelay`
- The cmdlet 'New-AzWcfRelay' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSWcfRelayAttributes'.
- The cmdlet 'New-AzWcfRelay' no longer supports the type 'Microsoft.Azure.Commands.Relay.Models.PSWcfRelayAttributes' for parameter 'InputObject'.
- The cmdlet 'New-AzWcfRelay' no longer supports the type 'System.String' for parameter 'WcfRelayType'.
- The cmdlet 'New-AzWcfRelay' no longer supports the type 'System.Nullable`1[System.Boolean]' for parameter 'RequiresClientAuthorization'.
- The cmdlet 'New-AzWcfRelay' no longer supports the type 'System.Nullable`1[System.Boolean]' for parameter 'RequiresTransportSecurity'.
- The cmdlet 'New-AzWcfRelay' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzWcfRelay' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzWcfRelay' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `New-AzRelayNamespace`
- The cmdlet 'New-AzRelayNamespace' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSRelayNamespaceAttributes'.
- The cmdlet 'New-AzRelayNamespace' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzRelayNamespace' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzRelayNamespace' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `New-AzRelayKey`
- The cmdlet 'New-AzRelayKey' no longer supports the type 'System.String' for parameter 'RegenerateKey'.
- The cmdlet 'New-AzRelayKey' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzRelayKey' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzRelayKey' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
New-AzRelayKey -ResourceGroupName Default-ServiceBus-WestUS -Name AuthoRule1 -HybridConnection TestHybridConnection -RegenerateKey PrimaryKey
```
#### After
```powershell
New-AzRelayKey -ResourceGroupName Default-ServiceBus-WestUS -Namespace TestNameSpace-Relay1 -Name AuthoRule1 -HybridConnection TestHybridConnection -RegenerateKey PrimaryKey
```


### `New-AzRelayHybridConnection`
- The cmdlet 'New-AzRelayHybridConnection' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSHybridConnectionAttributes'.
- The cmdlet 'New-AzRelayHybridConnection' no longer supports the type 'Microsoft.Azure.Commands.Relay.Models.PSHybridConnectionAttributes' for parameter 'InputObject'.
- The cmdlet 'New-AzRelayHybridConnection' no longer supports the type 'System.Nullable`1[System.Boolean]' for parameter 'RequiresClientAuthorization'.
- The cmdlet 'New-AzRelayHybridConnection' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzRelayHybridConnection' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzRelayHybridConnection' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `New-AzRelayAuthorizationRule`
- The cmdlet 'New-AzRelayAuthorizationRule' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSAuthorizationRuleAttributes'.
The element type for parameter 'Rights' has been changed from 'System.String' to 'Microsoft.Azure.PowerShell.Cmdlets.Relay.Support.AccessRights'.
- The cmdlet 'New-AzRelayAuthorizationRule' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzRelayAuthorizationRule' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzRelayAuthorizationRule' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
New-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -WcfRelay TestWCFRelay1 -Name AuthoRule1 -Rights "Listen"
```
#### After
```powershell
New-AzRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -Namespace TestNameSpace-Relay1 -WcfRelay TestWCFRelay1 -Name AuthoRule1 -Rights "Listen"
```


### `Get-AzWcfRelay`
- The cmdlet 'Get-AzWcfRelay' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSWcfRelayAttributes'.
- The cmdlet 'Get-AzWcfRelay' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzWcfRelay' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzWcfRelay' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Get-AzRelayOperation`
- The cmdlet 'Get-AzRelayOperation' has been removed and no alias was found for the original cmdlet name.

### `Get-AzRelayNamespace`
- The cmdlet 'Get-AzRelayNamespace' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSRelayNamespaceAttributes'.
- The cmdlet 'Get-AzRelayNamespace' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzRelayNamespace' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzRelayNamespace' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Get-AzRelayKey`
- The cmdlet 'Get-AzRelayKey' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzRelayKey' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzRelayKey' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Get-AzRelayKey -ResourceGroupName Default-ServiceBus-WestUS -HybridConnection TestHybridConnection -Name AuthoRule1
```
#### After
```powershell
Get-AzRelayKey -ResourceGroupName Default-ServiceBus-WestUS -Namespace TestNameSpace-Relay1 -HybridConnection TestHybridConnection -Name AuthoRule1
```


### `Get-AzRelayHybridConnection`
- The cmdlet 'Get-AzRelayHybridConnection' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSHybridConnectionAttributes'.
- The cmdlet 'Get-AzRelayHybridConnection' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzRelayHybridConnection' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzRelayHybridConnection' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Get-AzRelayAuthorizationRule`
- The cmdlet 'Get-AzRelayAuthorizationRule' no longer has output type 'Microsoft.Azure.Commands.Relay.Models.PSAuthorizationRuleAttributes'.
- The cmdlet 'Get-AzRelayAuthorizationRule' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzRelayAuthorizationRule' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzRelayAuthorizationRule' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

## Az.ServiceBus

### `Set-AzServiceBusNamespace`
- The cmdlet 'Set-AzServiceBusNamespace' has undergone several changes, including changes to the output type and default parameter set. 
- The cmdlet no longer supports certain aliases and parameter types, including 'NamespaceName', 'System.String' for 'SkuName', and 'System.Nullable`1[System.Int32]' for 'SkuCapacity'. Additionally, the parameters 'MaximumThroughputUnits', 'EnableKafka', 'ClusterARMId', 'IdentityId', and 'EncryptionConfig' are no longer supported, and no aliases were found for the original parameter names. 
- The cmdlet also no longer supports the 'IAzureContextContainer' type for the 'DefaultProfile' parameter, and the 'AzContext' and 'AzureRmContext' aliases for 'DefaultProfile' are no longer supported.

### `Remove-AzServiceBusVirtualNetworkRule`
- The cmdlet 'Remove-AzServiceBusVirtualNetworkRule' has been removed. Use 'Set-AzServiceBusNetworkRuleSet' instead.

#### Before
```powershell
Remove-AzServiceBusVirtualNetworkRule -ResourceGroupName v-ajnavtest -Name ServiceBus-Namespace1-2389 -SubnetId "/subscriptions/SubscriptionId/resourcegroups/ResourceGroup/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault01"
```
#### After
```powershell
$virtualNetworkRule1 = New-AzServiceBusVirtualNetworkRuleConfig -SubnetId /subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/default
Set-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -IPRule $ipRule1,$ipRule2 -VirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2,$virtualNetworkRule3
```


### `Remove-AzServiceBusNetworkRuleSet`
- The cmdlet 'Remove-AzServiceBusNetworkRuleSet' has been removed. Use 'Set-AzServiceBusNetworkRuleSet' instead.

#### Before
```powershell
Remove-AzServiceBusNetworkRuleSet -ResourceGroupName  v-ajnavtest -Name ServiceBus-Namespace1-1375
```
#### After
```powershell
Set-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -IPRule @() -VirtualNetworkRule @()
```


### `Remove-AzServiceBusNamespace`
- The cmdlet 'Remove-AzServiceBusNamespace' no longer supports the alias 'ResourceGroup' for parameter 'ResourceGroupName'.

#### Before
```powershell
Remove-AzServiceBusNamespace -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1
```
#### After
```powershell
Remove-AzServiceBusNamespace -ResourceGroupName Default-ServiceBus-WestUS -NamespaceName SB-Example1
```


### `Remove-AzServiceBusIPRule`
- The cmdlet 'Remove-AzServiceBusIPRule' has been removed. Use 'Set-AzServiceBusNetworkRuleSet' instead.

#### Before
```powershell
Remove-AzServiceBusIPRule -ResourceGroupName v-ajnavtest -Name ServiceBus-Namespace1-2389 -IpMask "11.22.33.44"
```
#### After
```powershell
Set-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -IPRule @()
```


### `New-AzServiceBusNamespace`
- The cmdlet 'New-AzServiceBusNamespace' has undergone several changes. 
- The cmdlet no longer supports certain aliases and parameter types, including 'NamespaceName', 'System.String' for 'SkuName', and 'System.Nullable`1[System.Int32]' for 'SkuCapacity'. Additionally, the parameters 'MaximumThroughputUnits', 'EnableKafka', 'ClusterARMId', 'IdentityId', and 'EncryptionConfig' are no longer supported, and no aliases were found for the original parameter names. 
- The cmdlet also no longer supports the 'IAzureContextContainer' type for the 'DefaultProfile' parameter, and the 'AzContext' and 'AzureRmContext' aliases for 'DefaultProfile' are no longer supported.

### `New-AzServiceBusGeoDRConfiguration`
- The cmdlet 'New-AzServiceBusGeoDRConfiguration' no longer supports the parameter 'PassThru' and no alias was found for the original parameter name.

#### Before
```powershell
New-AzServiceBusGeoDRConfiguration -Name myAlias -ResourceGroupName myResourceGroup -NamespaceName myPrimaryNamespace -PartnerNamespace "/subscriptions/0000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/mySecondaryNamespace" -PassThru
```
#### After
```powershell
New-AzServiceBusGeoDRConfiguration -Name myAlias -ResourceGroupName myResourceGroup -NamespaceName myPrimaryNamespace -PartnerNamespace "/subscriptions/0000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/mySecondaryNamespace"
```


### `New-AzServiceBusEncryptionConfig`
- The cmdlet 'New-AzServiceBusEncryptionConfig' has been removed. Use 'New-AzServiceBusNamespace' and 'Set-AzServiceBusNamespace' to enable encryption.

#### Before
```powershell
New-AzServiceBusEncryptionConfig -KeyName key1 -KeyVaultUri https://myvaultname.vault.azure.net -UserAssignedIdentity '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName2'
```
#### After
```powershell
$id1 = "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$id2 = "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mySecondIdentity"
$keyVaultProperty1 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key4 -KeyVaultUri https://testkeyvault.vault.azure.net/ -UserAssignedIdentity "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
$keyVaultProperty2 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key5 -KeyVaultUri https://testkeyvault.vault.azure.net/ -UserAssignedIdentity "/subscriptions/000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
New-AzServiceBusNamespace -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentityID $id1,$id2 -KeyVaultProperty $keyVaultProperty1,$keyVaultProperty2

```


### `Get-AzServiceBusOperation`
- The cmdlet 'Get-AzServiceBusOperation' has been removed.

### `Get-AzServiceBusNamespace`
- The cmdlet 'Get-AzServiceBusNamespace' no longer supports the alias 'ResourceGroup' for parameter 'ResourceGroupName'.

#### Before
```powershell
Get-AzServiceBusNamespace -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1
```
#### After
```powershell
Get-AzServiceBusNamespace -ResourceGroupName Default-ServiceBus-WestUS -NamespaceName SB-Example1
```


### `Add-AzServiceBusVirtualNetworkRule`
- The cmdlet 'Add-AzServiceBusVirtualNetworkRule' has been removed. Use 'Set-AzServiceBusNetworkRuleSet' instead.

#### Before
```powershell
Add-AzServiceBusVirtualNetworkRule -ResourceGroupName v-ajnavtest -Name ServiceBus-Namespace1-2389 -SubnetId "/subscriptions/SubscriptionId/resourcegroups/ResourceGroup/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault01" -IgnoreMissingVnetServiceEndpoint
```
#### After
```powershell
$virtualNetworkRule1 = New-AzServiceBusVirtualNetworkRuleConfig -SubnetId /subscriptions/subscriptionId/resourcegroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork/subnets/default
Set-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -VirtualNetworkRule $virtualNetworkRule1
```


### `Add-AzServiceBusIPRule`
- The cmdlet 'Add-AzServiceBusIPRule' has been removed. Use 'Set-AzServiceBusNetworkRuleSet' instead.

#### Before
```powershell
Add-AzServiceBusIPRule -ResourceGroupName v-ajnavtest -Name ServiceBus-Namespace1-2389 -IpMask "11.22.33.44" -Action Allow
```
#### After
```powershell
$ipRule1 = New-AzServiceBusIPRuleConfig -IPMask 2.2.2.2 -Action Allow
$ipRule2 = New-AzServiceBusIPRuleConfig -IPMask 3.3.3.3 -Action Allow
Set-AzServiceBusNetworkRuleSet -ResourceGroupName myResourceGroup -NamespaceName myNamespace -IPRule $ipRule1,$ipRule2
```


## Az.SignalR

### `Update-AzSignalRNetworkAcl`
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.

### `Update-AzSignalR`
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.

#### Before
```powershell
$hostNamePrefix = $(Update-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1 -UnitCount 5).HostNamePrefix
```
#### After
```powershell
$hostNamePrefix = $(Update-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1 -UnitCount 5).Name
```


### `Set-AzSignalRUpstream`
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.

### `Restart-AzSignalR`
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.

### `Remove-AzSignalR`
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.

### `New-AzSignalRKey`
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.

### `New-AzSignalR`
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.

#### Before
```powershell
$hostNamePrefix = $(New-AzSignalR -ResourceGroupName myResourceGroup1 -Name mysignalr1 -Location eastus -Sku Standard_S1).HostNamePrefix
```
#### After
```powershell
$hostNamePrefix = $(New-AzSignalR -ResourceGroupName myResourceGroup1 -Name mysignalr1 -Location eastus -Sku Standard_S1).Name
```


### `Get-AzSignalRKey`
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.

### `Get-AzSignalR`
- The property 'HostNamePrefix' of type 'Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource' has been removed.

#### Before
```powershell
$hostNamePrefix = $(Get-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1).HostNamePrefix
```
#### After
```powershell
$hostNamePrefix = $(Get-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1).Name
```


## Az.SqlVirtualMachine

### `Update-AzSqlVMGroup`
- The cmdlet 'Update-AzSqlVMGroup' no longer has output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMGroupModel'.
- The cmdlet 'Update-AzSqlVMGroup' no longer supports the type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMGroupModel' for parameter 'InputObject'.
- The cmdlet 'Update-AzSqlVMGroup' no longer supports the alias 'SqlVMGroup' for parameter 'InputObject'.
- The cmdlet 'Update-AzSqlVMGroup' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Update-AzSqlVMGroup' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzSqlVMGroup' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzSqlVMGroup' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
$group = Get-AzSqlVMGroup -ResourceGroupName "ResourceGroup01" -Name "test-group"
Update-AzSqlVMGroup -SqlVMGroup $group -Tag @{'key'='value'}
```
#### After
```powershell
$group = Get-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01'
$group | Update-AzSqlVMGroup -Tag @{'key'='value'}
```


### `Update-AzSqlVM`
- The cmdlet 'Update-AzSqlVM' no longer has output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMModel'.
- The cmdlet 'Update-AzSqlVM' no longer supports the type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMModel' for parameter 'InputObject'.
- The cmdlet 'Update-AzSqlVM' no longer supports the alias 'SqlVM' for parameter 'InputObject'.
- The cmdlet 'Update-AzSqlVM' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Update-AzSqlVM' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzSqlVM' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Update-AzSqlVM' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Update-AzAvailabilityGroupListener`
- The cmdlet 'Update-AzAvailabilityGroupListener' has been removed and no alias was found for the original cmdlet name.

### `Set-AzSqlVMConfigGroup`
- The cmdlet 'Set-AzSqlVMConfigGroup' has been removed and no alias was found for the original cmdlet name.

### `Remove-AzSqlVMGroup`
- The cmdlet 'Remove-AzSqlVMGroup' has undergone changes and no longer supports certain parameters and output types. Specifically, the 'InputObject' parameter no longer supports the 'AzureSqlVMGroupModel' type or its 'SqlVMGroup' alias, and the 'ResourceId' parameter has been removed entirely. Additionally, the 'DefaultProfile' parameter no longer supports the 'IAzureContextContainer' type, and its aliases 'AzContext' and 'AzureRmContext'.

#### Before
```powershell
$group = Get-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01'
Remove-AzSqlVMGroup -SqlVMGroup $group
```
#### After
```powershell
$group = Get-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01'
$group | Remove-AzSqlVMGroup
```


### `Remove-AzSqlVM`
- The cmdlet 'Remove-AzSqlVM' no longer has output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMModel'.
- The cmdlet 'Remove-AzSqlVM' no longer supports the type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMModel' for parameter 'InputObject'.
- The cmdlet 'Remove-AzSqlVM' no longer supports the alias 'SqlVM' for parameter 'InputObject'.
- The cmdlet 'Remove-AzSqlVM' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Remove-AzSqlVM' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzSqlVM' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Remove-AzSqlVM' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
Remove-AzSqlVM -SqlVM $sqlVM
```
#### After
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlVM | Remove-AzSqlVM
```


### `Remove-AzAvailabilityGroupListener`
- The cmdlet 'Remove-AzAvailabilityGroupListener' has undergone changes and some features have been removed. Specifically, the output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureAvailabilityGroupListenerModel' is no longer supported. Additionally, the parameter 'InputObject' no longer supports this type. The 'ResourceId' and 'SqlVMGroupObject' parameters have also been removed without any alias found. The 'DefaultProfile' parameter no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' and its aliases 'AzContext' and 'AzureRmContext'. 

#### Before
```powershell
$SqlVmGroupObject = Get-AzSqlVMGroup -ResourceGroupName ResourceGroup01 -SqlVMGroupName SqlVmGroup01
Remove-AzAvailabilityGroupListener -Name AgListener01 -SqlVMGroupObject $SqlVmGroupObject
```
#### After
```powershell
Remove-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'SqlVmGroup01' -Name 'AgListener01'
```


### `New-AzSqlVMGroup`
- The cmdlet 'New-AzSqlVMGroup' no longer has output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMGroupModel'.
- The cmdlet 'New-AzSqlVMGroup' no longer supports the type 'System.String' for parameter 'Sku'.
- The cmdlet 'New-AzSqlVMGroup' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzSqlVMGroup' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzSqlVMGroup' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `New-AzSqlVMConfig`
- The cmdlet 'New-AzSqlVMConfig' has been removed and no alias was found for the original cmdlet name.

#### Before
```powershell
$config = New-AzSqlVMConfig -LicenseType "PAYG"
New-AzSqlVM -ResourceGroupName "ResourceGroup01" -Name "vm" -SqlVM $config
```
#### After
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -Sku 'Developer' -LicenseType 'PAYG'
```


### `New-AzSqlVM`
- The cmdlet 'New-AzSqlVM' no longer has output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMModel'.
- The cmdlet 'New-AzSqlVM' no longer supports the parameter 'SqlVM' and no alias was found for the original parameter name.
- The cmdlet 'New-AzSqlVM' no longer supports the type 'System.String' for parameter 'LicenseType'.
- The cmdlet 'New-AzSqlVM' no longer supports the type 'System.String' for parameter 'Sku'.
- The cmdlet 'New-AzSqlVM' no longer supports the type 'System.String' for parameter 'SqlManagementType'.
- The cmdlet 'New-AzSqlVM' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzSqlVM' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzSqlVM' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
$config = New-AzSqlVMConfig -LicenseType "PAYG"
New-AzSqlVM -ResourceGroupName "ResourceGroup01" -Name "vm" -SqlVM $config
```
#### After
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -Sku 'Developer' -LicenseType 'PAYG'
```


### `New-AzAvailabilityGroupListener`
- The cmdlet 'New-AzAvailabilityGroupListener' no longer has output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureAvailabilityGroupListenerModel'.
- The cmdlet 'New-AzAvailabilityGroupListener' no longer supports the type 'System.Nullable`1[System.Int32]' for parameter 'Port'.
- The cmdlet 'New-AzAvailabilityGroupListener' no longer supports the type 'System.Nullable`1[System.Int32]' for parameter 'ProbePort'.
- The cmdlet 'New-AzAvailabilityGroupListener' no longer supports the parameter 'SqlVMGroupObject' and no alias was found for the original parameter name.
- The cmdlet 'New-AzAvailabilityGroupListener' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzAvailabilityGroupListener' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'New-AzAvailabilityGroupListener' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Get-AzSqlVMGroup`
- The cmdlet 'Get-AzSqlVMGroup' no longer has output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMGroupModel'.
- The cmdlet 'Get-AzSqlVMGroup' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Get-AzSqlVMGroup' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzSqlVMGroup' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzSqlVMGroup' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Get-AzSqlVM`
- The cmdlet 'Get-AzSqlVM' no longer has output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureSqlVMModel'.
- The cmdlet 'Get-AzSqlVM' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- The cmdlet 'Get-AzSqlVM' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzSqlVM' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- The cmdlet 'Get-AzSqlVM' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

### `Get-AzAvailabilityGroupListener`
- The cmdlet 'Get-AzAvailabilityGroupListener' has been updated and some features have been removed. 
- The cmdlet 'Get-AzAvailabilityGroupListener' no longer has output type 'Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model.AzureAvailabilityGroupListenerModel'. The 'ResourceId' and 'SqlVMGroupObject' parameters have been removed without any alias found. The 'DefaultProfile' parameter no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' and its aliases 'AzContext' and 'AzureRmContext'.

#### Before
```powershell
$SqlVmGroupObject = Get-AzSqlVMGroup -ResourceGroupName ResourceGroup01 -SqlVMGroupName SqlVmGroup01
Get-AzAvailabilityGroupListener -Name AgListener01 -SqlVMGroupObject $SqlVmGroupObject
```
#### After
```powershell
Get-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'SqlVmGroup01' -Name 'AgListener01'
```


## Az.StackHCI

### `Unregister-AzStackHCI`
- The cmdlet 'Unregister-AzStackHCI' no longer supports the parameter 'GraphAccessToken' and no alias was found for the original parameter name.

#### Before
```powershell
Customers had an option to pass GraphAccessToken parameter in Unregister-AzStackHCI, which used to be ignored by the cmdlet
```
#### After
```powershell
Unregister-AzStackHCI  won’t support GraphAccessToken as a parameter
```


### `Test-AzStackHCIConnection`
- The cmdlet 'Test-AzStackHCIConnection' has been removed and no alias was found for the original cmdlet name.

#### Before
```powershell
Customers used Test-AzStackHCIConnection for connectivity verification tests
```
#### After
```powershell
Customers can use Invoke-AzStackHciConnectivityValidation from AzStackHCI.EnvironmentChecker module for enhanced connectivity verification tests
```


### `Set-AzStackHCI`
- The cmdlet 'Set-AzStackHCI' no longer supports the parameter 'GraphAccessToken' and no alias was found for the original parameter name.

#### Before
```powershell
Customers had an option to pass GraphAccessToken parameter in Set-AzStackHCI, which used to be ignored by the cmdlet
```
#### After
```powershell
Set-AzStackHCI won’t support GraphAccessToken as a parameter
```


### `Register-AzStackHCI`
- The cmdlet 'Register-AzStackHCI' no longer supports the parameter 'GraphAccessToken' and no alias was found for the original parameter name.
- The cmdlet 'Register-AzStackHCI' no longer supports the parameter 'EnableAzureArcServer' and no alias was found for the original parameter name.

#### Before
```powershell
Customers had an option to pass GraphAccessToken parameter in Register-AzStackHCI, which used to be ignored by the cmdlet. Customers had an option to pass EnableAzureArcServer as true or false. Register-AzStackHCI used to fail for customers who passed EnableAzureArcServer as false. Customers used to get a confirmation prompt if they didn't pass the Region parameter in Register-AzStackHCI
```
#### After
```powershell
Register-AzStackHCI won’t support GraphAccessToken and EnableAzureArcServer as parameters, and will make Region parameter as mandatory.
```

## Az.StorageSync

### `Set-AzStorageSyncServerEndpoint`
- The cmdlet 'Set-AzStorageSyncServerEndpoint' no longer supports the alias 'RegisteredServer' for parameter 'InputObject'.

#### Before
```powershell
Set-AzStorageSyncServerEndpoint -RegisteredServer $inputObject
```
#### After
```powershell
Set-AzStorageSyncServerEndpoint -ServerEndpoint $inputObject
```


## Az.Synapse

### `Update-AzSynapseSparkPool`
- The cmdlet 'Update-AzSynapseSparkPool' no longer supports the parameter 'SparkConfigFilePath' and no alias was found for the original parameter name.


#### Before
```powershell
Update-AzSynapseSparkPool -WorkspaceName $wsname -Name $sparkpoolname -SparkConfigFilePath $path
```
#### After
```powershell
Update-AzSynapseSparkPool -WorkspaceName $wsname -Name $sparkpoolname -SparkConfiguration $config
```


### `New-AzSynapseSparkPool`
- The cmdlet 'New-AzSynapseSparkPool' no longer supports the parameter 'SparkConfigFilePath' and no alias was found for the original parameter name.

#### Before
```powershell
New-AzSynapseSparkPool -WorkspaceName $wsname -Name $sparkpoolname -SparkConfigFilePath $path
```
#### After
```powershell
New-AzSynapseSparkPool -WorkspaceName $wsname -Name $sparkpoolname -SparkConfiguration $config
```


## Az.Websites

### `New-AzWebAppContainerPSSession`
- The cmdlet 'New-AzWebAppContainerPSSession' has been removed and no alias was found for the original cmdlet name.

#### Before
```powershell
Opens a remote PowerShell session into the windows container specified in a given site or slot and given resource group
```
#### After
```powershell
N/A
```


### `Enter-AzWebAppContainerPSSession`
- The cmdlet 'Enter-AzWebAppContainerPSSession' has been removed and no alias was found for the original cmdlet name.

#### Before
```powershell
Create new remote PowerShell Session into the windows container specified in a given site or slot and given resource group
```
#### After
```powershell
N/A
```


