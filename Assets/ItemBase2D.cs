using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ItemBase2D : MonoBehaviour
{
    [Tooltip("Get を選ぶと、取った時に効果が発動する。Use を選ぶと、アイテムを使った時に発動する")]
    [SerializeField] ActivateTiming _whenActivated = ActivateTiming.Get;
    // Start is called before the first frame update
    public abstract void Activate();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            if (_whenActivated == ActivateTiming.Get)
            {
                Activate();
                Destroy(this.gameObject);
            }
            else if (_whenActivated == ActivateTiming.Use)
            {
                // 見えない所に移動する
                this.transform.position = Camera.main.transform.position;
                // コライダーを無効にする
                GetComponent<Collider2D>().enabled = false;
                // プレイヤーにアイテムを渡す
                collision.gameObject.GetComponent<PlayerController>();
            }
    }
}

/// <summary>
/// アイテムをいつアクティベートするか
/// </summary>
enum ActivateTiming
{
    /// <summary>取った時にすぐ使う</summary>
    Get,
    /// <summary>「使う」コマンドで使う</summary>
    Use,
}

