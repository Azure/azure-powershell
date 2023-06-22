namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview
{
    public class PSContainerRegistryCredential
    {
        public PSContainerRegistryCredential(RegistryListCredentialsResult credentials)
        {
            Username = credentials?.Username;
            Password = credentials?.Password?.Length > 0 ? credentials.Password[0]?.Value : string.Empty;
            Password2 = credentials?.Password?.Length > 1 ? credentials.Password[1]?.Value : string.Empty;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
    }
}
