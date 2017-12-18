FROM microsoft/powershell

ARG CONFIG=Release

COPY src/Package/${CONFIG}/ResourceManager/AzureResourceManager /usr/local/share/powershell/Modules
COPY tools/InstallationTests/NetcoreTests /azpstests