### Example 1: Gets online deployment log
```powershell
Get-AzMLWorkspaceOnlineDeploymentLog -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-cli01 -Name blue
```

```output
Instance status:
SystemSetup: Succeeded
UserContainerImagePull: Succeeded
ModelDownload: Succeeded
UserContainerStart: Succeeded

Container events:
Kind: Pod, Name: Pulling, Type: Normal, Time: 20220519-03:11:59.750675, Message: Start pulling container image
Kind: Pod, Name: Pulling, Type: Normal, Time: 20220519-03:11:59.843068, Message: Start downloading models
Kind: Pod, Name: Pulled, Type: Normal, Time: 20220519-03:12:54.679466, Message: Container image is pulled successfully
Kind: Pod, Name: Downloaded, Type: Normal, Time: 20220519-03:12:54.679466, Message: Models are downloaded successfully or no model need to download
Kind: Pod, Name: Created, Type: Normal, Time: 20220519-03:12:54.798575, Message: Created container inference-server
Kind: Pod, Name: Started, Type: Normal, Time: 20220519-03:12:54.921722, Message: Started container inference-server
```

Gets online deployment log

