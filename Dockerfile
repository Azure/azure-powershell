FROM microsoft/powershell

ARG CONFIG=Release

COPY src/Package/${CONFIG}/ResourceManager /usr/local/share/powershell/Modules