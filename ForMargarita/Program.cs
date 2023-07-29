using System.Text.RegularExpressions;
namespace ForMargarita
{
    public class DESCRIBE
    {
        public string describe { get; set; }
        public string en { get; set; }
        public string ru { get; set; }
    }
    internal class Program
    {
        static List<DESCRIBE> CreateDescribe(string name, string wikiData, List<DESCRIBE> list)
        {
            string DES = "CHARACTERS." + name + ".DESCRIBE.";
            string DES2 = "CHARACTERS." + name + ".DESCRIBE_";
            string DES3 = "CHARACTERS." + name + ".ANNOUNCE";
            string DES4 = "CHARACTERS." + name + ".ACTIONFAIL";
            string DES5 = "CHARACTERS." + name + ".BATTLECRY";
            string DES6 = "CHARACTERS." + name + ".COMBAT";
            var str = wikiData.Split("#.");
            foreach (string s in str)
            {
                if (s.Contains(DES) || s.Contains(DES2)|| s.Contains(DES3)|| s.Contains(DES4)|| s.Contains(DES5)|| s.Contains(DES6))
                {
                    
                    Regex regex = new Regex(@"msgid.+\n", RegexOptions.Singleline);
                    MatchCollection matches = regex.Matches(s);
                    string e = matches[0].Value;
                    string[] tmp = e.Split("\n");
                    DESCRIBE temp = new DESCRIBE();

                    if (s.Contains(DES) || s.Contains(DES2))
                    {

                        Regex regexDES = new Regex(@"DESCRIBE.+\n");
                        MatchCollection matchesDES = regexDES.Matches(s);


                        string[] tmp1 = matchesDES[0].Value.Split("\n");

                      
                        temp.describe = "#." + tmp1[0];
                        temp.ru = tmp[1].Replace("msgstr", "").Trim();
                        temp.en = tmp[0].Replace("msgid", "").Trim();
                    }
                    else if(s.Contains(DES3))
                    {
                        Regex regexDES = new Regex(@"ANNOUNCE.+\n");
                        MatchCollection matchesDES = regexDES.Matches(s);


                        string[] tmp1 = matchesDES[0].Value.Split("\n");


                        temp.describe = "#." + tmp1[0];
                        temp.ru = tmp[1].Replace("msgstr", "").Trim();
                        temp.en = tmp[0].Replace("msgid", "").Trim();
                    }
                    else if (s.Contains(DES4))
                    {
                        Regex regexDES = new Regex(@"ACTIONFAIL.+\n");
                        MatchCollection matchesDES = regexDES.Matches(s);


                        string[] tmp1 = matchesDES[0].Value.Split("\n");


                        temp.describe = "#." + tmp1[0];
                        temp.ru = tmp[1].Replace("msgstr","").Trim();
                        temp.en = tmp[0].Replace("msgid", "").Trim();
                    }
                    else if (s.Contains(DES5))
                    {
                        Regex regexDES = new Regex(@"BATTLECRY.+\n");
                        MatchCollection matchesDES = regexDES.Matches(s);


                        string[] tmp1 = matchesDES[0].Value.Split("\n");


                        temp.describe = "#." + tmp1[0];
                        temp.ru = tmp[1].Replace("msgstr", "").Trim();
                        temp.en = tmp[0].Replace("msgid", "").Trim();
                    }
                    else if (s.Contains(DES6))
                    {
                        Regex regexDES = new Regex(@"COMBAT.+\n");
                        MatchCollection matchesDES = regexDES.Matches(s);


                        string[] tmp1 = matchesDES[0].Value.Split("\n");


                        temp.describe = "#." + tmp1[0];
                        temp.ru = tmp[1].Replace("msgstr", "").Trim();
                        temp.en = tmp[0].Replace("msgid", "").Trim();
                    }

                    list.Add(temp);
                }
            }
            return list;
        }

        static void Write(List<DESCRIBE> list, string template,string path2)
        {
            string temp = template;
 
            foreach(var e in list)
            {  
                temp = temp.Replace(e.describe, e.en + " " + "(" + e.ru + ")");
            }
            File.WriteAllText(path2, temp);
        }
            

        static void Main(string[] args)
        {
            string[] characters =
            {
                "WANDA",
                "GENERIC",
                "WILLOW",
                "WOLFGANG",
                "WENDY",
                "WX78",
                "WICKERBOTTOM",
                "WOODIE",
                "WES",
                "WAXWELL",
                "WATHGRITHR",
                "WEBBER",
                "WARLY",
                "WORMWOOD",
                "WINONA",
                "WORTOX",
                "WURT",
                "WALTER",
                "WONKEY"
            };



            Console.WriteLine("Введите путь до файла с шаблоном");
            string path = Console.ReadLine().Replace("\"","");

            Console.WriteLine("Введите путь до файла с репликами");
            string path1 = Console.ReadLine().Replace("\"", "");

            Console.WriteLine("Введите путь до файла с результатом");
            string path2 = Console.ReadLine().Replace("\"", "");


            Console.WriteLine("Выберите персонажа");
            foreach(var e in characters)
            {
                Console.WriteLine(e);
            }
            string character = Console.ReadLine();


            string template = File.ReadAllText(path);

            string wikiData = File.ReadAllText(path1);

            List<DESCRIBE> list = new List<DESCRIBE>();

           


           var list1 = CreateDescribe(character, wikiData, list);
            Write(list1, template, path2);

            Console.Clear();
            Console.WriteLine("Успешно");
        }
    }
}