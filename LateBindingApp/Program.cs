﻿using System.Reflection;

// This program will load an external library,
// and create an object using late binding.

Console.WriteLine("***** Fun with Late Binding *****");
// Try to load a local copy of CarLibrary.
Assembly a = null;
try
{
    a = Assembly.LoadFrom("CarLibrary");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
    return;
}
if (a != null)
{
    CreateUsingLateBinding(a);
}
Console.ReadLine();

static void CreateUsingLateBinding(Assembly asm)
{
    try
    {
        // Get metadata for the Minivan type.
        Type miniVan = asm.GetType("CarLibrary.MiniVan");
        // Create the Minivan on the fly.
        object obj = Activator.CreateInstance(miniVan);
        Console.WriteLine($"Created a {obj} using late binding!");
        // Get info for TurboBoost.
        MethodInfo mi = miniVan.GetMethod("TurboBoost");
        // Invoke method ('null' for no parameters).
        mi.Invoke(obj, null);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

//static void CreateUsingLateBinding(Assembly asm)
//{
//    try
//    {
//        // Get metadata for the Minivan type.
//        Type miniVan = asm.GetType("CarLibrary.MiniVan");
//        // Create a Minivan instance on the fly.
//        object obj = Activator.CreateInstance(miniVan);
//        Console.WriteLine("Created a {0} using late binding!", obj);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}