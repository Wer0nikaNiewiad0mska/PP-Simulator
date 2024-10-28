using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    public required string Description 
    { 
        get => description; 
        init
        {
            string trimmedDescription = value.Trim();
            if (trimmedDescription.Length < 3)
            {
                trimmedDescription = trimmedDescription.PadRight(3, '#');
            }
            else if (trimmedDescription.Length > 15)
            {
                trimmedDescription = trimmedDescription.Substring(0, 15).TrimEnd();
                if (trimmedDescription.Length < 3) trimmedDescription = trimmedDescription.PadRight(3, '#');
            }
            description = char.ToUpper(trimmedDescription[0]) + trimmedDescription.Substring(1);
        }
    }
    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
