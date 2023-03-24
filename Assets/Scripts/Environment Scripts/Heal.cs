using UnityEngine;

public class Heal : MonoBehaviour
{

    public float speed = 0.2f;
    private float initialY;
    private bool healed = false;

    private void Start()
    {
        initialY = gameObject.transform.position.y;
    }
    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 0.2f);
        gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, initialY+y, gameObject.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !healed)
        {
            AudioManager.instance.PlaySFX("heart");
            healed = true;

            if(PlayerHealth.currHp < PlayerHealth.maxHp)
            {
                Destroy(gameObject);
                PlayerHealth.currHp += 1;
            }
            else if (PlayerHealth.currHp == PlayerHealth.maxHp)
            {
                Destroy(gameObject);
                PlayerHealth.maxHp += 1;
                PlayerHealth.currHp += 1;
            }
        }
    }
}
