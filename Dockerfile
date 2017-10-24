FROM microsoft/powershell
COPY src/Package/Debug/ResourceManager /azure-powershell
COPY tools/InstallationTests/NetcoreTests /tests
CMD powershell -NoExit -Command '$env:PSModulePath = "$($env:PSModulePath):/azure-powershell"'