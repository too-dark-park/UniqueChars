using System.Linq;
using System.Text;
using UniqueChars.Application.Extensions;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            var ascii = new ASCIIEncoding();
            var utf8 = new UTF8Encoding();


            var a = ascii.GetUniqueSequence();
            var b = ascii.GetNonUniqueSequence();
            var c = ascii.IsUnique_UsingHash(a);
            var d = ascii.IsUnique_UsingHash(b);

            var nonAsciiChars = string.Concat(Enumerable.Repeat("𠀋𠍱𠌫𠈓1234abcd", 1000000));
        }
    }
}