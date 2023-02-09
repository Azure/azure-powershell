### Example 1: List the details of Media Services account by Sub.
```powershell
Get-AzMediaService
```

```output
Name       Location ResourceGroupName ProvisioningState
----       -------- ----------------- -----------------
azporatlms East US  azps_test_group   Succeeded
azpsms     East US  azps_test_group   Succeeded
```

List the details of Media Services account by Sub.

### Example 2: List the details of Media Services account by ResourceGroup.
```powershell
Get-AzMediaService -ResourceGroupName azps_test_group
```

```output
Name       Location ResourceGroupName ProvisioningState
----       -------- ----------------- -----------------
azporatlms East US  azps_test_group   Succeeded
azpsms     East US  azps_test_group   Succeeded
```

List the details of Media Services account by ResourceGroup.

### Example 3: Get the details of a Media Services account by Media Service account name.
```powershell
Get-AzMediaService -ResourceGroupName azps_test_group -AccountName azpsms
```

```output
Name   Location ResourceGroupName ProvisioningState
----   -------- ----------------- -----------------
azpsms East US  azps_test_group   Succeeded
```

Get the details of a Media Services account by Media Service account ame.