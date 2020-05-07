using System;
using System.Collections.Generic;
using System.Text;

public interface IProduct
{
    String SKU { get; set; }
    String Name { get; set; }
    double Price { get; set; }
}
