### Example 1: Remove "frontdoor1" in resource group "rg1" under the current subscription.
```powershell
Remove-AzFrontDoor -Name "frontdoor1" -ResourceGroupName "rg1"
```

Remove "frontdoor1" in resource group "rg1" under the current subscription.

### Example 2: Remove all FrontDoors in resource group "rg1" under the current subscription.
```powershell
Get-AzFrontDoor -ResourceGroupName "rg1" | Remove-AzFrontDoor
```

Remove all FrontDoors in resource group "rg1" under the current subscription.

### Example 3: Remove all FrontDoors under the current subscription.
```powershell
Get-AzFrontDoor | Remove-AzFrontDoor
```

Remove all FrontDoors under the current subscription.

### Example 4: Remove all FrontDoors with name "frontdoor1" under the current subscription.
```powershell
Remove-AzFrontDoor -Name "frontdoor1" | Remove-AzFrontDoor
```

Remove all FrontDoors with name "frontdoor1" under the current subscription.