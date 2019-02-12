using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UniqueChars.Application.Validation
{
    public static class SequenceChecker
    {
        public static bool IsUnique_UsingCollection(string sequence)
        {
            var charArray = sequence.ToCharArray();
            var characters = new Collection<char>();

            foreach (char character in charArray)
            {
                if (characters.Contains(character))
                    return false;

                characters.Add(character);
            }

            return true;
        }

        public static bool IsUnique_UsingHash(string sequence)
        {
            var charArray = sequence.ToCharArray();

            var hashSet = new HashSet<char>();
            foreach (char b in charArray)
            {
                if (!hashSet.Add(b))
                    return false;
            }

            return true;
        }

        public static bool IsUnique_UsingDistinct(string sequence)
        {
            var charArray = sequence.ToCharArray();
            var distinctArray = charArray.Distinct().ToArray();
            if (distinctArray.Length != charArray.Length)
                return false;

            return true;
        }
    }
}