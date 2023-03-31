using Azure.Core.Extensions;
using System;

namespace Azure.CodeSigning.Extensions
{
    public static class CertificateProfileClientBuilderExtensions
    {
        public static IAzureClientBuilder<CertificateProfileClient, CertificateProfileClientOptions> AddCertificateProfileClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<CertificateProfileClient, CertificateProfileClientOptions>((options, credential) => new CertificateProfileClient(credential, endpoint, options));
        }

        public static IAzureClientBuilder<CertificateProfileClient, CertificateProfileClientOptions> AddCertificateProfileClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<CertificateProfileClient, CertificateProfileClientOptions>(configuration);
        }
    }
}
