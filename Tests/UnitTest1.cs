using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using Moq;

namespace Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_Should_Sum_Two_Integers()
        {
            // Arrange
            var mockNotifier = new Mock<UnitTestingDemo2.INotify>();
            var calculator = new UnitTestingDemo2.Calculator(mockNotifier.Object);
            var expected = 5;

            // Act
            var actual = calculator.Add(2, 3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_Should_Notify()
        {
            // Arrange
            var mockNotifier = new Mock<UnitTestingDemo2.INotify>();
            var calculator = new UnitTestingDemo2.Calculator(mockNotifier.Object);
            var expected = 5;

            // Act
            var actual = calculator.Add(2, 3);

            // Assert
            mockNotifier.Verify(x => x.Send("Add was called with a result of : 5"), Times.Once);
        }
    }
}
