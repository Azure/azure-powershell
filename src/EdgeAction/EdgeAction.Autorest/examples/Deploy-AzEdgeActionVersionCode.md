### Example 1: Deploy a JavaScript file to an edge action version

```powershell
Deploy-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -FilePath "C:\code\handler.js"
```

Deploys a JavaScript file to the specified edge action version. The deployment type is automatically detected based on the file extension (.js → file type).

### Example 2: Deploy a JavaScript file as a zip package

```powershell
Deploy-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -FilePath "C:\code\handler.js" -DeploymentType "zip"
```

Deploys a JavaScript file by automatically creating a zip archive, encoding it in base64, and uploading it to the edge action version.

### Example 3: Deploy a pre-packaged zip file

```powershell
Deploy-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -FilePath "C:\code\package.zip"
```

Deploys an existing zip file containing the edge action code. The zip file is encoded in base64 and uploaded.

### Example 4: Deploy with a custom deployment name

```powershell
Deploy-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -FilePath "C:\code\handler.js" -Name "production-deploy-001"
```

Deploys code with a custom deployment name for tracking purposes.

