### Example 1: Enable the diagnotics support for a NGINX deployment
```powershell
Update-AzNginxDeployment -Name nginx-test -ResourceGroupName nginx-test-rg -EnableDiagnosticsSupport
```

```output
Location      Name
--------      ----
westcentralus nginx-test
```

This command enables the diagnotics support for a NGINX deployment.

### Example 2: Disable the diagnotics support for a NGINX deployment
```powershell
Update-AzNginxDeployment -Name nginx-test -ResourceGroupName nginx-test-rg -EnableDiagnosticsSupport:$false
```

```output
Location      Name
--------      ----
westcentralus nginx-test
```

This command disables the diagnotics support for a NGINX deployment.
