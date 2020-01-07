# Docker

This Dockerfile enable running Azure-PowerShell in a container for each Linux distribution we support.

This requires Docker 17.05 or newer.
It also expects you to be able to run Docker without `sudo`.
Please follow [Docker's official instructions][install] to install `docker` correctly.

[install]: https://docs.docker.com/engine/installation/

## Release

The release containers derive from the [Powershell image][powershell image], and then install the Az package.

[powershell image]: https://hub.docker.com/_/microsoft-powershell

TODO: link to azure-powershell release page

## Examples

### Download/Update image

```sh
docker pull mcr.microsoft.com/azure-powershell
```

### Run azure-powershell container 

To run azure-powerShell from using a container in an interactive mode:

```sh
$ docker run -it mcr.microsoft.com/azure-powershell pwsh 
```
To run azure-powerShell from using a container in an interactive mode using host authentication, 
you need to make sure "~/.Azure" is existed (which is the default location) and you might need to grant docker to access this location:

```sh
$ docker run -it -v ~/.Azure/AzureRmContext.json:/root/.Azure/AzureRmContext.json -v ~/.Azure/TokenCache.dat:/root/.Azure/TokenCache.dat mcr.microsoft.com/azure-powershell pwsh 
```
To check host authentication:

```sh
docker run -it --rm -v ~/.Azure/AzureRmContext.json:/root/.Azure/AzureRmContext.json -v ~/.Azure/TokenCache.dat:/root/.Azure/TokenCache.dat mcr.microsoft.com/azure-powershell pwsh -c Get-AzContext
```

### Building image

In your local copy of azure-powershell repo, run:

```sh
$ dotnet msbuild /t:Build /p:Configuration=Release
$ dotnet msbuild /t:publish /p:Configuration=Release /p:NuGetKey=1234
$ dotnet msbuild /t:BuildImage
$ docker images
```

### Remove image

```sh
docker rmi mcr.microsoft.com/azure-powershell
```

## Developing and Contributing

Please see the [Contribution Guide][] for general information about how to develop and contribute.

If you have any problems, please consult the [GitHub issues][].
If you do not see your problem captured, please file a [new issue][] and follow the provided template.

[Contribution Guide]: https://github.com/Azure/azure-powershell/blob/master/CONTRIBUTING.md
[GitHub issues]: https://github.com/Azure/azure-powershell/issues
[new issue]:https://github.com/Azure/azure-powershell/issues/new
## Legal and Licensing

Azure-PowerShell is licensed under the [MIT license][].

[MIT license]: https://github.com/Azure/azure-powershell/blob/master/LICENSE.txt

### Telemetry

By default, PowerShell collects the OS description and the version of PowerShell (equivalent to `$PSVersionTable.OS` and `$PSVersionTable.GitCommitId`) using [Application Insights](https://azure.microsoft.com/en-us/services/application-insights/).
To opt-out of sending telemetry, create an environment variable called `POWERSHELL_TELEMETRY_OPTOUT` set to a value of `1` before starting PowerShell from the installed location.
The telemetry we collect fall under the [Microsoft Privacy Statement](https://privacy.microsoft.com/en-us/privacystatement/).


## [Code of Conduct][conduct-md]

This project has adopted the [Microsoft Open Source Code of Conduct][conduct-code].
For more information see the [Code of Conduct FAQ][conduct-FAQ] or contact [opencode@microsoft.com][conduct-email] with any additional questions or comments.

[conduct-code]: http://opensource.microsoft.com/codeofconduct/
[conduct-FAQ]: http://opensource.microsoft.com/codeofconduct/faq/
[conduct-email]: mailto:opencode@microsoft.com
[conduct-md]: https://github.com/PowerShell/PowerShell/tree/master/./CODE_OF_CONDUCT.md