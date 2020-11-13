using NUnit.Framework;
using HSTS_RecipeManager;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using Moq;

namespace HSTS_RecipeManager_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSerialize()
        {
            MyRecipe ar = new MyRecipe();
            Stream stream = File.Open("favourite_recipes.osl", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            try
            {
                b.Serialize(stream, ar);

            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TestDeserialize()
        {
            TestDeserialize();
            Stream stream = File.Open("favourite_recipes.osl", FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            MyRecipe ar = new MyRecipe();
            try
            {
                ar = (MyRecipe)b.Deserialize(stream);
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        
        [Test]
        public void TestInsert()
        {
            //Arrange
            var commandMock = new Mock<IDbCommand>();
            commandMock
                .Setup(m => m.ExecuteNonQuery())
                .Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock
                .Setup(m => m.CreateCommand())
                .Returns(commandMock.Object);

            var connectionFactoryMock = new Mock<IDbConnectionFactory>();
            connectionFactoryMock
                .Setup(m => m.CreateConnection())
                .Returns(connectionMock.Object);

            var sut = new MyDataAccessClass(connectionFactoryMock.Object);
            var name = "Apple Pie";
            var numServe = 8;
            var category = "dessert";
            var prepTime = 50;
            var ingredient = "apple, butter, flour";
            var methods = "Not available";
            //Act
            sut.Insert(name, numServe, category, prepTime, ingredient, methods);

            //Assert
            commandMock.Verify();
        }
        
    }
}