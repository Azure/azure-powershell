using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models;
using System;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace SecurityDomain.Test
{
    public class SecurityDomainTests
    {
        [Fact]
        public void X509Tests()
        {
            X509Certificate2 cert = new X509Certificate2(@"C:\yeming.liu.cer");
            Assert.NotNull(cert);

            JWK jwk = new JWK(cert);
            Assert.NotNull(jwk);

            Assert.Equal(JwkKeyType.RSA.ToString(), jwk.kty);
        }
    }
}
