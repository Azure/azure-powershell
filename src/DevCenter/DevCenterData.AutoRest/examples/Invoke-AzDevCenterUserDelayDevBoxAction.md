### Example 1: Delay all actions on the dev box by endpoint
```powershell
Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -DevBoxName myDevBox -UserId "me" -ProjectName DevProject -DelayTime "01:30"
```
This command delays all actions on the dev box "myDevBox" to the time 1 hour and 30 minutes from the earliest scheduled action. 

### Example 2: Delay all actions on the dev box by dev center
```powershell
Invoke-AzDevCenterUserDelayDevBoxAction -DevCenter Contoso -DevBoxName myDevBox -ProjectName DevProject -DelayTime "02:00"
```
This command delays all actions on the dev box "myDevBox" to the time 2 hours from the earliest scheduled action.

### Example 3: Delay an action on the dev box by endpoint
```powershell
Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -DevBoxName myDevBox -ProjectName DevProject -ActionName "schedule-default" -DelayTime "00:30"
```
This command delays the action "schedule-default" for the dev box "myDevBox" for 30 minutes. 

### Example 4: Delay an action on the dev box by dev center
```powershell
Invoke-AzDevCenterUserDelayDevBoxAction -DevCenter Contoso -DevBoxName myDevBox -UserId "me" -ProjectName DevProject -ActionName "schedule-default" -DelayTime "05:15"
```
This command delays the action "schedule-default" for the dev box "myDevBox" for 5 hours and 15 minutes. 

