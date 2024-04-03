using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagementSystem
{
    public class HomeMenu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public int SelectedItem { get; set; }
        public List<MenuItem> Items { get; set; } // creating a list of type MenuItem. And the name of the list is Items

        public HomeMenu()
        { // overloaded ctor
            ColPos = 10;
            RowPos = 5;
            SelectedItem = 0;
            Items = new List<MenuItem> // enetering data into the list.
            {
                new MenuItem("        A D D   U S E R",true),
                new MenuItem("     S E L E C T   U S E R", false),
                new MenuItem("     D E L E T E   U S E R", false),
                new MenuItem("D I S P L A Y   A L L   U S E R S", false),
                new MenuItem("            Q U I T", false)
            };
        }

        public void displayMenu()
        {
            List<Student> students = new List<Student>() { 
                new Student (1, "Ryan", "Perera", "01/05/2000", "341, Neluthota Rd, Delaura"), 
                new Student (2, "Lasith", "Perera", "21/05/2000", "341, kolathota Rd, Delaura"), 
                new Student (3, "Nithil", "Perera", "11/04/2030", "341, Nelutala Rd, Delaura"),
                new Student (4, "Adeesha", "Gunathilake", "31/08/2000", "341, marathota Rd, Delaura"), 
                new Student (5, "Marco", "Perera", "16/09/2030", "341, Neliwalla Rd, Delaura") };
            int StudentID = 6;
            Console.CursorVisible = false;
            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine(" --M A I N   M E N U-- ");
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.SetCursorPosition((ColPos+20), (RowPos + i*2));
                    if (Items[i].IsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(Items[i].Title);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Items[i].Title);
                    }
                }
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Items[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem + 1) % Items.Count;
                    Items[SelectedItem].IsSelected = true;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Items[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem - 1);
                    if (SelectedItem < 0)
                    {
                        SelectedItem = (Items.Count - 1);
                    }
                    Items[SelectedItem].IsSelected = true;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    if (Items[SelectedItem].Title == "        A D D   U S E R")  // ADD USER IMPLEMENTATION
                    {

                        Console.Clear();
                        Console.Write("F I R S T   N A M E : ");
                        string firstName = Console.ReadLine();
                        Console.Write("L A S T   N A M E : ");
                        string lastName = Console.ReadLine();
                        Console.Write("D A T E   O F   B I R T H (DD/MM/YYYY) : ");
                        string dateOfBirth = Console.ReadLine();
                        Console.Write("R E S I D E N T I A L   A D D R E S S : ");
                        string address = Console.ReadLine();

                        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(dateOfBirth) || string.IsNullOrEmpty(address))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nV A L U E S   C A N N O T   BE   N U L L!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();  

                        }
                        else
                        {
                            Student student = new Student(StudentID, firstName, lastName, dateOfBirth, address);
                            students.Add(student);
                            Console.WriteLine();
                            Console.WriteLine(". . U S E R   A D D E D   S U C C E S S F U L L Y . .");
                            StudentID++;
                            Console.Beep();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }

                    }

                    if (Items[SelectedItem].Title == "     D E L E T E   U S E R") // DELETE USER IMPLEMENTATION
                    {
                        Console.Clear();
                        int userID;
                        try { //EXCEPTION HANDLER FOR userID
                            Console.Write("E N T E R   S T U D E N T   I D: ");
                            userID = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            userID = 0;
                            Console.WriteLine();
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("!!! -I N V A L I D   I N P U T- !!!");
                            Console.ReadKey();
                            continue;
                        }
                        bool found = false;
                        if (students.Count == null)
                        {
                            Console.WriteLine(". . S T U D E N T   L I S T   I S   E M P T Y . .");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Press any key...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            foreach (Student student in students)
                            {
                                if (student.ID == userID)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("                            -U S E R   D E T A I L S-           ");
                                    Console.WriteLine("  ___________________________________________________________________________");
                                    Console.WriteLine("  |                                                                         | ");
                                    Console.WriteLine("       I D                                      :" + student.ID);
                                    Console.WriteLine("       F I R S T   N A M E                      :" + student.FirstName);
                                    Console.WriteLine("       L A S T   N A M E                        :" + student.LastName);
                                    Console.WriteLine("       D A T E   O F   B I R T H                :" + student.DateOfBirth);
                                    Console.WriteLine("       R E S I D E N T I A L   A D D R E S S    :" + student.Address);
                                    Console.WriteLine("  |                                                                         | ");
                                    Console.WriteLine("  --------------------------------------------------------------------------- ");
                                    Console.WriteLine();
                                    Console.WriteLine("A R E   Y O U   S U R E   Y O U   W A N T   T O   D E L E T E ? (y/n)");
                                    char confirm;
                                    try
                                    {
                                        confirm = Convert.ToChar(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        confirm = 'w';
                                        Console.WriteLine("!!! -I N V A L I D   I N P U T- !!!");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    if (confirm == 'y' || confirm == 'Y')
                                    {
                                        students.Remove(student);
                                        Console.WriteLine(". . S T U D E N T   D E L E T E D   S U C C E S S F U L L Y . .");
                                        Console.Beep();
                                        found = true;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Press any key...");
                                        Console.ReadKey();

                                    }
                                    else if (confirm == 'n' || confirm == 'N')
                                    {
                                        Console.WriteLine(". . Y O U   S E L E C T E D   N O   A N D   S T U D E N T   N O T   D E L E T E D . .");
                                        found = true;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Press any key...");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(". . Y O U R   C H O I C E   I S   W R O N G :( . .");
                                        Console.ReadLine();
                                        found= true;
                                    }
                                    break;  
                                }
                            }
                            if(found==false)
                            {
                                Console.WriteLine("!!! -I N V A L I D   S T U D E N T   I D   O R   S T D E N T   A L R E A D Y   D E L E T E D- !!!");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Press any key...");
                                Console.ReadKey();
                            }
                        }
                    }

                    if (Items[SelectedItem].Title == "     S E L E C T   U S E R") // SELECT USER IMPLEMENTATION
                    {
                        Console.Clear();
                        int userID;
                        try
                        {
                            Console.Write("E N T E R   S T U D E N T   I D : ");
                            userID = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            userID = 0;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!!! -I N V A L I D   I N P U T- !!!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        bool found = false;
                        if (students.Count == null)
                        {
                            Console.WriteLine(". . S T U D E N T   L I S T   I S   E M P T Y . .");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Press any key...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            foreach (Student student in students)
                            {
                                if (student.ID == userID)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("                            -U S E R   D E T A I L S-           ");
                                    Console.WriteLine("  ___________________________________________________________________________");
                                    Console.WriteLine("  |                                                                         | ");
                                    Console.WriteLine("       I D                                      :" + student.ID);
                                    Console.WriteLine("       F I R S T   N A M E                      :" + student.FirstName);
                                    Console.WriteLine("       L A S T   N A M E                        :" + student.LastName);
                                    Console.WriteLine("       D A T E   O F   B I R T H                :" + student.DateOfBirth);
                                    Console.WriteLine("       R E S I D E N T I A L   A D D R E S S    :" + student.Address);
                                    Console.WriteLine("  |                                                                         | ");
                                    Console.WriteLine("  --------------------------------------------------------------------------- ");
                                    Console.WriteLine();
                                    Console.WriteLine("I S   T H I S   T H E   S T U D E N T   Y O U A R E   L O O K I N G   F O R ? (y/n)");
                                    found = true;
                                    char confirm;
                                    try
                                    {
                                        confirm = Convert.ToChar(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        confirm = 'w';
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("!!! - I N V A L I D   I N P U T - !!!");
                                        Console.ResetColor();
                                        Console.ReadLine();
                                        continue;
                                    }
                                    if (confirm == 'y' || confirm == 'Y')
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        SelectUserMenu Smenu = new SelectUserMenu();
                                        Smenu.DisplayUserMenu(student, students);
                                    }
                                    else if (confirm == 'n' || confirm == 'N')
                                    {
                                        Console.WriteLine("Y O U   S E L E C T E D   N O . .");
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Press any key...");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(". . Y O U R   C H O I C E   I S   W R O N G :( . .");
                                        Console.ResetColor();
                                        Console.ReadLine();
                                    }
                                    break;
                                }
                            }
                            if (found == false)
                            {
                                Console.WriteLine("!!! -I N V A L I D   S T U D E N T   I D   O R   S T D E N T   A L R E A D Y   D E L E T E D- !!!");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Press any key...");
                                Console.ReadKey();
                            }
                        }
                    }


                    if (Items[SelectedItem].Title == "D I S P L A Y   A L L   U S E R S") // DISPLAY ALL USER IMPLEMENTATION

                    {
                        Console.Clear();
                        Console.WriteLine("                     -U S E R   L I S T-                ");
                        Console.WriteLine("____________________________________________________________");
                        Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", "ID", "First Name", "Last Name", "Date of Birth", "GPA");
                        Console.WriteLine("============================================================");
                        foreach (Student student in students)
                        {
                            Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", student.ID, student.FirstName, student.LastName, student.DateOfBirth, student.CalculateGPA());
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press any key to go back to main menu...");
                        Console.ReadKey();

                    }
                    if (Items[SelectedItem].Title == "            Q U I T") // QUIT THE PROGRAM
                        running = false;
                }
            }
        }
    }
}
