### Example 1: Get environment logs by endpoint
```powershell
Get-AzDevCenterUserEnvironmentLog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -OperationId "d0954a94-3550-4919-bcbe-1c94ed79e0cd"
```
This command gets the logs on the environment "myEnvironment" for the operation id "d0954a94-3550-4919-bcbe-1c94ed79e0cd" and outputs the logs to the file "output_logs.txt".

### Example 2: Get environment logs by dev center
```powershell
Get-AzDevCenterUserEnvironmentLog -DevCenterName Contoso -EnvironmentName myEnvironment -ProjectName DevProject -OperationId "d0954a94-3550-4919-bcbe-1c94ed79e0cd"
```
This command gets the logs on the environment "myEnvironment"  for the operation id "d0954a94-3550-4919-bcbe-1c94ed79e0cd" and outputs the logs to the file "output_logs.txt".
