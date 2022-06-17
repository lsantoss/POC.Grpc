using NUnit.Framework;

namespace POC.Grpc.Test.Tools.Base
{
    [TestFixture]
    public class UnitTest : BaseTest
    {
        public UnitTest() : base() { }

        [OneTimeSetUp]
        protected override void OneTimeSetUp() => base.OneTimeSetUp();

        [OneTimeTearDown]
        protected override void OneTimeTearDown() => base.OneTimeTearDown();

        [SetUp]
        protected override void SetUp() => base.SetUp();

        [TearDown]
        protected override void TearDown() => base.TearDown();
    }
}