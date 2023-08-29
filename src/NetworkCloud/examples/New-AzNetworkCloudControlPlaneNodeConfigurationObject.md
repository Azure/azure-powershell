### Example 1: Create an in-memory object for ControlPlaneNodeConfiguration.

```powershell

$sshPublicKey=@{
    keyData= "ssh-rsa"
}
New-AzNetworkCloudControlPlaneNodeConfigurationObject -Count 1 -VMSkuName vmSkuName -AdministratorConfigurationAdminUsername userName -AdministratorConfigurationSshPublicKey $sshPublicKey -AvailabilityZone @("1","2","3")
```

```output
AvailabilityZone Count VMSkuName
---------------- ----- ---------
{1, 2, 3}        1     vmSkuName
```

Create an in-memory object for ControlPlaneNodeConfiguration.

