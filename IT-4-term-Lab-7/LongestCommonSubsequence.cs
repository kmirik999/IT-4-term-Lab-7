using System.Collections;

namespace IT_4_term_Lab_7;

public class LongestCommonSubsequence
{
    private static int GetLength(string a, string b)
    {
        var lenA = a.Length;
        var lenB = b.Length;
        var lcs = new int[lenA + 1, lenB + 1];
        
        for (int i = 0; i <= lenA; i++)
        {
            lcs[i, 0] = 0;
            
        }

        for (int j = 0; j <= lenB; j++)
        {
            lcs[0, j] = 0;
        }
            
        for (int i = 1; i <= lenA; i++)
        {
            for (int j = 1; j <= lenB; j++)
            {
                if (a[i - 1] == b[j - 1])
                {
                    lcs[i, j] = lcs[i - 1, j - 1] + 1;
                }
                else
                {
                    lcs[i, j] = Math.Max(lcs[i, j - 1], lcs[i - 1, j]);
                }
                    
            }
        }
        return lcs[lenA, lenB];
        

    }

    public static string[] GetMostSimilarWords(List<string> list,string wordTypo)
    {
        var sortedList = new SortedList<int, string>(new DuplicateKeyComparer<int>());
        foreach (var word in list)
        {
            var current = GetLength(word,wordTypo);
            if (sortedList.Count < 5 || current >  sortedList.Keys[4])
            {
                sortedList.Add(current, word);
            }
           
        }

        var returnValue = new string [5];
        for (int i = 0; i < 5; i++)
        {
            returnValue[i] = sortedList.Values[i] + sortedList.Keys[i] ;
        }
        return returnValue;
    }
    
    
    
    private class DuplicateKeyComparer<TKey>:IComparer<TKey> where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                return 1;
            return - result; 
        }
    }
    
    
}