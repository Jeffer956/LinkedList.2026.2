using Backend;

var list = new DoublyLinkedList<string>();
var option = string.Empty;

do
{
    option = Menu();
    Console.WriteLine();
    switch (option)
    {
        case "1":
            Console.Write("Enter value: ");
            list.Add(Console.ReadLine()!);
            break;
        case "2":
            Console.WriteLine(list.ToStringForward());
            break;
        case "3":
            Console.WriteLine(list.ToStringReverse());
            break;
        case "4":
            list.OrderDescending();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine( "List ordered in descending order." );
            Console.WriteLine("-----------------------------------");
            break;
        case "5":
            Console.WriteLine(list.GetModes());
            break;
        case "6":
            Console.WriteLine("--- Frequency Graphics ---");
            var graph = list.GetGraph();
            Console.WriteLine(graph.Count > 0 ? string.Join("\n", graph) : "The list is empty.");
            break;

        case "7":
            Console.Write("Enter value to search: ");
            var searchVal = Console.ReadLine()!;
            if (list.Contains(searchVal))
            {
                Console.WriteLine($"\n[✓] '{searchVal}' exists in the list.");
            }
            else
            {
                Console.WriteLine($"\n[X] '{searchVal}' does not exist in the list.");
            }
            break;
        case "8":
            var datoEliminado = list.RemoveFirst();
            if (datoEliminado != null && !datoEliminado.Equals(default))
            {
                Console.WriteLine($"The first element has been removed from the list {datoEliminado}");
            }
            else
            {
                Console.WriteLine("The list is empty, there are no elements to remove.");
            }
            break;
        case "9":
            list.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|         Remove all dates        |");
            Console.WriteLine("-----------------------------------");
            break;
    }
} while (option != "0");
Console.WriteLine("Exiting the program. Goodbye!");
Console.ReadKey();

string Menu()
{
    Console.WriteLine("===================================");
    Console.WriteLine("            MAIN MENU              ");
    Console.WriteLine("===================================");
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show Forward list.");
    Console.WriteLine("3. Show Reverse list.");
    Console.WriteLine("4. Order Descending.");
    Console.WriteLine("5. Mode");
    Console.WriteLine("6. Show chart");
    Console.WriteLine("7. Exist");
    Console.WriteLine("8. Remove occurrence.");
    Console.WriteLine("9. Remove All.");
    Console.WriteLine("0. Exit.");
    Console.WriteLine("===================================");
    Console.Write("Enter your option? ");
    return Console.ReadLine()!;
}