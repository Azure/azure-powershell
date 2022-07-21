# All-in-One Docker Image for Azure PowerShell Code Generation
Packages contained in the image.
* PowerShell 6.2.4
* NodeJS 14.15.5
* Latest autorest
* Dotnet SDK 2.1

# How to Build the Image
`docker build -t autorest ./`

# Launch the Image
`docker run -it -v <path-to-your-source>:/src autorest`

# Code Generation vs Build vs Run
## Code Generation
`autorest`
## Build
`pwsh build-module.ps1`
## Run
`pwsh run-module.ps1`
## Playback Test
`pwsh test-module.ps1`
