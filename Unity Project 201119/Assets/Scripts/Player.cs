
using UnityEngine;
using UnityEngine.UI;       // 只要控制介面我們都要匯入這個 API

public class Player : MonoBehaviour
{
    private Animator aniPlayer;
    private SpriteRenderer sprPlayer;
    private float hp = 100;
    private float hpMax;
    private Image hpBar;
    private bool dead;
    private GameManager gm;

    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;

    /// <summary>
    /// 移動方法：小恐龍左右移動、翻面與動畫
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");          // 輸入.取得軸向("水平")    [玩家按 A 為 -1，玩家按 D 為 1，沒按為 0]

        transform.Translate(speed * h * Time.deltaTime, 0, 0);           // 變形.位移(X,Y,Z)
                                                                         // Time.deltaTime 可以取得不同裝置上一禎的時間，讓遊戲在每個裝置上的反應時間會是一樣的
        aniPlayer.SetBool("跑步開關", h != 0);          // 動畫.設定布林值("參數名稱".布林值)

        if (Input.GetKeyDown(KeyCode.A))
        {
            sprPlayer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            sprPlayer.flipX = false;
        }
    }

    /// <summary>
    /// 死亡方法：死亡動畫、關閉腳本
    /// </summary>
    private void Dead()
    {
        aniPlayer.SetTrigger("死亡觸發");       // 動畫.設定觸發("參數名稱")
        this.enabled = false;                   // 關閉腳本 (讓腳色死亡後不能再移動)
        dead = true;
        gm.GameOver();
    }

    private void Start()
    {
        // 這個步驟可以避免忘記將物件拉進設定好的動作內
        aniPlayer = GetComponent<Animator>();
        sprPlayer = GetComponent<SpriteRenderer>();

        hpBar = GameObject.Find("血條").GetComponent<Image>();

        gm = FindObjectOfType<GameManager>();

        hpMax = hp;
    }
    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dead) return;                         // 如果 死亡 跳出 (讓腳色死亡後不再影響血量增減)

        if (collision.tag == "陷阱")              // 如果 碰到物件.標籤 為 "陷阱"
        {
            hp -= 20;                             // 血量 -= 20
            hpBar.fillAmount = hp / hpMax;        // 血條.長度 = 血量 / 血量最大值

            if (hp <= 0) Dead();                  
        }
        if (collision.tag == "櫻桃")              // 如果 碰到物件.標籤 為 "櫻桃"
        {
            hp += 5;                              // 血量 += 5
            hp = Mathf.Clamp(hp, 0, hpMax);       // 數學.夾住 (血量.0,血量最大值)
                                                  // 防止補血超過原血條
            hpBar.fillAmount = hp / hpMax;        // 血條.長度 = 血量 / 血量最大值
        }

        Destroy(collision.gameObject);            // 刪除 (碰到物件.遊戲物件)
    }
}
