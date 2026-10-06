### Example 1: Validate an edge action version without changing it

```powershell
$version = Get-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1"
Update-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -DeploymentType $version.DeploymentType -IsDefaultVersion $version.IsDefaultVersion
```

```output
Name Location ProvisioningState
---- -------- -----------------
v1   global   Succeeded
```

Validates the request using the version's existing values. The operation does not change version properties or tags. Use `Switch-AzEdgeActionVersionDefault` to change the default version.
