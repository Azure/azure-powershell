

public enum DiagnosticLevel
{
    Off,
    Basic,
    Enhanced
}
public enum ArcStatus
{
    Unknown,
    Enabled,
    Disabled,
    DisableInProgress
}

public enum RegistrationStatus
{
    Registered,
    NotYet,
    OutOfPolicy
}

public enum CertificateManagedBy
{
    Invalid,
    User,
    Cluster,
}
public enum VMAttestationStatus
{
    Unknown,
    Connected,
    Disconnected,
}
public enum ImdsAttestationNodeStatus
{
    Inactive,
    Active,
    Expired,
    Error,
}
public enum EventLogLevel
{
    Error,
    Warning,
    Information,
}