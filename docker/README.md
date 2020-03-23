# Docker


## Overview
These Dockerfiles enable executing Azure-PowerShell cmdlets in a container for the supported OS.

## Configuration
This image requires Docker 17.05 or newer.

It is also expected that you are able to run Docker without `sudo`.
Please follow [Docker's official instructions][install] to install `docker` correctly.

[install]: https://docs.docker.com/engine/installation/


## Release

The release containers derive from the [Powershell image][powershell image], and then install the current Az package. Starting with Az 3.6.1 the images are using PowerShell 7, the previous versions are using PowerShell 6.2.4.

[powershell image]: https://hub.docker.com/_/microsoft-powershell

Azure PowerShell [release notes](https://docs.microsoft.com/en-us/powershell/azure/release-notes-azureps)

## Examples

### Download/Update the azure-powershell image

```sh
docker pull mcr.microsoft.com/azure-powershell
```

### Run azure-powershell container 

- To run azure-powershell using a container in an interactive mode:

```sh
$ docker run -it mcr.microsoft.com/azure-powershell pwsh 
```

- To run azure-powershell from using a container in an interactive mode using host authentication: 

    1- Make sure that `$HOME/.Azure` is present on the host (default location) 
    2- You may need to grant access this location for the docker process.

```sh
$ docker run -it -v ~/.Azure/AzureRmContext.json:/root/.Azure/AzureRmContext.json -v ~/.Azure/TokenCache.dat:/root/.Azure/TokenCache.dat mcr.microsoft.com/azure-powershell pwsh 
```

Verify the host authentication:

```sh
docker run -it --rm -v ~/.Azure/AzureRmContext.json:/root/.Azure/AzureRmContext.json -v ~/.Azure/TokenCache.dat:/root/.Azure/TokenCache.dat mcr.microsoft.com/azure-powershell pwsh -c Get-AzContext
```

### Building image

Clone the azure-powershell repo, and in your local copy run the following commands:

```sh
$ dotnet msbuild /t:Build /p:Configuration=Release
$ dotnet msbuild /t:publish /p:Configuration=Release /p:NuGetKey=1234
$ dotnet msbuild /t:BuildImage /p:DockerImageName=mcr.microsoft.com/azure-powershell
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
[new issue]:https://aka.ms/azpsissue


## Legal and Licensing

Azure-PowerShell is licensed under the [Apache license][].

[Apache license]: https://github.com/Azure/azure-powershell/blob/master/LICENSE.txt


PowerShell is licensed under the [Apache license][].

[Apache license]: https://github.com/PowerShell/PowerShell/tree/master/LICENSE.txt

## [Code of Conduct][conduct-md]

This project has adopted the [Microsoft Open Source Code of Conduct][conduct-code].
For more information see the [Code of Conduct FAQ][conduct-FAQ] or contact [opencode@microsoft.com][conduct-email] with any additional questions or comments.

[conduct-code]: http://opensource.microsoft.com/codeofconduct/
[conduct-FAQ]: http://opensource.microsoft.com/codeofconduct/faq/
[conduct-email]: mailto:opencode@microsoft.com
