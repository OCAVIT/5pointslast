using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnHpChanged))]
    public int hp = 100;

    public TextMesh hpText;

    void Start()
    {
        hpText = GetComponentInChildren<TextMesh>();
        UpdateHpText();
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.H))
        {
            CmdTakeDamage(10);
        }
    }

    [Command]
    void CmdTakeDamage(int amount)
    {
        hp -= amount;
        if (hp < 0) hp = 0;
    }

    void OnHpChanged(int oldHp, int newHp)
    {
        UpdateHpText();
    }

    void UpdateHpText()
    {
        if (hpText != null)
            hpText.text = $"HP: {hp}";
    }
}