namespace IT_4_term_Lab_7;

public class LevenshteinDistance
{
    public static int GetDistance (string a, string b, int i, int j )
    {
        if (Math.Min( i, j) == 0)
        {
           return Math.Max(i, j);
        }
        else
        {
            var aDistance = GetDistance(a, b, i - 1, j) + 1 ;
            var bDistance = GetDistance(a, b, i , j-1) + 1 ;
            var abDistance = GetDistance(a, b, i - 1, j - 1) + (a[i] != b[j] ? 1 : 0);
            
            return Math.Min(abDistance,Math.Min(aDistance, bDistance));
        }
    }

    public static int GetDistance(string a, string b)
    {
        return GetDistance(a, b, a.Length, b.Length);
    }
}