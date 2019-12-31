FROM mcr.microsoft.com/powershell

ARG CONFIG=Release
ARG ARTIFACTS=/tmp/artifacts/
ARG ARTIFACT=*.nupkg
ARG TEMPREPO=tmp
ARG MODULE=Az
ARG SETTINGS=AzureRmContextSettings.json
ARG AZURE=/root/.Azure

LABEL maintainer="Microsoft" \
      org.label-schema.schema-version="1.0" \
      org.label-schema.vendor="Microsoft" \
      org.label-schema.name="Azure Powershell" \
      org.label-schema.version="TODO" \
      org.label-schema.license="MIT" \
      org.label-schema.description="TODO" \
      org.label-schema.url="TODO" \
      org.label-schema.usage="TODO" \
      org.label-schema.build-date=$BUILD_DATE \
      org.label-schema.vcs-url="https://github.com/Azure/azure-powershell.git" \
      org.label-schema.docker.cmd="TODO"

# install azure-powershell from built artifacts
COPY ${ARTIFACT} ${ARTIFACTS}
RUN pwsh -Command Register-PSRepository -Name ${TEMPREPO} -SourceLocation ${ARTIFACTS} -PublishLocation $ARTIFACTS -InstallationPolicy Trusted -PackageManagementProvider NuGet
RUN pwsh -Command Install-Module -Name ${MODULE} -Repository ${TEMPREPO}
RUN pwsh -Command Get-Module -ListAvailable
RUN pwsh -Command Unregister-PSRepository -Name ${TEMPREPO}

# create AzureRmContextSettings.json before it was generated
COPY ${SETTINGS} ${AZURE}/${SETTINGS}

CMD [ "pwsh" ]