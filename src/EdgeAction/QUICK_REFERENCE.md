# EdgeAction PowerShell Quick Reference

## Installation
```powershell
# Import the module
Import-Module "C:\azpowershell\azure-powershell\artifacts\Debug\Az.EdgeAction\Az.EdgeAction.psd1" -Force
```

## Basic Workflow

### 1. Create Edge Action
```powershell
New-AzEdgeAction `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction" `
    -SkuName "Standard" `
    -SkuTier "Standard" `
    -Location "global"
```

### 2. Create Version
```powershell
New-AzEdgeActionVersion `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction" `
    -Version "v1" `
    -DeploymentType "file" `
    -IsDefaultVersion $false `
    -Location "global"
```

### 3. Deploy Code (NEW - File-based)
```powershell
# Option A: Deploy JavaScript file directly
Deploy-AzEdgeActionVersionCode `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction" `
    -Version "v1" `
    -FilePath "C:\path\to\handler.js" `
    -DeploymentType "file"

# Option B: Deploy JavaScript as zip (auto-zips)
Deploy-AzEdgeActionVersionCode `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction" `
    -Version "v1" `
    -FilePath "C:\path\to\handler.js" `
    -DeploymentType "zip"

# Option C: Deploy existing zip file
Deploy-AzEdgeActionVersionCode `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction" `
    -Version "v1" `
    -FilePath "C:\path\to\code.zip"

# Option D: Auto-detect (simplest)
Deploy-AzEdgeActionVersionCode `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction" `
    -Version "v1" `
    -FilePath "C:\path\to\handler.js"
```

### 4. Verify Deployment
```powershell
Get-AzEdgeActionVersionCode `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction" `
    -Version "v1"
```

### 5. List All Versions
```powershell
Get-AzEdgeActionVersion `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction"
```

### 6. Switch Default Version
```powershell
Switch-AzEdgeActionVersionDefault `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction" `
    -Version "v2"
```

### 7. Clean Up
```powershell
# Delete version
Remove-AzEdgeActionVersion `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction" `
    -Version "v1"

# Delete edge action
Remove-AzEdgeAction `
    -ResourceGroupName "myResourceGroup" `
    -EdgeActionName "myEdgeAction"
```

## File Deployment Rules

| File Extension | Default Deployment Type | Supported Types |
|---------------|------------------------|-----------------|
| `.js` | `file` | `file`, `zip` |
| `.zip` | `zip` | `zip` |

## Deployment Type Behavior

| Deployment Type | JavaScript File (.js) | Zip File (.zip) |
|----------------|----------------------|-----------------|
| `file` | ✅ Read and encode | ❌ Not supported |
| `zip` | ✅ Auto-zip then encode | ✅ Read and encode |
| Auto-detect | → `file` | → `zip` |

## Complete Example
```powershell
# Full workflow example
$rg = "test-rg"
$edgeAction = "my-edge-action"
$version = "v1.0"
$jsFile = "C:\code\edge-action-handler.js"

# 1. Create resources
New-AzEdgeAction -ResourceGroupName $rg -EdgeActionName $edgeAction `
    -SkuName "Standard" -SkuTier "Standard" -Location "global"

New-AzEdgeActionVersion -ResourceGroupName $rg -EdgeActionName $edgeAction `
    -Version $version -DeploymentType "file" -IsDefaultVersion $true -Location "global"

# 2. Deploy code
Deploy-AzEdgeActionVersionCode -ResourceGroupName $rg -EdgeActionName $edgeAction `
    -Version $version -FilePath $jsFile

# 3. Verify
Get-AzEdgeActionVersionCode -ResourceGroupName $rg -EdgeActionName $edgeAction -Version $version

# 4. View all versions
Get-AzEdgeActionVersion -ResourceGroupName $rg -EdgeActionName $edgeAction

# 5. Clean up
Remove-AzEdgeActionVersion -ResourceGroupName $rg -EdgeActionName $edgeAction -Version $version
Remove-AzEdgeAction -ResourceGroupName $rg -EdgeActionName $edgeAction
```
