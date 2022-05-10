var inputLine = Console.ReadLine();


foreach (var separator in new string[]{",", "." ,";" ,":", "?", "!", "(", ")", "[", "]", "{", "}", "/"})
{
    inputLine = inputLine.Replace(separator, "");
}

var words = inputLine.Split(' ');

Console.WriteLine(inputLine);

var file = File.ReadLines("words_list.txt");
var list = new List<string>();

foreach (var line in file)
{
    list.Add(line);
}

var listTypos = new List<string>();
foreach (var word in words)
{
    if (list.IndexOf(word) == -1)
    {
        listTypos.Add(word);
    }
}

if (listTypos.Count > 0)
{
    Console.WriteLine("Looks like you have typos in next words: ");
    foreach (var wordTypo in listTypos )
    {
        Console.WriteLine(wordTypo);
    }
}
