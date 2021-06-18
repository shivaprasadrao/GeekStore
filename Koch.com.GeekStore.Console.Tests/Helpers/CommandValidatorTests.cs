namespace Koch.com.GeekStore.Console.Tests.Helpers
{
    using Koch.com.GeekStore.Console.Logic;
    using NUnit.Framework;

    [TestFixture]
    public class CommandValidatorTests
    {
        private GeekStoreService _geekService;

        [SetUp]
        public void SetUp()
        {
            _geekService = new GeekStoreService();
        }

        [TestCase("1", 1)]
        [TestCase("A15", 0)]
        [TestCase("-8", -8)]
        public void ToSafeInt_GivenCommand(string command, int expectedResult)
        {
            // Arrange & Act
            int result = _geekService.ToSafeInt(command);
            // Assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestCase("1", 1)]
        [TestCase("A15", 0)]
        [TestCase("-8", -8)]
        public void ToSafeIntArbitrary_GivenCommand(string command, int expectedResult)
        {
            // Arrange & Act
            var result = _geekService.ToSafeIntArbitrary(command, 0);
            // Assert
            Assert.AreEqual(expectedResult, result.Item1);

        }

        [TestCase("1",-1, 1)]
        [TestCase("A15", -1, -1)]
        [TestCase("-8", -1, -8)]
        public void ToSafeIntArbitrary_DefaultValueTest(string command, int defaultValue, int expectedResult)
        {
            // Arrange & Act
            var result = _geekService.ToSafeIntArbitrary(command, defaultValue);
            // Assert
            Assert.AreEqual(expectedResult, result.Item1);

        }

    }
}
