using UnityEngine;

public class BaseScript : MonoBehaviour
{
    [SerializeField] int baseHP = 5;

    bool flag = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int GetHP()
	{
		return baseHP;
	}

    public void TakeDamage(int attack)
	{
		baseHP -= attack;
	}

    public void HealBase(int heal)
	{
		baseHP += heal;
	}

    void FinishGame()
	{
        Debug.Log("Game over!");
	}

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
	{
		if (flag && baseHP <= 0)
		{
			FinishGame();
			flag = false;
		}
	}
}
