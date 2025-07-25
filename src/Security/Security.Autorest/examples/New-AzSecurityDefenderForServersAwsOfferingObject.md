### Example 1: Create new DefenderForServersAwsOffering object
```powershell
$arnPrefix = "arn:aws:iam::123456789012:role"
New-AzSecurityDefenderForServersAwsOfferingObject `
    -DefenderForServerCloudRoleArn "$arnPrefix/DefenderForCloud-DefenderForServers" `
    -ArcAutoProvisioningEnabled $true -ArcAutoProvisioningCloudRoleArn "$arnPrefix/DefenderForCloud-ArcAutoProvisioning" `
    -MdeAutoProvisioningEnabled $true `
    -VaAutoProvisioningEnabled $true -ConfigurationType TVM `
    -VMScannerEnabled $true -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" -ConfigurationScanningMode Default `
    -SubPlanType P2
```

```output
ArcAutoProvisioningCloudRoleArn  : arn:aws:iam::123456789012:role/DefenderForCloud-ArcAutoProvisioning
ArcAutoProvisioningEnabled       : True
ConfigurationCloudRoleArn        : arn:aws:iam::123456789012:role/DefenderForCloud-AgentlessScanner
ConfigurationExclusionTag        : {
                                   }
ConfigurationPrivateLinkScope    : 
ConfigurationProxy               : 
ConfigurationScanningMode        : Default
ConfigurationType                : TVM
DefenderForServerCloudRoleArn    : arn:aws:iam::123456789012:role/DefenderForCloud-DefenderForServers
Description                      : 
MdeAutoProvisioningConfiguration : {
                                   }
MdeAutoProvisioningEnabled       : True
OfferingType                     : DefenderForServersAws
SubPlanType                      : P2
VMScannerEnabled                 : True
VaAutoProvisioningEnabled        : True
```


