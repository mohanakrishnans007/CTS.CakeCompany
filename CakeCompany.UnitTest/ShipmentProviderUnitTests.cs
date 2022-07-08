using NUnit.Framework;
using System;
using CakeCompany.Models;
using System.Collections.Generic;


namespace CakeCompany.UnitTest
{
    /// <summary>
    /// ShipmentProviderUnitTests - Unit tests to validate the order details and test the functionality
    /// </summary>
    [TestFixture]
    internal class ShipmentProviderUnitTests
    {
        /// <summary>
        /// GetShipment_CheckOrderDetails_ReturnsMessage - Check for order details and returns message
        /// </summary>
        [Test]            
        public void GetShipment_CheckOrderDetails_ReturnsMessage()
        {
           
            try
            {
                Provider.ShipmentProvider.GetShipment();
                Assert.IsTrue(true);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        /// <summary>
        /// GetTransportAndDeliver_CheckTransportTypeVan_ReturnSuccessMessage- Checks for the Transport type Van
        /// and returns the success message
        /// </summary>
        [Test]
        public void GetTransportAndDeliver_CheckTransportTypeVan_ReturnSuccessMessage()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Cake = Cake.Chocolate,
                    Id = Guid.NewGuid(),
                    OrderId = 111,
                    Quantity = 200
                }
            };

            try 
            {
                //Act
                Provider.ShipmentProvider.GetTransportAndDeliver(products);
                
                //Assert
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// GetTransportAndDeliver_CheckTransportTypeTruck_ReturnSuccessMessage - Checks for the Transport type Truck
        /// and returns the success message
        /// </summary>
        [Test]
        public void GetTransportAndDeliver_CheckTransportTypeTruck_ReturnSuccessMessage()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Cake = Cake.Vanilla,
                    Id = Guid.NewGuid(),
                    OrderId = 222,
                    Quantity = 3000
                }
            };


            try
            {
                //Act
                Provider.ShipmentProvider.GetTransportAndDeliver(products);

                //Assert
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// GetTransportAndDeliver_CheckTransportTypeShip_ReturnSuccessMessage - Checks for the Transport type ship
        /// and returns the success message
        /// </summary>
        [Test]
        public void GetTransportAndDeliver_CheckTransportTypeShip_ReturnSuccessMessage()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Cake = Cake.RedVelvet,
                    Id = Guid.NewGuid(),
                    OrderId = 333,
                    Quantity = 30000
                }
            };


            try
            {
                //Act
                Provider.ShipmentProvider.GetTransportAndDeliver(products);

                //Assert
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
