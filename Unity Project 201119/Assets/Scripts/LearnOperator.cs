
using UnityEngine;

public class LearnOperator : MonoBehaviour
{
    public float a = 10;
    public float b = 3;

    public int c = 99;
    public int d = 1;

    private void Start()
    {
        print(a + b);   // 結果為 13
        print(a - b);   // 結果為 7
        print(a * b);   // 結果為 30
        print(a / b);   // 結果為 3
        print(a % b);   // 結果為 1

        print(c < d);    // 結果為 false
        print(c > d);    // 結果為 true
        print(c <= d);   // 結果為 false
        print(c >= d);   // 結果為 true
        print(c == d);   // 結果為 false
        print(c != d);   // 結果為 true

        print(true && true);
        print(true && false);
        print(false && true);
        print(false && false);

        print(true || true);
        print(true || false);
        print(false || true);
        print(false || false);

        print(!true);
        print(!false);

    }

}
