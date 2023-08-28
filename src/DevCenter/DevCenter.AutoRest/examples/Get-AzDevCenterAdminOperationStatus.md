### Example 1: Get an operation
```powershell
Get-AzDevCenterAdminOperationStatus -Location "eastus"  -OperationId "7e9e1394-dad0-4414-8160-21c592e880ef*4699EE32265F9FA5BF00FA169E7D9CF51755378796E32F2D1A198E080CC84614"
```
This command gets the operation. 

### Example 2: Get an operatio using InputObject
```powershell
$operation = @{"Location" = "eastus"; "OperationId" = "7e9e1394-dad0-4414-8160-21c592e880ef*4699EE32265F9FA5BF00FA169E7D9CF51755378796E32F2D1A198E080CC84614"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminOperationStatus -InputObject $operation
```
This command gets the operation. 
