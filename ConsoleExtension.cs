using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MovieRental.Models;
using CommandDotNet;
using CommandDotNet.Rendering;
using ConsoleTables;

namespace MovieRental
{
    internal static class ConsoleExtensions
    {
        internal static void DisplayTable<T>(this IConsole console, IEnumerable<T> values)
        {
            var table = ConsoleTable.From(values);
            console.Write(table);
        }
    }
}