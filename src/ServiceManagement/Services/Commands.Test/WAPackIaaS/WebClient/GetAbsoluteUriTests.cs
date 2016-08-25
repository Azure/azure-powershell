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

using System;
using System.Text;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient;

namespace Microsoft.WindowsAzure.Commands.Test.WAPackIaaS.WebClient
{
    
    public class GetAbsoluteUriTests
    {
        private Subscription subscription;

        public GetAbsoluteUriTests()
        {
            var azureSub = new AzureSubscription();
            azureSub.Id = Guid.NewGuid();
            this.subscription = new Subscription(azureSub);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldGenerateUri()
        {
            var expectedUri = new StringBuilder();
            expectedUri.AppendFormat("{0}", this.subscription.ServiceEndpoint);

            var client = new WAPackIaaSClient(this.subscription);
            var actualUri = client.GetAbsoluteUri();

           Assert.Equal(expectedUri.ToString(), actualUri);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldGenerateUriWithoutSubscription()
        {
            this.subscription.SubscriptionId = String.Empty;

            var expectedUri = new StringBuilder();
            expectedUri.AppendFormat("{0}", this.subscription.ServiceEndpoint.ToString());

            var client = new WAPackIaaSClient(this.subscription);
            var actualUri = client.GetAbsoluteUri();

            Assert.Equal(expectedUri.ToString(), actualUri);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldGenerateUriWithUriSuffix()
        {
            const string uriSuffix = "/myResource";

            var expectedUri = new StringBuilder();
            expectedUri.AppendFormat("{0}{1}", this.subscription.ServiceEndpoint, uriSuffix);

            var client = new WAPackIaaSClient(this.subscription);
            client.SetUriSuffix(uriSuffix);
            var actualUri = client.GetAbsoluteUri();

            Assert.Equal(expectedUri.ToString(), actualUri);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldGenerateUriWithUriSuffixAndSingleQueryParameter()
        {
            const string uriSuffix = "/myResource";

            var expectedUri = new StringBuilder();
            expectedUri.AppendFormat("{0}{1}",this.subscription.ServiceEndpoint, uriSuffix);
            expectedUri.Append("?query1=value1");

            var client = new WAPackIaaSClient(this.subscription);
            client.SetUriSuffix(uriSuffix);
            client.AddQueryParameters("query1", "value1");
            var actualUri = client.GetAbsoluteUri();

            Assert.Equal(expectedUri.ToString(), actualUri);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldGenerateUriWithUriSuffixAndTwoQueryParameter()
        {
            const string uriSuffix = "/myResource";

            var expectedUri = new StringBuilder();
            expectedUri.AppendFormat("{0}{1}", this.subscription.ServiceEndpoint, uriSuffix);
            expectedUri.Append("?query1=value1&query2=value2");

            var client = new WAPackIaaSClient(this.subscription);
            client.SetUriSuffix(uriSuffix);
            client.AddQueryParameters("query1", "value1");
            client.AddQueryParameters("query2", "value2");
            var actualUri = client.GetAbsoluteUri();

            Assert.Equal(expectedUri.ToString(), actualUri);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldGenerateUriWithUriSuffixAndSingleFilter()
        {
            const string uriSuffix = "/myResource";
            const string filterName = "filterName1";

            var expectedUri = new StringBuilder();
            expectedUri.AppendFormat("{0}{1}", this.subscription.ServiceEndpoint, uriSuffix);
            expectedUri.AppendFormat("?$filter={0} eq 'val1'", filterName);

            var client = new WAPackIaaSClient(this.subscription);
            client.SetUriSuffix(uriSuffix);
            client.AddHttpFilter(filterName, WebFilterOptions.eq, "val1");
            var actualUri = client.GetAbsoluteUri();

            Assert.Equal(expectedUri.ToString(), actualUri);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldGenerateUriWithUriSuffixAndTwoFilters()
        {
            const string uriSuffix = "/myResource";
            const string filterName = "filterName1";
            const string filterName2 = "filterName2";

            var expectedUri = new StringBuilder();
            expectedUri.AppendFormat("{0}{1}", this.subscription.ServiceEndpoint, uriSuffix);
            expectedUri.AppendFormat("?$filter={0} eq 'val1' and {1} ne 20", filterName, filterName2);

            var client = new WAPackIaaSClient(this.subscription);
            client.SetUriSuffix(uriSuffix);
            client.AddHttpFilter(filterName, WebFilterOptions.eq, "val1");
            client.AddHttpFilter(filterName2, WebFilterOptions.ne, "20");
            var actualUri = client.GetAbsoluteUri();

            Assert.Equal(expectedUri.ToString(), actualUri);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldGenerateUriWithSuffixAndFilterAndQueryParameter()
        {
            const string uriSuffix = "/myResource";
            const string filterName = "filterName1";

            var expectedUri = new StringBuilder();
            expectedUri.AppendFormat("{0}{1}", this.subscription.ServiceEndpoint, uriSuffix);
            expectedUri.Append("?query1=value1");
            expectedUri.AppendFormat("&$filter={0} eq 'val1'", filterName);
            
            var client = new WAPackIaaSClient(this.subscription);
            client.SetUriSuffix(uriSuffix);
            client.AddHttpFilter(filterName, WebFilterOptions.eq, "val1");
            client.AddQueryParameters("query1", "value1");

            var actualUri = client.GetAbsoluteUri();

            Assert.Equal(expectedUri.ToString(), actualUri);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldGenerateUriWithUriSuffixAndSingleGuidFilter()
        {
            const string uriSuffix = "/myResource";
            const string filterName = "filterName1";

            Guid guidValue = Guid.NewGuid();

            var expectedUri = new StringBuilder();
            expectedUri.AppendFormat("{0}{1}", this.subscription.ServiceEndpoint, uriSuffix);
            expectedUri.AppendFormat("?$filter={0} eq guid'{1}'", filterName, guidValue);

            var client = new WAPackIaaSClient(this.subscription);
            client.SetUriSuffix(uriSuffix);
            client.AddHttpFilter(filterName, WebFilterOptions.eq, guidValue.ToString());
            var actualUri = client.GetAbsoluteUri();

            Assert.Equal(expectedUri.ToString(), actualUri);
        }
    }
}
