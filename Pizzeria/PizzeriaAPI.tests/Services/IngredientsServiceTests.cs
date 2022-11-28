using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PizzeriaAPI.Services;
using PizzeriaAPI.Services.Interface;
using PizzeriaAPI.tests.TestHelpers;
using PizzeriaShared.Models;

namespace PizzeriaAPI.tests.Services
{
    [TestFixture]    
    public class IngredientsServiceTests
    {
        private TestApplicationDbContext _testApplicationDbContext = null!;
        private IIngredientService _ingredientsService = null!;

        [SetUp]
        public void SetUp()
        {
            _testApplicationDbContext = new TestApplicationDbContext();
            _ingredientsService = new IngredientsService(_testApplicationDbContext.applicationDbContext!);
        }

        [TearDown]
        public void TearDown()
        {
            _testApplicationDbContext.Dispose();
        }

        [Test]
        public async Task CreateIngredient_NameIsNull_ReturnNull()
        {
            //GWT - given, when, then
            //AAA - arrange, act, assert

            //Arrange
            const string name = null!;

            //Act
            var result = await _ingredientsService.CreateIngredient(name!);

            //Assert
            result.Should().Be(null!);
        }

        [Test]
        public async Task CreateIngredient_NameIsEmpty_ReturnNull()
        {
            //GWT - given, when, then
            //AAA - arrange, act, assert

            //Arrange
            var name = string.Empty;

            // string.Empty = "";

            //Act
            var result = await _ingredientsService.CreateIngredient(name!);

            //Assert
            result.Should().Be(null!);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(999)]
        public async Task CreateIngredient_IdIsIncorrect_ReturnNull(int id)
        {


            //Arrange
            _testApplicationDbContext.applicationDbContext!.Ingredients!.Add(new Ingredient { Id = 1, Name = "Test" });
            _testApplicationDbContext.applicationDbContext.SaveChanges();
            //Act
            var result = await _ingredientsService.GetIngredientById(id);

            //Assert
            result.Should().Be(null!);
        }

        [Test]
        public async Task CreateIngredient_CorrectScenario_ReturnNull()
        {
            const int correctId = 1;

            //Arrange
            _testApplicationDbContext.applicationDbContext!.Ingredients!.Add(new Ingredient { Id = correctId, Name = "Test" });
            _testApplicationDbContext.applicationDbContext.SaveChanges();
            //Act
            var result = await _ingredientsService.GetIngredientById(correctId);

            //Assert
            result.Should().BeOfType<Ingredient>();
        }
    }
}
