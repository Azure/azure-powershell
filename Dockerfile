FROM mcr.microsoft.com/powershell

ARG CONFIG=Release
ARG ARTIFACTS=/tmp/artifacts/
ARG ARTIFACT=artifacts/*.nupkg
ARG TEMPREPO=tmp
ARG MODULE=Az

ENV USE_HOST_AUTHENTICATION=false

# install azure-powershell from built artifacts
COPY ${ARTIFACT} ${ARTIFACTS}
RUN pwsh -Command Register-PSRepository -Name ${TEMPREPO} -SourceLocation ${ARTIFACTS} -PublishLocation $ARTIFACTS -InstallationPolicy Trusted -PackageManagementProvider NuGet
RUN pwsh -Command Install-Module -Name ${MODULE} -Repository ${TEMPREPO}
RUN pwsh -Command Get-Module -ListAvailable
RUN pwsh -Command Unregister-PSRepository -Name ${TEMPREPO}



CMD [ "pwsh" ]