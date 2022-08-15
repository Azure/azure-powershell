
function GetDatasourceSetInfo
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.IDatasource]
		$DatasourceInfo
	)

	process 
	{
		$DataSourceSetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.DatasourceSet]::new()
		$DataSourceSetInfo.DatasourceType = $DatasourceInfo.Type
        $DataSourceSetInfo.ObjectType = "DatasourceSet"
        $splitResourceId = $DatasourceInfo.ResourceId.Split("/")
        $DataSourceSetInfo.ResourceId =  [System.String]::Join('/', $splitResourceId[0..($splitResourceId.Count -3)]) 
        $DataSourceSetInfo.ResourceLocation = $DatasourceInfo.ResourceLocation
        $DataSourceSetInfo.ResourceName = $splitResourceId[$splitResourceId.Count -3]
        $splitResourceType = $DatasourceInfo.ResourceType.Split("/")
        $DataSourceSetInfo.ResourceType =  [System.String]::Join('/', $splitResourceType[0..($splitResourceType.Count -2)])     # Use manifest for datasource set type
        $DataSourceSetInfo.ResourceUri = ""

		return $DataSourceSetInfo
	}
}

function GetDatasourceInfo
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$ResourceId,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$ResourceLocation,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$DatasourceType
	)

	process
	{
		$manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
		$DataSourceInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.Datasource]::new()
		$DataSourceInfo.ObjectType = "Datasource"
        $DataSourceInfo.ResourceId = $ResourceId
        $DataSourceInfo.ResourceLocation = $ResourceLocation
        $DataSourceInfo.ResourceName = $ResourceId.Split("/")[-1]
        $DataSourceInfo.ResourceType = $manifest.resourceType
        $DataSourceInfo.ResourceUri = ""
        if($manifest.isProxyResource -eq $false)
        {
            $DataSourceInfo.ResourceUri = $ResourceId
        }
        $DataSourceInfo.Type = $manifest.datasourceType

		return $DataSourceInfo
	}
}

function GetClientDatasourceType
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$ServiceDatasourceType
	)

	process
	{
		$datasourceTypes = GetDatasourceTypes
		foreach($datasourceInfo in $datasourceTypes.supportedDatasourceTypes)
		{
			if($datasourceInfo.serviceDatasourceType -eq $ServiceDatasourceType)
			{
				return $datasourceInfo.clientDatasourceType
			}
		}
		return ""
	}
}