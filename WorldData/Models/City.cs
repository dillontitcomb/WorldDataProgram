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

  public int getId()
  {
    return _id;
  }

  public string getName()
  {
    return _name;
  }

  public string getCountryCode()
  {
    return _countryCode;
  }

  public string getDistrict()
  {
    return _district;
  }

  public int getPopulation()
  {
    return _population;
  }

  public static List<City> GetAll()
  {
    List<City> allCities = new List<City> {};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM city;";
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
