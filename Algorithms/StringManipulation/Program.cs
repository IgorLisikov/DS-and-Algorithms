using System.Text;



Console.WriteLine("Count vowels in \"hello\":");
Console.WriteLine(StringUtils.CountVowels("hello"));
Console.WriteLine();

Console.WriteLine("Reverse a string \"hello\":");
Console.WriteLine(StringUtils.ReverseString("hello"));
Console.WriteLine();

Console.WriteLine("Reverse the order of words:");
Console.WriteLine(StringUtils.ReverseWordsInSentence("Reverse the order of words"));
Console.WriteLine();

Console.WriteLine("Check if \"DABC\" is a rotation of \"ABCD\":");
Console.WriteLine(StringUtils.IsRotation("ABCD", "DABC"));
Console.WriteLine();

Console.WriteLine("Remove duplicate characters in \"Helloo\":");
Console.WriteLine(StringUtils.RemoveDuplicateChars("Helloo"));
Console.WriteLine();

Console.WriteLine("Most repeated char in \"Hello\":");
Console.WriteLine(StringUtils.MostRepeatedChar("Hello"));
Console.WriteLine();

Console.WriteLine("Capitalize the first letter of each word in a sentence. Also, remove any\r\n" +
                  "extra spaces between words:\r\n" +
                  "initial:   Capitalize the FIRST   letter of each WoRD in a sentence   ");
Console.WriteLine($"capitalized: {StringUtils.CapitalizeEachWord("   Capitalize the FIRST   letter of each WoRD in a sentence   ")}");
Console.WriteLine();

Console.WriteLine("Detect if \"abcd\" and \"abdc\" are anagrams:");
Console.WriteLine(StringUtils.DetectAnagram("abcd", "abdc"));
Console.WriteLine();

Console.WriteLine("Detect if \"abba\" is palindrome:");
Console.WriteLine(StringUtils.IsPalindrome("abba"));
Console.WriteLine();




public static class StringUtils
{
    public static int CountVowels(string word)
    {
        if (string.IsNullOrEmpty(word))
            return 0;

        string vowels = "aeouiAEOUI";
        int count = 0;
        foreach (var c in word.ToCharArray())
        {
            if (vowels.Contains(c))
                count++;
        }

        return count;
    }

    public static string ReverseString(string str)
    {
        if (string.IsNullOrEmpty(str))
            return "";

        var arr = new char[str.Length];
        int left = 0;
        int right = str.Length - 1;

        while (left <= right)
        {
            arr[left] = str[right];
            arr[right] = str[left];
            left++;
            right--;
        }

        return new string(arr);
    }

    public static string ReverseWordsInSentence(string sentence)
    {
        if (string.IsNullOrEmpty(sentence))
            return sentence;

        var words = sentence.Split(' ');
        var sb = new StringBuilder();
        for(int i = words.Length - 1; i >= 0; i--)
        {
            sb.Append(words[i]);
            sb.Append(' ');
        }
        sb.Remove(sb.Length - 1, 1);

        return sb.ToString();
    }

    // “ABCD”, “DABC” - true
    // “ABCD”, “CDAB” - true
    // “ABCD”, “ADBC” - false
    public static bool IsRotation(string str1, string str2)
    {
        if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            return false;

        return (str1.Length == str2.Length && (str1 + str1).Contains(str2));
    }

    public static string RemoveDuplicateChars(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        var sb = new StringBuilder();
        var set = new HashSet<char>();
        foreach (var c in str.ToCharArray())
        {
            if (set.Add(c))
                sb.Append(c);
        }

        return sb.ToString();
    }

    public static char MostRepeatedChar(string str)
    {
        if (string.IsNullOrEmpty(str))
            return char.MinValue;

        var dict = new Dictionary<char, int>();
        char res = str[0];
        int maxFreq = 1;
        foreach (var c in str.ToCharArray())
        {
            if (dict.TryGetValue(c, out int val))
            {
                dict[c]++;
                val++;
                if (val > maxFreq)
                {
                    maxFreq = val;
                    res = c;
                }
            }
            else
            {
                dict[c] = 1;
            }
        }

        return res;
    }

    public static string CapitalizeEachWord(string sentence)
    {
        if (string.IsNullOrEmpty(sentence))
            return sentence;

        var words = sentence.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder();
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
            sb.Append(words[i]);
            sb.Append(' ');
        }
        sb.Remove(sb.Length - 1, 1);

        return sb.ToString();
    }

    // “abcd”, “adbc” - true
    // “abcd”, “cadb” - true
    // “abcd”, “abce” - false
    // A string is an anagram of another string if it has the exact same characters in any order.
    public static bool DetectAnagram(string str1, string str2)
    {
        if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            return false;

        if (str1.Length != str2.Length)
            return false;

        var freq = new Dictionary<char, int>();
        foreach (char c in str1.ToCharArray())
        {
            if (freq.ContainsKey(c))
            {
                freq[c]++;
            }
            else
            {
                freq[c] = 1;
            }
        }
        foreach (char c in str2.ToCharArray())
        {
            if (freq.TryGetValue(c, out int val))
            {
                if (val == 0)
                    return false;
                freq[c]--;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    // If we read a palindrome string from left or from right, we get the exact same characters.
    public static bool IsPalindrome(string word)
    {
        if (string.IsNullOrEmpty(word))
            return false;

        int left = 0;
        int right = word.Length - 1;
        while (left < right)
        {
            if (word[left++] != word[right--])
                return false;
        }
        return true;
    }
}
