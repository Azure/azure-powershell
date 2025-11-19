### Example 1: Create a new edge action version

```powershell
New-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -DeploymentType "file" -IsDefaultVersion $false -Location "global"
```

Creates a new version for an edge action with file-based deployment type.

### Example 2: Create a default version with zip deployment

```powershell
New-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v2" -DeploymentType "zip" -IsDefaultVersion $true -Location "global"
```

Creates a new version configured for zip deployment and sets it as the default version.

