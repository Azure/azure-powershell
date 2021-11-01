class Constants
{
    static [System.String] $PublicTelemetryInstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090"
    static [System.String] $CurrentSessionId = [System.GUID]::NewGuid().ToString()
    static [Microsoft.ApplicationInsights.TelemetryClient] $TelemetryClient = $null
    static [System.String] $HashMacAddress = $null
}