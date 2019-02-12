using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UniqueChars.Application.Validation
{
    public static class SequenceChecker
    {
        public static bool IsUnique_UsingCollection(byte[] sequence)
        {
            var characters = new Collection<char>();

            foreach (char character in sequence)
            {
                if (characters.Contains(character))
                    return false;

                characters.Add(character);
            }

            return true;
        }

        public static bool IsUnique_UsingHash(byte[] sequence)
        {
            var hashSet = new HashSet<char>();
            foreach (char b in sequence)
            {
                if (!hashSet.Add(b))
                    return false;
            }

            return true;
        }

        public static bool IsUnique_UsingDistinct(byte[] sequence)
        {
            var distinctArray = sequence.Distinct().ToArray();
            if (distinctArray.Length != sequence.Length)
                return false;

            return true;
        }
    }
}