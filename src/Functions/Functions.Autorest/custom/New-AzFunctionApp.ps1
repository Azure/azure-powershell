function New-AzFunctionApp {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.ISite])]
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
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IResourceTags]))]
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
        [String]
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
        [ValidateSet("StorageAccountConnectionString","SystemAssignedIdentity","UserAssignedIdentity")]
        [System.String]
        ${DeploymentStorageAuthType},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Deployment storage authentication value used for the chosen auth type (eg: connection string, or user-assigned identity resource id).')]
        [System.String]
        ${DeploymentStorageAuthValue},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage=
'Array of hashtables describing the AlwaysReady configuration. Each hashtable must include:
- name: The function name or route name.
- instanceCount: The number of pre-warmed instances for that function.

Example:
@(@{ name = "http"; instanceCount = 2 }).')]
        [Hashtable[]]
        ${AlwaysReady},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Maximum instance count for Flex Consumption.')]
        [ValidateRange(40, 1000)]
        [int]
        ${MaximumInstanceCount} = 100,

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Per-instance memory in MB for Flex Consumption instances.')]
        [ValidateSet(512, 2048, 4096)]
        [int]
        ${InstanceMemoryMB} = 2048,

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='The maximum number of concurrent HTTP trigger invocations per instance.')]
        [ValidateRange(1, 1000)]
        [int]
        ${HttpPerInstanceConcurrency},

        [Parameter(ParameterSetName="FlexConsumption", HelpMessage='Enable zone redundancy for high availability. Applies to Flex Consumption SKU only.')]
        [System.Management.Automation.SwitchParameter]
        ${EnableZoneRedundancy},

        [Parameter(ParameterSetName="ByAppServicePlan", HelpMessage='When the HttpsOnly property is enabled, all HTTP requests to the app are automatically redirected to HTTPS for secure communication. Using the DisableHttpsOnly switch removes this restriction, allowing HTTP traffic without redirection to HTTPS.')]
        [Parameter(ParameterSetName="Consumption")]
        [Parameter(ParameterSetName="CustomDockerImage")]
        [Parameter(ParameterSetName="EnvironmentForContainerApp")]
        [Parameter(ParameterSetName="FlexConsumption")]
        [System.Management.Automation.SwitchParameter]
        ${DisableHttpsOnly},

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

        $appSettings = New-Object -TypeName 'System.Collections.Generic.List[Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.INameValuePair]'
        $siteConfig = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.SiteConfig
        $functionAppDef = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Site

        $OSIsLinux = ($OSType -eq "Linux") -or $functionAppIsFlexConsumption

        $params = GetParameterKeyValues -PSBoundParametersDictionary $PSBoundParameters `
                                        -ParameterList @("SubscriptionId", "HttpPipelineAppend", "HttpPipelinePrepend")

        $functionAppDef.HttpsOnly = if ($DisableHttpsOnly.IsPresent) { $false } else { $true }

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

        # TODO: Need to move this to the top before any logic for an SKU specific settings are added.
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

                # # Validate Flex Consumption location
                # $formattedLocation = Format-FlexConsumptionLocation -Location $FlexConsumptionLocation
                # $flexConsumptionRegions = Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption `
                #                                                             -ZoneRedundant:$EnableZoneRedundancy `
                #                                                             @params

                # $found = $false
                # foreach ($region in $flexConsumptionRegions)
                # {
                #     $regionName = Format-FlexConsumptionLocation -Location $region.Name

                #     if ($region.Name -eq $FlexConsumptionLocation)
                #     {
                #         $found = $true
                #         break
                #     }
                #     elseif ($regionName -eq $formattedLocation)
                #     {
                #         $found = $true
                #         break
                #     }
                # }

                # Validate Flex Consumption location
                Validate-FlexConsumptionLocation -Location $FlexConsumptionLocation ZoneRedundant:$EnableZoneRedundancy @params
                $FlexConsumptionLocation = Format-FlexConsumptionLocation -Location $FlexConsumptionLocation

                # Validate runtime and runtime version
                $runtimeInfo = $null
                if (-not [string]::IsNullOrEmpty($RuntimeVersion))
                {
                    # If not version is not found, the helper function will error out.
                    $runtimeInfo =  Get-FlexFunctionAppRuntime -Location $Location -Runtime $Runtime -Version $RuntimeVersion
                }
                else
                {
                    $runtimeInfo = Get-FlexFunctionAppRuntime -Location $Location -Runtime $Runtime -Version $RuntimeVersion -DefaultOrLatest:$true
                    $RuntimeVersion = $runtimeInfo.Version
                    Write-Warning "RuntimeVersion not specified. Setting default value to '$RuntimeVersion'. $SetDefaultValueParameterWarningMessage"
                }

                # TODO: Validate end of life for runtime version
                # if ($runtimeInfo.EndOfLifeDate)
                # {
                #     $today = Get-Today
                #     $sixMonthsFromToday = (Get-Today).AddMonths(6)
                #     $endOfLifeDate = $runtimeInfo.EndOfLifeDate
                #     $formattedEOLDate = ([DateTime]$endOfLifeDate).ToString("MMMM dd yyyy")

                #     $defaultRuntimeVersion = GetDefaultOrLatestRuntimeVersion -SupportedRuntimes $supportedRuntimes `
                #                                                             -Runtime $Runtime `
                #                                                             -FunctionsExtensionVersion $functionsExtensionVersion

                #     if ($endOfLifeDate -le $today)
                #     {
                #         $errorMsg = "Use $Runtime $defaultRuntimeVersion as $Runtime $RuntimeVersion has reached end-of-life "
                #         $errorMsg += "on $formattedEOLDate and is no longer supported. Learn more: aka.ms/FunctionsStackUpgrade."

                #         $exception = [System.InvalidOperationException]::New($errorMsg)
                #         ThrowTerminatingError -ErrorId "RuntimeVersionEndOfLife" `
                #                             -ErrorMessage $errorMsg `
                #                             -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                #                             -Exception $exception
                #     }
                #     elseif ($endOfLifeDate -lt $sixMonthsFromToday)
                #     {
                #         $warningMsg = "Use $Runtime $defaultRuntimeVersion as $Runtime $RuntimeVersion will reach end-of-life on $formattedEOLDate"
                #         $warningMsg += " and will no longer be supported. Learn more: aka.ms/FunctionsStackUpgrade."
                #         Write-Warning $warningMsg
                #     }
                # }

                # Validate and set AlwaysReady configuration
                if ($AlwaysReady -and $AlwaysReady.Count -gt 0)
                {
                    $NAME = 'name'
                    $INSTANCECOUNT = 'instanceCount'

                    foreach ($entry in $AlwaysReady)
                    {
                        if (-not ($entry.ContainsKey($NAME) -and $entry.ContainsKey($INSTANCECOUNT)))
                        {
                            $errorMessage = "Each hashtable in AlwaysReady must contain '$NAME' and '$INSTANCECOUNT' keys."
                            $exception = [System.InvalidOperationException]::New($errorMessage)
                            ThrowTerminatingError -ErrorId "InvalidAlwaysReadyConfiguration" `
                                                    -ErrorMessage $errorMessage `
                                                    -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                    -Exception $exception
                        }

                        # Validate that Name is a non-empty string
                        if ([string]::IsNullOrWhiteSpace($entry[$NAME]))
                        {
                            $errorMessage = "Name in AlwaysReady must be a non-empty string."
                            $exception = [System.InvalidOperationException]::New($errorMessage)
                            ThrowTerminatingError -ErrorId "InvalidAlwaysReadyName" `
                                                    -ErrorMessage $errorMessage `
                                                    -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                    -Exception $exception
                        }

                        # Validate that InstanceCount is a non-negative integer
                        if (-not [int]::TryParse($entry[$INSTANCECOUNT], [ref]$null))
                        {
                            $errorMessage = "InstanceCount in AlwaysReady must be a valid integer."
                            $exception = [System.InvalidOperationException]::New($errorMessage)
                            ThrowTerminatingError -ErrorId "InvalidAlwaysReadyInstanceCount" `
                                                    -ErrorMessage $errorMessage `
                                                    -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                    -Exception $exception
                        }

                        if ([int]$entry[$INSTANCECOUNT] -lt 0)
                        {
                            $errorMessage = "InstanceCount in AlwaysReady must be a non-negative integer."
                            $exception = [System.InvalidOperationException]::New($errorMessage)
                            ThrowTerminatingError -ErrorId "InvalidAlwaysReadyInstanceCount" `
                                                    -ErrorMessage $errorMessage `
                                                    -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                                    -Exception $exception
                        }
                    }

                    $functionAppDef.ScaleAndConcurrencyAlwaysReady = $AlwaysReady
                }

                # Set scaling information
                if ($MaximumInstanceCount -gt 0)
                {
                    $maximumInstanceCountValue = ValidateMaximumInstanceCount -SkuMaximumInstanceCount $runtimeInfo.Sku.maximumInstanceCount -MaximumInstanceCount $MaximumInstanceCount 
                    $functionAppDef.ScaleAndConcurrencyMaximumInstanceCount = $maximumInstanceCountValue
                }

                if ($InstanceMemoryMB -gt 0)
                {
                    $functionAppDef.ScaleAndConcurrencyInstanceMemoryMB = $InstanceMemoryMB
                }

                if ($HttpPerInstanceConcurrency -gt 0)
                {
                    $functionAppDef.HttpPerInstanceConcurrency = $HttpPerInstanceConcurrency
                }

                try {

                    # Create Flex Consumption App Service Plan
                    $planName = New-PlanName -ResourceGroupName $ResourceGroupName
                    $planInfo = New-FlexConsumptionAppPlan -Name $PlanName `
                                                        -ResourceGroupName $ResourceGroupName `
                                                        -Location $FlexConsumptionLocation `
                                                        -EnableZoneRedundancy:$EnableZoneRedundancy `
                                                        @params

                    $flexConsumptionPlanCreated = $true

                    $functionAppDef.ServerFarmId = $planInfo.Id
                    $functionAppDef.Location = $FlexConsumptionLocation

                    # Validate Deployment Storage
                    if (-not $DeploymentStorageName) {
                        $DeploymentStorageName = $StorageAccountName
                    }

                    if (-not $DeploymentStorageContainerName)
                    {
                        # Generate a unique container name
                        $normalizedName = ($Name -replace '[^a-zA-Z0-9]', '').Substring(0, [Math]::Min(32, $Name.Length))
                        $randomSuffix = Get-Random -Minimum 0 -Maximum 9999999
                        $DeploymentStorageContainerName = "app-package-$normalizedName-{0:D7}" -f $randomSuffix
                    }

                    # Check if container exists; create if missing
                    $StorageAccountInfo = Get-StorageAccountInfo -Name $DeploymentStorageName @params

                    $container = Get-AzBlobContainer -ContainerName $DeploymentStorageContainerName `
                                                     -AccountName $DeploymentStorageName `
                                                     -ResourceGroupName $ResourceGroupName `
                                                     -ErrorAction SilentlyContinue @params
                    if (-not $container)
                    {
                        Write-Verbose "Container '$DeploymentStorageContainerName' does not exist. Creating..."
                        $container = New-AzBlobContainer -ContainerName $DeploymentStorageContainerName `
                                                         -AccountName $DeploymentStorageName `
                                                         -ResourceGroupName $ResourceGroupName `
                                                         -ContainerPropertyPublicAccess None `
                                                        @params
                        $flexConsumptionStorageContainerCreated = $true
                    }

                    # Blob URL
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
                            Write-Verbose "DeploymentStorageAuthValue was not provided. Generating a connection string for deployment storage..."
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

                        # $identityUserAssignedIdentity = NewIdentityUserAssignedIdentity -IdentityID $IdentityID
                        # $functionAppDef.IdentityUserAssignedIdentity = $identityUserAssignedIdentity
                        $identity = Resolve-UserAssignedIdentity -IdentityResourceId $DeploymentStorageAuthValue @params
                        $functionAppDef.AuthenticationUserAssignedIdentityResourceId = $identity.Id
                    }

                    # Set runtime information
                    $functionAppDef.RuntimeName = $runtimeInfo.Sku.functionAppConfigProperties.runtime.name
                    $functionAppDef.RuntimeVersion = $runtimeInfo.Sku.functionAppConfigProperties.runtime.version
                }
                catch
                {
                    # TODO: We need a similar cleanup logic for when we fail to create the function app.
                    if ($flexConsumptionPlanCreated)
                    {
                        Remove-AzFunctionAppPlan -ResourceGroupName $ResourceGroupName -Name $planName @params
                    }
                    if ($flexConsumptionStorageContainerCreated)
                    {
                        Remove-AzBlobContainer -ResourceGroupName $ResourceGroupName -StorageAccountName $DeploymentStorageName -ContainerName $DeploymentStorageContainerName @params
                    }

                    $errorMessage = "Failed to create Flex Consumption Function App. Exception: $_"
                    $exception = [System.InvalidOperationException]::New($errorMessage)
                    ThrowTerminatingError -ErrorId "FailedToCreateFlexConsumptionFunctionApp" `
                                        -ErrorMessage $errorMessage `
                                        -ErrorCategory ([System.Management.Automation.ErrorCategory]::InvalidOperation) `
                                        -Exception $exception
                }
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

                    #$appSettings.Add((NewAppSetting -Name 'APPINSIGHTS_INSTRUMENTATIONKEY' -Value $appInsightsProject.InstrumentationKey))
                    $appSettings.Add((NewAppSetting -Name 'APPLICATIONINSIGHTS_CONNECTION_STRING' -Value $appInsightsProject.ConnectionString))
                }
                else
                {
                    Write-Verbose "Creating new Application Insights project for function app '$Name' in resource group '$ResourceGroupName'." -Verbose
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
                    Remove-AzFunctionAppPlan -ResourceGroupName $ResourceGroupName -Name $planName @params -Force
                }
                if ($flexConsumptionStorageContainerCreated)
                {
                    Remove-AzBlobContainer -ResourceGroupName $ResourceGroupName -StorageAccountName $DeploymentStorageName -ContainerName $DeploymentStorageContainerName @params
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
