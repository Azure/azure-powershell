### Example 1: Create new CspmMonitorGcpOffering object
```powershell
New-AzSecurityCspmMonitorGcpOfferingObject -NativeCloudConnectionServiceAccountEmailAddress "microsoft-defender-cspm@asc-sdk-samples.iam.gserviceaccount.com" -NativeCloudConnectionWorkloadIdentityProviderId "cspm"
```

```output
Description NativeCloudConnectionServiceAccountEmailAddress                 NativeCloudConnectionWorkloadIdentityProviderId OfferingType
----------- -----------------------------------------------                 ----------------------------------------------- ------------
            microsoft-defender-cspm@asc-sdk-samples.iam.gserviceaccount.com cspm                                            CspmMonitorGcp
```



