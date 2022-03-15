namespace Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model
{
    public class AzureSqlInstanceServerTrustCertificateModel
    {
        /// <summary>
        /// Gets or sets managed instance name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets managed instance name
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets certificate id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets certificate type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets certificate name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets certificate thumbprint
        /// </summary>
        public string Thumbprint { get; set; }

        /// <summary>
        /// Gets or sets certificate public key
        /// </summary>
        public string PublicKey { get; set; }
    }
}
