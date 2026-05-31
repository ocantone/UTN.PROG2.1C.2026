using System;
using System.Collections.Generic;

Console.WriteLine("Hello, World!\nEnter cads:");
string cad;
while ( (cad=Console.ReadLine().ToUpper()) != "FIN" )
{
    Console.WriteLine(cad);
}
Console.WriteLine(cad+" Bye, World!");
