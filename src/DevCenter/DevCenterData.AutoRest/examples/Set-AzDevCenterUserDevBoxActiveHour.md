### Example 1: Set active hours for a Dev Box by endpoint and user ID
```powershell
Set-AzDevCenterUserDevBoxActiveHour `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -StartTimeHour 9 `
  -EndTimeHour 17 `
  -TimeZone "America/Los_Angeles"
```
This command sets the active hours for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" from 9 AM to 5 PM in the "America/Los_Angeles" time zone using the endpoint.

### Example 2: Set active hours for a Dev Box by dev center name and current user
```powershell
Set-AzDevCenterUserDevBoxActiveHour `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me" `
  -StartTimeHour 8 `
  -EndTimeHour 16 `
  -TimeZone "America/New_York"
```
This command sets the active hours for the dev box "myDevBox" assigned to the current signed-in user from 8 AM to 4 PM in the "America/New_York" time zone using the dev center name.

### Example 3: Set active hours for a Dev Box using Body parameter and endpoint
```powershell
$activeHours = @{
    StartTimeHour = 10
    EndTimeHour = 18
    TimeZone = "America/Chicago"
}
Set-AzDevCenterUserDevBoxActiveHour `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me" `
  -Body $activeHours
```
This command sets the active hours for the dev box "myDevBox" assigned to the current signed-in user from 10 AM to 6 PM in the "America/Chicago" time zone using the endpoint and a body object.

### Example 4: Set active hours for a Dev Box using Body parameter and dev center name
```powershell
$activeHours = @{
    StartTimeHour = 7
    EndTimeHour = 15
    TimeZone = "America/Los_Angeles"
}
Set-AzDevCenterUserDevBoxActiveHour `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -Body $activeHours
```
This command sets the active hours for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" from 7 AM to 3 PM in the "UTC" time zone using the dev center name and a body object.