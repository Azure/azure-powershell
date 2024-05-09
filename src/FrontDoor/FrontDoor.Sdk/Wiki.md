https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/teams_docs/azps_docs/process-track1-sdk-migration

## Generate Csharp version

```
autorest --reset

autorest --use:@microsoft.azure/autorest.csharp@2.3.90

autorest.cmd README.md --version=v2
```

## Generate Pwsh version

```
autorest --reset

autorest --use:@autorest/powershell@4.x
```