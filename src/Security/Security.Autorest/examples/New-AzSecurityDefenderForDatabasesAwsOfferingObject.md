### Example 1: Create new DefenderForDatabasesAwsOffering object
```powershell
$arnPrefix = "arn:aws:iam::123456789012:role"
New-AzSecurityDefenderForDatabasesAwsOfferingObject `
    -ArcAutoProvisioningEnabled $true -ArcAutoProvisioningCloudRoleArn "$arnPrefix/DefenderForCloud-ArcAutoProvisioning" `
    -DatabaseDspmEnabled $true -DatabaseDspmCloudRoleArn "$arnPrefix/DefenderForCloud-DataSecurityPostureDB"
        
```

```output
ArcAutoProvisioningCloudRoleArn : arn:aws:iam::123456789012:role/DefenderForCloud-ArcAutoProvisioning
ArcAutoProvisioningEnabled      : True
ConfigurationPrivateLinkScope   : 
ConfigurationProxy              : 
DatabaseDspmCloudRoleArn        : arn:aws:iam::123456789012:role/DefenderForCloud-DataSecurityPostureDB
DatabaseDspmEnabled             : True
Description                     : 
OfferingType                    : DefenderForDatabasesAws
RdCloudRoleArn                  : 
RdEnabled                       : 
```



