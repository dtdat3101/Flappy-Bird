using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public GameManager gameManager;
    public float v = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.statusGame == StatusGame.START)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.up * v;
                SoundManager.Instance.OnPlaySound(SoundType.CLICK);
            }

            if (rb.velocity.y > 0)
            {
                float angle = 0;
                angle = Mathf.Lerp(0, 90, rb.velocity.y / 10);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }else if(rb.velocity.y == 0) {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }else if (rb.velocity.y < 0) {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -rb.velocity.y / 10);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
        SoundManager.Instance.OnPlaySound(SoundType.GAMEOVER);
    }
}
