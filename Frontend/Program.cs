using Backend;

var list = new DoublyLinkedList<string>();
var option = string.Empty;

do
{
    option = Menu();
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
            Console.WriteLine("List ordered in descending order.");
            break;
        case "5":
            Console.WriteLine(list.GetModes());
            break;
        case "6":
            Console.WriteLine(string.Join("\n", list.GetGraph()));
            break;

        case "7":
            Console.WriteLine("Enter value to search: ");
            if (list.Contains(Console.ReadLine()!))
            {
                Console.WriteLine("Exist");
            }
            else
            {
                Console.WriteLine("Not Exist");
            }

            break;
        case "8":
            var datoEliminado = list.RemoveFirst();
            if (datoEliminado != null && !datoEliminado.Equals(default))
            {
                Console.WriteLine($"Se ha eliminado el primer elemento de la lista: {datoEliminado}");
            }
            else
            {
                Console.WriteLine("La lista está vacía, no hay elementos para eliminar.");
            }
            break;
        case "9":
            list.Clear();
            Console.WriteLine("Remove all dates");
            break;
    }
} while (option != "0");
Console.WriteLine("Exiting the program. Goodbye!");

string Menu()
{
    Console.WriteLine("1. To add");
    Console.WriteLine("2. Show Forward list.");
    Console.WriteLine("3. Show Reverse list.");
    Console.WriteLine("4. Order Descending.");
    Console.WriteLine("5. Mode");
    Console.WriteLine("6. Graphis");
    Console.WriteLine("7. Exist");
    Console.WriteLine("8. Remove occurrence.");
    Console.WriteLine("9. Remove All.");
    Console.WriteLine("0. Exit.");
    Console.Write("Enter your option? ");
    return Console.ReadLine()!;
}