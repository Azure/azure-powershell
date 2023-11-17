### Example 1: Returns instance details for the account name.
```powershell
Get-AzDeviceUpdateInstance -AccountName azpstest-account -ResourceGroupName azpstest_gp
```

```output
AccountName      Name              Location ResourceGroupName
-----------      ----              -------- -----------------
azpstest-account azpstest-instance eastus   azpstest_gp
```

Returns instance details for the account name.

### Example 2: Returns instance details for the given instance and account name.
```powershell
Get-AzDeviceUpdateInstance -AccountName azpstest-account -ResourceGroupName azpstest_gp -Name azpstest-instance
```

```output
AccountName      Name              Location ResourceGroupName
-----------      ----              -------- -----------------
azpstest-account azpstest-instance eastus   azpstest_gp
```

Returns instance details for the given instance and account name.