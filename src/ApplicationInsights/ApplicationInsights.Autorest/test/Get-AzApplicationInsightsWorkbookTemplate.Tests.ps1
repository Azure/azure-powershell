if(($null -eq $TestName) -or ($TestName -contains 'Get-AzApplicationInsightsWorkbookTemplate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationInsightsWorkbookTemplate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzApplicationInsightsWorkbookTemplate' {
	It 'Get' {
		{
			$gallery = New-AzApplicationInsightsWorkbookTemplateGalleryObject -Category "Failures" -Name "Simple Template" -Type 'tsg' -ResourceType "microsoft.insights/components" -Order 100
			$data = @{
			  "version"= "Notebook/1.0";
			  "items"= @(
			    @{
			      "type"= 1;
			      "content"= @{
			        "json"= "## New workbook\n---\n\nWelcome to your new workbook.  This area will display text formatted as markdown.\n\n\nWe've included a basic analytics query to get you started. Use the `Edit` button below each section to configure it or add more sections."
			      };
			      "name"= "text - 2"
			    },
			    @{
			      "type"= 3;
			      "content"= @{
			        "version"= "KqlItem/1.0";
			        "query"= "union withsource=TableName *\n| summarize Count=count() by TableName\n| render barchart";
			        "size"= 1;
			        "exportToExcelOptions"= "visible";
			        "queryType"= 0;
			        "resourceType"= "microsoft.operationalinsights/workspaces"
			      };
			      "name"= "query - 2"
			    }
			  );
			  "styleSettings"= @{};
			  "$schema"= "https://github.com/Microsoft/Application-Insights-Workbooks/blob/master/schema/workbook.json"
			}
			New-AzApplicationInsightsWorkbookTemplate -ResourceGroupName $env.resourceGroup -Name $env.workbookTemplate01 -Location $env.location -Gallery $gallery -TemplateData $data -Priority 1
			Get-AzApplicationInsightsWorkbookTemplate -ResourceGroupName $env.resourceGroup -Name $env.workbookTemplate01
			Update-AzApplicationInsightsWorkbookTemplate -ResourceGroupName $env.resourceGroup -Name $env.workbookTemplate01 -Tag @{'k1'='v1'}
			Remove-AzApplicationInsightsWorkbookTemplate -ResourceGroupName $env.resourceGroup -Name $env.workbookTemplate01
		} | Should -Not -Throw
	}

	It 'GetViaIdentity' {
		{
			$gallery = New-AzApplicationInsightsWorkbookTemplateGalleryObject -Category "Failures" -Name "Simple Template" -Type 'tsg' -ResourceType "microsoft.insights/components" -Order 100
			$data = @{
			  "version"= "Notebook/1.0";
			  "items"= @(
			    @{
			      "type"= 1;
			      "content"= @{
			        "json"= "## New workbook\n---\n\nWelcome to your new workbook.  This area will display text formatted as markdown.\n\n\nWe've included a basic analytics query to get you started. Use the `Edit` button below each section to configure it or add more sections."
			      };
			      "name"= "text - 2"
			    },
			    @{
			      "type"= 3;
			      "content"= @{
			        "version"= "KqlItem/1.0";
			        "query"= "union withsource=TableName *\n| summarize Count=count() by TableName\n| render barchart";
			        "size"= 1;
			        "exportToExcelOptions"= "visible";
			        "queryType"= 0;
			        "resourceType"= "microsoft.operationalinsights/workspaces"
			      };
			      "name"= "query - 2"
			    }
			  );
			  "styleSettings"= @{};
			  "$schema"= "https://github.com/Microsoft/Application-Insights-Workbooks/blob/master/schema/workbook.json"
			}
			$workTemplate = New-AzApplicationInsightsWorkbookTemplate -ResourceGroupName $env.resourceGroup -Name $env.workbookTemplate01 -Location $env.location -Gallery $gallery -TemplateData $data -Priority 1
			Get-AzApplicationInsightsWorkbookTemplate -InputObject $workTemplate
			Update-AzApplicationInsightsWorkbookTemplate -InputObject $workTemplate -Tag @{'k1'='v1'}
			Remove-AzApplicationInsightsWorkbookTemplate -InputObject $workTemplate
		} | Should -Not -Throw
	}
}