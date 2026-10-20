using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using Microsoft.Data.Sqlite;

namespace Client.Services;

public class ProductService : IProductService
{
    private readonly string _path = string.Empty;
    private readonly Storage<Product> _storage;

    public ProductService()
    {
        _path = "Data Source=Runbase.db";
        
    }
    public void Add(Product product)
    {
        var products = ListAll();
        products.Add(product);
        _storage.Write(_path, products);
    }

    public List<Product> ListAll()
    {
        try
        {
            List<Product>products = [];
            using SqliteConnection connection = new(_path);
            using SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Products";
            connection.Open();

            using SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
            }
            return products;
        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

    private Product CreateProduct(SqliteDataReader reader)
    {
        return new Product()
        {
            Id = reader.GetString(0),
            
        };
    }
}
