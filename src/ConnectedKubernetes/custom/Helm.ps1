# function Get-ReleaseNamespace {
#     Param(
#         [Parameter()]
#         [string]
#         $KubeConfig,
#         [Parameter()]
#         [string]
#         $KubeContext
#     )
#     try {
#         if ($KubeContext -eq $null) {
#             $Status = helm status azure-arc -o json --kubeconfig $KubeConfig | ConvertFrom-Json
#         } else {
#             $Status = helm status azure-arc -o json --kubeconfig $KubeConfig --kubecontext $KubeContext | ConvertFrom-Json
#         }
#         return $Status.namespace
#     } catch {
#         Write-Error "Fail to find the namespace for azure-arc."
#         throw
#     }
# }



# def resource_group_exists(ctx, resource_group_name, subscription_id=None):
#     groups = cf_resource_groups(ctx, subscription_id=subscription_id)
#     try:
#         groups.get(resource_group_name)
#         return True
#     except:  # pylint: disable=bare-except
#         return False


# def connected_cluster_exists(client, resource_group_name, cluster_name):
#     try:
#         client.get(resource_group_name, cluster_name)
#     except Exception as ex:
#         if (('was not found' in str(ex)) or ('could not be found' in str(ex))):
#             return False
#         raise CLIError("Unable to determine if the connected cluster resource exists. " + str(ex))
#     return True


# function Get-HelmRegistery {
#     Param(
#         [Parameter()]
#         [string]
#         $KubeConfig,
#         [Parameter()]
#         [string]
#         $Location
#     )

#     $ChartLocationUrl = "https://${Location}.dp.kubernetesconfiguration.azure.com/azure-arc-k8sagents/GetLatestHelmPackagePath?api-version=2019-11-01-preview"

# }


# def get_helm_registery(profile, location):
#     cred, _, _ = profile.get_login_credentials(
#         resource='https://management.core.windows.net/')
#     token = cred._token_retriever()[2].get('accessToken')  # pylint: disable=protected-access

#     get_chart_location_url = "".format(location, 'azure-arc-k8sagents')
#     query_parameters = {}
#     query_parameters['releaseTrain'] = 'stable'
#     header_parameters = {}
#     header_parameters['Authorization'] = "Bearer {}".format(str(token))
#     try:
#         response = requests.post(get_chart_location_url, params=query_parameters, headers=header_parameters)
#     except Exception as e:
#         raise CLIError("Error while fetching helm chart registery path: " + str(e))
#     if response.status_code == 200:
#         return response.json().get('repositoryPath')
#     raise CLIError("Error while fetching helm chart registery path: {}".format(str(response.json())))


# def pull_helm_chart(registery_path, kube_config, kube_context):
#     cmd_helm_chart_pull = ["helm", "chart", "pull", registery_path, "--kubeconfig", kube_config]
#     if kube_context:
#         cmd_helm_chart_pull.extend(["--kube-context", kube_context])
#     response_helm_chart_pull = subprocess.Popen(cmd_helm_chart_pull, stdout=PIPE, stderr=PIPE)
#     _, error_helm_chart_pull = response_helm_chart_pull.communicate()
#     if response_helm_chart_pull.returncode != 0:
#         raise CLIError("Unable to pull helm chart from the registery '{}': ".format(registery_path) + error_helm_chart_pull.decode("ascii"))


# def export_helm_chart(registery_path, chart_export_path, kube_config, kube_context):
#     chart_export_path = os.path.join(os.path.expanduser('~'), '.azure', 'AzureArcCharts')
#     cmd_helm_chart_export = ["helm", "chart", "export", registery_path, "--destination", chart_export_path, "--kubeconfig", kube_config]
#     if kube_context:
#         cmd_helm_chart_export.extend(["--kube-context", kube_context])
#     response_helm_chart_export = subprocess.Popen(cmd_helm_chart_export, stdout=PIPE, stderr=PIPE)
#     _, error_helm_chart_export = response_helm_chart_export.communicate()
#     if response_helm_chart_export.returncode != 0:
#         raise CLIError("Unable to export helm chart from the registery '{}': ".format(registery_path) + error_helm_chart_export.decode("ascii"))