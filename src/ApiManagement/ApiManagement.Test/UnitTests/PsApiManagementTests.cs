using Microsoft.Azure.Commands.ApiManagement.ServiceManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.ApiManagement.Test.UnitTests
{
    [Trait(Category.AcceptanceType, Category.CheckIn)]
    public class PsApiManagementTests
    {
        public PsApiManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            global::Microsoft.Azure.ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new global::Microsoft.Azure.ServiceManagement.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        public void DictionaryToHashTable_PreservesNullEntriesAndMixedValues()
        {
            var dictionary = new Dictionary<string, IList<string>>
            {
                ["sig"] = null,
                ["token"] = new[] { "abc", "def" },
                ["empty"] = Array.Empty<string>(),
                ["mixed"] = new[] { "first", null, "third" }
            };

            var hashTable = Utils.DictionaryToHashTable(dictionary);

            Assert.NotNull(hashTable);
            Assert.Null(hashTable["sig"]);
            Assert.Equal(new object[] { "abc", "def" }, (object[])hashTable["token"]);
            Assert.IsType<object[]>(hashTable["empty"]);
            Assert.Empty((object[])hashTable["empty"]);
            Assert.Equal(new object[] { "first", null, "third" }, (object[])hashTable["mixed"]);
        }

        [Fact]
        public void DictionaryToHashTable_DoesNotThrowForRedactedNullValues()
        {
            var dictionary = new Dictionary<string, IList<string>>
            {
                ["header"] = null,
                ["query"] = new[] { "version=1" }
            };

            var exception = Record.Exception(() => Utils.DictionaryToHashTable(dictionary));

            Assert.Null(exception);
            Assert.Null(((Hashtable)Utils.DictionaryToHashTable(dictionary))["header"]);
            Assert.Equal(new object[] { "version=1" }, (object[])Utils.DictionaryToHashTable(dictionary)["query"]);
        }
    }
}
