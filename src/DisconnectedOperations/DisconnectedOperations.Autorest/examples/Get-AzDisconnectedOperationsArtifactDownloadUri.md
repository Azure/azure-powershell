### Example 1: Get download URI for an artifact
```powershell
Get-AzDisconnectedOperationsArtifactDownloadUri -ArtifactName "my-artifact" -ImageName "default" -Name "disconnected-operation-name" -ResourceGroupName "my-resource-group"
```

```output
ArtifactOrder     : 2
Description       : Local data disk
DownloadLink      : Downloadable link with 24 hrs validity
LinkExpiry        : 11/11/2025 09:25:56
ProvisioningState :
Size              : 35068
Title             : my-artifact.vhdx
```

This command gets the download URI for the artifact `my-artifact` from image `default` in resource group `my-resource-group`.