# Batch Powershell Data Model Generator

This executable automatically generates the PowerShell data model classes used by the Azure Batch PowerShell cmdlets.

## Usage

```shell
dotnet run <The file path to the Microsoft.Azure.Batch.dll to operate on>
```

## Updating with new models

Once generation succeeds, you may delete the old models inside `azure-powershell\src\Batch\Batch\Models.Generated` and replace them with the new models from the `GeneratedFiles` directory.
