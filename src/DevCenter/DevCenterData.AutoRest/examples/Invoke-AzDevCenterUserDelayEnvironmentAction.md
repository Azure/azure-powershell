### Example 1: Delay an action on the environment by endpoint
```powershell
Invoke-AzDevCenterUserDelayEnvironmentAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -Name "myEnvironment-Delete" -DelayTime "00:30"
```
This command delays the action "schedule-default" for the environment "myEnvironment" for 30 minutes. 

### Example 2: Delay an action on the environment by dev center
```powershell
Invoke-AzDevCenterUserDelayEnvironmentAction -DevCenterName Contoso -EnvironmentName myEnvironment -UserId "me" -ProjectName DevProject -Name "myEnvironment-Delete" -DelayTime "05:15"
```
This command delays the action "myEnvironment-Delete" for the environment "myEnvironment" for 5 hours and 15 minutes. 

