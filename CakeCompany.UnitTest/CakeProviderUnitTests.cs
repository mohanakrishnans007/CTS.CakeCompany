using NUnit.Framework;
using System;
using CakeCompany.Models;
using Moq;
using CakeCompany.Provider;
using CakeCompany.Interfaces;

namespace CakeCompany.UnitTest
{
    /// <summary>
    /// CakeProviderUnitTests - unit tests the Cake Provider classes and methods
    /// </summary>
    [TestFixture]
    internal class CakeProviderUnitTests
    {
        /// <summary>
        /// Bake_CheckforCakeTypeChocolate_ReturnProductDetails - checks for the cake type chocolate consuming
        /// Bake method.
        /// </summary>
        [Test]
        public void Bake_CheckforCakeTypeChocolate_ReturnProductDetails()
        {
            //Arrange
            var sampleOrder = new Order
                ("CakeTest", DateTime.Now, 1, Cake.Chocolate, 120.25);

            var mockCakeProvider = new Mock<ICakeProviderInterface>();

            mockCakeProvider.Setup(x => x.Bake(sampleOrder))
                .Returns(new Product { Cake = Cake.Chocolate, Id = Guid.NewGuid(), OrderId = 1, Quantity = 120.25 });
            //Act
            CakeProvider cakeProvider = new CakeProvider();
            var result = cakeProvider.Bake(sampleOrder);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Cake.ToString(), "Chocolate");
        }

        /// <summary>
        /// Bake_CheckforCakeTypeVanilla_ReturnProductDetails - checks for wrong cake type consuming
        /// Bake method.Expected was Chocolate but actual was Vanilla.
        /// </summary>
        [Test]
        public void Bake_CheckforWrongCakeType_ReturnProductDetails()
        {
            //Arrange
            var sampleOrder = new Order
                ("CakeTest", DateTime.Now, 1, Cake.Chocolate, 500);

            var mockCakeProvider = new Mock<ICakeProviderInterface>();

            mockCakeProvider.Setup(x => x.Bake(sampleOrder))
                .Returns(new Product { Cake = Cake.Vanilla, Id = Guid.NewGuid(), OrderId = 1, Quantity = 500 });
            //Act
            CakeProvider cakeProvider = new CakeProvider();
            var result = cakeProvider.Bake(sampleOrder);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Cake.ToString(), "Vanilla");
        }


        /// <summary>
        /// Bake_CheckforCakeTypeVanilla_ReturnProductDetails - checks for wrong cake type consuming
        /// Bake method.Expected was Chocolate but actual was Vanilla.
        /// </summary>
        [Test]
        public void Check_CheckEstimatedCakeBakeTimeChocolate_ReturnEstimatedTime()
        {
            //Arrange
            var sampleOrder = new Order
                ("CakeTest", DateTime.Now, 1, Cake.Chocolate, 500);

            var mockCakeProvider = new Mock<ICakeProviderInterface>();

            mockCakeProvider.Setup(x => x.Check(sampleOrder))
                .Returns(DateTime.Now.Add(TimeSpan.FromMinutes(30)));
            //Act
            CakeProvider cakeProvider = new CakeProvider();
            var result = cakeProvider.Check(sampleOrder);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ToString("MM/dd/yyyy h:mm tt"),
                DateTime.Now.Add(TimeSpan.FromMinutes(30)).ToString("MM/dd/yyyy h:mm tt"));
        }


    }
}
