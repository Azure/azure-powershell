### Example 1: Create a PSFrontendEndpoint Object for Front Door creation
```powershell
New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName "frontendendpoint1"
```

```output
CertificateSource                  :
CertificateType                    :
CustomHttpsProvisioningState       :
CustomHttpsProvisioningSubstate    :
HostName                           : frontendendpoint1
Id                                 :
MinimumTlsVersion                  :
Name                               : frontendendpoint1
ProtocolType                       : ServerNameIndication
ResourceGroupName                  :
ResourceState                      :
SecretName                         :
SecretVersion                      :
SessionAffinityEnabledState        : Enabled
SessionAffinityTtlInSeconds        : 0
Type                               :
Vault                              :
WebApplicationFirewallPolicyLinkId 
```

Create a PSFrontendEndpoint Object for Front Door creation