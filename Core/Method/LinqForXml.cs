using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Core.Method
{
    public class LinqForXml
    {
        public void SelectWords()
        {
            XDocument xDoc = XDocument.Load(@"C:\Users\dell\Source\Repos\MyProject\RepeatWord\Core\RepeatWords.xml");
            var xmlquery = (from item in xDoc.Descendants("Kelimeler")
                            where
                            Convert.ToInt32(item.Element("Tekrar").Value) > 1000
                            select new {
                                Words=item.Element("Kelime").Value,
                                Counter=item.Element("Tekrar").Value
                            } ).ToList();
            foreach (var item in xmlquery)
            {
                Console.WriteLine($"Kelimeler:{item.Words} Tekrar:{item.Counter}");
            }
        }

    }
}
