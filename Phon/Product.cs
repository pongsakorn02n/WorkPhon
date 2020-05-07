using System;

public class Product : IProduct
{
	private string _SKU;
	public String SKU { get => _SKU; set => _SKU = value; }
	private string _Name;
	public String Name { get => _Name; set => _Name = value; }
	private double _Price;
	public double Price { get => _Price; set => _Price = value; }
}
