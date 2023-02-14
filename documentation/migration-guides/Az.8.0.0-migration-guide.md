# Migration Guide for Az 8.0.0
## Az.Aks

### `Get-AzAks`
Alias `Get-AzAks` is removed. Please use `Get-AzAksCluster` instead.

#### Before
```powershell
Get-AzAks -ResourceGroupName $resourceGroupName -Name $name
```
#### After
```powershell
Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $name
```

### `New-AzAks`
Alias `New-AzAks` is removed. Please use `New-AzAksCluster` instead.

#### Before
```powershell
New-AzAks -ResourceGroupName $resourceGroupName -Name $name -Location $location
```
#### After
```powershell
New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $name -Location $location
```

### `Set-AzAks`
Alias `Set-AzAks` is removed. Please use `Set-AzAksCluster` instead.

#### Before
```powershell
Set-AzAks -ResourceGroupName $resourceGroupName -Name $name
```
#### After
```powershell
Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $name
```

### `Remove-AzAks`
Alias `Remove-AzAks` is removed. Please use `Remove-AzAksCluster` instead.

#### Before
```powershell
Remove-AzAks -ResourceGroupName $resourceGroupName -Name $name
```
#### After
```powershell
Remove-AzAksCluster -ResourceGroupName $resourceGroupName -Name $name
```

## Az.Cdn

### `New-AzCdnProfile`
Changed the type of parameter `Sku` to `SkuName`
Changed the type of parameter `ProfileName` to `Name`

#### Before
```powershell
$profileSku = "Standard_Microsoft";
$cdnProfileName = "profileNameXXXX";
$resourceGroupName = "myresourcegroup"
New-AzCdnProfile -Sku $profileSku -ProfileName $cdnProfileName -ResourceGroupName $resourceGroupName -Location Global
```
#### After
```powershell
$profileSku = "Standard_Microsoft";
$cdnProfileName = "profileNameXXXX";
$resourceGroupName = "myresourcegroup"
New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $resourceGroupName -Location Global
```

### `New-AzCdnEndpoint`
Changed parameter `EndpointName` to `Name`
Changed parameter `GeoFilters` to `GeoFilter`
Changed parameter `DefaultOriginGroup` to `DefaultOriginGroupId`
Merge parameters `OriginHostName`,`OriginId`,`OriginName`,`Priority`,`PrivateLinkApprovalMessage`,`PrivateLinkLocation`,`PrivateLinkResourceId`,`Weight`,`HttpPort`,`HttpsPort`into parameter `Origin`
Merge parameters `OriginGroupName`,`OriginGroupProbeIntervalInSeconds`,`OriginGroupProbePath`,`OriginGroupProbeProtocol`,`OriginGroupProbeRequestType`into parameter `OriginGroup`
Split parameter `DeliveryPolicy` in to parameters `DeliveryPolicyDescription`,`DeliveryPolicyRule`
Add parameters `SubscriptionId`,`UrlSigningKey`,`WebApplicationFirewallPolicyLinkId`
Delete parameter `CdnProfile `

#### Before
```powershell
New-AzCdnEndpoint -ResourceGroupName myresourcegroup -ProfileName mycdnprofile -Location westus -EndpointName myendpoint `
                  -OriginName mystorage -OriginHostName mystorage.blob.core.windows.net `
                  -OriginHostHeader mystorage.blob.core.windows.net -IsHttpAllowed $false
```
#### After
```powershell
$origin = @{
  Name = "origin1"
  HostName = "host1.hello.com"
};
$location = "westus"
   
$endpoint = New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin
```

### `New-AzCdnDeliveryPolicy`
Delete command `New-AzCdnDeliveryPolicy`. Use `New-AzCdnDeliveryRuleObject` create rule object and used it in `New-AzCdnEndpoint` directly


### `New-AzCdnDeliveryRule`
Changed command name to `New-AzCdnDeliveryRuleObject`

#### Before
```powershell
New-AzCdnDeliveryRule -Name "rule1" -Order 1 -Condition $cond1 -Action $action1
```
#### After
```powershell
$cond1 = New-AzCdnDeliveryRuleIsDeviceConditionObject -Name "IsDevice" -ParameterMatchValue "Desktop"
$action1 = New-AzCdnUrlRewriteActionObject -Name "UrlRewrite" -ParameterDestination "/def" -ParameterSourcePattern "/abc" -ParameterPreserveUnmatchedPath $true
$rule1 = New-AzCdnDeliveryRuleObject -Name "Rule1" -Action $action1,$action2 -Condition $cond1 -Order 1
```

### `New-AzCdnCustomDomain`
Changed the type of parameter `CustomDomainName` to `Name`
Add parameter `SubscriptionId`
Delete parameter `CdnEndpoint`

#### Before
```powershell
New-AzCdnCustomDomain -ResourceGroupName $resourceGroupName -ProfileName $cdnProfileName -EndpointName $endpointName -CustomDomainName $customDomainName -HostName $customDomainHostName
```
#### After
```powershell
New-AzCdnCustomDomain -ResourceGroupName $resourceGroupName -ProfileName $cdnProfileName -EndpointName $endpointName -Name $customDomainName -HostName $customDomainHostName -SubscriptionId $subId
```

### `Set-AzCdnProfile`
Replaced by command `Update-AzCdnProfile`

#### Before
```powershell
$profileObject = Get-AzCdnProfile -ResourceGroupName myresourcegroup -ProfileName mycdnprofile
$profileObject.Tags = @{"key"="value"}
Set-AzCdnProfile -CdnProfile $profileObject
```

