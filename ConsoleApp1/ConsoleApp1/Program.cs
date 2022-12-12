
using ConsoleApp1;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

Queue<Order> orders = new Queue<Order>(5);
double finalPrice = 0;
Boolean finishOrder = false;

do
{
    Console.Clear();
    Console.WriteLine("------ MENU -------");
    Console.ReadKey();
    Product selectedProduct = SelectProducts();
    Order orderGetted = GetOrder(selectedProduct);
    orders.Enqueue(orderGetted);
    Console.WriteLine("--------------------");
    Console.WriteLine("Would you like anything else");
    Console.WriteLine("Press  (1) to keep ordering or any key to finish");
    string answer = Console.ReadLine();
    if (answer == "1")
    {
        finishOrder = false;
            
    }
    else finishOrder = true;
    
}
while (!finishOrder && orders.Count < 5 );
Console.Clear();
finalPrice=CalculateFinalPrice(orders);
Console.WriteLine("-------BILL --------- ");
Billing(finalPrice, orders);



static void Billing(double finalPrice, Queue<Order> orders)
{
    int counter = 1;
    Console.WriteLine("Write your name please");
    string fullname = Console.ReadLine();

    Console.WriteLine("write your NIT");
    string nit = Console.ReadLine();

    Console.WriteLine("------- GENERANDO FACTURA --------- ");
    foreach (Order order in orders)
    {
       
        Console.Write($"Order number {counter} you order {order.Quantity} {order.Product}(s) with the subtotal of{order.Subtotal}\n");
        counter++;
    }
    
    Console.WriteLine($"------- nombre     :  {fullname} ");
    Console.WriteLine($"------- nit        :  {nit} ");
    Console.WriteLine($"------- precioTotal:  {finalPrice} ");
    
}

static Product SelectProducts()
{
    Product product= Product.Unkown;
    Console.WriteLine(
    "Welcome to this italian restaurant!\nSelect your dishes from this menu (enter the number of the dish)");
    Console.WriteLine(
    "---DISHES---\n1.-Spaguetti --> $10.99\n2.-Lasagna--> $12.99\n3.-Pizza--> $8\n4.-Calzone--> $6");
    Console.WriteLine("---BEVERAGES---\n5.-Soda --> $6.5\n6.-Wine --> $9\n7.-Beer --> $7.5");


    string option = Console.ReadLine();
    switch (option)
    {
        case "1":
            product = Product.Spaguetti;
        
        break;
        case "2":
            product = Product.Lasagna;
        
        break;
        case "3":
            product = Product.Pizza;
        break;
        case "4":
            product = Product.Calzone;
        break;
        case "5":
            product = Product.Soda;
        break;
        case "6":
            product = Product.Wine;
        break;
        case "7":
            product = Product.Beer;
        break;
        default:
            Console.WriteLine("opcion invalida");
        break;
        
    }
    
    return product;
}
static Order GetOrder(Product product)
{
    Order order=new Order();
    double selectedPrice = 0;
    double priceSpaguetti = 10.99, priceLasagna = 12.99, pricePizza = 8, priceCalzone = 6;
    double priceSoda = 6.5, priceWine = 9, priceBeer = 7.5;
    


    
    switch (product)
    {
        case Product.Spaguetti:
            selectedPrice = priceSpaguetti;

            break;
        case Product.Lasagna:
            selectedPrice = priceLasagna;

            break;
        case Product.Pizza:
            selectedPrice = pricePizza;
            break;
        case Product.Calzone:
            selectedPrice = priceCalzone;
            break;
        case Product.Soda:
            selectedPrice = priceSoda;
            break;
        case Product.Wine:
            selectedPrice = priceWine;
            break;
        case Product.Beer:
            selectedPrice = priceBeer;
            break;
        default:
            selectedPrice= 0;
            break;

    }
    double selectedQuantity = SelectProductQuantity();

    double subtotal = CalculateSubTotal(selectedPrice, selectedQuantity);
    order.Product = product;
    order.Quantity = selectedQuantity;
    order.Subtotal = subtotal;
    return order;
}
static double SelectProductQuantity()
{
    Console.WriteLine("How many of this option do you want?");
    double quantity = Convert.ToInt32(Console.ReadLine());
    return quantity;
}
static double CalculateSubTotal(double productPrice, double productQuantity)
{
    double calculatedPrice = productPrice*productQuantity;
    return calculatedPrice;
}
static double CalculateFinalPrice (Queue<Order> orders)
{
    double calculatedFinalPrice = 0;
    foreach (Order order in orders)
    {
        calculatedFinalPrice += order.Subtotal;
    }
    return calculatedFinalPrice;
}