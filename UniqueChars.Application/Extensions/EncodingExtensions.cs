using System;
using System.Collections.Generic;
using System.Text;
using UniqueChars.Application.Validation;

namespace UniqueChars.Application.Extensions
{
    public static class EncodingExtensions
    {
        #region ASCII

        public static int GetMaximumCharacterLimit(this ASCIIEncoding encoding)
        {
            return 128; //(int)Math.Pow(2, 7); // 128, 7-bit character code
        }

        public static string GetUniqueSequence(this ASCIIEncoding encoding, int? numberOfCharacters = null)
        {
            // For the purpose of this example app, ensure numberOfCharacters doesn't exceed GetMaximumCharacterLimit
            // to ensure all characters are unique (input should be validated instead)
            int length = numberOfCharacters == null || numberOfCharacters > encoding.GetMaximumCharacterLimit()
                ? encoding.GetMaximumCharacterLimit()
                : numberOfCharacters.Value;

            var byteArray = new byte[encoding.GetMaximumCharacterLimit()];

            for (int i = 0; i < length; i++)
            {
                byteArray[i] = (byte)i;
            }

            return encoding.GetString(byteArray);
        }

        public static string GetNonUniqueSequence(this ASCIIEncoding encoding, int? numberOfCharacters = null)
        {
            numberOfCharacters = numberOfCharacters <= 1 ? 2 : numberOfCharacters; // Force non unique sequence for purposes of this example (input should be validated instead)
            int length = numberOfCharacters ?? encoding.GetMaximumCharacterLimit();
            int restart = length == 2 ? 0 : length / 2; // Ensures at least half the characters are the same
            int restartCount = 0;
            var byteArray = new byte[length];

            for (int i = 0; i < length; i++)
            {
                byteArray[i] = (byte)restartCount;
                restartCount = restartCount == restart ? 0 : restartCount + 1;
            }

            return encoding.GetString(byteArray);
        }

        public static bool IsUnique_UsingHash(this ASCIIEncoding encoding, string sequence)
        {
            return SequenceChecker.IsUnique_UsingHash(sequence);
        }

        public static bool IsUnique_UsingDistinct(this ASCIIEncoding encoding, string sequence)
        {
            return SequenceChecker.IsUnique_UsingDistinct(sequence);
        }

        public static bool IsExceedingCharacterLimit(this ASCIIEncoding encoding, string sequence)
        {
            return sequence.Length > GetMaximumCharacterLimit(encoding);
        }

        #endregion

        #region UTF8

        //https://en.wikipedia.org/wiki/UTF-8
        private static Dictionary<int, int> GetCodePoints(this UTF8Encoding encoding)
        {
            return new Dictionary<int, int>()
            {
                { 0x0,          0x7F },
                { 0x80,        0x7FF },
                { 0x800,      0xFFFF },
                { 0x10000,  0x10FFFF }
            };
        }

        public static int GetMaximumCharacterCount(this UTF8Encoding encoding)
        {
            var total = 0;
            foreach (KeyValuePair<int, int> codePoint in encoding.GetCodePoints())
            {
                total += Math.Abs(codePoint.Value - codePoint.Key) + 1;
            }

            return total - 2048; // 1112064 (1114112 minus 2048 code points for technically-invalid surrogate code points) https://en.wikipedia.org/wiki/UTF-8#cite_note-1
        }

        public static bool IsExceedingCharacterLimit(this UTF8Encoding encoding, string sequence)
        {
            return sequence.Length > GetMaximumCharacterCount(encoding);
        }

        #endregion
    }
}