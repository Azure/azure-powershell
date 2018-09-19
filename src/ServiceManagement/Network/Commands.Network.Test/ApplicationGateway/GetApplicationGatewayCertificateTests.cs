// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using PowerShellAppGwModel = Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.ApplicationGateway
{
    public class GetApplicationGatewayCertificateTests
    {
        private const string CertWithCAChain = "MIIMTgYJKoZIhvcNAQcCoIIMPzCCDDsCAQExADALBgkqhkiG9w0BBwGgggwjMIIDBzCCAfOgAwIBAgIQJXteG9dZZ61Bkbq4Ev9CQzAJBgUrDgMCHQUAMBQxEjAQBgNVBAMTCVRlc3QgQ0EgMzAeFw0xNzA2MDIwNDAzNDNaFw0zOTEyMzEyMzU5NTlaMBMxETAPBgNVBAMTCG15c2VydmVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAx4Y8K/dvl+wRqyOZu0wO6QfLYNEM9XVbIDcIb4fS4fsdFXEsS9TVBH19mhiKv6BHNdaifha2V5mFYCe61mqRg8fpijstRYXMHE9G6YtyjpsCUmfAWZI0fLqHIKg83U3gT6zznDQ+udYJCYyBNI5K++3exhYEntVaKkZq/Bcb0b/qcTPMmbyPD8IYOKu7rZW1B8NHfPlN2DW0Eq6MozgnFe458CDjlX5tWWa08e0Pmt/UzIDPYNsQt1u7wCaBsUCImWQ5+nFqG5z0qxKt6m46TA9tBM8evNbg3AQr9nCrIu37XGKsjJW6tutPCNdfnn0u/9SOo2Hj/n5h13R4efWnTwIDAQABo14wXDATBgNVHSUEDDAKBggrBgEFBQcDATBFBgNVHQEEPjA8gBBJJo/m+4M/23rx419DXo3xoRYwFDESMBAGA1UEAxMJVGVzdCBDQSAyghDFG9j2uBl7pUmYQ7nv/2AMMAkGBSsOAwIdBQADggEBAFjPC4HY7LcPljQmqwPrmoKweW+0C11TTGCjfmB/BM2cm8OeWWn99CBFr+s5TPcTtUTWRob5NfpbDicgT2AuhHWzO/bVSRb3pr7asghIkteEWXR4AKWRhsRvsSqxEAMUzZb/q34+PZuHYXq4XyOP/o9RCoTqsIl/F9NfyAKDlyAHtNzvUt8f/WZ4+1Qd6PnO2//9MK6aL7CJDC2LlGju3x9BIa+skDoPek9Z3Jv8SsZLcoGjF47NbFbgtZedm34Kt4/bwUSE9wUTT0LfHeLgaMPTGqn2maCqYHzP6BH+YiFGE8vlO/IrNQXCuuALnsSbm3LkZ5IqgQft0KnSxqU4ZMIwggMEMIIB8KADAgECAhC+t6JvjU0siUOdsfHUjp59MAkGBSsOAwIdBQAwFDESMBAGA1UEAxMJVGVzdCBDQSAxMB4XDTE3MDYwMjA0MDI0OVoXDTM5MTIzMTIzNTk1OVowFDESMBAGA1UEAxMJVGVzdCBDQSAxMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA1g+N/Zz8f4ISG2DDu4taD+IDu6ua06VeRRFTIWM/GtL4S5a/orVRCNHp2hSlABOpbifUYg4C1IGdFlM88b00QjEvSd0stnhs9O5tJkEy+lrcUMSew8U+nDNXTukCgGaXNHuVmkqHXwGVEA9vMu+gO8w7LrigFqczUI6zs52+o37U9AZLecTWTfC1wIVa34cU3Zpl2D6I4PCyDEAmGR4ESo1j6Hq89C39mkI283EjQsJ39wN2IDgkk0mgsABqmsEaL5uzXPHJ5xtAN5gUWMa2B3qJKs2ndV53+y6zODcb91bY0Zusj+acsG8HxAKF+22TxYpHIJEQwKbKfRn1g3xZ6QIDAQABo1owWDAPBgNVHRMBAf8EBTADAQH/MEUGA1UdAQQ+MDyAEDl918q6tDvlaq66pWfXZxehFjAUMRIwEAYDVQQDEwlUZXN0IENBIDGCEL63om+NTSyJQ52x8dSOnn0wCQYFKw4DAh0FAAOCAQEAa9COHYFtKE9a8FdakNHfabJhec1G408s6Ov5l8Z7zYKO0BcJPyL17sdblpzEWcu3XQ6mNUMBgsp70RPRYDnRe+5HG02nKOBhWD96ML97xY3BJcysm9oe2R3oqFFysjCUZlfdPLQWHwhIDhQh+6UuHXQDLxuAAgQxGNYDwHaJ/Kx5XC7JE4Q0wob3PWWAg2EigZPPX4YrDT9BiJXuA8XsNfv9/OLqY7tpTte4AIYaAS0/x2hQfUNpEBdmuOvx6psJ25R4a4GbN+QKKeC/KVdtnmatKn6aaCfrHXfXdQZPQNlD1/3hUgbmCQ0KBOl8JopZ+yyp5o+XwhDQqdL0scm5LDCCAwQwggHwoAMCAQICEDJ3DkbnG7GeQj+icBjNffkwCQYFKw4DAh0FADAUMRIwEAYDVQQDEwlUZXN0IENBIDEwHhcNMTcwNjAyMDQwMzAwWhcNMzkxMjMxMjM1OTU5WjAUMRIwEAYDVQQDEwlUZXN0IENBIDIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCx338Nqv3mg5VFkFWliDlL12HG7GzJ9p1sstFmsOPPvPCUMxVgcRdjEE2JSg875mjVe5dYCzZIMbY+fTRgBoNhL6fzY9JxvXSUlERNH5jVRVoMQ27j11wtnCEcWVrzW3AIkW97SeBQtKJadOD9DL6yNKrzej0WJkTd/x3nJBt6qlEOt8isSjiRh/83DHg1oO4EqDUrpM81OSf3RoeqxbX+FJO5KLv6HtWFNWUVOisxQVtBtFKx5tEpViEeoirXXnv5OCO+uiVcA0CJoDqWg6sXiku1RfuzW3PQsQrocixaLuzAjZ8zG6/LZplQ2KVQE/a4oBFrY+n5w+zE3ihxQoy1AgMBAAGjWjBYMA8GA1UdEwEB/wQFMAMBAf8wRQYDVR0BBD4wPIAQOX3Xyrq0O+VqrrqlZ9dnF6EWMBQxEjAQBgNVBAMTCVRlc3QgQ0EgMYIQvreib41NLIlDnbHx1I6efTAJBgUrDgMCHQUAA4IBAQCRU8vSrjmy2om6Gh7TOlApgxOtAtCjsZYYxeS1cQFnr6vnQHNjei6wiEVVv4PIYvYQcLpKfAIvZZJEEPXKwGX1G4l7SiEt7xQ22jHTUMLsFPPQLsVZyUNM8Bs//bfp+wFaOJkaHO4m8e1bnl40fT8XdoKYAdgaScWjYGEAWKYRtGZxJLIudzGs2XVYKqEC4/2g8uBfTPhDVtU+/uzWsP5ztLqz0xXSM0mgVKjjFJ85+gji7aUjqTEMIzIZjLxv9gCuyp9Tu5DeMQ1AZ2/uJZ6TVgHnamIem04rzIIiEPIWBC7tYyZhGq0T5Frwi98wwiLTJQnR5BdXtrrilFJZ+bkNMIIDBDCCAfCgAwIBAgIQxRvY9rgZe6VJmEO57/9gDDAJBgUrDgMCHQUAMBQxEjAQBgNVBAMTCVRlc3QgQ0EgMjAeFw0xNzA2MDIwNDAzMjJaFw0zOTEyMzEyMzU5NTlaMBQxEjAQBgNVBAMTCVRlc3QgQ0EgMzCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAK7Db96KsHaxlMK2L/2SV1flb87ao5evjW4thv/z5TXSVteI/jdSsvnEf+KvbwZzZvY//SdSl1WjBQMWDFrO/GRZVhhLkWz75I9W4l/6mCckkMKZ7iHPpEe8+hDgj6shACf1NoqvguJ9Ot83fDIKmmKOgDy6tPrvdjc5NeZNmKKXAy9umFRjSnBhl5Y5V/0mhhwYN4Ibg8/mX8YE/oVGsBTLvUYfX65pwC3JjtSJdHqrIg1y6Z3gD0CnxXd5HraW+H8tEpKQiGRqsQ45TGL0h+c+M1qrjvD8GsJLw6EzUHVUP7p1A2Tc+kDYkfXB1dzYvstTgdIzEg7nPXzuHupUyikCAwEAAaNaMFgwDwYDVR0TAQH/BAUwAwEB/zBFBgNVHQEEPjA8gBB1xLhbYUElRKkEX+LyDY5XoRYwFDESMBAGA1UEAxMJVGVzdCBDQSAxghAydw5G5xuxnkI/onAYzX35MAkGBSsOAwIdBQADggEBAApNbFLCxg+pFckCScLOmiu1D5w7gdjAzP1lDz8aiAkip6ua6nZBUKpgFoGfq+uPXxQU/SH68JDzp9C3mdMmRSyz6ZTTQ6I3bn8pRUy7W6jN1PmjIKQ8ruNGYukX3M/jujxdFXLwqaDp+Nl1WEktZZzxj5y2YPsHhNyFIfyu1obp/2Zfqae+6qr2itYhN/k0c2HI0ZcObS//IlpO/7DNib7q6/yZ7mVqcJ31iTDXL0WUwssS6/wekroTL6ohLwsXJPWoYeGvlFWzf1M/lNm7TCpJ6c6iHl+mFLwXY8qH3QB6xm6IG9KLqPr38vsXmzjkqzBFFyb7bSF33NWzr1bOq60xAA==";
        private const string SelfSignedCert = "MIIDWgYJKoZIhvcNAQcCoIIDSzCCA0cCAQExADALBgkqhkiG9w0BBwGgggMvMIIDKzCCAhOgAwIBAgIQRX3qiBwWP7xCrNLmDrkk0zANBgkqhkiG9w0BAQsFADAdMRswGQYDVQQDExJteXNlbGZzaWduZWRzZXJ2ZXIwHhcNMTcwNjAyMDQxOTAzWhcNMzkxMjMxMjM1OTU5WjAdMRswGQYDVQQDExJteXNlbGZzaWduZWRzZXJ2ZXIwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCqUUNsYjVD/Gly67Y46Xgi5oNJH0aXWC/y04oLrmT8nugeeM1BdlLuqFdRZ223Q54N1XS1BJKwWmeo+/2FeWlenWoJHvxTYVTPCen4CpX34EXyLwkW0sk7xefoN6ykfpR/URf+53A3gQt0B2OPjNSQV/z0KLq0HZ7oWp8XRwPEIkSioEUdI5dSfqjQ8eL1HV962LK7x3nCaCc/MCyfc/Ork3Rfo8ZQiOuE8Ei3IlJw/b2mUeZ9IuKRwTGKQ8z8weXVjfSQ0o7P5nSrQcYS6f2vXhugov8bSKxw5SGAzvAaoRedj4hvUcIrH4Bmpbdju1ykZYU1CmfBNIfytVQUVamfAgMBAAGjZzBlMBMGA1UdJQQMMAoGCCsGAQUFBwMBME4GA1UdAQRHMEWAEIbgiHZ2FJOsHlc3iheady2hHzAdMRswGQYDVQQDExJteXNlbGZzaWduZWRzZXJ2ZXKCEEV96ogcFj+8QqzS5g65JNMwDQYJKoZIhvcNAQELBQADggEBAJM9BHtyyX9EXXNO8XwWC6MAPJwiR6m3xN7/qUJsSr9PcTBgsn10l3qP7l4g/XAPt2Ot8WFxe/VSyLM+TQ1WxYKxUIE3QbILH1orn+6pKjr40dLBodQdTQFtg8x0Z1bCPn3kne1WlLeaOlrLDMUlfgQgg6/ompYu0W4gKF3e3t3inoLb5ETpQ4Pa+8XIzKRNwen3twt2us4CG2RU5cwQdzLwIvgcAkok3U3zo5Tz4GIJ9n7x1zVjJdz1VSDMilqWr57e3jfT7cGmGXE3m34oT36rSxF2HsF5jTJHT1QVnPBu7VRmC85vBcZAGh9VTdL01oCk2VvAgaXw78wHJquHPOUxAA==";

        private MockCommandRuntime mockCommandRuntime;

        private GetApplicationGatewayCertificateCommand cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;

        public GetApplicationGatewayCertificateTests()
        {
            this.networkingClientMock = new Mock<INetworkManagementClient>();
            var computeClientMock = new Mock<IComputeManagementClient>();
            var managementClientMock = new Mock<IManagementClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.client = new NetworkClient(
                this.networkingClientMock.Object,
                computeClientMock.Object,
                managementClientMock.Object,
                mockCommandRuntime);

            this.networkingClientMock
                .Setup(n => n.ApplicationGateways.GetCertificateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new ApplicationGatewayGetCertificate()
                {
                    Name = "cert1",
                    Data = CertWithCAChain,
                }));
                

            this.networkingClientMock
                .Setup(n => n.ApplicationGateways.ListCertificateAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new ApplicationGatewayListCertificate()
                {
                    ApplicationGatewayCertificates =  new List<ApplicationGatewayGetCertificate>()
                    {
                        new ApplicationGatewayGetCertificate()
                        {
                            Name = "cert1",
                            Data = CertWithCAChain
                        },
                        new ApplicationGatewayGetCertificate()
                        {
                            Name = "cert2",
                            Data = SelfSignedCert,
                        }
                    }
                }));
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetCertByName()
        {
            // Setup
            cmdlet = new GetApplicationGatewayCertificateCommand
            {
                Name = "appgw1",
                CertificateName = "cert1",
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            this.networkingClientMock.Verify(
                n => n.ApplicationGateways.ListCertificateAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Never());

            this.networkingClientMock.Verify(
                n => n.ApplicationGateways.GetCertificateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);

            var returnedPsObj = (PowerShellAppGwModel.ApplicationGatewayCertificate)mockCommandRuntime.OutputPipeline[0];
            Assert.Equal("cert1", returnedPsObj.Name);
            Assert.Equal("4D0431E9C2DAEB10BEFE50CAD7FD43539EC410B1", returnedPsObj.Thumbprint);
            Assert.Equal("sha1RSA", returnedPsObj.ThumbprintAlgo);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListCerts()
        {
            // Setup
            cmdlet = new GetApplicationGatewayCertificateCommand
            {
                Name = "appgw1",
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            this.networkingClientMock.Verify(
                n => n.ApplicationGateways.ListCertificateAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Once());

            this.networkingClientMock.Verify(
                n => n.ApplicationGateways.GetCertificateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Never());

            Assert.Equal(2, mockCommandRuntime.OutputPipeline.Count);

            var returnedPsObj1 = (PowerShellAppGwModel.ApplicationGatewayCertificate)mockCommandRuntime.OutputPipeline[0];
            Assert.Equal("cert1", returnedPsObj1.Name);
            Assert.Equal("4D0431E9C2DAEB10BEFE50CAD7FD43539EC410B1", returnedPsObj1.Thumbprint);
            Assert.Equal("sha1RSA", returnedPsObj1.ThumbprintAlgo);

            var returnedPsObj2 = (PowerShellAppGwModel.ApplicationGatewayCertificate)mockCommandRuntime.OutputPipeline[1];
            Assert.Equal("cert2", returnedPsObj2.Name);
            Assert.Equal("89A6A0B7FDC249488ED9B23BAE674121CD9B036F", returnedPsObj2.Thumbprint);
            Assert.Equal("sha256RSA", returnedPsObj2.ThumbprintAlgo);
        }
    }
}
