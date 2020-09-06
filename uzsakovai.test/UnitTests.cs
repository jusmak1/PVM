using NSubstitute;
using System;
using Xunit;
using Contractors;
using Classes;

namespace uzsakovai.test
{
    public class UnitTests
    {
        private ServiceProvider serviceProvider;
        private Client client;

        [Fact]
        public void ShouldReturnZerothenServiceProviderIsNotVATpayer()
        {
            //Arange
            SubsituteClasses();
            serviceProvider.IsVATPayer = false;

            //Act
            var VAT = serviceProvider.CalculateVAT(client);

            //Assert
            Assert.Equal(0, VAT);
        }


        [Fact]
        public void ShouldReturnZerothenServiceProviderIsVATpayerAndClientDoesntLiveInEU()
        {
            //Arange
            SubsituteClasses();
            serviceProvider.IsVATPayer = true;

            client.Location =  new Location() { Continent = "USA", Country = "Cleveland" };

            //Act
            var VAT = serviceProvider.CalculateVAT(client);

            //Assert
            Assert.Equal(0, VAT);
        }

        [Fact]
        public void ShouldReturnXCountryVATifServiceProviderIsVATpayerAndClientIsNotAndBothLiveInDifferentCountry()
        {
            //Arange
            SubsituteClasses();
            serviceProvider.IsVATPayer = true;
            client.IsVATPayer = false;

            client.Location = new Location() { Continent = "EU", Country = "Lithuania", VATinPercent = 21 };
            serviceProvider.Location = new Location() { Continent = "EU", Country = "Latvia", VATinPercent = 20 };

            //Act
            var VAT = serviceProvider.CalculateVAT(client);

            //Assert
            Assert.Equal(21, VAT);
        }

        [Fact]
        public void ShouldReturnZeroIfServiceProviderIsVATpayerAndClientIsAlsoAndBothLiveInInDifferentCountry()
        {
            //Arange
            SubsituteClasses();
            serviceProvider.IsVATPayer = true;
            client.IsVATPayer = true;

            client.Location = new Location() { Continent = "EU", Country = "Lithuania", VATinPercent = 21 };
            serviceProvider.Location = new Location() { Continent = "EU", Country = "Latvia", VATinPercent = 22 };

            //Act
            var VAT = serviceProvider.CalculateVAT(client);

            //Assert
            Assert.Equal(0, VAT);
        }

        [Fact]
        public void ShouldReturnVATIfBothLivesInTheSameCountry()
        {
            //Arange
            SubsituteClasses();
            serviceProvider.IsVATPayer = true;
            client.IsVATPayer = true;

            client.Location = new Location() { Continent = "EU", Country = "Lithuania", VATinPercent = 21 };
            serviceProvider.Location = new Location() { Continent = "EU", Country = "Lithuania", VATinPercent = 21 };

            //Act
            var VAT = serviceProvider.CalculateVAT(client);

            //Assert
            Assert.Equal(21, VAT);
        }


        private void SubsituteClasses()
        {
           serviceProvider = Substitute.For<ServiceProvider>();
           client = Substitute.For<Client>();
        }
    }
}
