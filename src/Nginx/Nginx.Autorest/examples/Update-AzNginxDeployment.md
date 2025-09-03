### Example 1: Enable the diagnostics support for a NGINX deployment
```powershell
Update-AzNginxDeployment -Name nginx-test -ResourceGroupName nginx-test-rg -EnableDiagnosticsSupport
```

```output
Location      Name
--------      ----
westcentralus nginx-test
```

This command enables the diagnostics support for a NGINX deployment.

### Example 2: Disable the diagnostics support for a NGINX deployment
```powershell
Update-AzNginxDeployment -Name nginx-test -ResourceGroupName nginx-test-rg -EnableDiagnosticsSupport:$false
```

```output
Location      Name
--------      ----
westcentralus nginx-test
```

This command disables the diagnostics support for a NGINX deployment.
