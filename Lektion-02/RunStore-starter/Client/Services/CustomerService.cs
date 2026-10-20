using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Client.Interfaces;
using Client.Models;
using Client.Views;
using Microsoft.Data.Sqlite;

namespace Client.Services;

public class CustomerService : ICustomerService
{
    private readonly string _path;
    private readonly Storage<Customer> _storage;

    public CustomerService()
    {
        _path = string.Concat(Environment.CurrentDirectory, "/Data/customers.json");
        _storage = new();
    }

    public void Add(Customer customer)
    {
        throw new NotImplementedException();
    }

    public List<Customer> ListAll()
    {
        var customers = _storage.Read(_path);
        return customers;
    }

    
}
