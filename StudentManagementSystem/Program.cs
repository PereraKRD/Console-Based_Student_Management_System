using StudentManagementSystem;
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Console.WindowWidth = 100;

Console.WriteLine("                              ____ _____ _   _ ____  _____ _   _ _____ \r\n                             / ___|_   _| | | |  _ \\| ____| \\ | |_   _|\r\n                             \\___ \\ | | | | | | | | |  _| |  \\| | | |  \r\n                              ___) || | | |_| | |_| | |___| |\\  | | |  \r\n                             |____/ |_|  \\___/|____/|_____|_| \\_| |_|  \r\n                                                                       \r\n                  __  __    _    _   _    _    ____ _____ __  __ _____ _   _ _____ \r\n                 |  \\/  |  / \\  | \\ | |  / \\  / ___| ____|  \\/  | ____| \\ | |_   _|\r\n                 | |\\/| | / _ \\ |  \\| | / _ \\| |  _|  _| | |\\/| |  _| |  \\| | | |  \r\n                 | |  | |/ ___ \\| |\\  |/ ___ \\ |_| | |___| |  | | |___| |\\  | | |  \r\n                 |_|  |_/_/   \\_\\_| \\_/_/   \\_\\____|_____|_|  |_|_____|_| \\_| |_|  \r\n                                                                                   \r\n                            ______   ______ _____ _____ __  __     _ _ _ \r\n                           / ___\\ \\ / / ___|_   _| ____|  \\/  |   | | | |\r\n                           \\___ \\\\ V /\\___ \\ | | |  _| | |\\/| |   | | | |\r\n                            ___) || |  ___) || | | |___| |  | |   |_|_|_|\r\n                           |____/ |_| |____/ |_| |_____|_|  |_|   (_|_|_)\r\n                                                                         ");

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Press any key to continue...");
Console.ReadKey();

HomeMenu menu = new();
menu.displayMenu();