#### After
```powershell
$profileSku = "Standard_Microsoft";
$cdnProfileName = "profileNameXXXX";
$resourceGroupName = "myresourcegroup"
New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $resourceGroupName -Location Global

$tags = @{
  Tag1 = 11
  Tag2  = 22
}
Update-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $resourceGroupName -Tag $tags
```

### `Set-AzCdnEndpoint`
Replaced by command `Update-AzCdnEndpoint`
`DeliveryPolicyDescription` and `DeliveryPolicyRule` should be provided together when you want to update one of them.

#### Before
```powershell
$endpointObject = Get-AzCdnEndpoint -ResourceGroupName myresourcegroup -ProfileName mycdnprofile -EndpointName myendpoint
$endpointObject.IsHttpAllowed = $false
Set-AzCdnEndpoint -CdnEndpoint $endpointObject
```
#### After
```powershell
$tags = @{
  Tag1 = 11
  Tag2  = 22
}

//Update tags
Update-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $resourceGroupName -Tag $tags

//Update DeliveryPolicyDescription or DeliveryPolicyRule 
Update-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $resourceGroupName `
   -DeliveryPolicyDescription $descprption -DeliveryPolicyRule $rule
```

### `Set-AzCdnOriginGroup`
Replaced by command `Update-AzCdnOriginGroup`

#### Before
```powershell
Set-AzCdnOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -EndpointName $endpointName -OriginGroupName $originGroupName -OriginId $originIds -ProbeIntervalInSeconds $probeInterval
```
#### After
```powershell
Update-AzCdnOriginGroup -EndpointName $endpointName -Name $originGroup.Name -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName `
                -HealthProbeSetting $healthProbeParametersObject2 -Origin @(@{ Id = $originId })
            
```

### `Set-AzCdnOrigin`
Replaced by command `Update-AzCdnOrigin`

#### Before
```powershell
Set-AzCdnOrigin -ResourceGroupName $resourceGroupName -ProfileName $cdnProfileName -EndpointName $endpointName `
    -OriginName $originName -HostName "mystorage2.blob.core.windows.net"
```
#### After
```powershell
Update-AzCdnOrigin -ResourceGroupName $resourceGroupName -ProfileName $cdnProfileName -EndpointName $endpointName `
    -Name $originName  -HostName "mystorage2.blob.core.windows.net" -HttpPort 456 -HttpsPort 789           
```

## Az.EventHub

### `New-AzEventHubNamespace`
Parameter `Identity` is removed.
#### Before
```powershell
New-AzEventHubNamespace -ResourceGroupName myresourcegroup -Name MyNamespaceName -Location northeurope -SkuName Premium -IdentityType SystemAssigned -Identity
```
#### After
```powershell
New-AzEventHubNamespace -ResourceGroupName myresourcegroup -Name MyNamespaceName -Location northeurope -SkuName Premium -IdentityType SystemAssigned
```

### `Set-AzEventHubNamespace`
Parameter `Identity` is removed.
#### Before
```powershell
Set-AzEventHubNamespace -ResourceGroupName myresourcegroup -Name MyNamespaceName -EncryptionConfig $ec1,$ec2 -Identity
```
#### After
```powershell
Set-AzEventHubNamespace -ResourceGroupName myresourcegroup -Name MyNamespaceName -EncryptionConfig $ec1,$ec2
```


## Az.HealthcareApis

### `Set-AzHealthcareApisService`
Combine New-AzHealthcareApisService and Set-AzHealthcareApisService into New-AzHealthcareApisService

#### Before
```powershell
Set-AzHealthcareApisService -Name MyService -ResourceGroupName MyResourceGroup -CosmosOfferThroughput 500
```
#### After
```powershell
New-AzHealthcareApisService -Name MyService -ResourceGroupName MyResourceGroup -Location MyLocation -Kind fhir-R4 -CosmosOfferThroughput 500
```


### `Get-AzHealthcareApisService`
`-ResourceId` is removed

#### Before
```powershell
Get-AzHealthcareApisService -ResourceId $ResourceId
```
#### After
```powershell
Get-AzHealthcareApisService -ResourceGroupName $ResourceGroup -Name $Name
```


### `Remove-AzHealthcareApisService`
`-ResourceId` is removed

#### Before
```powershell
Remove-AzHealthcareApisService -ResourceId $ResourceId
```
#### After
```powershell
Remove-AzHealthcareApisService -ResourceGroupName $ResourceGroup -Name $Name
```


### `New-AzHealthcareApisService`
`-ManagedIdentity` is renamed to `-IdentityType`
`-FhirVersion` is removed and the desired content can be selected with the parameter `-Kind`
`-DisableCorsCredential` and `-AllowCorsCredential`: now uniformly named as `-AllowCorsCredential`, example: -AllowCorsCredential:$false or -AllowCorsCredential:$true
`-DisableSmartProxy` and `-EnableSmartProxy`: now uniformly named as `-EnableSmartProxy`, example: -EnableSmartProxy:$false or -EnableSmartProxy:$true

#### Before
```powershell
New-AzHealthcareApisService -Name MyService -ResourceGroupName MyResourceGroup -Location MyLocation -FhirVersion fhir-R4 -CosmosOfferThroughput 500 -ManagedIdentity $IdentityType -DisableCorsCredential -DisableSmartProxy
```
#### After
```powershell
New-AzHealthcareApisService -Name MyService -ResourceGroupName MyResourceGroup -Location MyLocation -Kind fhir-R4 -CosmosOfferThroughput 500 -IdentityType $IdentityType -AllowCorsCredential:$false -EnableSmartProxy:$false
```


