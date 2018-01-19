namespace VersionController.Models
{
    /// <summary>
    /// Defines the different types of version bumps that can be applied to a version.
    /// </summary>
    public enum Version
    {
        PATCH = 0,
        MINOR = 1,
        MAJOR = 2
    }
}
