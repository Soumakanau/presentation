using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ItemBase2D : MonoBehaviour
{
    [Tooltip("Get ��I�ԂƁA��������Ɍ��ʂ���������BUse ��I�ԂƁA�A�C�e�����g�������ɔ�������")]
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
                // �����Ȃ����Ɉړ�����
                this.transform.position = Camera.main.transform.position;
                // �R���C�_�[�𖳌��ɂ���
                GetComponent<Collider2D>().enabled = false;
                // �v���C���[�ɃA�C�e����n��
                collision.gameObject.GetComponent<PlayerController>();
            }
    }
}

/// <summary>
/// �A�C�e�������A�N�e�B�x�[�g���邩
/// </summary>
enum ActivateTiming
{
    /// <summary>��������ɂ����g��</summary>
    Get,
    /// <summary>�u�g���v�R�}���h�Ŏg��</summary>
    Use,
}

