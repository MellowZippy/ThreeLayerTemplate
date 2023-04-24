using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class CustomerLogic
{
    private List<CustomerModel> _customers;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    
    public CustomerLogic()
    {
        _customers = CustomerAccess.LoadAll();
    }

    public CustomerModel GetById(int id)
    {
        return _customers.Find(i => i.customerId == id)!;
    }    
}
