### Example 1: Get all cloud service under a resource group

```powershell
Get-AzCloudService -ResourceGroupName "ContosOrg"
```

```output
ResourceGroupName Name              Location    ProvisioningState
----------------- ----              --------    -----------------
ContosOrg         ContosoCS         eastus2euap Succeeded
ContosOrg         ContosoCSTest     eastus2euap Failed
```

This command gets all cloud services in resource group named ContosOrg

### Example 2: Get cloud service

```powershell
<<<<<<< HEAD
$cloudService = Get-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"
$cloudService | Format-List
```

```output
=======
Get-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"

ResourceGroupName Name              Location    ProvisioningState
----------------- ----              --------    -----------------
ContosOrg         ContosoCS         eastus2euap Succeeded

$cloudService = Get-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"
$cloudService | Format-List
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ResourceGroupName : ContosOrg
Configuration     : xxxxxxxx
ConfigurationUrl  :
ExtensionProfile  : xxxxxxxx
Id                : xxxxxxxx
Location          : East US
Name              : ContosoCS
NetworkProfile    : xxxxxxxx
OSProfile         : xxxxxxxx
PackageUrl        : xxxxxxxx
ProvisioningState : Succeeded
RoleProfile       : xxxxxxxx
StartCloudService :
Tag               : {
                      "Owner": "Contos"
                    }
Type              : Microsoft.Compute/cloudServices
UniqueId          : xxxxxxxx
UpgradeMode       : Auto
<<<<<<< HEAD
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command gets cloud service named ContosoCS that belongs to the resource group named ContosOrg.
