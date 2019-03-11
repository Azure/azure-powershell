FROM mcr.microsoft.com/powershell

ARG CONFIG=Release

COPY artifacts/${CONFIG} /usr/local/share/powershell/Modules
COPY tools/InstallationTests/NetcoreTests /azpstests
