using System.ComponentModel.Design;
int sifra;
string text;
int key;
Console.WriteLine("Napiš text");
text = Console.ReadLine();
Console.WriteLine("O kolik míst chcete posunout?");
int.TryParse(Console.ReadLine(), out key);
char[] textArray = text.ToCharArray();
for (int i = 0; i < textArray.Length; i++)
{
    sifra = textArray[i];
    sifra = sifra + key;
    textArray[i] = (char)sifra;
}
for  (int i = 0;i < textArray.Length; i++)
{
    Console.WriteLine(textArray[i]);
}