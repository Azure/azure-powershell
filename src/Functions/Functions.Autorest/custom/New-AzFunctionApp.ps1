function New-AzFunctionApp {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ISite])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Creates a function app.')]
    [CmdletBinding(SupportsShouldProcess=$true, DefaultParametersetname="Consumption")]
    param(
        [Parameter(ParameterSetName="Consumption", HelpMessage='The Azure subscription ID.')]
        [Parameter(ParameterSetName="ByAppServicePlan")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${SubscriptionId},
        
        [Parameter(Mandatory=$true, ParameterSetName="Consumption", HelpMessage='The name of the resource group.')]
        [Parameter(Mandatory=$true, ParameterSetName="ByAppServicePlan")]
        [Parameter(Mandatory=$true, ParameterSetName="CustomDockerImage")]
        [Parameter(Mandatory=$true, ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(Mandatory=$true, ParameterSetName="FlexConsumption")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${ResourceGroupName},
        
        [Parameter(Mandatory=$true, ParameterSetName="Consumption", HelpMessage='The name of the function app.')]
        [Parameter(Mandatory=$true, ParameterSetName="ByAppServicePlan")]
        [Parameter(Mandatory=$true, ParameterSetName="CustomDockerImage")]
        [Parameter(Mandatory=$true, ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(Mandatory=$true,ParameterSetName="FlexConsumption")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Name},
        
        [Parameter(Mandatory=$true, ParameterSetName="Consumption", HelpMessage='The name of the storage account.')]
        [Parameter(Mandatory=$true, ParameterSetName="ByAppServicePlan")]
        [Parameter(Mandatory=$true, ParameterSetName="CustomDockerImage")]
        [Parameter(Mandatory=$true, ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(Mandatory=$true, ParameterSetName="FlexConsumption")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${StorageAccountName},

        [Parameter(ParameterSetName="Consumption", HelpMessage='Name of the existing App Insights project to be added to the function app.')]
        [Parameter(ParameterSetName="ByAppServicePlan")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        [Alias("AppInsightsName")]
        ${ApplicationInsightsName},

        [Parameter(ParameterSetName="Consumption", HelpMessage='Instrumentation key of App Insights to be added.')]
        [Parameter(ParameterSetName="ByAppServicePlan")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        [Alias("AppInsightsKey")]
        ${ApplicationInsightsKey},

        [Parameter(Mandatory=$true, ParameterSetName="Consumption", HelpMessage='The location for the consumption plan.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Location},

        [Parameter(Mandatory=$true, ParameterSetName="ByAppServicePlan", HelpMessage='The name of the service plan.')]
        [Parameter(Mandatory=$true, ParameterSetName="CustomDockerImage")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${PlanName},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage='The OS to host the function app.')]
        [Parameter(ParameterSetName="Consumption")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerType])]
        [ValidateSet("Linux", "Windows")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        # OS type (Linux or Windows)
        ${OSType},
        
        [Parameter(Mandatory=$true, ParameterSetName="ByAppServicePlan", HelpMessage='The function runtime.')]
        [Parameter(Mandatory=$true, ParameterSetName="Consumption")]
        [Parameter(Mandatory=$true, ParameterSetName="FlexConsumption")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        # Runtime types are defined in HelperFunctions.ps1
        ${Runtime},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage='The function runtime.')]
        [Parameter(ParameterSetName="Consumption")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        # RuntimeVersion types are defined in HelperFunctions.ps1
        ${RuntimeVersion},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage='The Functions version.')]
        [Parameter(ParameterSetName="Consumption")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        # FunctionsVersion types are defined in HelperFunctions.ps1
        ${FunctionsVersion},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage='Disable creating application insights resource during the function app creation. No logs will be available.')]
        [Parameter(ParameterSetName="Consumption")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [System.Management.Automation.SwitchParameter]
        [Alias("DisableAppInsights")]
        ${DisableApplicationInsights},
        
        [Parameter(Mandatory=$true, ParameterSetName="CustomDockerImage", HelpMessage='Container image name, e.g., publisher/image-name:tag.')]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        [Alias("DockerImageName")]
        ${Image},

        [Parameter(ParameterSetName="CustomDockerImage", HelpMessage='The container registry username and password. Required for private registries.')]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [ValidateNotNullOrEmpty()]
        [PSCredential]
        [Alias("DockerRegistryCredential")]
        ${RegistryCredential},

        [Parameter(HelpMessage='Returns true when the command succeeds.')]
        [System.Management.Automation.SwitchParameter]
        ${PassThru},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage='Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.')]
        [Parameter(ParameterSetName="Consumption")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${NoWait},
        
        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage='Runs the cmdlet as a background job.')]
        [Parameter(ParameterSetName="Consumption")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${AsJob},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage='Resource tags.')]
        [Parameter(ParameterSetName="Consumption")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.IResourceTags]))]
        [System.Collections.Hashtable]
        [ValidateNotNull()]
        ${Tag},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage='Function app settings.')]
        [Parameter(ParameterSetName="Consumption")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [ValidateNotNullOrEmpty()]
        [Hashtable]
        ${AppSetting},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage="Specifies the type of identity used for the function app.
            The acceptable values for this parameter are:
            - SystemAssigned
            - UserAssigned
            ")]
        [Parameter(ParameterSetName="Consumption")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FunctionAppManagedServiceIdentityCreateType])]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType]
        ${IdentityType},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage="Specifies the list of user identities associated with the function app.
            The user identity references will be ARM resource ids in the form:
            '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'")]
        [Parameter(ParameterSetName="Consumption")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [ValidateNotNull()]
        [System.String[]]
        ${IdentityID},

        [Parameter(Mandatory=$true,ParameterSetName="FlexConsumption", HelpMessage='Location to create Flex Consumption function app.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${FlexConsumptionLocation},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Name of deployment storage account to be used for function app artifacts.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${DeploymentStorageName},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Deployment storage container name.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${DeploymentStorageContainerName},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Deployment storage authentication type. Allowed values: StorageAccountConnectionString, SystemAssignedIdentity, UserAssignedIdentity')]
        [ValidateSet("StorageAccountConnectionString", "SystemAssignedIdentity", "UserAssignedIdentity")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${DeploymentStorageAuthType},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Deployment storage authentication value used for the chosen auth type (eg: connection string, or user-assigned identity resource id).')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        ${DeploymentStorageAuthValue},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage=
'Array of hashtables describing the AlwaysReady configuration. Each hashtable must include:
- name: The function name or route name.
- instanceCount: The number of pre-warmed instances for that function.

Example:
@(@{ name = "http"; instanceCount = 2 }).')]
        [ValidateNotNullOrEmpty()]
        [Hashtable[]]
        ${AlwaysReady},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Maximum instance count for Flex Consumption.')]
        [ValidateRange(40, 1000)]
        [int]
        ${MaximumInstanceCount},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Per-instance memory in MB for Flex Consumption instances.')]
        [ValidateSet(512, 2048, 4096)]
        [int]
        ${InstanceMemoryMB},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='The maximum number of concurrent HTTP trigger invocations per instance.')]
        [ValidateRange(1, 1000)]
        [int]
        ${HttpPerInstanceConcurrency},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Enable zone redundancy for high availability. Applies to Flex Consumption SKU only.')]
        [System.Management.Automation.SwitchParameter]
        ${EnableZoneRedundancy},

        [Parameter(Mandatory=$true, ParameterSetName="EnvironmentForContainerApp", HelpMessage='Name of the container app environment.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Environment},

        [Parameter(Mandatory=$false, ParameterSetName="EnvironmentForContainerApp", HelpMessage='The workload profile name to run the container app on.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${WorkloadProfileName},

        [Parameter(Mandatory=$false, ParameterSetName="EnvironmentForContainerApp", HelpMessage='The CPU in cores of the container app. e.g., 0.75.')]
        [ValidateNotNullOrEmpty()]
        [Double]
        ${ResourceCpu},

        [Parameter(Mandatory=$false, ParameterSetName="EnvironmentForContainerApp", HelpMessage='The memory size of the container app. e.g., 1.0Gi.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${ResourceMemory},

        [Parameter(Mandatory=$false, ParameterSetName="EnvironmentForContainerApp", HelpMessage='The maximum number of replicas when creating a function app on container app.')]
        [ValidateScript({$_ -gt 0})]
        [Int]
        ${ScaleMaxReplica},

        [Parameter(Mandatory=$false, ParameterSetName="EnvironmentForContainerApp", HelpMessage='The minimum number of replicas when create function app on container app.')]
        [ValidateScript({$_ -gt 0})]
        [Int]
        ${ScaleMinReplica},

        [Parameter(Mandatory=$false, ParameterSetName="EnvironmentForContainerApp", HelpMessage='The container registry server hostname, e.g. myregistry.azurecr.io.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${RegistryServer},
        
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {

        RegisterFunctionsTabCompleters

        # Remove bound parameters from the dictionary that cannot be process by the intenal cmdlets.
        $paramsToRemove = @(
            "StorageAccountName",
            "ApplicationInsightsName",
            "ApplicationInsightsKey",
            "Location",
            "PlanName",
            "OSType",
            "Runtime",
            "DisableApplicationInsights",
            "Image",
            "RegistryCredential",
            "FunctionsVersion",
            "RuntimeVersion",
            "AppSetting",
            "IdentityType",
            "IdentityID",
            "Tag",
            "Environment",
            "RegistryServer",
            "WorkloadProfileName",
            "ResourceCpu",
            "ResourceMemory",
            "ScaleMaxReplica",
            "ScaleMinReplica",
            "FlexConsumptionLocation",
            "DeploymentStorageName",
            "DeploymentStorageContainerName",
            "DeploymentStorageAuthType",
            "DeploymentStorageAuthValue",
            "AlwaysReady",
            "MaximumInstanceCount",
            "InstanceMemoryMB",
            "HttpPerInstanceConcurrency",
            "EnableZoneRedundancy"
        )
        foreach ($paramName in $paramsToRemove)
        {
            if ($PSBoundParameters.ContainsKey($paramName))
            {
                $PSBoundParameters.Remove($paramName)  | Out-Null
            }
        }

        $functionAppIsCustomDockerImage = $PsCmdlet.ParameterSetName -eq "CustomDockerImage"
        $environmentForContainerApp = $PsCmdlet.ParameterSetName -eq "EnvironmentForContainerApp"
        $consumptionPlan = $PsCmdlet.ParameterSetName -eq "Consumption"
        $functionAppIsFlexConsumption = $PsCmdlet.ParameterSetName -eq "FlexConsumption"

        $flexConsumptionStorageContainerCreated = $false
        $flexConsumptionPlanCreated = $false
        $appInsightCreated = $false
        $functionAppCreatedSuccessfully = $false

        $appSettings = New-Object -TypeName System.Collections.Generic.List[System.Object]
        $siteConfig = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.SiteConfig
        $functionAppDef = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.Site

        $OSIsLinux = ($OSType -eq "Linux") -or $functionAppIsFlexConsumption

        $params = GetParameterKeyValues -PSBoundParametersDictionary $PSBoundParameters `
                                        -ParameterList @("SubscriptionId", "HttpPipelineAppend", "HttpPipelinePrepend")

        ValidateFunctionAppNameAvailability -Name $Name @params

        $runtimeJsonDefinition = $null

        if (-not ($functionAppIsCustomDockerImage -or $environmentForContainerApp -or $functionAppIsFlexConsumption))
        {
            if (-not $FunctionsVersion)
            {
                $FunctionsVersion = $DefaultFunctionsVersion
                Write-Warning "FunctionsVersion not specified. Setting default value to '$FunctionsVersion'. $SetDefaultValueParameterWarningMessage"
            }

            ValidateFunctionsVersion -FunctionsVersion $FunctionsVersion

            if (-not $OSType)
            {
                $OSType = GetDefaultOSType -Runtime $Runtime
                Write-Warning "OSType not specified. Setting default value to '$OSType'. $SetDefaultValueParameterWarningMessage"
            }

            $runtimeJsonDefinition = GetStackDefinitionForRuntime -FunctionsVersion $FunctionsVersion -Runtime $Runtime -RuntimeVersion $RuntimeVersion -OSType $OSType

            if (-not $runtimeJsonDefinition)
            {
                $errorId = "FailedToGetRuntimeDefinition"
                $message += "Failed to get runtime definition for '$Runtime' version '$RuntimeVersion' in Functions version '$FunctionsVersion' on '$OSType'."
                $exception = [System.InvalidOperationException]::New($message)
                ThrowTerminatingError -ErrorId $errorId `
                                      -ErrorMessage $message `
                                      -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                      -Exception $exception

            }

            # Add app settings
            if ($runtimeJsonDefinition.AppSettingsDictionary.Count -gt 0)
            {
                foreach ($keyName in $runtimeJsonDefinition.AppSettingsDictionary.Keys)
                {
                    $value = $runtimeJsonDefinition.AppSettingsDictionary[$keyName]
                    $appSettings.Add((NewAppSetting -Name $keyName -Value $value))
                }
            }

            # Add site config properties
            if ($runtimeJsonDefinition.SiteConfigPropertiesDictionary.Count -gt 0)
            {
                foreach ($PropertyName in $runtimeJsonDefinition.SiteConfigPropertiesDictionary.Keys)
                {
                    $value = $runtimeJsonDefinition.SiteConfigPropertiesDictionary[$PropertyName]
                    $siteConfig.$PropertyName = $value
                }
            }
        }

        # Set function app managed identity
        if ($IdentityType)
        {
            $functionAppDef.IdentityType = $IdentityType

            if ($IdentityType -eq "UserAssigned")
            {
                # Set UserAssigned managed identiy
                if (-not $IdentityID)
                {
                    $errorMessage = "IdentityID is required for UserAssigned identity"
                    $exception = [System.InvalidOperationException]::New($errorMessage)
                    ThrowTerminatingError -ErrorId "IdentityIDIsRequiredForUserAssignedIdentity" `
                                            -ErrorMessage $errorMessage `
                                            -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                            -Exception $exception

                }

                $identityUserAssignedIdentity = NewIdentityUserAssignedIdentity -IdentityID $IdentityID
                $functionAppDef.IdentityUserAssignedIdentity = $identityUserAssignedIdentity
            }
        }

        $servicePlan = $null
        $dockerRegistryServerUrl = $null
        
        if ($consumptionPlan)
        {
            ValidateConsumptionPlanLocation -Location $Location -OSIsLinux:$OSIsLinux @params
            $functionAppDef.Location = $Location
        }
        elseif ($environmentForContainerApp)
        {
            $OSIsLinux = $true

            if (-not $Image)
            {
                Write-Warning "Image not specified. Setting default value to '$DefaultCentauriImage'."
                $Image = $DefaultCentauriImage
            }
            if ($RegistryServer)
            {
                $dockerRegistryServerUrl = $RegistryServer
            }

            if ($Environment -and $RegistryCredential)
            {
                # Error out if the user has specified both Environment and RegistryCredential and not provided RegistryServer.
                if (-not $RegistryServer)
                {
                    $errorMessage = "RegistryServer is required when Environment and RegistryCredential is specified."
                    $exception = [System.InvalidOperationException]::New($errorMessage)
                    ThrowTerminatingError -ErrorId "RegistryServerRequired" `
                                          -ErrorMessage $errorMessage `
                                          -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                          -Exception $exception
                }
            }
        }
        elseif ($PlanName)
        {
            # Host function app in Elastic Premium or app service plan
            $servicePlan = GetServicePlan $PlanName @params

            if ($null -ne $servicePlan.Location)
            {
                $Location = $servicePlan.Location
            }

            if ($null -ne $servicePlan.Reserved)
            {
                $OSIsLinux = $servicePlan.Reserved
            }

            $functionAppDef.ServerFarmId = $servicePlan.Id
            $functionAppDef.Location = $Location
        }

        if ($OSIsLinux)
        {
            # These are the scenarios we currently support when creating a Docker container:
            # 1) In Consumption, we only support images created by Functions with a predefine runtime name and version, e.g., Python 3.7
            # 2) For App Service and Premium plans, a customer can specify a customer container image

            # Linux function app
            $functionAppDef.Kind = 'functionapp,linux'
            $functionAppDef.Reserved = $true

            # Bring your own container is only supported on App Service, Premium plans and Container App
            if ($Image)
            {
                $functionAppDef.Kind = 'functionapp,linux,container'

                $appSettings.Add((NewAppSetting -Name 'DOCKER_CUSTOM_IMAGE_NAME' -Value $Image.Trim().ToLower()))
                $appSettings.Add((NewAppSetting -Name 'FUNCTION_APP_EDIT_MODE' -Value 'readOnly'))
                $appSettings.Add((NewAppSetting -Name 'WEBSITES_ENABLE_APP_SERVICE_STORAGE' -Value 'false'))

                $siteConfig.LinuxFxVersion = FormatFxVersion -Image $Image

                # Parse the docker registry url only for the custom image parameter set (otherwise it will be a breaking change for existing customers).
                # For the container app environment, the registry url must me explicitly provided.
                if (-not $dockerRegistryServerUrl -and -not $environmentForContainerApp)
                {
                    $dockerRegistryServerUrl = ParseDockerImage -DockerImageName $Image
                }

                if ($dockerRegistryServerUrl)
                {
                    $appSettings.Add((NewAppSetting -Name 'DOCKER_REGISTRY_SERVER_URL' -Value $dockerRegistryServerUrl))

                    if ($RegistryCredential)
                    {
                        $appSettings.Add((NewAppSetting -Name 'DOCKER_REGISTRY_SERVER_USERNAME' -Value $RegistryCredential.GetNetworkCredential().UserName))
                        $appSettings.Add((NewAppSetting -Name 'DOCKER_REGISTRY_SERVER_PASSWORD' -Value $RegistryCredential.GetNetworkCredential().Password))
                    }
                }
            }
            else
            {
                if (-not $functionAppIsFlexConsumption)
                {
                    $appSettings.Add((NewAppSetting -Name 'WEBSITES_ENABLE_APP_SERVICE_STORAGE' -Value 'true'))
                }
            }
        }
        else
        {
            # Windows function app
            $functionAppDef.Kind = 'functionapp'
        }

        if ($environmentForContainerApp)
        {
            $functionAppDef.Kind = 'functionapp,linux,container,azurecontainerapps'
            $functionAppDef.Reserved = $null
            $functionAppDef.HttpsOnly = $null
            $functionAppDef.ScmSiteAlsoStopped = $null

            ValidateCpuAndMemory -ResourceCpu $ResourceCpu -ResourceMemory $ResourceMemory
            if ($ResourceCpu -and $ResourceMemory)
            {
                $functionAppDef.ResourceConfigCpu = $ResourceCpu
                $functionAppDef.ResourceConfigMemory = $ResourceMemory
            }

            if ($WorkloadProfileName)
            {
                $functionAppDef.WorkloadProfileName = $WorkloadProfileName
            }

            $siteConfig.netFrameworkVersion = $null
            $siteConfig.JavaVersion = $null
            $siteConfig.Use32BitWorkerProcess = $null
            $siteConfig.PowerShellVersion = $null
            $siteConfig.Http20Enabled = $null
            $siteConfig.LocalMySqlEnabled = $null

            if ($ScaleMinReplica)
            {
                $siteConfig.MinimumElasticInstanceCount = $ScaleMinReplica
            }

            if ($ScaleMaxReplica)
            {
                $siteConfig.FunctionAppScaleLimit = $ScaleMaxReplica
            }
            
            $managedEnvironment = GetManagedEnvironment -Environment $Environment -ResourceGroupName $ResourceGroupName
            $functionAppDef.Location = $managedEnvironment.Location
            $functionAppDef.ManagedEnvironmentId = $managedEnvironment.Id
        }

        try
        {
            if ($functionAppIsFlexConsumption)
            {
                # Reset properties not applicable for Flex Consumption
                $siteConfig.NetFrameworkVersion = $null
                $functionAppDef.Reserved = $null
                $functionAppDef.IsXenon = $null
                $appSettings.Clear()

                # Validate Flex Consumption location
                Validate-FlexConsumptionLocation -Location $FlexConsumptionLocation -ZoneRedundancy:$EnableZoneRedundancy
                $FlexConsumptionLocation = Format-FlexConsumptionLocation -Location $FlexConsumptionLocation

                # Validate runtime and runtime version
                if (-not ($FlexConsumptionSupportedRuntimes -contains $Runtime))
                {
                    $errorId = "InvalidRuntimeForFlexConsumption"
                    $message += "The specified Runtime '$Runtime' is not valid for Flex Consumption. "
                    $message += "Supported runtimes are: $($FlexConsumptionSupportedRuntimes -join ', '). Learn more about supported runtimes and versions for Flex Consumption: aka.ms/FunctionsStackUpgrade."
                    $exception = [System.InvalidOperationException]::New($message)
                    ThrowTerminatingError -ErrorId $errorId `
                                          -ErrorMessage $message `
                                          -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                          -Exception $exception
                }

                $runtimeInfo = $null
                $hasDefaultVersion = $false

                if ([string]::IsNullOrEmpty($RuntimeVersion))
                {
                    $runtimeInfo = Get-FlexFunctionAppRuntime -Location $FlexConsumptionLocation -Runtime $Runtime -DefaultOrLatest:$true
                    $hasDefaultVersion = $true

                    $RuntimeVersion = $runtimeInfo.Version
                    Write-Warning "RuntimeVersion not specified. Setting default value to '$RuntimeVersion'. $SetDefaultValueParameterWarningMessage"
                }
                else
                {
                    # Get runtime info for specified version. If not available, Get-FlexFunctionAppRuntime will error out.
                    $runtimeInfo =  Get-FlexFunctionAppRuntime -Location $FlexConsumptionLocation -Runtime $Runtime -Version $RuntimeVersion
                }

                # Validate EndOfLifeDate
                if ($runtimeInfo.EndOfLifeDate -and (-not $hasDefaultVersion))
                {
                    $defaultRuntimeInfo = Get-FlexFunctionAppRuntime -Location $FlexConsumptionLocation -Runtime $Runtime -DefaultOrLatest:$true

                    Validate-EndOfLifeDate -EndOfLifeDate $runtimeInfo.EndOfLifeDate `
                                           -Runtime $Runtime `
                                           -RuntimeVersion $RuntimeVersion `
                                           -DefaultRuntimeVersion $defaultRuntimeInfo.Version
                }

                # Validate and set AlwaysReady configuration
                if ($AlwaysReady -and $AlwaysReady.Count -gt 0)
                {
                    $ALWAYSREADY_NAME = 'name'
                    $ALWAYSREADY_INSTANCECOUNT = 'instanceCount'

                    foreach ($entry in $AlwaysReady)
                    {
                        # Ensure required keys exist
                        if (-not ($entry.ContainsKey($ALWAYSREADY_NAME) -and $entry.ContainsKey($ALWAYSREADY_INSTANCECOUNT)))
                        {
                            $errorMessage = "Each hashtable in AlwaysReady must contain '$ALWAYSREADY_NAME' and '$ALWAYSREADY_INSTANCECOUNT' keys."
                            $exception = [System.InvalidOperationException]::New($errorMessage)
                            ThrowTerminatingError -ErrorId "InvalidAlwaysReadyConfiguration" `
                                                  -ErrorMessage $errorMessage `
                                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                  -Exception $exception
                        }

                        # Validate that Name is a non-empty string
                        if ([string]::IsNullOrWhiteSpace($entry[$ALWAYSREADY_NAME]))
                        {
                            $errorMessage = "Name in AlwaysReady must be a non-empty string."
                            $exception = [System.InvalidOperationException]::New($errorMessage)
                            ThrowTerminatingError -ErrorId "InvalidAlwaysReadyName" `
                                                    -ErrorMessage $errorMessage `
                                                    -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                    -Exception $exception
                        }

                        # Validate InstanceCount is a non-negative integer (single-parse + combined check)
                        [int]$parsedInstanceCount = 0
                        $rawInstanceCount = $entry[$ALWAYSREADY_INSTANCECOUNT]

                        if (-not ([int]::TryParse($rawInstanceCount, [ref]$parsedInstanceCount) -and $parsedInstanceCount -ge 0))
                        {
                            $errorMessage = "InstanceCount in AlwaysReady must be a non-negative integer."
                            $exception    = [System.InvalidOperationException]::new($errorMessage)
                            ThrowTerminatingError -ErrorId "InvalidAlwaysReadyInstanceCount" `
                                                  -ErrorMessage $errorMessage `
                                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                  -Exception $exception
                        }
                    }
                    $functionAppDef.ScaleAndConcurrencyAlwaysReady = $AlwaysReady
                }

                # Set scaling information
                $maximumInstanceCountValue = Validate-MaximumInstanceCount -SkuMaximumInstanceCount $runtimeInfo.Sku.maximumInstanceCount -MaximumInstanceCount $MaximumInstanceCount 
                $functionAppDef.ScaleAndConcurrencyMaximumInstanceCount = $maximumInstanceCountValue

                $instanceMemoryMBValue = Validate-InstanceMemoryMB -SkuInstanceMemoryMB $runtimeInfo.Sku.instanceMemoryMB -InstanceMemoryMB $InstanceMemoryMB
                $functionAppDef.ScaleAndConcurrencyInstanceMemoryMB = $instanceMemoryMBValue

                if ($HttpPerInstanceConcurrency -gt 0)
                {
                    $functionAppDef.HttpPerInstanceConcurrency = $HttpPerInstanceConcurrency
                }

                # Create Flex Consumption App Service Plan
                $planName = New-PlanName -ResourceGroupName $ResourceGroupName
                if ($WhatIfPreference.IsPresent)
                {
                    Write-Verbose "WhatIf: Creating Flex Consumption App Service Plan '$planName' in resource group '$ResourceGroupName' at location '$FlexConsumptionLocation'..."
                    $planInfo = New-Object PSObject -Property @{
                        Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/$ResourceGroupName/providers/Microsoft.Web/serverfarms/$planName"
                    }
                }
                else
                {
                    $planInfo = New-FlexConsumptionAppPlan -Name $PlanName `
                                                           -ResourceGroupName $ResourceGroupName `
                                                           -Location $FlexConsumptionLocation `
                                                           -EnableZoneRedundancy:$EnableZoneRedundancy `
                                                           @params
                    $flexConsumptionPlanCreated = $true
                }

                $functionAppDef.ServerFarmId = $planInfo.Id
                $functionAppDef.Location = $FlexConsumptionLocation

                # Validate Deployment Storage
                if (-not $DeploymentStorageName) {
                    $DeploymentStorageName = $StorageAccountName
                }

                if (-not $DeploymentStorageContainerName)
                {
                    $useTestData = ($env:FunctionsTestMode -and $env:FunctionsUseFlexStackTestData)
                    # Generate a unique container name
                    $tempName = $Name -replace '[^a-zA-Z0-9]', ''
                    $normalizedName = $tempName.Substring(0, [Math]::Min(32, $tempName.Length))
                    $normalizedName = $normalizedName.ToLower()

                    if ($useTestData)
                    {
                        $randomSuffix = 0
                    }
                    else
                    {
                        $randomSuffix = Get-Random -Minimum 0 -Maximum 9999999
                    }

                    $DeploymentStorageContainerName = "app-package-$normalizedName-{0:D7}" -f $randomSuffix

                    if ($useTestData)
                    {
                        Write-Verbose "Setting DeploymentStorageContainerName to: '$DeploymentStorageContainerName'." -Verbose
                    }
                }

                $StorageAccountInfo = Get-StorageAccountInfo -Name $DeploymentStorageName @params

                # If container does not exist, create it
                $container = Az.Functions.internal\Get-AzBlobContainer -ContainerName $DeploymentStorageContainerName `
                                                                       -AccountName $DeploymentStorageName `
                                                                       -ResourceGroupName $ResourceGroupName `
                                                                       -ErrorAction SilentlyContinue `
                                                                       @params
                if (-not $container)
                {
                    if ($WhatIfPreference.IsPresent)
                    {
                        Write-Verbose "WhatIf: Creating container '$DeploymentStorageContainerName' in storage account '$DeploymentStorageName'..."
                        $container = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.BlobContainer
                    }
                    else
                    {
                        # Create blob container
                        $maxNumberOfTries = 3
                        $tries = 1
                        $myError = $null
                        while ($true)
                        {
                            try
                            {
                                $container = Az.Functions.internal\New-AzBlobContainer -ContainerName $DeploymentStorageContainerName `
                                                                                       -AccountName $DeploymentStorageName `
                                                                                       -ResourceGroupName $ResourceGroupName `
                                                                                       -ContainerPropertyPublicAccess None `
                                                                                       -ErrorAction Stop `
                                                                                       @params
                                if ($container)
                                {
                                    $flexConsumptionStorageContainerCreated = $true
                                    break
                                }
                            }
                            catch
                            {
                                # Ignore the failure and continue
                                $myError = $_
                            }

                            if ($tries -ge $maxNumberOfTries)
                            {
                                break
                            }

                            # Wait for 2^(tries-1) seconds between retries. In this case, it would be 1, 2, and 4 seconds, respectively.
                            $waitInSeconds = [Math]::Pow(2, $tries - 1)
                            Start-Sleep -Seconds $waitInSeconds

                            $tries++
                        }

                        if (-not $container)
                        {
                            $errorMessage = "Failed to create blob container '$DeploymentStorageContainerName' in storage account '$DeploymentStorageName'."
                            if ($myError.Exception.Message)
                            {
                                $errorMessage += " Error details: $($myError.Exception.Message)"
                            }

                            $exception = [System.InvalidOperationException]::New($errorMessage)
                            ThrowTerminatingError -ErrorId "FailedToCreateBlobContainer" `
                                                  -ErrorMessage $errorMessage `
                                                  -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                  -Exception $exception
                        }
                    }
                }

                # Set storage type and value
                $blobContainerUrl = "$($StorageAccountInfo.PrimaryEndpointBlob)$DeploymentStorageContainerName"
                $functionAppDef.StorageType = "blobContainer"
                $functionAppDef.StorageValue = $blobContainerUrl

                # Validate DeploymentStorageAuthType
                if (-not $DeploymentStorageAuthType)
                {
                    $DeploymentStorageAuthType = 'StorageAccountConnectionString'
                }

                $functionAppDef.AuthenticationType = $DeploymentStorageAuthType

                # Set deployment storage authentication
                if ($DeploymentStorageAuthType -eq "SystemAssignedIdentity")
                {
                    if ($DeploymentStorageAuthValue)
                    {
                        $errorMessage = "-DeploymentStorageAuthValue is only valid when -DeploymentStorageAuthType is UserAssignedIdentity or StorageAccountConnectionString."
                        $exception = [System.InvalidOperationException]::New($errorMessage)
                        ThrowTerminatingError -ErrorId $errorId `
                                            -ErrorMessage $errorMessage `
                                            -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                            -Exception $exception
                    }
                }
                elseif ($DeploymentStorageAuthType -eq "StorageAccountConnectionString")
                {
                    if (-not $DeploymentStorageAuthValue)
                    {
                        # Get connection string for deployment storage
                        $DeploymentStorageAuthValue = GetConnectionString -StorageAccountName $DeploymentStorageName @params
                    }

                    $DEPLOYMENT_STORAGE_CONNECTION_STRING = 'DEPLOYMENT_STORAGE_CONNECTION_STRING'

                    $functionAppDef.AuthenticationStorageAccountConnectionStringName = $DEPLOYMENT_STORAGE_CONNECTION_STRING
                    $appSettings.Add((NewAppSetting -Name $DEPLOYMENT_STORAGE_CONNECTION_STRING -Value $DeploymentStorageAuthValue))
                }
                elseif ($DeploymentStorageAuthType -eq "UserAssignedIdentity")
                {
                    if (-not $DeploymentStorageAuthValue)
                    {
                        $errorMessage = "IdentityID is required for UserAssigned identity"
                        $exception = [System.InvalidOperationException]::New($errorMessage)
                        ThrowTerminatingError -ErrorId "IdentityIDIsRequiredForUserAssignedIdentity" `
                                                -ErrorMessage $errorMessage `
                                                -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                -Exception $exception
                    }

                    $identity = Resolve-UserAssignedIdentity -IdentityResourceId $DeploymentStorageAuthValue @params
                    $functionAppDef.AuthenticationUserAssignedIdentityResourceId = $identity.Id
                }

                # Set runtime information
                $functionAppDef.RuntimeName = $runtimeInfo.Sku.functionAppConfigProperties.runtime.name
                $functionAppDef.RuntimeVersion = $runtimeInfo.Sku.functionAppConfigProperties.runtime.version
            }

            # Validate storage account and get connection string
            $connectionString = GetConnectionString -StorageAccountName $StorageAccountName @params
            $appSettings.Add((NewAppSetting -Name 'AzureWebJobsStorage' -Value $connectionString))

            if (-not ($functionAppIsCustomDockerImage -or $environmentForContainerApp -or $functionAppIsFlexConsumption))
            {
                $appSettings.Add((NewAppSetting -Name 'FUNCTIONS_EXTENSION_VERSION' -Value "~$FunctionsVersion"))
            }

            # If plan is not consumption, elastic premium or a container app environment, set always on
            $planIsElasticPremium = $servicePlan.SkuTier -eq 'ElasticPremium'
            if ((-not $consumptionPlan) -and (-not $planIsElasticPremium) -and (-not $Environment) -and (-not $functionAppIsFlexConsumption))
            {
                $siteConfig.AlwaysOn = $true
            }

            # If plan is Elastic Premium or Consumption (Windows or Linux), we need these app settings
            if ($planIsElasticPremium -or $consumptionPlan)
            {
                $appSettings.Add((NewAppSetting -Name 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING' -Value $connectionString))

                $shareName = GetShareName -FunctionAppName $Name
                $appSettings.Add((NewAppSetting -Name 'WEBSITE_CONTENTSHARE' -Value $shareName))
            }

            # Set up Dashboard if no ApplicationInsights
            if ($DisableApplicationInsights -and (-not $functionAppIsFlexConsumption))
            {
                $appSettings.Add((NewAppSetting -Name 'AzureWebJobsDashboard' -Value $connectionString))
            }

            # Set up Application Insights
            if (-not $DisableApplicationInsights)
            {
                if ($ApplicationInsightsKey)
                {
                    $appSettings.Add((NewAppSetting -Name 'APPINSIGHTS_INSTRUMENTATIONKEY' -Value $ApplicationInsightsKey))
                }
                elseif ($ApplicationInsightsName)
                {
                    $appInsightsProject = GetApplicationInsightsProject -Name $ApplicationInsightsName @params
                    if (-not $appInsightsProject)
                    {
                        $errorMessage = "Failed to get application insights project name '$ApplicationInsightsName'. Please make sure the project exist."
                        $exception = [System.InvalidOperationException]::New($errorMessage)
                        ThrowTerminatingError -ErrorId "ApplicationInsightsProjectNotFound" `
                                            -ErrorMessage $errorMessage `
                                            -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                            -Exception $exception
                    }

                    $appSettings.Add((NewAppSetting -Name 'APPLICATIONINSIGHTS_CONNECTION_STRING' -Value $appInsightsProject.ConnectionString))
                }
                else
                {
                    if ($WhatIfPreference.IsPresent)
                    {
                        Write-Verbose "WhatIf: Creating Application Insights '$Name' in resource group '$ResourceGroupName' at location '$($functionAppDef.Location)'..."
                        # Create a mock object for WhatIf to avoid null reference issues
                        $newAppInsightsProject = New-Object PSObject -Property @{
                            ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://placeholder.applicationinsights.azure.com/"
                            Name = $Name
                        }
                        $appSettings.Add((NewAppSetting -Name 'APPLICATIONINSIGHTS_CONNECTION_STRING' -Value $newAppInsightsProject.ConnectionString))
                    }
                    else
                    {
                        # Create the Application Insights project
                        $newAppInsightsProject = CreateApplicationInsightsProject -ResourceGroupName $resourceGroupName `
                                                                                  -ResourceName $Name `
                                                                                  -Location $functionAppDef.Location `
                                                                                  @params
                        if ($newAppInsightsProject)
                        {
                            $appSettings.Add((NewAppSetting -Name 'APPLICATIONINSIGHTS_CONNECTION_STRING' -Value $newAppInsightsProject.ConnectionString))
                            $appInsightCreated = $true
                        }
                        else
                        {
                            $warningMessage = "Unable to create the Application Insights for the function app. Creation of Application Insights will help you monitor and diagnose your function apps in the Azure Portal. `r`n"
                            $warningMessage += "Use the 'New-AzApplicationInsights' cmdlet or the Azure Portal to create a new Application Insights project. After that, use the 'Update-AzFunctionApp' cmdlet to update Application Insights for your function app."
                            Write-Warning $warningMessage
                        }
                    }
                }
            }

            if ($Tag.Count -gt 0)
            {
                $resourceTag = NewResourceTag -Tag $Tag
                $functionAppDef.Tag = $resourceTag
            }

            # Add user app settings
            if ($AppSetting.Count -gt 0)
            {
                foreach ($keyName in $AppSetting.Keys)
                {
                    $appSettings.Add((NewAppSetting -Name $keyName -Value $AppSetting[$keyName]))
                }
            }

            # Set app settings and site configuration
            $siteConfig.AppSetting = $appSettings
            $functionAppDef.Config = $siteConfig
            $PSBoundParameters.Add("SiteEnvelope", $functionAppDef)  | Out-Null

            if ($PsCmdlet.ShouldProcess($Name, "Creating function app"))
            {
                # Save the ErrorActionPreference
                $currentErrorActionPreference = $ErrorActionPreference
                $ErrorActionPreference = 'Stop'

                $exceptionThrown = $false

                try
                {
                    Az.Functions.internal\New-AzFunctionApp @PSBoundParameters
                    $functionAppCreatedSuccessfully = $true
                }
                catch
                {
                    $exceptionThrown = $true

                    $errorMessage = GetErrorMessage -Response $_

                    if ($errorMessage)
                    {
                        $exception = [System.InvalidOperationException]::New($errorMessage)
                        ThrowTerminatingError -ErrorId "FailedToCreateFunctionApp" `
                                                -ErrorMessage $errorMessage `
                                                -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                -Exception $exception
                    }

                    throw $_
                }
                finally
                {
                    # Reset the ErrorActionPreference
                    $ErrorActionPreference = $currentErrorActionPreference
                }

                if (-not $exceptionThrown)
                {
                    if ($consumptionPlan -and $OSIsLinux)
                    {
                        $message = "Your Linux function app '$Name', that uses a consumption plan has been successfully created but is not active until content is published using Azure Portal or the Functions Core Tools."
                        Write-Verbose $message -Verbose
                    }
                }
            }
        }
        finally
        {
            # Cleanup created resources in case of failure
            if (-not $functionAppCreatedSuccessfully)
            {
                if ($flexConsumptionPlanCreated)
                {
                    Az.Functions\Remove-AzFunctionAppPlan -ResourceGroupName $ResourceGroupName -Name $planName @params -Force
                }
                if ($flexConsumptionStorageContainerCreated)
                {
                    Az.Functions.internal\Remove-AzBlobContainer -ResourceGroupName $ResourceGroupName -AccountName $DeploymentStorageName -ContainerName $DeploymentStorageContainerName @params
                }

                if ($appInsightCreated -and ($null -ne $newAppInsightsProject))
                {
                    $ApplicationInsightsName = $newAppInsightsProject.Name
                    Az.Functions.internal\Remove-AzAppInsights -ResourceGroupName $ResourceGroupName -ResourceName $ApplicationInsightsName @params
                }
            }
        }
    }
}
