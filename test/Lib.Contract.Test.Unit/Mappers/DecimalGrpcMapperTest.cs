using NUnit.Framework;
using POC.Grpc.Lib.Contract.Mappers;
using POC.Grpc.Lib.Contract.Proto.Common.CustomTypes;
using POC.Grpc.Test.Tools.Base;
using POC.Grpc.Test.Tools.Constants;
using System;

namespace POC.Grpc.Lib.Contract.Test.Unit.Mappers
{
    internal class DecimalGrpcMapperTest : UnitTest
    {
        private const decimal NanoFactor = DecimalConstants.NanoFactor;

        [Test]
        [TestCase(-1, 75)]
        [TestCase(-1, 0)]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(1, 75)]
        public void Map_Decimal_To_DecimalGrpc(long units, int nanos)
        {
            var value = Convert.ToDecimal($"{units},{nanos}");
            var decimalGrpc = DecimalGrpcMapper.Map(value);
            var valueDecimal = DecimalGrpcMapper.Map(decimalGrpc);

            TestContext.WriteLine($"Input: {value}");
            TestContext.WriteLine($"Decimal: {valueDecimal}");
            TestContext.WriteLine($"DecimalGrpc: {decimalGrpc}");

            Assert.That(valueDecimal, Is.EqualTo(value));
        }

        [Test]
        [TestCase(-1.75)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(175)]
        public void Map_DecimalGrpc_To_Decimal_Valid_Parameter(decimal value)
        {
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);

            var decimalGrpc = new DecimalGrpc() { Units = units, Nanos = nanos };
            var valueDecimal = DecimalGrpcMapper.Map(decimalGrpc);

            TestContext.WriteLine($"Input: {value}");
            TestContext.WriteLine($"Decimal: {valueDecimal}");
            TestContext.WriteLine($"DecimalGrpc: {decimalGrpc}");

            Assert.That(valueDecimal, Is.EqualTo(value));
        }

        [Test]
        public void Map_DecimalGrpc_To_Decimal_Null_Parameter()
        {
            var valueDecimal = DecimalGrpcMapper.Map(null);

            TestContext.WriteLine($"Decimal: {valueDecimal}");
            TestContext.WriteLine($"DecimalGrpc: {null}");

            Assert.That(valueDecimal, Is.Zero);
        }
    }
}