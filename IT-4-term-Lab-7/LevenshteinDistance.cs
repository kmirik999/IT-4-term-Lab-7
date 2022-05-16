namespace IT_4_term_Lab_7;

public class LevenshteinDistance
{
    public static int GetDistance(string a, string b)
    {
        
        var lenA = a.Length + 1;
        var lenB = b.Length + 1;
        var matrix = new int [lenA ,lenB ];
        for (int i = 0; i < lenA; i++)
        {
            matrix[i, 0] = i;
        }

        for (int j = 0; j < lenB; j++)
        {
            matrix[0, j] = j;
        }
        
        for (int i = 1; i < lenA; i++)
        {
            for (int j = 1; j < lenB; j++)
            {
                var aDistance = matrix[i-1,j] + 1 ;
                var bDistance = matrix[i,j - 1] + 1 ;
                var abDistance = matrix[i-1,j-1] + (a[i - 1] != b[j - 1] ? 1 : 0);
                matrix[i, j] = Math.Min(abDistance, Math.Min(aDistance, bDistance));
                
                if (i > 1 && j > 1 && a[i - 1] == b[j - 2] && a[i - 2] == b[j - 1])
                {
                    matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + 1);
                }
            }
        }
        return matrix[lenA - 1, lenB - 1];
    }
    
    
    
    public static string[] GetMostSimilarWords(List<string> list,string wordTypo)
    {
        var sortedList = new SortedList<int, string>(new DuplicateKeyComparer<int>());
        foreach (var word in list)
        {
            var current = GetDistance(word,wordTypo);
            if (sortedList.Count < 5 || current <  sortedList.Keys[4])
            {
                sortedList.Add(current, word);
            }
           
        }

        var returnValue = new string [5];
        for (int i = 0; i < 5; i++)
        {
            returnValue[i] = sortedList.Values[i];
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
            return  result; 
        }
    }
}