### Example 1: Create new DefenderForDatabasesGcpOffering object
```powershell
$emailSuffix = "myproject.iam.gserviceaccount.com"
New-AzSecurityDefenderForDatabasesGcpOfferingObject `
    -ArcAutoProvisioningEnabled $true `
    -DefenderForDatabaseArcAutoProvisioningServiceAccountEmailAddress "microsoft-databases-arc-ap@" -DefenderForDatabaseArcAutoProvisioningWorkloadIdentityProviderId "defender-for-databases-arc-ap"
        
```

```output
ArcAutoProvisioningEnabled                                       : True
ConfigurationPrivateLinkScope                                    : 
ConfigurationProxy                                               : 
DefenderForDatabaseArcAutoProvisioningServiceAccountEmailAddress : microsoft-databases-arc-ap@
DefenderForDatabaseArcAutoProvisioningWorkloadIdentityProviderId : defender-for-databases-arc-ap
Description                                                      : 
OfferingType                                                     : DefenderForDatabasesGcp
```


