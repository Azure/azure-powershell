[CmdletBinding()]
param(
    [string]$Root = $PSScriptRoot,
    [switch]$FailOnMissing
)

Write-Host "Sanitizing recordings under: $Root" -ForegroundColor Cyan

$patterns = @(
    # === Application Insights ===
    @{
        Name = 'InstrumentationKeyProperty'
        Regex = '"InstrumentationKey"\s*:\s*"[^"]+"'
        Replacement = '"InstrumentationKey":"AI-INSTRUMENTATION-KEY-REDACTED"'
    },
    @{
        Name = 'StandaloneInstrumentationKeyInConnString'
        Regex = 'InstrumentationKey=[0-9a-fA-F-]{36}'
        Replacement = 'InstrumentationKey=AI-INSTRUMENTATION-KEY-REDACTED'
    },
    @{
        Name = 'AppInsightsApplicationIdInConnString'
        Regex = 'ApplicationId=[0-9a-fA-F-]{36}'
        Replacement = 'ApplicationId=APP-INSIGHTS-APPID-REDACTED'
    },
    @{
        Name = 'IngestionEndpoint'
        Regex = 'IngestionEndpoint=https://[a-zA-Z0-9\-\.]+'
        Replacement = 'IngestionEndpoint=https://redacted.ingest'
    },
    @{
        Name = 'LiveEndpoint'
        Regex = 'LiveEndpoint=https://[a-zA-Z0-9\-\.]+'
        Replacement = 'LiveEndpoint=https://redacted.live'
    },

    # === Storage connection strings ===
    @{
        Name = 'ConnectionStringKeyValue'
        Regex = 'AccountKey=[A-Za-z0-9+/=]+'
        Replacement = 'AccountKey=STORAGE-ACCOUNT-KEY-REDACTED'
    },
    @{
        Name = 'ApplicationInsightsConnectionStringSetting'
        Regex = '"name"\s*:\s*"APPLICATIONINSIGHTS_CONNECTION_STRING",(?:\s|\r|\n)*"value"\s*:\s*"[^"]+"'
        Replacement = '"name":"APPLICATIONINSIGHTS_CONNECTION_STRING","value":"InstrumentationKey=AI-INSTRUMENTATION-KEY-REDACTED;IngestionEndpoint=https://redacted.ingest/;LiveEndpoint=https://redacted.live/;ApplicationId=APP-INSIGHTS-APPID-REDACTED"'
    },
    @{
        Name = 'DeploymentStorageConnectionStringSetting'
        Regex = '"name"\s*:\s*"DEPLOYMENT_STORAGE_CONNECTION_STRING",(?:\s|\r|\n)*"value"\s*:\s*"[^"]+"'
        Replacement = '"name":"DEPLOYMENT_STORAGE_CONNECTION_STRING","value":"DefaultEndpointsProtocol=https;AccountName=REDACTEDACCOUNT;AccountKey=STORAGE-ACCOUNT-KEY-REDACTED;EndpointSuffix=core.windows.net"'
    },
    @{
        Name = 'AzureWebJobsStorageSetting'
        Regex = '"name"\s*:\s*"AzureWebJobsStorage",(?:\s|\r|\n)*"value"\s*:\s*"[^"]+"'
        Replacement = '"name":"AzureWebJobsStorage","value":"DefaultEndpointsProtocol=https;AccountName=REDACTEDACCOUNT;AccountKey=STORAGE-ACCOUNT-KEY-REDACTED;EndpointSuffix=core.windows.net"'
    },
    @{
        Name = 'StorageConnectionStringFull'
        Regex = 'DefaultEndpointsProtocol=https;AccountName=[^;"]+;AccountKey=[^;"]+;EndpointSuffix=core\.windows\.net'
        Replacement = 'DefaultEndpointsProtocol=https;AccountName=REDACTEDACCOUNT;AccountKey=STORAGE-ACCOUNT-KEY-REDACTED;EndpointSuffix=core.windows.net'
    },

    # === SAS tokens ===
    @{
        Name = 'SasTokenLikeQuery'
        Regex = '\?sv=20[0-9]{2}-[0-9]{2}-[0-9]{2}[^"]*'
        Replacement = '?SANITIZED_SAS_TOKEN'
    },

    # === JSON properties that clearly look like storage/secret keys ===
    @{
        Name = 'Json_WellKnownStorageKeyNames'
        Regex = '"(storageKey|primaryKey|secondaryKey|accountKey|AzureWebJobsStorage|DEPLOYMENT_STORAGE_CONNECTION_STRING)"\s*:\s*"[^"]+"'
        Replacement = '"$1":"STORAGE-ACCOUNT-KEY-REDACTED"'
    },

    # === Inner serialized single-key JSON (legacy shape) ===
    @{
        Name = 'InnerKeysValueJson'
        Regex = '"Content"\s*:\s*"\{\\\"keys\\\":\[\{\\\"keyName\\\":\\\"[^\\"]+\\\",\\\"value\\\":\\\"[^\\"]+\\\",\\\"permissions\\\":\\\"FULL\\\"}\]\}"'
        Replacement = '"Content":"{\"keys\":[{\"keyName\":\"key1\",\"value\":\"SANITIZED-KEY-VALUE\",\"permissions\":\"FULL\"}]}"'
    },

    # === Generic key-like JSON values (CredScan hardening) ===
    @{
        Name = 'Json_KeyLike_LongValue'
        Regex = '"(?<keyName>[^"]*(key|Key|KEY)[^"]*)"\s*:\s*"[^"]{20,}"'
        Replacement = '"${keyName}":"STORAGE-ACCOUNT-KEY-REDACTED"'
    },
    @{
        Name = 'Json_ConnectionStringLike_LongValue'
        Regex = '"(?<keyName>[^"]*(connectionstring|ConnectionString|CONNECTIONSTRING)[^"]*)"\s*:\s*"[^"]{20,}"'
        Replacement = '"${keyName}":"SANITIZED-CONNECTION-STRING"'
    },
    @{
        Name = 'Standalone_AppInsights_Key'
        Regex = '"name"\s*:\s*"APPINSIGHTS_INSTRUMENTATIONKEY",(?:\s|\r|\n)*"value"\s*:\s*"[0-9a-fA-F-]{36}"'
        Replacement = '"name":"APPINSIGHTS_INSTRUMENTATIONKEY","value":"AI-INSTRUMENTATION-KEY-REDACTED"'
    },
    @{
        Name = 'Unescaped_Keys_Array_Generic'
        Regex = '"keys"\s*:\s*\[(?:\{"keyName":"[^"]+","value":"[A-Za-z0-9+/=]{20,}","permissions":"FULL"\}(?:,\s*)?)+\]'
        Replacement = '"keys":[{"keyName":"key1","value":"SANITIZED-KEY-VALUE","permissions":"FULL"},{"keyName":"key2","value":"SANITIZED-KEY-VALUE","permissions":"FULL"}]'
    },

    # === Multi-key + base64 redaction ===
    # (Optional repair pattern — uncomment if prior runs produced \\\"value\\\":\\\"SANITIZED-KEY-VALUE\\\")
    # @{
    #     Name = 'Fix_DoubleEscaped_SanitizedValues'
    #     Regex = '\\\\\"value\\\\\":\\\\\"SANITIZED-KEY-VALUE\\\\\"'
    #     Replacement = '\"value\":\"SANITIZED-KEY-VALUE\"'
    # },
    @{
        Name = 'SerializedKeys_Value_Base64'
        Regex = '\\\"value\\\":\\\"[A-Za-z0-9+/=]{40,}\\\"'
        Replacement = '\"value\":\"SANITIZED-KEY-VALUE\"'
    },
    @{
        Name = 'Json_Value_LongBase64_Unescaped'
        Regex = '"value"\s*:\s*"[A-Za-z0-9+/=]{40,}"'
        Replacement = '"value":"SANITIZED-KEY-VALUE"'
    },
    @{
        Name = 'SerializedKeys_Array_Generic'
        Regex = '"Content"\s*:\s*"\{\\\"keys\\\":\[(?:\{\\\"keyName\\\":\\\"[^\\"]+\\\",\\\"value\\\":\\\"[A-Za-z0-9+/=]{20,}\\\",\\\"permissions\\\":\\\"FULL\\\"}(?:,)?)+\]\}"'
        Replacement = '"Content":"{\"keys\":[{\"keyName\":\"key1\",\"value\":\"SANITIZED-KEY-VALUE\",\"permissions\":\"FULL\"},{\"keyName\":\"key2\",\"value\":\"SANITIZED-KEY-VALUE\",\"permissions\":\"FULL\"}]}"'
    }

    # Optional broad fallback (commented out; enable only if push protection still flags residual tokens)
    # @{
    #     Name = 'Generic_Long_Base64_Fallback'
    #     Regex = '[A-Za-z0-9+/=]{60,}'
    #     Replacement = 'SANITIZED-BASE64-TOKEN'
    # }
)

Get-ChildItem -Path $Root -Recurse -Filter *.Recording.json | ForEach-Object {
    $file = $_.FullName
    $original = Get-Content -Raw -Path $file
    $updated = $original
    $applied = @()

    foreach ($p in $patterns) {
        $before = $updated
        $updated = [regex]::Replace($updated, $p.Regex, $p.Replacement)
        if ($updated -ne $before) {
            $applied += $p.Name
        } elseif ($FailOnMissing) {
            Write-Warning "Pattern '$($p.Name)' not found in $file"
        }
    }

    if ($applied.Count -gt 0) {
        $backup = "$file.bak"
        if (-not (Test-Path $backup)) {
            Set-Content -Path $backup -Value $original
        }
        Set-Content -Path $file -Value $updated
        Write-Host "Sanitized $file (patterns: $($applied -join ', '))" -ForegroundColor Green
    } else {
        Write-Host "No sensitive patterns changed in $file" -ForegroundColor DarkYellow
    }
}

Write-Host "Sanitization complete." -ForegroundColor Cyan