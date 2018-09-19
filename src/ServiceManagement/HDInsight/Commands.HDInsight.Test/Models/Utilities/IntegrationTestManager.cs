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
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities
{
    public class IntegrationTestManager
    {
        public IntegrationTestManager()
        {
            this.InitializeCredentialSets();
        }

        private void InitializeCredentialSets()
        {
            var defaultCredentialSet = new AzureTestCredentials()
            {
                AccessToken = Guid.NewGuid().ToString("N"),
                AzurePassword = "HDInsight123!",
                AzureUserName = "HDInsightUser",
                Certificate = @"MIIKJAIBAzCCCeQGCSqGSIb3DQEHAaCCCdUEggnRMIIJzTCCBe4GCSqGSIb3DQEHAaCCBd8EggXbMIIF1zCCBdMGCyqGSIb3DQEMCgECoIIE7jCCBOowHAYKKoZIhvcNAQwBAzAOBAi3trgRTVm06gICB9AEggTIlm0GB/VlsXv0K7CYreHb8OG+QfqJFpTlZAlGZhdm3i/bdCS86gnX4+F8SfW/x4f3nPnDIW50Avf0e9uULXBPIKvLKjQJL1xSOm+R1L1LVV/g4cXuK3jjCreDJaYVhhr2cmo2mrRCmyHePED39h0oBmwABRR/b49HcUQGTYN+dgh3ZcrhfLqrePhcufCaVREepJ6KNgIjYyPxoj2CU43maNiDwS1jl2rCbSe9EwLsvabV0yngHZZKtdOtwD14f6sbTJd3IlxNR+ohQZ2sP182PhCWGavHtDPagbj0CnVNl6zVQKqjQGbide8Nu6jskQxtmcQ0OriUHTz7ZsH6dJXhLBdxY8wYzZlCooOWei58HehWacPfC2RxG2uZz5Yq1ARoU9Py+L0j5SGg6/WhZNEakRDfVtwm2ias97jy/U+534UdeQobTQeZrKTpoYCaVBpd1FRt7s9LBP2z3wp84FdjI2QbvnHey/NS3ACplejOX5ZeHXRqJQhzLy2BFdmMXpS+eX8iqhVkXFzDEoJJtX7DlSdCvfFVODw2lz5DvxJidPayadDrh1WVpZTI/y5UtSrBiU9Z+xiE5FmgIK6i5WPxkoxIDcyeshlY6uyubdJi//EAe9+J7Lhenn20UgoVG7X9wnPiQIGfaTAXiVVbHf4ZvKogoLk03lFCGJhJDLbo5X6wvDOP0uY+zgnSPqoajv2pm/Znuwr7EdE5PLzNxuM0fFcO60+Fk/uwp9cL/jtN5EZ2jx83JR/zighBr2rJokDnaOMD7LQLwEooNL2kPrXLxr7KbwNzTpLB99spBSqdMC/W4y3elyJsquvopt5FAveLbXYV0auGe/3RSu8WXebTlVHjikJgZi/rpsyA0GG8sjixXAUcCyJLGKcxkFsk5+duds1RkoRo81+1PNlxQjFptqgKzHp0oDHswZgFBXZkq7Fa1anTqrH9qBOuY8xa0bgA6/XcUEvcWqWYpCTL1z0T3FwtraOSpg8SvLFoIGoVkEMzBAMHIq0KVDyTINE7SGOlPDHkkw1X7Hq1xItKjh9iJ3B6jp0nKmV+tqDeIOUgtNhQwAs8cpIAgXLq9zUL9nUDiYvqZnV9+uqO/j6/Ushq3+bHRa6aJh2750siwwF1n3sYG7rDykWH9BqtBJHgrzSfepxzJNOFEgwIAAm578iKAofEf9takCVmj1ndKRBiqRxA+qHOxKkE7D8CmrNvpz8Q1bz0WFVgP6XIQJquM9az9jf6VvTU9p4qrI/NQ8sdUtNEO1uwqzwrSf2sLAIVyNXjA1KrubRVNZn+qnTaoF0uEZce4foIBSxuHRF+ZFpbhC3QM6f6xuYIpMhnfSEt76Xo3D66pmOmcQmhjVMp1QbxdoBCtsPhCsGGKGfCdDBdMm5EHvB7PXHFEoxBoVKLGReuHRLMgVv+8eaa0rIGAXbxFOXff+UZKthXoI/MsBDzP9EMly83GH0VOePVgLixNZgx9rcAL91o2l+s8i1ZNklqe85XUQUmzJJ3UHRUJo1Bwcgg47RR+gJpZ5N8ArVB9TxSKUyKignQ6Hmo4CMrPaj+/4JovzxWz8MviteHxYhSkpgmFKPqe7H1UtD8Ri5t5XwdPKpGOjthUtDsFMfH/u8Mp61wMjE8ec8pMYHRMBMGCSqGSIb3DQEJFTEGBAQBAAAAMFsGCSqGSIb3DQEJFDFOHkwAewBGAEUAMABCAEMAOQAyADYALQBFADYAMwA0AC0ANABBAEQAOQAtADgAOQA3ADIALQA3AEMAMAA4AEUANgAzAEUANwA4ADIARgB9MF0GCSsGAQQBgjcRATFQHk4ATQBpAGMAcgBvAHMAbwBmAHQAIABTAG8AZgB0AHcAYQByAGUAIABLAGUAeQAgAFMAdABvAHIAYQBnAGUAIABQAHIAbwB2AGkAZABlAHIwggPXBgkqhkiG9w0BBwagggPIMIIDxAIBADCCA70GCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEGMA4ECCBMrMfW/pLnAgIH0ICCA5ACNbwiA1a9rPXiCXXjyUB2R/UQeRCOZQpt0RJyY+thE8POzrwXOudXtM4lZjAd8XMSvSrojC+lN+yKdjjrcN7L5rWQP+TCCilaO4LpEcso1xTe65NH7yMQzNXSKCkmzIToqcp12vh4DiYg9aT1m968c7KcyoJcvt2qn5ezcKSyv0dHZdKt9RNr3mPsPxA7vMesC6wsHRr0nCkvo8sgPTMgZdJIM0pLqyBEmZPTHz15dcUzNOb7A+5pi7vdzJ7ezalrG8jyHdBpnBp+7ct/5DzZALawWdngR5mbxbDqxooO+8hWH15DpsEvBjqt6AUwsVl4iszlCrdafqJHW5igmA8TC69NS1OerueU6VYcZBD1kf/T5Jt+ax9rq5NgQ0HrQwAbFeS+nnFABHJWFrzF79sfgT3i185ke5qYllN9ttX2Fh14HkJ/ZvlKOVsPkmEKbmWq83SQ9DNsL46ltjWB/krTWA836UVUtrXwKYRVmMKrleLNmpwKCoZ4En3G2ZHyOaRYcDGm3Sc0ZM7OgdSOnvGiOCo4FAUjV8K2ZtNAkxLJ4aoLV6qJqEaoSvNNCpBD8B8ZgjwoyG5JEE4SE/pJBOQPmqmbys5+wXIif76TBKy8aIFv2zuMZjSdF9I0Ma6gI23jO94HGsXPin/ed2PAn9WGhaqqQ+vQ9YUnfXRq/xucQ3X550pwUdEVTlB9F7zGe4H2p8eHUqJUd8acZeghTOOJsQYfeP2al8yS9NKwQsYMjEPal8Jvf6shZJ0M0g4LwxAXFk9FUzWubNT3nYqVYOteMpCUswBW+qCwZ9fMEOV/U77ESP0IAP1Lmec2i5Az3Efj1XIDu0xJxCTY/s0ZpJeNx/kIVtlPZPFAOPh18EJk75jyAcU8JkTkKwB5Vppi0k8BRdWONkH1zTApaQxX0wO4nsN+BKL730kvI/2Hx1Hf1z7RXpTFBzjoEjFO6HkQKC63aun4JK3MO51FgxXAjgvF36PLBF2NwwHRXIChwY4NawSPfG2Vy0LXfgNU/LnSdK5TI+YvAq/Z1MWtvRcV9f5323vtieEZ2LP7xhQ5TDyEE2WJagn5GuUM5h17x2a5VhXw2tLZYyyqrdbZh/aB6qIEtbD/wrirqj2Cb/T27G1Ya4GuQRTYIzSeD1NQ0wamBZo7FlmLHRo9gwaiGK1MFZgZp/6xbdleKGCvEyvrPzhPDbkO2yuz4TyOpL5S4nmb+mEwNzAfMAcGBSsOAwIaBBSi0CmFbjfFF5eZ3Ew3lnTrOvlZRwQUx15wNo0WgvIEMjLF9YCzvK0PTXE=",
                CloudServiceName = "HDInsight",
                SubscriptionId = new Guid("e4c4bcab-7e3b-4439-9919-d2e607f10286"),
                CredentialsName = "default",
                Endpoint = "https://management.core.windows.net:8443/",
                HadoopUserName = "HDInsightUser",
                WellKnownCluster =
                    new KnownCluster()
                    {
                        Cluster = "https://AzureHDInsightTestCluster.AzureHDInsight.net",
                        DnsName = "AzureHDInsightTestCluster",
                        Version = "1.6"
                    },
                Environments = new CreationDetails[]
                {
                    new CreationDetails()
                    {
                        Location="East US 2",
                        HiveStores = new MetastoreCredentials[]
                        {
                          new MetastoreCredentials()
                          {
                              Database = "Hivemetabase",
                              Description="Hive metabase",
                              SqlServer ="hive.sql.server.azure.net"
                          }  
                        },
                        OozieStores = new MetastoreCredentials[]
                        {
                          new MetastoreCredentials()
                          {
                              Database = "ooziemetabase",
                              Description="oozie metabase",
                              SqlServer ="oozie.sql.server.azure.net"
                          }  
                        },
                        DefaultStorageAccount = new StorageAccountCredentials()
                        {
                            Container = "deployment1",
                            Key = Guid.NewGuid().ToString("N"),
                            Name = "defaultstorageaccount.blob.core.windows.net"
                        },
                        AdditionalStorageAccounts = new StorageAccountCredentials[]
                        {
                            new StorageAccountCredentials()
                            {
                                Container = "deployment1",
                                Key = Guid.NewGuid().ToString("N"),
                                Name = "additionaltorageaccount1.blob.core.windows.net"
                            },
                            new StorageAccountCredentials()
                            {
                                Container = "deployment1",
                                Key = Guid.NewGuid().ToString("N"),
                                Name = "additionaltorageaccount2.blob.core.windows.net"
                            }
                        }
                    }
                }
            };

            this.credentialSets.Add("default", defaultCredentialSet);
        }

        private readonly Dictionary<string, AzureTestCredentials> credentialSets = new Dictionary<string, AzureTestCredentials>();

        public IEnumerable<AzureTestCredentials> GetAllCredentials()
        {
            return this.credentialSets.Values;
        }

        public AzureTestCredentials GetCredentials(string name)
        {
            AzureTestCredentials creds = null;
            this.credentialSets.TryGetValue(name, out creds);
            return creds;
        }
    }
}
