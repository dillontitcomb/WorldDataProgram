using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldDataProgram.Models;
using System;
using System.Collections.Generic;

namespace WorldDataProgram.Tests
{
  [TestClass]
  public class CityTests: IDisposable
  {
    public void Dispose()
    {
      City.DeleteAll();
    }
    public CityTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
    }
    [TestMethod]
    public void GetAll_DataBaseAtFirst_0()
    {
      //Arrange, Act
      int result = City.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void Save_SavesToDatabase_CityList()
    {
      //Arrange
      City newTestyCity = new City(3, "Boston", "USA", "Hood", 12345);
      City newTestyCity2 = new City(3, "Boston", "USA", "Hood", 12345);

      //Assert
      Assert.AreEqual(newTestyCity, newTestyCity2);
    }

  }
}
