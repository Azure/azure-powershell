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

using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedCache.Models;
using Microsoft.Azure.Management.ManagedCache.Models;
using Xunit;

namespace Microsoft.Azure.Commands.ManagedCache.Test
{
    public class MemoryDynamicParameterSetTest
    {
        [Fact]
        public void ConstructCorrectDynamicParameterBasedOnCurrentSku()
        {
            //Arrange
            CacheServiceSkuType skuType = CacheServiceSkuType.Standard;
            int expectedValueNumber = 10;
            string minValue = "1GB";
            string maxValue = "10GB";
            string secondMinValue = "2GB";
            string memoryParameterName = "Memory";
            MemoryDynamicParameterSet memoryDynamicParameter = new MemoryDynamicParameterSet();

            //Act
            RuntimeDefinedParameterDictionary parameters = memoryDynamicParameter.GetDynamicParameters(skuType) 
                as RuntimeDefinedParameterDictionary;
            RuntimeDefinedParameter parameter = parameters[memoryParameterName];

            //Assert
            Assert.Equal(memoryParameterName, parameter.Name);
            Assert.Equal(2, parameter.Attributes.Count);
            Assert.True(parameter.Attributes[1] is ValidateSetAttribute);
            ValidateSetAttribute validateSetAttribute = parameter.Attributes[1] as ValidateSetAttribute;
            Assert.Equal(expectedValueNumber, validateSetAttribute.ValidValues.Count);
            Assert.Equal(minValue, validateSetAttribute.ValidValues[0]);
            Assert.Equal(secondMinValue, validateSetAttribute.ValidValues[1]);
            Assert.Equal(maxValue, validateSetAttribute.ValidValues[expectedValueNumber-1]);
        }

        [Fact]
        public void GetCorrectDefaultMemoryValueFromDynamicParameter()
        {
            //Arrange
            CacheServiceSkuType skuType = CacheServiceSkuType.Basic;
            MemoryDynamicParameterSet memoryDynamicParameter = new MemoryDynamicParameterSet();

            //Act
            memoryDynamicParameter.GetDynamicParameters(skuType);
            string memoryValue = memoryDynamicParameter.GetMemoryValue(skuType);

            //Assert
            Assert.Equal("128MB", memoryValue);
        }
    }
}
