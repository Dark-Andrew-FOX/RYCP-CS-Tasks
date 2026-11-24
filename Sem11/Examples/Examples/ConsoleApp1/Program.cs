//// Program
//MessageHandler? handler = PrintMessage;
//handler += PrintWarning;
//handler += PrintMessage;

//handler -= PrintMessage;

//handler?.Invoke("Simple message");

//static void PrintMessage(string message)
//{
//    Console.WriteLine(message);
//}

//static void PrintWarning(string message)
//{
//    Console.WriteLine($"Warning: {message}");
//}


//public delegate void MessageHandler(string message);

//int? digit = null;


//-----------------------2
//// Program
//MessageHandler handler = null;
//handler?.Invoke("Simple message");

//static void PrintMessage(string message)
//{
//    Console.WriteLine(message);
//}

//static void PrintWarning(string message)
//{
//    Console.WriteLine($"Warning: {message}");
//}


//public delegate void MessageHandler(string message);


////-----------------------3

//Action<string> handler = PrintMessage;

//handler?.Invoke("Hello!");


//static void PrintMessage(string message)
//{
//    Console.WriteLine(message);
//}

////-----------------------4 Func (последний -- возвращает).
//Console.WriteLine(CalculateDamage(10, (arg) => arg));

//Console.WriteLine(CalculateDamage(10, (arg) => {
//    Console.WriteLine(arg * 2);
//    return arg * 2;
//}));

//static int CalculateDamage(int damage, Func<int, int> modifier)
//{
//    return modifier(damage);
//}

////static int NormalDamage(int damage)
////{
////    return damage;
////}

////static int CriticalDamage(int damage)
////{
////    return damage * 2;
////}
///

////-----------------------5
Chest chest = new Chest();
chest.Opened += () => Console.WriteLine("Opened chest!!");
chest.Open();

// Уязвимости:
chest.Opened?.Invoke();
chest.Opened = null;
// Как решить: превратить делегат в событие.
// вместо: public Action Opened;
// написать: public event Action Opened;

public class Chest
{
    public Action Opened;

    public void Open()
    {
        Opened?.Invoke();
    }
}

