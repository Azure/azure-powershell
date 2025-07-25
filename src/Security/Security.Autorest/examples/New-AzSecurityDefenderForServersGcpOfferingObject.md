### Example 1: Create new DefenderForServersGcpOffering object
```powershell
$emailSuffix = "myproject.iam.gserviceaccount.com"
New-AzSecurityDefenderForServersGcpOfferingObject `
    -DefenderForServerServiceAccountEmailAddress "microsoft-defender-for-servers@$emailSuffix" -DefenderForServerWorkloadIdentityProviderId "defender-for-servers" `
    -ArcAutoProvisioningEnabled $true -MdeAutoProvisioningEnabled $true -VaAutoProvisioningEnabled $true -ConfigurationType TVM `
    -VMScannerEnabled $true -ConfigurationScanningMode Default `
    -SubPlanType P2
```

```output
ArcAutoProvisioningEnabled                  : True
ConfigurationExclusionTag                   : {
                                              }
ConfigurationPrivateLinkScope               : 
ConfigurationProxy                          : 
ConfigurationScanningMode                   : Default
ConfigurationType                           : TVM
DefenderForServerServiceAccountEmailAddress : microsoft-defender-for-servers@myproject.iam.gserviceaccount.com
DefenderForServerWorkloadIdentityProviderId : defender-for-servers
Description                                 : 
MdeAutoProvisioningConfiguration            : {
                                              }
MdeAutoProvisioningEnabled                  : True
OfferingType                                : DefenderForServersGcp
SubPlanType                                 : P2
VMScannerEnabled                            : True
VaAutoProvisioningEnabled                   : True
```

