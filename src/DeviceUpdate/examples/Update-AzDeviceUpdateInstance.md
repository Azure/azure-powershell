### Example 1: Updates instance's tags.
```powershell
Update-AzDeviceUpdateInstance -AccountName azpstest-account -ResourceGroupName azpstest_gp -Name azpstest-instance -Tag @{"abc"="123"}
```

```output
AccountName      Name              Location ResourceGroupName
-----------      ----              -------- -----------------
azpstest-account azpstest-instance eastus   azpstest_gp
```

Updates instance's tags.

### Example 2: Updates instance's tags.
```powershell
Get-AzDeviceUpdateInstance -AccountName azpstest-account -ResourceGroupName azpstest_gp -Name azpstest-instance | Update-AzDeviceUpdateInstance -Tag @{"abc"="123"}
```

```output
AccountName      Name              Location ResourceGroupName
-----------      ----              -------- -----------------
azpstest-account azpstest-instance eastus   azpstest_gp
```

Updates instance's tags.