FROM mcr.microsoft.com/powershell

ARG ARTIFACTS=/tmp/artifacts/
ARG ARTIFACT=*.nupkg
ARG TEMPREPO=tmp
ARG MODULE=Az
ARG CONFIG=config
ARG AZURERM_CONTEXT_SETTINGS=AzureRmContextSettings.json
ARG AZURE=/root/.Azure
ARG VCS_REF="none"
ARG VERSION=3.3.0

LABEL maintainer="Azure PowerShell Team <azdevxps@microsoft.com>" \
      readme.md="TODO" \
      description="This Dockerfile will install the latest release of Azure PowerShell." \
      org.label-schema.usage="TODO: official doc" \
      org.label-schema.url="TODO:same as readme.md" \
      org.label-schema.vcs-url="https://github.com/Azure/azure-powershell" \
      org.label-schema.name="azure powershell" \
      org.label-schema.vendor="Azure PowerShell" \
      org.label-schema.version=${VERSION} \
      org.label-schema.schema-version="1.0" \
      org.label-schema.vcs-ref=${VCS_REF} \
      org.label-schema.docker.cmd="docker run --rm ${IMAGE_NAME} pwsh -c '$PSVERSIONTABLE'" \
      org.label-schema.docker.cmd.devel="docker run -it --rm -v ~/.Azure/AzureRmContext.json:/root/.Azure/AzureRmContext.json -v ~/.Azure/TokenCache.dat:/root/.Azure/TokenCache.dat ${IMAGE_NAME} pwsh -c Get-AzContext" \
      org.label-schema.docker.cmd.test="currently not available" \
      org.label-schema.docker.cmd.help="docker run --rm ${IMAGE_NAME} pwsh -c Get-Help"

# install azure-powershell from built artifacts
COPY ${ARTIFACT} ${ARTIFACTS}
RUN pwsh -Command Register-PSRepository -Name ${TEMPREPO} -SourceLocation ${ARTIFACTS} -PublishLocation $ARTIFACTS -InstallationPolicy Trusted -PackageManagementProvider NuGet
RUN pwsh -Command Install-Module -Name ${MODULE} -Repository ${TEMPREPO}
RUN pwsh -Command Get-Module -ListAvailable
RUN pwsh -Command Unregister-PSRepository -Name ${TEMPREPO}

# create AzureRmContextSettings.json before it was generated
COPY ${CONFIG}/${AZURERM_CONTEXT_SETTINGS} ${AZURE}/${AZURERM_CONTEXT_SETTINGS}

CMD [ "pwsh" ]