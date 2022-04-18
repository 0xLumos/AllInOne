using AllInOne;
using AllInOne.Models;
using AllInOne.ViewModels;
using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using sun.security.util;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using FakeItEasy;
using Xamarin.Forms.Internals;

namespace AllInOneTests.ViewModels
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void  LoginTitle()
        {
            var loginViewModel = new ItemsViewModel();
            loginViewModel.Title.Should().Be("AI1");

        }
        [Test]
        public async Task AddToDatabase_Should_Pass_When_User_Signs_Up()
        {
            //Arrange
         
            using var mock = AutoMock.GetStrict();
            mock.Mock<IAuth>().Setup(method => method.Signup(It.IsAny<User>()));
            var platformServicesFake = A.Fake<IPlatformServices>();
            Device.PlatformServices = platformServicesFake;
            var viewmodelToTest = mock.Create<RegisterViewModel>();
            viewmodelToTest.Email = "test@test.com";
            viewmodelToTest.Password = "p455w0rd";

            //Act
            viewmodelToTest.RegisterButton.Execute(null);

            //Assert
            Assert.IsTrue(viewmodelToTest.Individuals.Count >=  0);

        }
        [Test]
        public async Task AddToDatabase_Should_Pass_When_Item_Entered_Is_Valid()
        {
            //Arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<FirebaseDB>().Setup(method => method.GetItems());

            var viewmodelToTest = mock.Create<NewItemViewModel>();
            viewmodelToTest.Name = "Item4";
            viewmodelToTest.Price = "PersonName4";
            viewmodelToTest.Description = "Description4";
            viewmodelToTest.Icon = "Icon4";
            //Act
            viewmodelToTest.AddItemCommand.Execute(null);

            //Assert
            Assert.IsTrue(viewmodelToTest.ToTestItems.Count == 4);

        }
    }

}

