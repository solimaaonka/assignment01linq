using LINQ.DataSources;

class Program
{
    static void Main()
    {
        var products = Source.ProductList;
        var customers = Source.CustomerList;

        Console.WriteLine("===== Q1: Seafood products =====");
        var q1 = products.Where(p => p.Category == "Seafood");
        foreach (var p in q1)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        Console.WriteLine("\n===== Q2: Product names =====");
        var q2 = products.Select(p => p.ProductName);
        foreach (var name in q2)
            Console.WriteLine(name);

        Console.WriteLine("\n===== Q3: Sorted by UnitPrice (asc) =====");
        var q3 = products.OrderBy(p => p.UnitPrice);
        foreach (var p in q3)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        Console.WriteLine("\n===== Q4: UnitPrice between 10 and 30 =====");
        var q4 = products.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
        foreach (var p in q4)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        Console.WriteLine("\n===== Q5: In-stock Condiments =====");
        var q5 = products.Where(p => p.UnitsInStock > 0 && p.Category == "Spices & Condiments");
        foreach (var p in q5)
            Console.WriteLine($"{p.ProductName} (Stock: {p.UnitsInStock})");

        Console.WriteLine("\n===== Q6: Anonymous type =====");
        var q6 = products.Select(p => new
        {
            Name = p.ProductName,
            Price = p.UnitPrice,
            StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
        });
        foreach (var item in q6)
            Console.WriteLine($"{item.Name} | {item.Price} | {item.StockStatus}");

        Console.WriteLine("\n===== Q7: Name with position =====");
        var q7 = products.Select((p, i) => $"{i + 1}. {p.ProductName}");
        foreach (var line in q7)
            Console.WriteLine(line);

        Console.WriteLine("\n===== Q8: Category asc, UnitPrice desc =====");
        var q8 = products.OrderBy(p => p.Category)
                         .ThenByDescending(p => p.UnitPrice);
        foreach (var p in q8)
            Console.WriteLine($"{p.Category} | {p.ProductName} | {p.UnitPrice}");

        Console.WriteLine("\n===== Q9: Beverages by stock (desc) =====");
        var q9 = products.Where(p => p.Category == "Beverages")
                         .OrderByDescending(p => p.UnitsInStock);
        foreach (var p in q9)
            Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");

        Console.WriteLine("\n===== Q10: Orders from 1997 or later =====");
        var q10 = from c in customers
                  from o in c.Orders
                  where o.OrderDate.Year >= 1997
                  select new { c.CustomerID, o.OrderDate };
        foreach (var item in q10)
            Console.WriteLine($"{item.CustomerID} - {item.OrderDate:yyyy-MM-dd}");

        Console.WriteLine("\n===== Q11: Position + ProductName =====");
        var q11 = products.Select((p, i) => new { Position = i + 1, p.ProductName });
        foreach (var item in q11)
            Console.WriteLine($"{item.Position} - {item.ProductName}");

        Console.WriteLine("\n===== Q12: Words sorted =====");
        string[] arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        var q12 = arr.OrderBy(w => w.Length)
                     .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
        foreach (var w in q12)
            Console.WriteLine(w);

        Console.WriteLine("\n===== Q13: Digits with 'i' as 2nd letter (reversed) =====");
        string[] digits = { "zero", "one", "two", "three", "four",
                            "five", "six", "seven", "eight", "nine" };
        var q13 = digits.Where(d => d.Length > 1 && d[1] == 'i')
                        .Reverse()
                        .ToList(); 
        foreach (var d in q13)
            Console.WriteLine(d); 
    }
}
