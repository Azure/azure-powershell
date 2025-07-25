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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.KeyVault.Test.Models
{
    public class PSKeyVaultCertificatePolicyTests
    {
        public PSKeyVaultCertificatePolicyTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        #region Create CertificatePolicy Tests
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithNoKeyTypeAndKeySize_SucceedsWithRsaKeyTypeAnd2048KeySize()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: string.Empty,
                keySize: 0,
                curve: string.Empty,
                exportable: null,
                certificateTransparency: null);

            Assert.Equal(Constants.RSA, policy.Kty);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(2048, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithRsaKeyTypeAndNoKeySize_SucceedsWith2048KeySize()
        {
            var keyType = Constants.RSAHSM;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: string.Empty,
                exportable: null,
                certificateTransparency: null);

            Assert.Equal(policy.Kty, keyType);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(2048, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithRsaKeyTypeAndCurve_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.RSA,
                    keySize: 0,
                    curve: Constants.P256,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithEccKeyTypeAndNoCurve_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 0,
                    curve: string.Empty,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithEcKeyTypeP256CurveAndNoKeySize_SucceedsWith256KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.P256;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(256, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithEcKeyTypeP256KCurveAndNoKeySize_SucceedsWith256KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.P256K;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(256, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithEcKeyTypeSECP256K1CurveAndNoKeySize_SucceedsWith256KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.SECP256K1;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(256, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithEcKeyTypeP384CurveAndNoKeySize_SucceedsWith384KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.P384;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(384, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithEcKeyTypeP521CurveAndNoKeySize_SucceedsWith521KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.P521;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(521, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithRsaKeyTypeAnd256KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.RSA,
                    keySize: 256,
                    curve: string.Empty,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithRsaKeyTypeAnd384KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.RSA,
                    keySize: 384,
                    curve: string.Empty,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithRsaKeyTypeAnd521KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.RSA,
                    keySize: 521,
                    curve: string.Empty,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithECKeyTypeAnd2048KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 2048,
                    curve: Constants.P256,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithECKeyTypeAnd3072KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 3072,
                    curve: Constants.P256,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithECKeyTypeAnd4096KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 4096,
                    curve: Constants.P256,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithECKeyTypeP256CurveAndNot256KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 1,
                    curve: Constants.P256,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithECKeyTypeP256KCurveAndNot256KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 1,
                    curve: Constants.P256K,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithECKeyTypeSECP256K1CurveAndNot256KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 1,
                    curve: Constants.SECP256K1,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithECKeyTypeP384CurveAndNot384KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 1,
                    curve: Constants.P384,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithECKeyTypeP521CurveAndNot521KeySize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 1,
                    curve: Constants.P521,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithOneLifetimeAction_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: 1,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null);

            Assert.NotNull(policy.RenewAtNumberOfDaysBeforeExpiry);
            Assert.Equal(1, policy.RenewAtNumberOfDaysBeforeExpiry.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithMoreThanOneLifetimeAction_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: 1,
                    renewAtPercentageLifetime: 1,
                    emailAtNumberOfDaysBeforeExpiry: 1,
                    emailAtPercentageLifetime: 1,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 256,
                    curve: Constants.P256,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithNoEku_SucceedsWithNullEku()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: new List<string>(),
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null);

            Assert.Null(policy.Ekus);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithEmptyEku_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: new List<string>() { string.Empty },
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 256,
                    curve: Constants.P256,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithNoDnsName_SucceedsWithNullDnsName()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: new List<string>(),
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null);

            Assert.Null(policy.Ekus);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithEmptyDnsName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: new List<string>() { string.Empty },
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: string.Empty,
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 256,
                    curve: Constants.P256,
                    exportable: null,
                    certificateTransparency: null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCertificatePolicy_WithInValidSubjectName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new PSKeyVaultCertificatePolicy(
                    dnsNames: null,
                    keyUsages: null,
                    ekus: null,
                    enabled: null,
                    issuerName: string.Empty,
                    certificateType: string.Empty,
                    renewAtNumberOfDaysBeforeExpiry: null,
                    renewAtPercentageLifetime: null,
                    emailAtNumberOfDaysBeforeExpiry: null,
                    emailAtPercentageLifetime: null,
                    reuseKeyOnRenewal: null,
                    secretContentType: string.Empty,
                    subjectName: "SubjectName",
                    validityInMonths: null,
                    keyType: Constants.EC,
                    keySize: 256,
                    curve: Constants.P256,
                    exportable: null,
                    certificateTransparency: null));
        }
        #endregion

        #region Validate CertificatePolicy Tests
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithNoKeyTypeAndKeySize_SucceedsWithRsaKeyTypeAnd2048KeySize()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: string.Empty,
                keySize: 0,
                curve: string.Empty,
                exportable: null,
                certificateTransparency: null);
            policy.Validate();

            Assert.Equal(Constants.RSA, policy.Kty);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(2048, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithRsaKeyTypeAndNoKeySize_SucceedsWith2048KeySize()
        {
            var keyType = Constants.RSAHSM;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: string.Empty,
                exportable: null,
                certificateTransparency: null);
            policy.Validate();

            Assert.Equal(policy.Kty, keyType);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(2048, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithRsaKeyTypeAndCurve_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.RSA,
                keySize: 0,
                curve: string.Empty,
                exportable: null,
                certificateTransparency: null)
            {
                Curve = Constants.P256,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithEccKeyTypeAndNoCurve_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 0,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                Curve = string.Empty,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithEcKeyTypeP256CurveAndNoKeySize_SucceedsWith256KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.P256;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);
            policy.Validate();

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(256, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithEcKeyTypeP256KCurveAndNoKeySize_SucceedsWith256KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.P256K;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);
            policy.Validate();

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(256, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithEcKeyTypeSECP256K1CurveAndNoKeySize_SucceedsWith256KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.SECP256K1;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);
            policy.Validate();

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(256, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithEcKeyTypeP384CurveAndNoKeySize_SucceedsWith384KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.P384;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);
            policy.Validate();

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(384, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithEcKeyTypeP521CurveAndNoKeySize_SucceedsWith521KeySize()
        {
            var keyType = Constants.EC;
            var curve = Constants.P521;
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: keyType,
                keySize: 0,
                curve: curve,
                exportable: null,
                certificateTransparency: null);
            policy.Validate();

            Assert.Equal(policy.Kty, keyType);
            Assert.Equal(policy.Curve, curve);
            Assert.NotNull(policy.KeySize);
            Assert.Equal(521, policy.KeySize.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithRsaKeyTypeAnd256KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.RSA,
                keySize: 0,
                curve: string.Empty,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize= 256,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithRsaKeyTypeAnd384KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.RSA,
                keySize: 0,
                curve: string.Empty,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize = 384,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithRsaKeyTypeAnd521KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.RSA,
                keySize: 0,
                curve: string.Empty,
                exportable: null,
                certificateTransparency: null)
                {
                    KeySize = 521,
                };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithECKeyTypeAnd2048KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 0,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize = 2048,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithECKeyTypeAnd3072KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 0,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize = 3072,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithECKeyTypeAnd4096KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 0,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize = 4096,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithECKeyTypeP256CurveAndNot256KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 0,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize = 1,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithECKeyTypeP256KCurveAndNot256KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 0,
                curve: Constants.P256K,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize = 1,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithECKeyTypeSECP256K1CurveAndNot256KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 0,
                curve: Constants.SECP256K1,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize = 1,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithECKeyTypeP384CurveAndNot384KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 0,
                curve: Constants.P384,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize = 1,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithECKeyTypeP521CurveAndNot521KeySize_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 0,
                curve: Constants.P521,
                exportable: null,
                certificateTransparency: null)
            {
                KeySize = 1,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithOneLifetimeAction_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                RenewAtNumberOfDaysBeforeExpiry = 1,
            };
            policy.Validate();

            Assert.NotNull(policy.RenewAtNumberOfDaysBeforeExpiry);
            Assert.Equal(1, policy.RenewAtNumberOfDaysBeforeExpiry.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithMoreThanOneLifetimeAction_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                RenewAtNumberOfDaysBeforeExpiry = 1,
                RenewAtPercentageLifetime = 1,
                EmailAtNumberOfDaysBeforeExpiry = 1,
                EmailAtPercentageLifetime = 1,
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithNoEku_SucceedsWithNullEku()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: new List<string>(),
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null);

            policy.Validate();
            Assert.Null(policy.Ekus);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithEmptyEku_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                Ekus = new List<string>() { string.Empty },
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithNoDnsName_SucceedsWithNullDnsName()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: new List<string>(),
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null);
            policy.Validate();

            Assert.Null(policy.Ekus);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithEmptyDnsName_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                DnsNames = new List<string>() { string.Empty },
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCertificatePolicy_WithInValidSubjectName_ThrowsException()
        {
            var policy = new PSKeyVaultCertificatePolicy(
                dnsNames: null,
                keyUsages: null,
                ekus: null,
                enabled: null,
                issuerName: string.Empty,
                certificateType: string.Empty,
                renewAtNumberOfDaysBeforeExpiry: null,
                renewAtPercentageLifetime: null,
                emailAtNumberOfDaysBeforeExpiry: null,
                emailAtPercentageLifetime: null,
                reuseKeyOnRenewal: null,
                secretContentType: string.Empty,
                subjectName: string.Empty,
                validityInMonths: null,
                keyType: Constants.EC,
                keySize: 256,
                curve: Constants.P256,
                exportable: null,
                certificateTransparency: null)
            {
                SubjectName = "SubjectName",
            };

            Assert.Throws<ArgumentException>(() => policy.Validate());
        }
        #endregion
    }
}
