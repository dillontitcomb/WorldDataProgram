using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldDataProgram;
using System;

namespace WorldDataProgram.Models
{
  public class City
  {
    private int _id;
    private string _name;
    private string _countryCode;
    private string _district;
    private int _population;

  public City(int id, string name, string countryCode, string district, int population)
  {
    _id = id;
    _name = name;
    _countryCode = countryCode;
    _district = district;
    _population = population;
  }

  public override bool Equals(System.Object otherCity)
  {
    if (!(otherCity is City))
    {
      return false;
    }
    else
    {
      City newCity = (City) otherCity;
      bool descriptionEquality = (this.GetName() == newCity.GetName());
      return (descriptionEquality);
    }
  }

  public int GetId()
  {
    return _id;
  }

  public string GetName()
  {
    return _name;
  }
  // 
  // public void Save()
  // {
  //   MySqlConnection conn = DB.Connection();
  //   conn.Open();
  //
  //   var cmd = conn.CreateCommand() as MySqlCommand;
  //   cmd.CommandText = @"INSERT INTO 'city' ('name') VALUES (@CityName);";
  //
  //   MySqlParameter newCityName = new MySqlParameter();
  //   newCityName.ParameterName = "@CityName";
  //   newCityName.Value = this._name;
  //   cmd.Parameters.Add(newCityName);
  //
  //   cmd.ExecuteNonQuery();
  //
  //   conn.Close();
  //   if (conn != null)
  //   {
  //     conn.Dispose();
  //   }
  // }
  public string GetCountryCode()
  {
    return _countryCode;
  }

  public string GetDistrict()
  {
    return _district;
  }

  public int GetPopulation()
  {
    return _population;
  }
  public void SetPopulation(int population)
  {
    _population = population;
  }

  public static void DeleteAll()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();

    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"DELETE FROM city;";

    cmd.ExecuteNonQuery();

    conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  public static List<City> GetMostPopulous(int inputPopulation)
  {
    List<City> allCities = new List<City> {};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM city WHERE population > '" + inputPopulation + "' ORDER BY population DESC;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
      int id = rdr.GetInt32(0);
      string name = rdr.GetString(1);
      string countryCode = rdr.GetString(2);
      string district = rdr.GetString(3);
      int population = rdr.GetInt32(4);
      City newCity = new City(id, name, countryCode, district, population);
      allCities.Add(newCity);
    }
    conn.Close();
    if (conn !=null)
    {
      conn.Dispose();
    }
    return allCities;
  }

  public static List<City> GetAll()
  {
    List<City> allCities = new List<City> {};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM city ;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
      int id = rdr.GetInt32(0);
      string name = rdr.GetString(1);
      string countryCode = rdr.GetString(2);
      string district = rdr.GetString(3);
      int population = rdr.GetInt32(4);
      City newCity = new City(id, name, countryCode, district, population);
      allCities.Add(newCity);
    }
    conn.Close();
    if (conn !=null)
    {
      conn.Dispose();
    }
    return allCities;
    }
  }
}
