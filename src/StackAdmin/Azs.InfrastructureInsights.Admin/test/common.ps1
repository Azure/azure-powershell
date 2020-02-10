function ValidateMetrics{
    param(
        $Metrics
    )
    $Metrics        | Should not be $null
    $Metrics.Name   | Should not be $null
    $Metrics.Unit   | Should not be $null
    $Metrics.Value  | Should not be $null
}

function ValidateUsageMetrics {
    param(
    $UsageMetrics
    )
    $UsageMetrics               | Should not be $null
    $UsageMetrics.MetricsValue  | Should not be $null
    $UsageMetrics.Name          | Should not be $null

    foreach($metrics in $UsageMetrics.MetricsValue) {
        ValidateMetrics $metrics
    }
}

function ValidateRegionHealth {
    param(
        [Parameter(Mandatory=$true)]
        $RegionHealth
    )

    $RegionHealth          | Should Not Be $null

    # Resource
    $RegionHealth.Id       | Should Not Be $null
    $RegionHealth.Location | Should Not Be $null
    $RegionHealth.Name     | Should Not Be $null
    $RegionHealth.Type     | Should Not Be $null

    # Region Health
    $RegionHealth.AlertSummaryCriticalAlertCount  | Should Not Be $null
    $RegionHealth.AlertSummaryWarningAlertCount   | Should Not Be $null

    $RegionHealth.AlertSummaryCriticalAlertCount  | Should BeGreaterThan -1
    $RegionHealth.AlertSummaryWarningAlertCount   | Should BeGreaterThan -1

    foreach($usageMetrics in $RegionHealth.UsageMetrics) {
        ValidateUsageMetrics $usageMetrics
    }
}

function AssertRegionHealthsAreSame {
    param(
        [Parameter(Mandatory=$true)]
        $Expected,

        [Parameter(Mandatory=$true)]
        $Found
    )
    if($Expected -eq $null) {
        $Found | Should Be $null
    } else {
        $Found                  | Should Not Be $null

        # Resource
        $Found.Id               | Should Be $Expected.Id
        $Found.Location         | Should Be $Expected.Location
        $Found.Name             | Should Be $Expected.Name
        $Found.Type             | Should Be $Expected.Type

        # Region Health
        $Found.AlertSummary.CriticalAlertCount  | Should Be $Expected.AlertSummary.CriticalAlertCount
        $Found.AlertSummary.WarningAlertCount   | Should Be $Expected.AlertSummary.WarningAlertCount
    }
}

function ValidateAlert {

            param(

                [Parameter(Mandatory = $true)]

                $Alert

            )

            $Alert          | Should Not Be $null

            # Resource
            $Alert.Id       | Should Not Be $null
            $Alert.Location | Should Not Be $null
            $Alert.Name     | Should Not Be $null
            $Alert.Type     | Should Not Be $null

            # Alert
            $Alert.AlertId                         | Should Not Be $null
            $Alert.AlertProperty                   | Should Not Be $null
            $Alert.CreatedTimestamp                | Should Not Be $null
            $Alert.Description                     | Should Not Be $null
            $Alert.FaultTypeId                     | Should Not Be $null
            $Alert.ImpactedResourceDisplayName     | Should Not Be $null
            $Alert.ImpactedResourceId              | Should Not Be $null
            $Alert.LastUpdatedTimestamp            | Should Not Be $null
            $Alert.Remediation                     | Should Not Be $null
            $Alert.ResourceProviderRegistrationId  | Should Not Be $null
            $Alert.Severity                        | Should Not Be $null
            $Alert.State                           | Should Not Be $null
            $Alert.Title                           | Should Not Be $null
}

function AssertAlertsAreSame {
    param(
        [Parameter(Mandatory = $true)]
        $Expected,

        [Parameter(Mandatory = $true)]
        $Found
    )

    if ($Expected -eq $null) {
        $Found | Should Be $null
    }
    else {
        $Found                  | Should Not Be $null

        # Resource
        $Found.Id               | Should Be $Expected.Id
        $Found.Location         | Should Be $Expected.Location
        $Found.Name             | Should Be $Expected.Name
        $Found.Type             | Should Be $Expected.Type

        # Alert
        $Found.AlertId                         | Should Be $Expected.AlertId

        if ($Expected.AlertProperties -eq $null) {
            $Found.AlertProperties             | Should Be $null
        }
        else {
            $Found.AlertProperties             | Should Not Be $null
            $Found.AlertProperties.Count       | Should Be $Expected.AlertProperties.Count
        }

        $Found.ClosedByUserAlias               | Should Be $Expected.ClosedByUserAlias
        $Found.ClosedTimestamp                 | Should Be $Expected.ClosedTimestamp
        $Found.CreatedTimestamp                | Should Be $Expected.CreatedTimestamp

        if ($Expected.Description -eq $null) {
            $Found.Description                 | Should Be $null
        }
        else {
            $Found.Description                 | Should Not Be $null
            $Found.Description.Count           | Should Be $Expected.Description.Count
        }

        $Found.FaultId                         | Should Be $Expected.FaultId
        $Found.FaultTypeId                     | Should Be $Expected.FaultTypeId
        $Found.ImpactedResourceDisplayName     | Should Be $Expected.ImpactedResourceDisplayName
        $Found.ImpactedResourceId              | Should Be $Expected.ImpactedResourceId
        $Found.LastUpdatedTimestamp            | Should Be $Expected.LastUpdatedTimestamp

        if ($Expected.Remediation -eq $null) {
            $Found.Remediation                 | Should Be $null
        }
        else {
            $Found.Remediation                 | Should Not Be $null
            $Found.Remediation.Count           | Should Be $Expected.Remediation.Count
        }

        $Found.ResourceProviderRegistrationId  | Should Be $Expected.ResourceProviderRegistrationId
        $Found.ResourceRegistrationId          | Should Be $Expected.ResourceRegistrationId
        $Found.Severity                        | Should Be $Expected.Severity
        $Found.State                           | Should Be $Expected.State
        $Found.Title                           | Should Be $Expected.Title



    }

}

