using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace HexViewer_LucaAlin
{
    internal static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            OpenFileDialog fileExplorer = new OpenFileDialog();
            fileExplorer.ShowDialog();
            String filePath = @fileExplorer.FileName;
            fileExplorer.Dispose();

            byte[] fileBytes = File.ReadAllBytes(filePath);
            List<String> hexContent = new List<string>();
            List<char> textContent = new List<char>();
            
            foreach(byte b in fileBytes)
            {
                hexContent.Add(Convert.ToString(b, 16));
                textContent.Add((char)b);
            }


            bool lastLine = false;
            int listIndex = 0;
            int lineIndex = 0;
            while (lastLine == false)
            {
                Console.Write((Convert.ToString(lineIndex++, 16).ToUpper() + "0").PadLeft(8, '0') + ": ");
                
                for (int i = listIndex; i < listIndex + 16; i++)
                {
                    if (i >= hexContent.Count) Console.Write("   ");
                    else Console.Write(hexContent[i].PadLeft(2, '0').ToUpper() + " ");
                    if ((i + 1) % 8 == 0) Console.Write("| ");
                }
            
                for (int i = listIndex; i < listIndex + 16; i++)
                    if (i >= hexContent.Count)
                    {
                        lastLine = true;
                        Console.Write(" ");
                    }
                    else if (textContent[i] >= 10 && textContent[i] <= 13) Console.Write(".");
                    else Console.Write(textContent[i]);
                
                Console.WriteLine();
                listIndex += 16;
            }
        }
    }
}