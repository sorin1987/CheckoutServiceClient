using System;
using System.Net;
using Checkout.ApiServices.Cards.RequestModels;
using Checkout.ApiServices.Customers.RequestModels;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture(Category = "DrinksApi")]
    public class DrinksApiTests : BaseServiceTests
    {
        [Test]
        public void CreateDrink()
        {
            var drinkCreateModel = TestHelper.GetDrinkCreateModel();
            var response = CheckoutClient.DrinkService.CreateDrink(drinkCreateModel);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Name.Should().Be("Coca Cola");
        }

        [Test]
        public void DeleteDrink()
        {
            var drink = CheckoutClient.DrinkService.CreateDrink(TestHelper.GetDrinkCreateModel()).Model;

            var response = CheckoutClient.DrinkService.DeleteDrink(drink.Name);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Message.Should().BeEquivalentTo("Ok");
        }

        [Test]
        public void GetDrink()
        {
            var drinkCreateModel = TestHelper.GetDrinkCreateModel();
            var drink = CheckoutClient.DrinkService.CreateDrink(drinkCreateModel).Model;

            var response = CheckoutClient.DrinkService.GetDrink(drink.Name);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Name.Should().Be(drink.Name);
            response.Model.Description.Should().Be("Fizzy Drink");
            drink.ShouldBeEquivalentTo(response.Model);
        }

        [Test]
        public void GetDrinkList()
        {
            var drink1 = CheckoutClient.DrinkService.CreateDrink(TestHelper.GetDrinkCreateModel());
            var drink2 = CheckoutClient.DrinkService.CreateDrink(TestHelper.GetDrinkCreateModel());
            var drink3 = CheckoutClient.DrinkService.CreateDrink(TestHelper.GetDrinkCreateModel());
            var drink4 = CheckoutClient.DrinkService.CreateDrink(TestHelper.GetDrinkCreateModel());

            var response = CheckoutClient.DrinkService.GetDrinkList(new DrinkGetList());

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Count.Should().BeGreaterOrEqualTo(4);

            response.Model.Data[0].Name.Should().Be(drink4.Model.Name);
            response.Model.Data[1].Name.Should().Be(drink3.Model.Name);
            response.Model.Data[2].Name.Should().Be(drink2.Model.Name);
            response.Model.Data[3].Name.Should().Be(drink1.Model.Name);
        }

        [Test]
        public void UpdateDrink()
        {
            var drink = CheckoutClient.DrinkService.CreateDrink(TestHelper.GetDrinkWaterCreateModel()).Model;

            var customerUpdateModel = TestHelper.GetDrinkUpdateModel();
            customerUpdateModel.Description = "Mineral Water";
            var response = CheckoutClient.DrinkService.UpdateDrink(drink.Name, customerUpdateModel);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Message.Should().BeEquivalentTo("Ok");
        }
    }
}
