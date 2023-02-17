### Example 1: List the details of Account Filter in the Media Services account by Media Name.
```powershell
Get-AzMediaAccountFilter -AccountName azpsms -ResourceGroupName azps_test_group
```

```output
Name                 ResourceGroupName
----                 -----------------
azpsms-accountfilter azps_test_group
```

List the details of Account Filter in the Media Services account by Media Name.

### Example 2: Get the details of an Account Filter in the Media Services account by Media Account Folter Name.
```powershell
Get-AzMediaAccountFilter -AccountName azpsms -ResourceGroupName azps_test_group -FilterName azpsms-accountfilter
```

```output
Name                 ResourceGroupName
----                 -----------------
azpsms-accountfilter azps_test_group
```

Get the details of an Account Filter in the Media Services account by Media Account Folter Name.