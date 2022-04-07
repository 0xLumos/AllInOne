using AllInOne.ViewModels;
using FluentAssertions;
using NUnit.Framework;

namespace AllInOneTests
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
        public void LoginTitle()
        {
            var loginViewModel = new ItemsViewModel();
            loginViewModel.Title.Should().Be("AI1");
        }
    }
}