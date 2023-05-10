### Example 1: Install the lateset version of kubectl and kubelogin
```powershell
Install-AzAksCliTool
```

### Example 2: Install the special version of kubectl and kubelogin into custom folder
```powershell
Install-AzAksCliTool -KubectlInstallVersion "v1.25.0" -KubectlInstallDestination "~/bin/" -KubeloginInstallVersion "v0.0.20" -KubeloginInstallDestination "~/bin"
```