function ValidateAzsServiceHealth {
    param(
        [Parameter(Mandatory = $true)]
        $ServiceHealth
    )

    $ServiceHealth          | Should Not Be $null

    # Resource
    $ServiceHealth.Id       | Should Not Be $null
    $ServiceHealth.Location | Should Not Be $null
    $ServiceHealth.Name     | Should Not Be $null
    $ServiceHealth.Type     | Should Not Be $null

    # Service Health
    $ServiceHealth.AlertSummaryCriticalAlertCount | Should Not Be $null
    $ServiceHealth.AlertSummaryWarningAlertCount | Should Not Be $null
    $ServiceHealth.DisplayName  	| Should Not Be $null
    $ServiceHealth.HealthState  	| Should Not Be $null
    $ServiceHealth.InfraURI  		| Should Not Be $null
    $ServiceHealth.RegistrationId   | Should Not Be $null
    $ServiceHealth.RoutePrefix      | Should Not Be $null
    $ServiceHealth.ServiceLocation	| Should Not Be $null
}

function AssertAzsServiceHealthsAreSame {
    param(
        [Parameter(Mandatory = $true)]
        $Expected,

        [Parameter(Mandatory = $true)]
        $Found
    )
    if ($Expected -eq $null) {
        $Found | Should Be $null
    } else {
        $Found                  | Should Not Be $null

        # Resource
        $Found.Id               | Should Be $Expected.Id
        $Found.Location         | Should Be $Expected.Location
        $Found.Name             | Should Be $Expected.Name
        $Found.Type             | Should Be $Expected.Type

        $Found.AlertSummaryCriticalAlertCount  | Should Be $Expected.AlertSummaryCriticalAlertCount
        $Found.AlertSummaryWarningAlertCount   | Should Be $Expected.AlertSummaryWarningAlertCount

        $Found.DisplayName  	| Should Be $Expected.DisplayName
        $Found.HealthState  	| Should Be $Expected.HealthState
        $Found.InfraURI  		| Should Be $Expected.InfraURI
        $Found.RegistrationId	| Should Be $Expected.RegistrationId
        $Found.RoutePrefix  	| Should Be $Expected.RoutePrefix
        $Found.ServiceLocation  | Should Be $Expected.ServiceLocation


    }
}

            function ValidateResourceHealth {
    param(
        [Parameter(Mandatory = $true)]
        $ResourceHealth
    )

    $ResourceHealth          | Should Not Be $null

    # Resource
    $ResourceHealth.Id       | Should Not Be $null
    $ResourceHealth.Location | Should Not Be $null
    $ResourceHealth.Name     | Should Not Be $null
    $ResourceHealth.Type     | Should Not Be $null

    # Scale Unit Node
    $ResourceHealth.AlertSummaryCriticalAlertCount  | Should Not Be $null
    $ResourceHealth.AlertSummaryWarningAlertCount   | Should Not Be $null
    $ResourceHealth.HealthState     	| Should Not Be $null
    # Sometimes this can be null??
    #$ResourceHealth.Namespace  			| Should Not Be $null
    $ResourceHealth.RegistrationId  	| Should Not Be $null
    $ResourceHealth.ResourceDisplayName	| Should Not Be $null
    $ResourceHealth.ResourceLocation	| Should Not Be $null
    $ResourceHealth.ResourceName		| Should Not Be $null
    $ResourceHealth.ResourceType		| Should Not Be $null
    $ResourceHealth.ResourceURI			| Should Not Be $null
    $ResourceHealth.RoutePrefix			| Should Not Be $null
    $ResourceHealth.RpRegistrationId	| Should Not Be $null
}

function AssertResourceHealthsAreSame {
    param(
        [Parameter(Mandatory = $true)]
        $Expected,

        [Parameter(Mandatory = $true)]
        $Found
    )
    if ($Expected -eq $null) {
        $Found | Should Be $null
    } else {
        $Found                  | Should Not Be $null

        # Resource
        $Found.Id               | Should Be $Expected.Id
        $Found.Location         | Should Be $Expected.Location
        $Found.Name             | Should Be $Expected.Name
        $Found.Type             | Should Be $Expected.Type

        # Resource Health
        $Found.AlertSummaryCriticalAlertCount  | Should Be $Expected.AlertSummaryCriticalAlertCount
        $Found.AlertSummaryWarningAlertCount  	| Should Be $Expected.AlertSummaryWarningAlertCount

        $Found.HealthState      	| Should Be $Expected.HealthState
        $Found.NamespaceProperty	| Should Be $Expected.NamespaceProperty
        $Found.RegistrationId       | Should Be $Expected.RegistrationId
        $Found.ResourceDisplayName  | Should Be $Expected.ResourceDisplayName
        $Found.ResourceLocation   	| Should Be $Expected.ResourceLocation
        $Found.ResourceName      	| Should Be $Expected.ResourceName
        $Found.ResourceType  		| Should Be $Expected.ResourceType
        $Found.ResourceURI  		| Should Be $Expected.ResourceURI
        $Found.RoutePrefix  		| Should Be $Expected.RoutePrefix
        $Found.RpRegistrationId  	| Should Be $Expected.RpRegistrationId
    }
}