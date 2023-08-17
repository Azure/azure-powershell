
function GetDatasourceSetInfo
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IDatasource]
		$DatasourceInfo,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$DatasourceType
	)

	process 
	{
		$DataSourceSetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.DatasourceSet]::new()
		$DataSourceSetInfo.DatasourceType = $DatasourceInfo.Type
		$DataSourceSetInfo.ObjectType = "DatasourceSet"        
		$DataSourceSetInfo.ResourceLocation = $DatasourceInfo.ResourceLocation
		
		$manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
		if($manifest.enableDataSourceSetInfo -eq $true){		
			$DataSourceSetInfo.ResourceId =  $DatasourceInfo.ResourceId
			$DataSourceSetInfo.ResourceName = $DatasourceInfo.ResourceName			
			$DataSourceSetInfo.ResourceType =  $DataSourceInfo.ResourceType
			$DataSourceSetInfo.ResourceUri = $DatasourceInfo.ResourceUri
		}
		else{
			$splitResourceId = $DatasourceInfo.ResourceId.Split("/")
			$DataSourceSetInfo.ResourceId =  [System.String]::Join('/', $splitResourceId[0..($splitResourceId.Count -3)]) 			
			$DataSourceSetInfo.ResourceName = $splitResourceId[$splitResourceId.Count -3]
			$splitResourceType = $DatasourceInfo.ResourceType.Split("/")
			$DataSourceSetInfo.ResourceType =  [System.String]::Join('/', $splitResourceType[0..($splitResourceType.Count -2)])
			$DataSourceSetInfo.ResourceUri = ""
		}

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
		$DataSourceInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.Datasource]::new()
		$DataSourceInfo.ObjectType = "Datasource"
        $DataSourceInfo.ResourceId = $ResourceId
        $DataSourceInfo.ResourceLocation = $ResourceLocation
        $DataSourceInfo.ResourceName = $ResourceId.Split("/")[-1]
        $DataSourceInfo.ResourceType = $manifest.resourceType
        $DataSourceInfo.ResourceUri = ""

        if($manifest.isProxyResource -eq $false -or $manifest.enableDataSourceSetInfo -eq $true)
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