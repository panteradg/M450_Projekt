using Preisvergleich.FetchData;
using Preisvergleich.DataAccess;
using Preisvergleich.FetchData.PageObjectModels;


HomePage digitecHomePage = new HomePage(new DigitecHomePageMap());
HomePage interdiscountHomePage = new HomePage(new InterdiscountHomePageMap());
HomePage microspotHomePage = new HomePage(new MicrospotHomePageMap());

DataLoader dataLoader = new DataLoader();

bool canContinue = true;
do
{
    Console.Clear();
    Console.WriteLine("\nWhat do you want to do?\n1\tGet new Data\n2\tCompare a product\n3\tExit application");
    var input = Console.ReadKey();
    switch (input.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("\nGetting Data...");
            GetData();
            Console.WriteLine("\nData saved");
            break;
        case ConsoleKey.D2:
            Console.WriteLine("\nWhat is the name of the product you want to compare?");
            ComparePrice(Console.ReadLine());
            break;
        case ConsoleKey.D3:
            canContinue = false;
            break;
        default:
            break;  
    }
    Console.ReadKey();
} while (true);


void GetData()
{
    if (WebUiDriver.driver == null)
    {
        WebUiDriver.Init();
    }
    foreach (string product in dataLoader.Products)
    {
        foreach (Website website in Enum.GetValues(typeof(Website)))
        {
            decimal result;
            switch (website)
            {
                case Website.Digitec:
                    result = digitecHomePage.GetPrice(product);
                    break;
                case Website.Interdiscount:
                    result = interdiscountHomePage.GetPrice(product);
                    break;
                case Website.Microspot:
                    result = microspotHomePage.GetPrice(product);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            dataLoader.AddProduct(product, website, result);
        }
    }
    dataLoader.SaveData();
}

void ComparePrice(string product)
{
    if(dataLoader.ProductFromWebsiteListList.Count() == 0)
    {
        Console.WriteLine("\nNo data...");
    }
    else
    {
        List<ProductFromWebsite> products = dataLoader.ProductFromWebsiteListList.Last().Where(x => x.Product == product).ToList();
        Console.WriteLine($"\nProduct shown: {product}");
        foreach (ProductFromWebsite productFromWebsite in products)
        {
            Console.WriteLine($"{productFromWebsite.Website}:\t{productFromWebsite.Price}");
        }
    }
}