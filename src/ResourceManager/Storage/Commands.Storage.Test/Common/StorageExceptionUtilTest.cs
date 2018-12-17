﻿// ----------------------------------------------------------------------------------
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common
{
    /// <summary>
    /// unit test for StorageExceptionUtil
    /// </summary>
    [TestClass]
    public class StorageExceptionUtilTest : StorageTestBase
    {
        [TestMethod]
        public void IsNotFoundExceptionWithoutStatusTest()
        {
            RequestResult result = new RequestResult();
            string message = string.Empty;
            ResourceAlreadyExistException innerException = new ResourceAlreadyExistException(message);
            StorageException exception = new StorageException(result, message, innerException);
            Assert.IsFalse(exception.IsNotFoundException());
        }

        [TestMethod]
        public void IsNotFoundExceptionWithoutInfoTest()
        {
            StorageException exception = new StorageException(null, string.Empty, null);
            Assert.IsFalse(exception.IsNotFoundException());
        }

        [TestMethod]
        public void IsNotFoundExceptionTest()
        {
            RequestResult result = new RequestResult()
            {
                HttpStatusCode = 500
            };
            string message = string.Empty;
            ResourceAlreadyExistException innerException = new ResourceAlreadyExistException(message);
            StorageException exception = new StorageException(result, message, innerException);
            Assert.IsFalse(exception.IsNotFoundException());

            result = new RequestResult()
            {
                HttpStatusCode = 404
            };
            exception = new StorageException(result, message, innerException);
            Assert.IsTrue(exception.IsNotFoundException());
        }

        [TestMethod]
        public void RepackStorageExceptionWithoutInfoTest()
        {
            StorageException exception = new StorageException(null, string.Empty, null);
            Assert.IsNotNull(exception.RepackStorageException());
        }

        [TestMethod]
        public void RepackStorageExceptionWithoutStatusMessageTest()
        {
            RequestResult result = new RequestResult()
            {
                HttpStatusCode = 500
            };
            string message = string.Empty;
            ResourceAlreadyExistException innerException = new ResourceAlreadyExistException(message);
            StorageException exception = new StorageException(result, message, innerException);
            Assert.IsNotNull(exception.RepackStorageException());
        }

        [TestMethod]
        public void RepackStorageExceptionTest()
        {
            string status = String.Empty;
            RequestResult result = new RequestResult()
            {
                HttpStatusCode = 404
            };
            string message = "storage exception";
            ResourceAlreadyExistException innerException = new ResourceAlreadyExistException(message);
            StorageException exception = new StorageException(result, message, innerException);
            exception = exception.RepackStorageException();
            Assert.IsNotNull(exception);
        }
    }
}
