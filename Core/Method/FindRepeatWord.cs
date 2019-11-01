using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Core.Method
{
    public class FindRepeatWord
    {
        private StreamReader reader;
        private Dictionary<string, int> wordsAndCounter;
        private List<Entities.Words> GetWords = new List<Entities.Words>();
        public bool ReadInText()
        {
            try
            {
                reader = new StreamReader(@"C:\Users\dell\Source\Repos\MyProject\RepeatWord\Core\MobyDick.txt");
                wordsAndCounter = new Dictionary<string, int>();
                string _line = reader.ReadLine();
                while (_line != null)
                {
                    var _word = _line.ToLower().Split(' ', ',', '.', '!', '-', '"', '?', ';', ':', '(', ')', '*');
                    for (int i = 0; i < _word.Length; i++)
                    {
                        if (wordsAndCounter.ContainsKey(_word[i]))
                        {
                            int _counter = wordsAndCounter[_word[i]];
                            wordsAndCounter[_word[i]] = _counter + 1;
                        }
                        else
                        {
                            wordsAndCounter.Add(_word[i], 1);
                        }
                    }
                    _line = reader.ReadLine();
                }
                reader.Close();
                foreach (var item in wordsAndCounter)
                {
                    //Console.WriteLine($"Anahtar kelime:{item.Key} || Tekrarlanma Sayısı:{item.Value}");
                    GetWords.Add(new Entities.Words()
                    {
                        Word = item.Key,
                        Counter = item.Value
                    });
                }
                return true;
            }
            catch (IOException ioex)
            {
                Console.WriteLine($"hata mesajı:{ioex.Message} - hata basamağı:{ioex.StackTrace}");
                return false;
            }
        }
        public bool WriteInXml()
        {
            try
            {
                XDocument xDoc = new XDocument(
                    new XDeclaration("1.1", "UTF-8", "yes"),
                    new XElement("TekrarEdenKelimeListesi",
                    GetWords.Select(I => new XElement("Kelimeler",
                    new XElement("ID", I.ID),
                    new XElement("Kelime", I.Word),
                    new XElement("Tekrar", I.Counter)
                    ))));
               xDoc.Save(@"C:\Users\dell\Source\Repos\MyProject\RepeatWord\Core\RepeatWords.xml");
                return true;
            }
            catch (IOException ioex)
            {
                Console.WriteLine($"hata mesajı:{ioex.Message} - hata basamağı:{ioex.StackTrace}");
                return false;
            }
        }
        public void ReadInXml()
        {
            try
            {
                XDocument xDoc = XDocument.Load(@"C:\Users\dell\Source\Repos\MyProject\RepeatWord\Core\RepeatWords.xml");
                List<XElement> GetXElement = xDoc.Descendants("Kelimeler").ToList();
                foreach (var item in GetXElement)
                {
                    GetWords.Add(new Entities.Words()
                    {
                        ID = Convert.ToInt32(item.Element("ID").Value),
                        Word =  item.Element("Kelime").Value,
                        Counter = Convert.ToInt32(item.Element("Tekrar").Value)
                    });
                }
                foreach (var item in GetWords)
                {
                    Console.WriteLine($"Anahtar ID:{item.ID} Anahtar kelime:{item.Word} || Tekrarlanma Sayısı:{item.Counter}");
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine($"hata mesajı:{ioex.Message} - hata basamağı:{ioex.StackTrace}");
            }
        }
    }
}
