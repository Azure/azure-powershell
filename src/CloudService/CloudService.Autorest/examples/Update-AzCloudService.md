### Example 1: Add RDP extension to existing cloud service

```powershell
# Create RDP extension object
$rdpExtension = New-AzCloudServiceRemoteDesktopExtensionObject -Name "RDPExtension" -Credential $credential -Expiration $expiration -TypeHandlerVersion "1.2.1"
# Get existing cloud service
$cloudService = Get-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"
# Add RDP extension to existing cloud service extension object
$cloudService.ExtensionProfile.Extension = $cloudService.ExtensionProfile.Extension + $rdpExtension
# Update cloud service
$cloudService | Update-AzCloudService
```

Above set of commands adds a RDP extension to already existing cloud service named ContosoCS that belongs to the resource group named ContosOrg.

### Example 2: Remove all extensions from cloud service

```powershell
# Get existing cloud service
$cloudService = Get-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"
# Set extension to empty list
$cloudService.ExtensionProfile.Extension = @()
# Update cloud service
$cloudService | Update-AzCloudService
```

Above set of commands removes all extensions from existing cloud service named ContosoCS that belongs to the resource group named ContosOrg.

### Example 3: Remove RDP extension from cloud service

```powershell
# Get existing cloud service
$cloudService = Get-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"
# Remove extension by name RDPExtension
$cloudService.ExtensionProfile.Extension = $cloudService.ExtensionProfile.Extension | Where-Object { $_.Name -ne "RDPExtension" }
# Update cloud service
$cloudService | Update-AzCloudService
```

Above set of commands removes RDP extension from existing cloud service named ContosoCS that belongs to the resource group named ContosOrg.

### Example 4: Scale-Out / Scale-In role instances

```powershell
# Get existing cloud service
$cloudService = Get-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"

# Scale-out all role instance count by 1
$cloudService.RoleProfile.Role | ForEach-Object {$_.SkuCapacity += 1}

# Scale-in ContosoFrontend role instance count by 1
$role = $cloudService.RoleProfile.Role | Where-Object {$_.Name -eq "ContosoFrontend"}
$role.SkuCapacity -= 1

# Update cloud service configuration as per the new role instance count
$cloudService.Configuration = $configuration

# Update cloud service
$cloudService | Update-AzCloudService
```

Above set of commands shows how to scale-out and scale-in role instance count for cloud service named ContosoCS that belongs to the resource group named ContosOrg.
